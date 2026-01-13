using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraEnterpriseSDLC
{
    public enum RiskLevel
    {
        Low,
        Medium,
        High,
        Critical
    }
    public enum SDLCStage
    {
        Backlog,
        Requirement,
        Design,
        Development,
        CodeReview,
        Testing,
        UAT,
        Deployment,
        Maintenance
    }
    public sealed class Requirement
    {
        public int Id { get; }
        public string Title { get; }
        public RiskLevel Risk { get; }
        public Requirement(int id, string title, RiskLevel risk)
        {
            Id = id;
            Title = title;
            Risk = risk;
        }
    }
    public sealed class WorkItem
    {
        public int Id { get; }
        public string Name { get; }
        public SDLCStage Stage { get; set; }
        public HashSet<int> DependencyIds { get; }
        public WorkItem(int id, string name, SDLCStage stage)
        {
            Id = id;
            Name = name;
            Stage = stage;
            DependencyIds = new HashSet<int>();
        }
    }
    public sealed class BuildSnapshot
    {
        public string Version { get; }
        public DateTime Timestamp { get; }
        public BuildSnapshot(string version)
        {
            Version = version;
            Timestamp = DateTime.Now;
        }
    }
    public sealed class AuditLog
    {
        public DateTime Time { get; }
        public string Action { get; }

        public AuditLog(string action)
        {
            Time = DateTime.Now;
            Action = action;
        }
    }
    public sealed class QualityMetric
    {
        public string Name { get; }
        public double Score { get; }

        public QualityMetric(string name, double score)
        {
            Name = name;
            Score = score;
        }
    }
    public class EnterpriseSDLCEngine
    {
        private List<Requirement> _requirements;
        private Dictionary<int, WorkItem> _workItemRegistry;
        private SortedDictionary<SDLCStage, List<WorkItem>> _stageBoard;
        private Queue<WorkItem> _executionQueue;
        private Stack<BuildSnapshot> _rollbackStack;
        private HashSet<string> _uniqueTestSuites;
        private LinkedList<AuditLog> _auditLedger;
        private SortedList<double, QualityMetric> _releaseScoreboard;
        private int _requirementCounter;
        private int _workItemCounter;
        public EnterpriseSDLCEngine()
        {
            _requirements = new List<Requirement>();
            _workItemRegistry = new Dictionary<int, WorkItem>();
            _stageBoard = new SortedDictionary<SDLCStage, List<WorkItem>>();
            foreach (SDLCStage stage in Enum.GetValues(typeof(SDLCStage)))
            {
                _stageBoard.Add(stage, new List<WorkItem>());
            }
            _executionQueue = new Queue<WorkItem>();
            _rollbackStack = new Stack<BuildSnapshot>();
            _uniqueTestSuites = new HashSet<string>();
            _auditLedger = new LinkedList<AuditLog>();
            _releaseScoreboard = new SortedList<double, QualityMetric>();
        }
        public void AddRequirement(string title, RiskLevel risk)
        {
            Requirement r = new Requirement(_requirementCounter, title, risk);
            _requirementCounter++;
            _requirements.Add(r);
            _auditLedger.AddLast(new AuditLog($"Requirement added: {title}"));
        }
        public WorkItem CreateWorkItem(string name, SDLCStage stage)
        {
            WorkItem w = new WorkItem(_workItemCounter, name, stage);
            _workItemCounter++;
            _workItemRegistry.Add(w.Id, w);
            _stageBoard[stage].Add(w);
            _auditLedger.AddLast(new AuditLog($"WorkItem created: {name} at stage {stage}"));
            return w;
        }
        public void AddDependency(int workItemId, int dependsOnId)
        {
            if (_workItemRegistry.ContainsKey(workItemId) && _workItemRegistry.ContainsKey(dependsOnId))
            {
                _workItemRegistry[workItemId].DependencyIds.Add(dependsOnId);
                _auditLedger.AddLast(new AuditLog($"Dependency added: {workItemId} depends on {dependsOnId}"));
            }
        }
        public void PlanStage(SDLCStage stage)
        {
            var items = _stageBoard[stage];
            var eligible = items.Where(w =>
                w.DependencyIds.All(d =>
                    _workItemRegistry.ContainsKey(d) &&
                    _workItemRegistry[d].Stage > stage
                )
            );
            foreach (var w in eligible)
            {
                _executionQueue.Enqueue(w);
            }

            _auditLedger.AddLast(new AuditLog($"Stage planned: {stage}"));
        }
        public void ExecuteNext()
        {
            if (_executionQueue.Count == 0)
                return;

            WorkItem w = _executionQueue.Dequeue();
            SDLCStage oldStage = w.Stage;
            w.Stage = oldStage + 1;
            _stageBoard[oldStage].Remove(w);
            _stageBoard[w.Stage].Add(w);
            _auditLedger.AddLast(
                new AuditLog($"WorkItem {w.Id} moved from {oldStage} to {w.Stage}")
            );
        }
        public void RegisterTestSuite(string suiteId)
        {
            if (_uniqueTestSuites.Add(suiteId))
            {
                _auditLedger.AddLast(new AuditLog($"Test suite registered: {suiteId}"));
            }
        }
        public void DeployRelease(string version)
        {
            BuildSnapshot snap = new BuildSnapshot(version);
            _rollbackStack.Push(snap);
            _auditLedger.AddLast(new AuditLog($"Release deployed: {version}"));
        }
        public void RollbackRelease()
        {
            if (_rollbackStack.Count == 0)
                return;

            BuildSnapshot snap = _rollbackStack.Pop();
            _auditLedger.AddLast(new AuditLog($"Rollback executed for version: {snap.Version}"));
        }
        public void RecordQualityMetric(string metricName, double score)
        {
            if (!_releaseScoreboard.ContainsKey(score))
            {
                _releaseScoreboard.Add(score, new QualityMetric(metricName, score));
            }
        }
        public void PrintAuditLedger()
        {
            foreach (var log in _auditLedger)
            {
                Console.WriteLine($"{log.Time} - {log.Action}");
            }
        }
        public void PrintReleaseScoreboard()
        {
            foreach (var entry in _releaseScoreboard.Reverse())
            {
                Console.WriteLine($"{entry.Value.Name} : {entry.Key:F2}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            EnterpriseSDLCEngine engine = new EnterpriseSDLCEngine();
            engine.AddRequirement("Single Sign-On", RiskLevel.High);
            engine.AddRequirement("Fraud Detection", RiskLevel.Critical);
            WorkItem design = engine.CreateWorkItem("SSO Design", SDLCStage.Design);
            WorkItem dev = engine.CreateWorkItem("SSO Development", SDLCStage.Development);
            WorkItem test = engine.CreateWorkItem("SSO Testing", SDLCStage.Testing);
            engine.AddDependency(dev.Id, design.Id);
            engine.AddDependency(test.Id, dev.Id);
            engine.RegisterTestSuite("SSO_Regression");
            engine.RegisterTestSuite("SSO_Security_Smoke");
            engine.PlanStage(SDLCStage.Design);
            engine.ExecuteNext();
            engine.ExecuteNext();
            engine.DeployRelease("v3.4.1");
            engine.RecordQualityMetric("Code Coverage", 91.7);
            engine.RecordQualityMetric("Security Score", 97.3);
            engine.RollbackRelease();
            Console.WriteLine("AUDIT LOG");
            engine.PrintAuditLedger();
            Console.WriteLine();
            Console.WriteLine("RELEASE QUALITY SCOREBOARD");
            engine.PrintReleaseScoreboard();
        }
    }
}
