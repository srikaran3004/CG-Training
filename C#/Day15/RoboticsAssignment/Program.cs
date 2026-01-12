using System;
using System.Linq;
using System.Collections.Generic;

namespace AutonomousRobot.AI
{
    public class SensorReading
    {
        public int SensorId { get; set; }
        public string? Type { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
        public double Confidence { get; set; }
    }

    public enum RobotAction
    {
        Stop,
        SlowDown,
        Reroute,
        Continue
    }

    public class DecisionEngine
    {
        // Task 1
        public List<SensorReading> GetRecentReadings(List<SensorReading> sensorHistory, DateTime fromTime)
        {
            return sensorHistory.Where(r => r.Timestamp >= fromTime).ToList();
        }

        // Task 2
        public bool IsBatteryCritical(List<SensorReading> readings)
        {
            return readings.Any(r => r.Type == "Battery" && r.Value < 20);
        }

        // Task 3 (simplified & safe)
        public double GetNearestObstacleDistance(List<SensorReading> readings)
        {
            var distances = readings.Where(r => r.Type == "Distance");

            return distances.Any() ? distances.Min(r => r.Value) : double.MaxValue;
        }

        // Task 4
        public bool IsTemperatureSafe(List<SensorReading> readings)
        {
            return readings.Where(r => r.Type == "Temperature")
                           .All(r => r.Value < 90);
        }

        // Task 5
        public double GetAverageVibration(List<SensorReading> readings)
        {
            var vibrationValues = readings
                .Where(r => r.Type == "Vibration")
                .Select(r => r.Value)
                .ToList();

            if (vibrationValues.Count == 0) return 0;

            return vibrationValues.Average();
        }

        // Task 6
        public Dictionary<string, double> CalculateSensorHealth(List<SensorReading> sensorHistory)
        {
            var groups = sensorHistory.GroupBy(r => r.Type);

            return groups.ToDictionary(
                g => g.Key!,
                g => g.Select(r => r.Confidence).Average()
            );
        }

        // Task 7
        public List<string> DetectFaultySensors(List<SensorReading> sensorHistory)
        {
            return sensorHistory
                .Where(r => r.Confidence < 0.4)
                .GroupBy(r => r.Type)
                .Where(g => g.Count() > 2)
                .Select(g => g.Key!)
                .ToList();
        }

        // Task 8 (simple + readable)
        public bool IsBatteryDrainingFast(List<SensorReading> sensorHistory)
        {
            var batteryReadings = sensorHistory
                .Where(r => r.Type == "Battery")
                .OrderBy(r => r.Timestamp)
                .Select(r => r.Value)
                .ToList();

            for (int i = 1; i < batteryReadings.Count; i++)
            {
                if (batteryReadings[i] >= batteryReadings[i - 1])
                    return false;
            }

            return batteryReadings.Count > 1;
        }

        // Task 9
        public double GetWeightedDistance(List<SensorReading> readings)
        {
            var distanceSensors = readings.Where(r => r.Type == "Distance").ToList();

            var totalConfidence = distanceSensors.Sum(r => r.Confidence);

            if (totalConfidence == 0)
                return double.MaxValue;

            var weightedSum = distanceSensors.Sum(r => r.Value * r.Confidence);

            return weightedSum / totalConfidence;
        }

        // Task 10
        public RobotAction DecideRobotAction(List<SensorReading> recentReadings, List<SensorReading> sensorHistory)
        {
            if (IsBatteryCritical(recentReadings))
                return RobotAction.Stop;

            if (IsBatteryDrainingFast(sensorHistory))
                return RobotAction.Stop;

            if (GetNearestObstacleDistance(recentReadings) < 1.0)
                return RobotAction.Reroute;

            if (!IsTemperatureSafe(recentReadings))
                return RobotAction.SlowDown;

            return RobotAction.Continue;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sensorHistory = new List<SensorReading>
            {
                new SensorReading { SensorId = 1, Type = "Distance", Value = 0.8, Confidence = 0.9, Timestamp = DateTime.Now.AddSeconds(-9) },
                new SensorReading { SensorId = 2, Type = "Battery", Value = 18, Confidence = 0.8, Timestamp = DateTime.Now.AddSeconds(-8) },
                new SensorReading { SensorId = 3, Type = "Temperature", Value = 92, Confidence = 0.7, Timestamp = DateTime.Now.AddSeconds(-7) },
                new SensorReading { SensorId = 4, Type = "Vibration", Value = 8.2, Confidence = 0.6, Timestamp = DateTime.Now.AddSeconds(-6) },
                new SensorReading { SensorId = 5, Type = "Battery", Value = 75, Confidence = 0.9, Timestamp = DateTime.Now.AddSeconds(-5) },
                new SensorReading { SensorId = 6, Type = "Distance", Value = 2.5, Confidence = 0.5, Timestamp = DateTime.Now.AddSeconds(-4) }
            };

            var engine = new DecisionEngine();
            var fromTime = DateTime.Now.AddSeconds(-10);

            var recentReadings = engine.GetRecentReadings(sensorHistory, fromTime);
            Console.WriteLine($"GetRecentReadings [Count]: {recentReadings.Count}");

            Console.WriteLine($"IsBatteryCritical: {engine.IsBatteryCritical(recentReadings)}");

            Console.WriteLine($"GetNearestObstacleDistance: {engine.GetNearestObstacleDistance(recentReadings)}");

            Console.WriteLine($"IsTemperatureSafe: {engine.IsTemperatureSafe(recentReadings)}");

            Console.WriteLine($"GetAverageVibration: {engine.GetAverageVibration(recentReadings)}");

            var health = engine.CalculateSensorHealth(sensorHistory);
            Console.WriteLine("CalculateSensorHealth: ");
            foreach (var item in health)
                Console.WriteLine($"{item.Key} : {item.Value}");

            var faulty = engine.DetectFaultySensors(sensorHistory);
            Console.Write("DetectFaultySensors: ");
            if (faulty.Count == 0)
                Console.WriteLine("None");
            else
                faulty.ForEach(Console.WriteLine);

            Console.WriteLine($"IsBatteryDrainingFast: {engine.IsBatteryDrainingFast(sensorHistory)}");

            Console.WriteLine($"GetWeightedDistance: {engine.GetWeightedDistance(recentReadings)}");

            Console.WriteLine($"DecideRobotAction: {engine.DecideRobotAction(recentReadings, sensorHistory)}");
        }

    }
}
