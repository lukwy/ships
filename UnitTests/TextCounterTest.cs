using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ships.Model;
using Ships.Model.Interfaces;

namespace UnitTests
{
    [TestClass]
    public class TextCounterTest
    {
        [TestMethod]
        public void TextCounter_SetEmptyTextTest()
        {
            ITextCounter textCounter = new TextCounter();

            textCounter.TextChangeCommand.Execute(new object());


            Assert.IsTrue(textCounter.Text.Equals("Ships to destroy: "));
        }

        [TestMethod]
        public void TextCounter_SetTenShipsTest()
        {
            ITextCounter textCounter = new TextCounter();

            textCounter.TextChangeCommand.Execute(new object());
            textCounter.Text = "10";

            Assert.IsTrue(textCounter.Text.Equals("Ships to destroy: 10"));
        }
    }
}
