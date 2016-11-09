using NUnit.Framework;
using Task1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestFixture()]
    public class CustomerTests
    {
        private readonly Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
        private IFormatProvider formatProvider = CultureInfo.InvariantCulture;


        [Test()]
        [TestCase("", null, Result = "Jeffrey Richter")]
        [TestCase("n", null, Result = "Jeffrey Richter")]
        [TestCase("npr", null, Result = "Jeffrey Richter +1 (425) 555-0100 ¤1,000,000.00")]
        [TestCase("npr", "en-GB", Result = "Jeffrey Richter +1 (425) 555-0100 £1,000,000.00")]
        public string ToString_Format(string format, string cultureName)
        {
            if (cultureName != null)
                formatProvider = new CultureInfo(cultureName);

            return customer.ToString(format, formatProvider);
        }

        [TestCase("nprb", "en-GB", Result = "Jeffrey Richter +1 (425) 555-0100 £1,000,000.00")]
        public void ToString_Format_A(string format, string cultureName)
        {
            if (cultureName != null)
                formatProvider = new CultureInfo(cultureName);

            Assert.That(() => customer.ToString(format, formatProvider), Throws.TypeOf<FormatException>());
        }

        [Test()]
        [TestCase("", null, Result = "Jeffrey Richter")]
        [TestCase("n", null, Result = "Jeffrey Richter")]
        [TestCase("np", null, Result = "Jeffrey Richter +1 (425) 555-0100")]
        [TestCase("npr", null, Result = "Jeffrey Richter +1 (425) 555-0100 ¤1,000,000.00")]
        [TestCase("npr", "en-GB", Result = "Jeffrey Richter +1 (425) 555-0100 £1,000,000.00")]
        public string ToString_Format_CustomerFormatProvider(string format, string provider)
        {
            if (provider != null)
                formatProvider = new CultureInfo(provider);

            CustomFormatProvider customFormatProvider = new CustomFormatProvider(formatProvider);

            return customFormatProvider.Format(format,customer,formatProvider);
        }

        [Test()]
        [TestCase("bbbb", null, Result = "Jeffrey Richter")]
        public void ToString_Format_Exception(string format, string provider)
        {
            if (provider != null)
                formatProvider = new CultureInfo(provider);

            CustomFormatProvider customFormatProvider = new CustomFormatProvider(formatProvider);

            Assert.That(() => customFormatProvider.Format(format, customer, formatProvider), Throws.TypeOf<FormatException>());

        }
    }
}