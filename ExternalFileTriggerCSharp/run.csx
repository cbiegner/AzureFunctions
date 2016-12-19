using System;

private struct fdata
{
    public string s1;
    public string s2;
    public string s3;
    public string s4;
    public double s5;
    public double s6;
    public double s7;
    public double s8;
    public string s9;
    public double s10;
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
                string[] fields = line.Split(';');
                if (fields.Length >= 12)
                {
                    try
                    {
                        var data = new fdata()
                        {
                            s1 = fields[0];
                            s2 = fields[1];
                            s3 = fields[2];
                            s4 = fields[3];
                            s5 = double.parse(fields[4]);
                            s6 = double.parse(fields[5]);
                            s7 = double.parse(fields[6]);
                            s8 = double.parse(fields[7]);
                            s9 = fields[8];
                            s10 = double.parse(fields[9]);
                        }
                        // Save Data
                        //dl.DataComplete_Set(fields[0], fields[1], fields[2], fields[3], double.Parse(fields[4]), double.Parse(fields[5]), double.Parse(fields[6]), double.Parse(fields[7]), fields[8], double.Parse(fields[9]));
                        //result.Add(JsonConvert.)
                    }
                    catch (Exception ex)
                    {
                        log.Error($"Error on writing data line {Counter}: {ex.Message}.");
                    }
                }
                else
                {
                    if(line.Trim() != string.Empty)
                        log.Error($"Number of fields differ in line: {Counter}.");
                }

                if (Counter % 10 == 0)
                {
                    svc.Logout();

                    svc = new Services();
                    svc.Session = new SessionID();
                    svc.URL = ServiceURL;
                    svc.ConnectionString = ConnectionString;
                    svc.ActionTracking = ActionTracking;
                    svc.Login();
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