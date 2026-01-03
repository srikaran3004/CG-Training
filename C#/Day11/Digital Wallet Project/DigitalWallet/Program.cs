using System;
using DigitalWallet.Core;

namespace DigitalWalletApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // WalletData wallet = new WalletData();

            // wallet.UserId = 105;
            // wallet.UserName = "Srikaran";
            // wallet.Balance = 1200.05m;
            // wallet.IsActive = true;

            // wallet.RecentTransactions = new decimal[3];
            // wallet.RecentTransactions[0] = 500;
            // wallet.RecentTransactions[1] = 1200;
            // wallet.RecentTransactions[2] = 300;

            // Console.WriteLine("User Name: " + wallet.UserName);
            // Console.WriteLine("Balance: " + wallet.Balance);
            // Console.WriteLine("Wallet Active: " + wallet.IsActive);

            // Console.WriteLine("Recent Transactions:");
            // for (int i = 0; i < wallet.RecentTransactions.Length; i++)
            // {
            //     Console.WriteLine(wallet.RecentTransactions[i]);
            // }
            /**          VALUE Typed Reference**/
            // WalletData wallet1 = new WalletData();
            // wallet1.Balance = 958m;

            // decimal copiedBalance = wallet1.Balance;
            // copiedBalance = copiedBalance + 500;

            // Console.WriteLine("Original Wallet Balance: " + wallet1.Balance);
            // Console.WriteLine("Copied Balance Value: " + copiedBalance);

            /** Reference typed**/
            // WalletData wallet2 = new WalletData();
            // wallet2.RecentTransactions = new decimal[2];
            // wallet2.RecentTransactions[0] = 200;
            // wallet2.RecentTransactions[1] = 300;

            // decimal[] copiedTransactions = wallet2.RecentTransactions;
            // copiedTransactions[0] = 999;

            // Console.WriteLine("Original Transaction Value: " + wallet2.RecentTransactions[0]);
            // Console.WriteLine("Copied Transaction Value: " + copiedTransactions[0]);

            // /**string (Reference Type with Value-Like Behavior) **/
            // wallet2.UserName = "Amit";
            // string copiedName = wallet2.UserName;
            // copiedName = "Rahul";

            // Console.WriteLine("Original Name: " + wallet2.UserName);
            // Console.WriteLine("Copied Name: " + copiedName);

            //Boxing Example
            decimal balance = 5000m;
            object boxedBalance = balance;
            Console.WriteLine("Boxed Balance: " + boxedBalance);
            /**
            boxing happens. decimal is a value type (struct).
            When you assign balance to an object (boxedBalance = balance;), 
            the value is boxed—copied into a new object on the heap. GetType() then reports System.Decimal as expected.
            **/
            //Unboxing
            decimal unboxedBalance = (decimal)boxedBalance;
            Console.WriteLine("Unboxed Balance: " + unboxedBalance);


        }
    }
}
