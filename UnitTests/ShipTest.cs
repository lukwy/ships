using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ships.Model;
using Ships.Model.Interfaces;
using System.Windows.Media;

namespace UnitTests
{
    [TestClass]
    public class ShipTest
    {
        [TestMethod]
        public void Ship_SetWhiteColorTest()
        {
            IShip ship = new Ship();

            ship.SetWhite();

            Brush whiteBrush = Brushes.White;

            Assert.AreEqual(ship.Color, whiteBrush);
        }

        [TestMethod]
        public void Ship_ChangeColorOnGreenBeforeGameStartTest()
        {
            IShip ship = new Ship();

            ship.SetWhite();
            ship.ButtonClick.Execute(new object());

            Brush greenColor = Brushes.Chartreuse;

            Assert.AreEqual(ship.Color, greenColor);
        }

        [TestMethod]
        public void Ship_ChangeColorOnRedAfterGameStartTest()
        {
            IShip ship = new Ship();

            ship.SetWhite();
            ship.IsGameStarted = true;
            ship.ButtonClick.Execute(new object());

            Brush redColor = Brushes.Red;

            Assert.AreEqual(ship.Color, redColor);
        }

        [TestMethod]
        public void Ship_SetAsShipTest()
        {
            IShip ship = new Ship();

            ship.SetWhite();
            ship.ButtonClick.Execute(new object());

            Assert.AreEqual(ship.IsShip, true);
        }
    }
}
