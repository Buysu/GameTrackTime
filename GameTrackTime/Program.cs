// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text;
using GameTrackLib.Extensions;
using GameTrackLib.Tracker;

ConsoleExtension.WriteLine("^mGame Track Time");

var tracker = new ProcessTracker();
tracker.Update();

for (int i = 0; i < tracker.Processes.Count; i++)
{
    var process = tracker.Processes[i];
    Console.WriteLine($"{i + 1} - {process.ProcessName} ()");
}

return 0;