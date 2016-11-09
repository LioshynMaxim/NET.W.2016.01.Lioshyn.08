using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class CustomerFormatter : IFormatProvider, IFormattable
    {
        /// <summary>
        /// 
        /// </summary>
        public IFormatProvider ParentProvider { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentProvider"></param>

        public CustomerFormatter(IFormatProvider parentProvider)
        {
            this.ParentProvider = parentProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        public CustomerFormatter() : this(CultureInfo.InvariantCulture)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="obj"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>

        public string ToString(string format, object obj, IFormatProvider formatProvider)
        {
            if (format == null || obj == null)
                throw new ArgumentNullException();

            format = format.ToUpperInvariant();

            Customer customer = obj as Customer; //????????

            switch (format)
            {
                case "PN":
                    return customer?.ContactPhone + " " + customer?.Name;
                case "PR":
                    return customer?.ContactPhone + " " + customer?.Revenue.ToString("F");
                default: throw new FormatException($"Bad format {format}. Atatata");
            }
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }
}
