using a2;

namespace a2Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OK1()
        {
            // common behavior
            Earth e = new("testcases/1.ok");
            int h; Weather? w; List<Area> a;

            a = e.getAreas();
            w = e.getWeather();
            h = e.getHumidity();
            Assert.AreEqual(h, 98);
            Assert.AreEqual(w, null);
            Assert.AreEqual(a.Count, 4);
            Assert.AreEqual(a[0].ToString(), "[Lakes]: 86km3 (owned by Mr Bean)");
            Assert.AreEqual(a[1].ToString(), "[Grassland]: 26km3 (owned by Mr Green)");
            Assert.AreEqual(a[2].ToString(), "[Plain]: 12km3 (owned by Mr Dean)");
            Assert.AreEqual(a[3].ToString(), "[Grassland]: 35km3 (owned by Mr Teen)");

            e.Run();
            a = e.getAreas();
            w = e.getWeather();
            h = e.getHumidity();
            Assert.AreEqual(h, 41);
            Assert.AreEqual(w, Rainy.Instance());
            Assert.AreEqual(a.Count, 4);
            Assert.AreEqual(a[0].ToString(), "[Grassland]: 86km3 (owned by Mr Bean)");
            Assert.AreEqual(a[1].ToString(), "[Grassland]: 26km3 (owned by Mr Green)");
            Assert.AreEqual(a[2].ToString(), "[Grassland]: 32km3 (owned by Mr Dean)");
            Assert.AreEqual(a[3].ToString(), "[Grassland]: 35km3 (owned by Mr Teen)");
        }

        [TestMethod]
        public void OK2()
        {
            Earth e = new("testcases/2.ok");
            int h; Weather? w; List<Area> a;

            a = e.getAreas();
            w = e.getWeather();
            h = e.getHumidity();
            Assert.AreEqual(h, 0);
            Assert.AreEqual(w, null);
            Assert.AreEqual(a.Count, 0);

            e.Run();
            a = e.getAreas();
            w = e.getWeather();
            h = e.getHumidity();
            Assert.AreEqual(h, 0);
            Assert.AreEqual(w, Sunny.Instance());
            Assert.AreEqual(a.Count, 0);
        }

        [TestMethod]
        public void BAD1()
        {
            Assert.ThrowsException<FormatError>(() => {
                Earth e = new("testcases/1.bad");
            });
        }

        [TestMethod]
        public void BAD2()
        {
            Assert.ThrowsException<FormatError>(() => {
                Earth e = new("testcases/2.bad");
            });
        }

        [TestMethod]
        public void BAD3()
        {
            Assert.ThrowsException<AreaError>(() => {
                Earth e = new("testcases/3.bad");
            });
        }

        [TestMethod]
        public void BAD4()
        {
            Assert.ThrowsException<FileError>(() => {
                Earth e = new("testcases/none");
            });
        }
    }
}