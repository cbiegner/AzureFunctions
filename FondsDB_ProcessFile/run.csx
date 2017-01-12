using System;

public static void Run(string inputFile, string name, TraceWriter log, ICollector<string> outputSbQueue)
{
    int Counter = 0;
    Guid UniqueID = Guid.NewGuid();

    log.Info($"File processed: {name} {UniqueID}");

    // Split lines
    try
    {
        string[] lines = inputFile.Split('\n');

        // Loop per line
        for(int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            
            // Skip first line
            if (Counter++ == 0)
                continue;
            if (line.Trim() == string.Empty)
                continue;

            outputSbQueue.Add(string.Format("{0};{1};{2}", UniqueID, name, line));
        }
    }
    catch (Exception ex)
    {
        log.Error($"Some error occured: {ex.Message}.");
    }
}
