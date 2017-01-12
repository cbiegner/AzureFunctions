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

        if (fields.Length >= 24)
        {
            this.TransferID = Guid.Parse(fields[0]);
            this.Filename = fields[1];
            this.Fondsname = fields[2];
            this.ISIN = fields[3];
            this.WKN = fields[4];
            this.Gesellschaft = fields[5];
            this.MindestanlageErst = decimal.Parse(fields[6]);
            this.GrundlageVPH = double.Parse(fields[7]);
            this.VP = double.Parse(fields[8]);
            this.VPh = double.Parse(fields[9]);
            this.Formel_VPh = fields[10];
            this.AGAG_fremd = double.Parse(fields[11]);            
            this.SchlusstagsabweichungKauf = int.Parse(fields[12]);
            this.SchlusstagsabweichungVerkauf = int.Parse(fields[13]);
            this.sparplanfaehig = fields[14];
            this.Mindestfolgeanlage = decimal.Parse(fields[15]);
            this.Mindestsparplanrate = decimal.Parse(fields[16]);
            this.Kaufsperre = fields[17];
            this.Verkaufsperre = fields[18];
            this.Waehrung = fields[19];
            this.Fondsart = fields[20];
            this.Transaktionskosten_Kauf = decimal.Parse(fields[21]);            
            this.Transaktionskosten_Verkauf = decimal.Parse(fields[22]);            
            this.ETF = fields[23];

            processed = true;
        }
    }

    public string raw { get; private set; }
    public bool processed { get; private set; }

    public Guid TransferID { get; set; }
    public string Filename { get; set; }

    public string Fondsname { get; set; }
    public string ISIN { get; set; }
    public string WKN { get; set; }
    public string Gesellschaft { get; set; }
    public decimal MindestanlageErst { get; set; }
    public double GrundlageVPH { get; set; }
    public double VP { get; set; }
    public double VPh { get; set; }
    public string Formel_VPh { get; set; }
    public double AGAG_fremd { get; set; }

    public int SchlusstagsabweichungKauf { get; set; }
    public int SchlusstagsabweichungVerkauf { get; set; }
    public string sparplanfaehig { get; set; }
    public decimal Mindestfolgeanlage { get; set; }
    public decimal Mindestsparplanrate { get; set; }
    public string Kaufsperre { get; set; }
    public string Verkaufsperre { get; set; }
    public string Waehrung { get; set; }
    public string Fondsart { get; set; }
    public decimal Transaktionskosten_Kauf { get; set; }
    public decimal Transaktionskosten_Verkauf { get; set; }
    public string ETF { get; set; }

    public int Fondsart_ID
    {
        get
        {
            string[] parts = Fondsart.Split('-');
            if(parts.Length == 2)
            {
                return int.Parse(parts[0].Trim());
            }
            else
            {
                return -1;
            }
        }
    }
    public string Fondsart_Text
    {
        get
        {
            string[] parts = Fondsart.Split('-');
            if(parts.Length == 2)
            {
                return parts[1].Trim();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public bool Save()
    {
        if(processed)
            return true;
        else
            return false;
    }
}
