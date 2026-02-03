using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MiniSocialMedia
{
    public class Program
    {
        private static Repository<User> _users = new();
        private static User? _currentUser;
        private static readonly string _dataFile = "social-data.json";

        static void Main()
        {
            Console.Title = "MiniSocial - Console Edition";
            Console.WriteLine("MiniSocial - Console Edition");

            LoadData();

            while (true)
            {
                try
                {
                    if (_currentUser == null)
                        ShowLoginMenu();
                    else
                        ShowMainMenu();
                }
                catch (SocialException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Error!!");
                    LogError(ex);
                }
            }
        }

        private static void ShowLoginMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");

            var choice = Console.ReadLine();

            if (choice == "1") Register();
            else if (choice == "2") Login();
            else if (choice == "0")
            {
                SaveData();
                Environment.Exit(0);
            }
            else
                Console.WriteLine("Invalid choice");
        }

        private static void Register()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            if (_users.Find(u =>
                u.Username.Equals(username?.Trim(),
                StringComparison.OrdinalIgnoreCase)) != null)
                throw new SocialException("Username already exists");

            var user = new User(username!, email!);
            _users.Add(user);

            Console.WriteLine($"Welcome @{user.Username}");
        }

        private static void Login()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            var user = _users.Find(u =>
                u.Username.Equals(username?.Trim(),
                StringComparison.OrdinalIgnoreCase));

            if (user == null)
                throw new SocialException("User not found");

            _currentUser = user;

            user.OnNewPost += post =>
            {
                var preview = post.Content.Length > 40
                    ? post.Content.Substring(0, 40) + "..."
                    : post.Content;

                Console.WriteLine(
                    $"Notification: @{post.Author.Username} - {preview}");
            };

            Console.WriteLine($"Logged in as {_currentUser}");
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine($"Logged in: {_currentUser}");
            Console.WriteLine("1. Post message");
            Console.WriteLine("2. View my posts");
            Console.WriteLine("3. View timeline");
            Console.WriteLine("4. Follow user");
            Console.WriteLine("5. List users");
            Console.WriteLine("6. Logout");
            Console.WriteLine("0. Exit and save");
            Console.Write("Choice: ");

            var choice = Console.ReadLine();

            if (choice == "1") PostMessage();
            else if (choice == "2") ShowPosts(_currentUser!.GetPosts());
            else if (choice == "3") ShowTimeline();
            else if (choice == "4") FollowUser();
            else if (choice == "5") ListUsers();
            else if (choice == "6") _currentUser = null;
            else if (choice == "0")
            {
                SaveData();
                Environment.Exit(0);
            }
            else
                Console.WriteLine("Invalid choice");
        }

        private static void PostMessage()
        {
            Console.Write("Post: ");
            var content = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("Post cancelled");
                return;
            }

            _currentUser!.AddPost(content);
            Console.WriteLine("Post added");
        }

        private static void ShowTimeline()
        {
            var posts = new List<Post>();
            posts.AddRange(_currentUser!.GetPosts());

            foreach (var name in _currentUser.GetFollowingNames())
            {
                var user = _users.Find(u =>
                    u.Username.Equals(name,
                    StringComparison.OrdinalIgnoreCase));

                if (user != null)
                    posts.AddRange(user.GetPosts());
            }

            var ordered = posts
                .OrderByDescending(p => p.CreatedAt);

            Console.WriteLine("Your Timeline");
            ShowPosts(ordered);
        }

        private static void ShowPosts(IEnumerable<Post> posts)
        {
            int count = 0;

            foreach (var post in posts)
            {
                if (count == 20) break;

                Console.WriteLine(post);
                Console.WriteLine(post.CreatedAt.FormatTimeAgo());
                Console.WriteLine();
                count++;
            }

            if (count == 0)
                Console.WriteLine("No posts yet");
        }

        private static void FollowUser()
        {
            Console.Write("Follow username: ");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Cancelled");
                return;
            }

            var user = _users.Find(u =>
                u.Username.Equals(name.Trim(),
                StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            _currentUser!.Follow(name.Trim());
            Console.WriteLine($"Now following @{name}");
        }

        private static void ListUsers()
        {
            Console.WriteLine("Registered users:");

            foreach (var u in _users.GetAll().OrderBy(u => u.Username))
                Console.WriteLine($"{u,-15} {u.Email}");
        }

        private static void SaveData()
        {
            var data = _users.GetAll().Select(u => new
            {
                u.Username,
                u.Email,
                Following = u.GetFollowingNames(),
                Posts = u.GetPosts().Select(p => new
                {
                    p.Content,
                    p.CreatedAt
                })
            });

            var json = JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(_dataFile, json);
        }

        private static void LoadData()
        {
            if (!File.Exists(_dataFile)) return;

            File.ReadAllText(_dataFile);
        }

        private static void LogError(Exception ex)
        {
            try
            {
                File.AppendAllText(
                    "error.log",
                    $"{DateTime.Now}\n{ex}\n\n");
            }
            catch { }
        }
    }
}
