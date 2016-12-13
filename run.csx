using System;

public static string Run(string inputFile, string name, TraceWriter log)
{
    log.Info($"C# External trigger function processed file: " + name);
    // Split lines
    string[] content = inputFile.Split("\n");

    // loop per line
    foreach(string s in content)
    {
        
    }

    return inputFile;
}