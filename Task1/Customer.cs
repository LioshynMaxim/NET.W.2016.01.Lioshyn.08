using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Customer : IFormattable
    {

        public string Name { get; private set; }
        public string ContactPhone { get; private set; }
        public decimal Revenue { get; private set; }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="name">Name value</param>
        /// <param name="phone">Contact phone value</param>
        /// <param name="revenue">Revenue value</param>

        public Customer(string name, string phone, decimal revenue)
        {
            Name = name;
            ContactPhone = phone;
            Revenue = revenue;
        }

        /// <summary>
        /// Override ToString in invariant Culture
        /// </summary>
        /// <param name="format">format show classes</param>
        /// <returns>String line in invariant Culture</returns>

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Override ToString in invariant Culture
        /// </summary>
        /// <param name="format">format show classes</param>
        /// <param name="formatProvider"></param>
        /// <returns>String line in invariant Culture</returns>

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                throw new ArgumentNullException();

            format = format.ToUpperInvariant();

            switch (format)
            {
                case "":
                    return Name;
                case "NAME":
                    return Name;
                case "PHONE":
                    return ContactPhone;
                case "REVENUE":
                    return Revenue.ToString("F");

                case "NP":
                    return Name + " " + ContactPhone;
                case "NR":
                    return Name + " " + Revenue.ToString("F");

                //case "PN":
                //    return ContactPhone + " " + Name;
                //case "PR":
                //    return ContactPhone + " " + Revenue.ToString("F");

                case "RN":
                    return Revenue.ToString("C") + " " + Name;
                case "RP":
                    return Revenue.ToString("C") + " " + ContactPhone;

                case "NPR":
                    return Name + " " + ContactPhone + " " + Revenue.ToString("F");

                default:
                    throw new FormatException($"Bad format {format}. Atatata");
            }
        }
    }
}
