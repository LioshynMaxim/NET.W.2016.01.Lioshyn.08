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
        public string Name { get; }
        public string ContactPhone { get; }
        public decimal Revenue { get; }

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
        /// <returns>String line in invariant Culture</returns>

        public override string ToString()
        {
            return ToString("G", CultureInfo.InvariantCulture);
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

            if (format == "")
                format = "G";

            format = format.ToUpperInvariant();

            switch (format)
            {
                case "G":
                    return Name;
                case "N":
                    return Name;
                case "P":
                    return ContactPhone;
                case "R":
                    return Revenue.ToString("F");
                case "NR":
                    return Name + " " + Revenue.ToString("C", formatProvider);
                case "NPR":
                    return Name + " " + ContactPhone + " " + Revenue.ToString("C", formatProvider);
                default:
                    throw new FormatException($"Bad format {format}. Atatata");
            }
        }
    }
}
