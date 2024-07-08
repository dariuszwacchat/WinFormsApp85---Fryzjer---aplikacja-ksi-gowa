using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class S
    {
        public static bool ImageFromWeb (this string sciezka)
        {
            string [] sciezkaSplit = sciezka.Split(':');
            if (sciezkaSplit[0] == "https" || sciezkaSplit[0] == "http" || sciezkaSplit[0] == "data")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
         
/*
        public static Image GetImage (string sciezka)
        {
            Image image;

            WebRequest webreq = WebRequest.Create(sciezka);
            WebResponse webres = webreq.GetResponse();
            Stream stream = webres.GetResponseStream();
            image = Image.FromStream(stream);
            stream.Close();

            return image;
        }
*/

        public static double BruttoVat8 (double kwota)
        {
            double vat = (kwota * 8) / 100;
            return Math.Round(vat, 2);
        }

        public static double BruttoVat22 (double kwota)
        {
            double vat = (kwota * 22) / 100;
            return Math.Round(vat, 2);
        }

        public static double ZyskBruttoVat8 (double kwota)
        {
            double vat = (kwota * 8) / 100;
            double k =  kwota - vat;
            return Math.Round(k, 2);
        }

        public static double ZyskBruttoVat22 (double kwota)
        {
            double vat = (kwota * 22) / 100;
            double k =  kwota - vat;
            return Math.Round(k, 2);
        }


        public static string IlePozostaloRoznica (DateTime dataObecna, DateTime dataPrzyszla)
        {
            var result = dataPrzyszla - dataObecna;
            return
                result.Days.ToString() + " dni, " +
                result.Hours.ToString() + ":" +
                result.Minutes.ToString() + ":" +
                result.Seconds.ToString();
        }


        public static int ProgressStepper (int values)
        {
            int value = 0;
            if (values < 100)
                value = 100 / values;
            else
                value = values / 100;
            return value;
        }


    }
}
