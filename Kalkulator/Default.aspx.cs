using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Kalkulator.Data;
using System.IO;
using System.Text;


namespace Kalkulator
{
    public partial class _Default : Page
    {
        public int Max;
        public int Min;
        public double Sestevanje(double a, double b)
        {
            return a + b; 
        }

        public double Odstevanje(double a, double b)
        {
            return a - b;
        }

        public double Mnozenje(double a, double b)
        {
            return a * b;
        }

        public double Deljenje(double a, double b)
        {
            if(b == 0)
            {
                return -1;
            }
            return a / b;
        }

        public void ResetTheInputs()
        {
            prvoStevilo.Value = "0";
            drugoStevilo.Value = "0";
            radio1.Checked = false;
            radio2.Checked = false;
            radio3.Checked = false;
            radio4.Checked = false;
        }

        public ConfigurationJson UnpackingJson()
        {
            try
            {
                var json = string.Empty;
                using (var fileStream = File.OpenRead(@"settings.json"))
                using (var streamReader = new StreamReader(fileStream, new UTF8Encoding(false)))
                    json = streamReader.ReadToEnd();

                return JsonConvert.DeserializeObject<ConfigurationJson>(json);
            }
            catch (Exception e)
            {
                return new ConfigurationJson
                {
                    MAX = 100,
                    MIN = 0
                };
            }
            
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {

            Max = UnpackingJson().MAX;
            Min = UnpackingJson().MIN;
            var steviloEna = Request.QueryString["prvoStevilo"];
            var operacija = Request.QueryString["operacija"];
            var steviloDva = Request.QueryString["drugoStevilo"];

            if(steviloEna != null && steviloDva != null && operacija != null)
            {
                switch (operacija)
                {
                    case "plus":
                        rezultat.InnerHtml = "Result: " + Sestevanje(Convert.ToDouble(steviloEna),
                    Convert.ToDouble(steviloDva)).ToString();
                        break;
                    case "minus":
                        rezultat.InnerHtml = "Result: " + Odstevanje(Convert.ToDouble(steviloEna),
                    Convert.ToDouble(steviloDva)).ToString();
                        break;
                    case "mult":
                        rezultat.InnerHtml = "Result: " + Mnozenje(Convert.ToDouble(steviloEna),
                    Convert.ToDouble(steviloDva)).ToString();
                        break;
                    case "devi":
                        if (Deljenje(Convert.ToDouble(steviloEna), Convert.ToDouble(steviloDva)) == -1)
                        {
                            prisloDoNapake.InnerHtml = "You cannot devide by zero";
                        }
                        else
                        {
                            rezultat.InnerHtml = "Result: " + Deljenje(Convert.ToDouble(steviloEna),
                    Convert.ToDouble(steviloDva)).ToString();
                        }
                        break;

                }
            }
            
        }

        protected void Calculate_click(object sender, EventArgs e)
        {
            if (radio1.Checked)
            {
                
                rezultat.InnerText = "Result: " + Sestevanje(Convert.ToDouble(prvoStevilo.Value),
                    Convert.ToDouble(drugoStevilo.Value));
                ResetTheInputs();
                
            }
            else
                if (radio2.Checked)
            {
                rezultat.InnerText = "Result: " + Odstevanje(Convert.ToDouble(prvoStevilo.Value),
                    Convert.ToDouble(drugoStevilo.Value));
                ResetTheInputs();
            }
            else
                if (radio3.Checked)
            {
                rezultat.InnerText = "Result: " + Mnozenje(Convert.ToDouble(prvoStevilo.Value),
                    Convert.ToDouble(drugoStevilo.Value));
                ResetTheInputs();
            }
            else
                if (radio4.Checked)
            {
                if(Deljenje(Convert.ToDouble(prvoStevilo.Value),Convert.ToDouble(drugoStevilo.Value)) == -1)
                {
                    prisloDoNapake.InnerHtml = "You cannot devide by zero";
                }
                else
                {
                    rezultat.InnerText = "Result: " + Deljenje(Convert.ToDouble(prvoStevilo.Value),
                    Convert.ToDouble(drugoStevilo.Value));
                }
                ResetTheInputs();
            }
            else
            {
                prisloDoNapake.InnerHtml = "You must select an operation for calculations";
            }
        }

        protected void Reset_click(object sender, EventArgs e)
        {
            ResetTheInputs();
            prisloDoNapake.InnerHtml = null;
            rezultat.InnerHtml = null;
        }
    }
}