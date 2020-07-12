using NUnit.Framework;

namespace AttributesLib.Tests {
    public class CSVParserTests {
        [Test]
        public void GetData_ReturnsCity_WhenValid() {
            var parser = new CSVParser("CSVs/cities.csv");

            var cityName = parser.GetData(64, 8);

            Assert.AreEqual(cityName, "Springfield");
        }

        [Test]
        public void GetData_ReturnsCity_WhenRowInvalid() {
            var parser = new CSVParser("CSVs/cities.csv");

            var cityName = parser.GetData(int.MaxValue, 8);

            Assert.IsNull(cityName);
        }

        [Test]
        public void GetData_ReturnsCity_WhenFieldInvalid() {
            var parser = new CSVParser("CSVs/cities.csv");

            var cityName = parser.GetData(64, int.MaxValue);

            Assert.IsNull(cityName);
        }
    }
}