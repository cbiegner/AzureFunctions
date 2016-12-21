using System;

public class fdata
{
    public fdata()
    {
        processed = false;
    }

    public fdata(string input)
    {
        processed = false;

        this.raw = input;
        string[] fields = input.Split(';');

        if (fields.Length >= 12)
        {
            this.s1 = fields[0];
            this.s2 = fields[1];
            this.s3 = fields[2];
            this.s4 = fields[3];
            this.s5 = double.Parse(fields[4]);
            this.s6 = double.Parse(fields[5]);
            this.s7 = double.Parse(fields[6]);
            this.s8 = double.Parse(fields[7]);
            this.s9 = fields[8];
            this.s10 = double.Parse(fields[9]);            

            processed = true;
        }
    }

    public string raw { get; private set; }
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
