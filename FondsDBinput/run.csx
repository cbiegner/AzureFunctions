using System;

private class fdata
{
    public fdata()
    {
        processed = false;
    }

    public fdata(string input)
    {
        processed = false;
        string[] fields = input.Split(';');

        if (fields.Length >= 12)
        {
            this.s1 = fields[0];
            this.s2 = fields[1];
            this.s3 = fields[2];
            this.s4 = fields[3];
            this.s5 = double.parse(fields[4]);
            this.s6 = double.parse(fields[5]);
            this.s7 = double.parse(fields[6]);
            this.s8 = double.parse(fields[7]);
            this.s9 = fields[8];
            this.s10 = double.parse(fields[9]);            

            processed = true;
        }
        else
        {
            if(input.Trim() != string.Empty)
            {
                log.Error($"Number of fields differ in line: {input}.")
            }    
        }
    }

    public bool processed { get; private set; }
    public string s1 { get; set; }
    public string s2 { get; set; }
    public string s3 { get; set; }
    public string s4 { get; set; }
    public double s5 { get; set; }
    public double s6 { get; set; }
    public double s7 { get; set; }
    public double s8 { get; set; }
    public string s9 { get; set; }
    public double s10 { get; set; }

    public bool Save()
    {
        if(processed)
            return true;
        else
            return false;
    }
}
public static string Run(string inputFile, string name, TraceWriter log)
{
    log.Info($"C# External trigger function processed file: " + name);

    // Split lines
    try
    {
        string[] lines = inputFile.Split('\n');

        // Loop per line
        foreach (string line in lines)
        {
            if (Counter++ > 0)
            {
                var data = new fdata(line);
                string[] fields = line.Split(';');
                if(!data.Save())
                {
                    log.Error($"Error on writing data line {Counter}: {ex.Message}.");
                }
            }
        }
    }
    catch (Exception ex)
    {
        log.Error($"Some error occured: {ex.Message}.");
    }

    return inputFile;
}