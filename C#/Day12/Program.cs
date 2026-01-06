using System;
using System.Security;
/**
class Program
{
    public static void Main(string[] args)
    {
        Delegate d = new Delegate();
        PaymentDelegate p = d.ProcessPayment;
        decimal amt=4000;
        if (amt.IsValidPayment())
        {
            p(amt);
        }
        else
        {
            Console.WriteLine("Enter Valid Amount");
        }
    }
}
public delegate void PaymentDelegate(decimal amt);
class Delegate
{
    public void ProcessPayment(decimal amt)
    {
        Console.WriteLine($"Payment of {amt} is processed.");
    }
}
static class PaymentExtensions
{
    public static bool IsValidPayment(this decimal amt)
    {
        return amt>0 && amt<1_000_000;
    }
}
**/
// delegate void OrderDelegate(string ordID);
// class NotificationService
// {
//     public void sendEmail(string ordID)
//     {
//         Console.WriteLine($"Email sent for Order: {ordID}");
//     }
//     public void sendSMS(string ordID)
//     {
//         Console.WriteLine($"SMS send for Order: {ordID}");
//     }
// }
// class Button
// {
//     public delegate void ButtonHandler();
//     public event ButtonHandler Clicked;
//     public event ButtonHandler DoubleClicked;
//     public event ButtonHandler Hovered;
//     public void Click()
//     {
//         Clicked?.Invoke();
//     }
//     public void DoubleClick()
//     {
//         DoubleClicked?.Invoke();
//     }
//     public void Hover()
//     {
//         Hovered?.Invoke();
//     }
// }
/**
class Program
{
    // delegate void ErrorDelegate(string msg);
    // static void OnClick()
    // {
    //     Console.WriteLine("Button clicked");
    // }
    // static void OnDoubleClick()
    // {
    //     Console.WriteLine("Button double-clicked");
    // }
    // static void OnHover()
    // {
    //     Console.WriteLine("Mouse is over the button");
    // }
    static void Main(string[] args)
    {
        // NotificationService service = new NotificationService();
        // OrderDelegate notify=null;
        // notify+=service.sendEmail;
        // notify+=service.sendSMS;
        // notify("ORD123");

        //Action Delegate(NO RETURN TYPE)
        // Action<string>logActivity=message=> Console.WriteLine("Log Entry: "+message);
        // logActivity("User logged in at 10:30AM");

        //Func Delegate(LAST PARAMETER IS THE RETURN TYPE)
        // Func<decimal, decimal, decimal> calculateDiscount = (price, discount) => price - (price * discount) / 100;
        // Console.WriteLine($"Discount Amount is {calculateDiscount(1000, 10)}");
        //Last parameter is the return type mentioned.

        //Predicate Delegate(RETURNS BOOL AS RETURN TYPE, Accepts only one parameter)
        // Predicate<int> isEligibleToVote = age => age >= 18;
        // Console.WriteLine(isEligibleToVote(16)); // False
        // Console.WriteLine(isEligibleToVote(25)); // True
        // List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        // Predicate<int> isEven = n => n % 2 == 0;
        // List<int> evenNumbers = numbers.FindAll(isEven);
        // Console.WriteLine(string.Join(", ", evenNumbers));

        //We use delegates to pass methods as parameters, enabling flexible, reusable, and loosely coupled behavior at runtime.
        //Mostly all Delegates are commonly used with Events.
        //Anonymous Delegate
        // ErrorDelegate errorHandler= delegate(string msg)
        // {
        //     Console.WriteLine("Error: "+msg);
        // };
        // errorHandler("File not found");


        // Button btn = new Button();
        // btn.Clicked += OnClick;
        // btn.DoubleClicked += OnDoubleClick;
        // btn.Hovered += OnHover;
        // // Console.WriteLine("Clicking button:");
        // btn.Click();
        // // Console.WriteLine("Double clicking button:");
        // btn.DoubleClick();
        // // Console.WriteLine("Hovering over button:");
        // btn.Hover();

        //Unsafe events : 
        //Safe events : We use event keyword.
    }
}
using System;

namespace SmartHomeSecurity
{
    public delegate void SecurityAction(string zone);

    public class MotionSensor
    {
        public SecurityAction OnEmergency;

        public void DetectIntruder(string zoneName)
        {
            Console.WriteLine($"[SENSOR] Motion detected in {zoneName}!");
            OnEmergency?.Invoke(zoneName);
        }
    }

    public class AlarmSystem
    {
        public void SoundSiren(string zone)
        {
            Console.WriteLine($"[ALARM] WOO-OOO! High-decibel siren active in {zone}.");
        }
    }

    public class PoliceNotifier
    {
        public void CallDispatch(string zone)
        {
            Console.WriteLine($"[POLICE] Notifying local precinct of intrusion in {zone}.");
        }
    }

    class Program
    {
        static void Main()
        {
            MotionSensor livingRoomSensor = new MotionSensor();
            AlarmSystem siren = new AlarmSystem();
            PoliceNotifier police = new PoliceNotifier();
            SecurityAction panicSequence = siren.SoundSiren; //Storing the reference to the method SoundSiren in siren object, because delegates store reference to the methods.
            //Delegates acts as function pointer.
            panicSequence += police.CallDispatch;
            //panicSequence, here delegate becomes multicast delegate.
            //Allows multiple methods to respond to a single event.
            livingRoomSensor.OnEmergency = panicSequence; //[Entire sequence of actions are injected into livingRoomSensor using OnEmergency (dependency Injection)].
            //The OnEmergency delegate inside MotionSensor now points to panicSequence.
            livingRoomSensor.DetectIntruder("Main Lobby");
            /**
            Main()
            ├─ Create objects
            ├─ Create delegate
            ├─ Add methods to delegate
            ├─ Assign delegate to sensor
            └─ DetectIntruder()
                ├─ Print sensor message
                └─ Invoke delegate
                        ├─ SoundSiren()
                        └─ CallDispatch()
        }
    }
}

using System;
using System.Threading;

namespace CallbackDemo
{
    // STEP 1: Define the Delegate
    public delegate void DownloadFinishedHandler(string fileName);
    class FileDownloader
    {
        // STEP 2: Method that accepts the callback
        public void DownloadFile(string name, DownloadFinishedHandler callback) //Highorder function.
        {
            Console.WriteLine($"Starting download: {name}...");
            // Simulating work
            Thread.Sleep(2000);
            Console.WriteLine($"{name} download complete.");
            // STEP 3: Execute the Callback
            if (callback != null)
            {
                callback(name);
            }
        }
    }
    class Program
    {
        // STEP 4: The actual Callback Method
        static void DisplayNotification(string file)
        {
            Console.WriteLine($"NOTIFICATION: You can now open {file}.");
        }
        static void Main()
        {
            FileDownloader downloader = new FileDownloader();
            // Pass the method 'DisplayNotification' as a callback
            downloader.DownloadFile("Presentation.pdf", DisplayNotification);
        }
    }
}

// COMPARISION DELEGATE
using System;

class Program
{
    static void Main()
    {
        Comparison<int> sortDescending = (a, b) => b.CompareTo(a);
        int result = sortDescending(5, 10);
        int res1 = sortDescending(5, 5);
        Console.WriteLine(result);
        Console.WriteLine(res1);
        Console.Write(sortDescending(10, 5));
    }
}
**/


