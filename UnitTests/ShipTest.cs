using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ships.Model;
using System.Windows.Media;

namespace UnitTests
{
    [TestClass]
    class ShipTest
    {
        [TestMethod]
        public void SetWhiteShould()
        {
            Mock<Ship> shipMock = new Mock<Ship>();

            shipMock.Setup(s => s.SetWhite());

            Brush whiteBrush = Brushes.White;

            Assert.AreEqual(shipMock.Object.Color, whiteBrush);
        }

        [TestMethod]
        public void ChangeColorOnGreenBeforeGameStart()
        {
            Mock<Ship> shipMock = new Mock<Ship>();

            shipMock.Setup(s => s.SetWhite());
            shipMock.Setup(s => s.ButtonClick);

            Brush greenColor = Brushes.Chartreuse;

            Assert.AreEqual(shipMock.Object.Color, greenColor);
        }

        [TestMethod]
        public void ChangeColorOnRedAfterGameStart()
        {
            Mock<Ship> shipMock = new Mock<Ship>();

            shipMock.Setup(s => s.SetWhite());
            shipMock.Object.IsGameStarted = true;
            shipMock.Setup(s => s.ButtonClick);

            Brush redColor = Brushes.Red;

            Assert.AreEqual(shipMock.Object.Color, redColor);
        }
    }
}
