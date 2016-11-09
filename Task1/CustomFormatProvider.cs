using System;
using System.Globalization;
using System.Threading;

namespace Task1
{
    public class CustomFormatProvider : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IFormatProvider parentProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentProvider"></param>

        public CustomFormatProvider(IFormatProvider parentProvider)
        {
            if (parentProvider == null)
                parentProvider = Thread.CurrentThread.CurrentCulture;

            this.parentProvider = parentProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        public CustomFormatProvider() : this(CultureInfo.CurrentCulture)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>

        public object GetFormat(Type formatType)
        {
            return formatType == typeof (ICustomFormatter) ? this : null; //parentProvider.GetFormat(formatType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="obj"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string Format(string format, object obj, IFormatProvider formatProvider)
        {
            Customer customer = (Customer) obj;
            format = format.ToUpperInvariant();
            
            if (string.IsNullOrEmpty(format))
                format = "G";

            switch (format)
            {
                case "NP":
                    return customer?.Name + " " + customer?.ContactPhone;
                case "RN":
                    return customer?.Revenue.ToString("C", formatProvider) + " " + customer?.Name;
                case "RP":
                    return customer?.Revenue.ToString("C", formatProvider) + " " + customer?.ContactPhone;
                case "PN":
                    return customer?.ContactPhone + " " + customer?.Name;
                case "PR":
                    return customer?.ContactPhone + " " + customer?.Revenue.ToString("C", formatProvider);
                default:

                    try
                    {
                        return customer.ToString(format, formatProvider);
                    }
                    catch (Exception)
                    {
                        throw new FormatException($"Bad format {format}. Atatata");
                    }
            }

        }
    }
}
