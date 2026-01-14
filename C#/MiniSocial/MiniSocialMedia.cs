using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
    public partial class User
    {
        public string GetDisplayName()
        {
            return $"User: {Username} <{Email}>";
        }
    }

    public class Post
    {
        public User Author { get; }
        public string Content { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;

        public Post(User author, string content)
        {
            if (author == null)
                throw new ArgumentException("Author is required", nameof(author));

            Author = author;
            Content = content;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");
            sb.AppendLine(Content);

            var hashtags = Regex.Matches(Content, @"#[A-Za-z]+");
            if (hashtags.Count > 0)
            {
                sb.Append("Tags: ");
                sb.Append(string.Join(", ", hashtags.Cast<Match>().Select(m => m.Value)));
            }

            return sb.ToString().TrimEnd();
        }
    }

    public class Repository<T> where T : class
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);

        public IReadOnlyList<T> GetAll() => _items.AsReadOnly();

        public T? Find(Predicate<T> match) => _items.Find(match);
    }

    public static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime dateTime)
        {
            var diff = DateTime.UtcNow - dateTime;

            if (diff.TotalMinutes < 1)
                return "just now";

            if (diff.TotalMinutes < 60)
                return $"{(int)diff.TotalMinutes} min ago";

            if (diff.TotalHours < 24)
                return $"{(int)diff.TotalHours} h ago";

            return dateTime.ToString("MMM dd");
        }
    }

    public static class UserExtensions
    {
        public static IEnumerable<string> GetFollowingNames(this User user)
        {
            return user
                .GetType()
                .GetField("_following", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.GetValue(user) as IEnumerable<string> ?? Enumerable.Empty<string>();
        }
    }
}
