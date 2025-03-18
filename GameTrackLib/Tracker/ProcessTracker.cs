using System.Diagnostics;

namespace GameTrackLib.Tracker;

public class ProcessTracker
{
    public List<Process> Processes { get; private set; }= new();
    public ProcessTracker(){}

    public void Update(List<string>? filteredProcesses = null)
    {
        Processes = Process.GetProcesses()
            .Where(p => isFilterProcess(p.ProcessName, filteredProcesses)).ToList();
    }

    private bool isFilterProcess(string processName, List<string>? filteredProcesses)
    {
        return !(processName.ToLower().Contains("system") || processName.ToLower().Contains("win")) && (filteredProcesses?.Contains(processName) ?? true);
    }
}