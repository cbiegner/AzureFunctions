#load "./fdata.csx"

#r "Newtonsoft.Json"

using System;

using Newtonsoft.Json;

public static string Run(string inputFile, string name, TraceWriter log, ICollector<string> outputSbQueue)
{
    log.Info($"C# External trigger function processed file: " + name);

    int Counter = 0;

    // Split lines
    try
    {
        string[] lines = inputFile.Split('\n');

        // Loop per line
        foreach (string line in lines)
        {
            // Skip first line
            if (Counter++ > 0)
            {
                var data = new fdata(line);
                string[] fields = line.Split(';');
                if(data.Save())
                {
                    outputSbQueue.Add(JsonConvert.SerializeObject(data));
                }
                else
                {
                    if(data.raw.Trim()!= string.Empty)
                    {
                        log.Error($"Error on writing data line {Counter}: {line}.");
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        log.Error($"Some error occured: {ex.Message}.");
    }

    log.Info($"{Counter} lines processed]: " + name);

    return inputFile;
}
