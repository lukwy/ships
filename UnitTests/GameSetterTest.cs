using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ships.Model;
using Ships.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class GameSetterTest
    {
        [TestMethod]
        public void GameSetter_GenerateMapTest()
        {
            IGameSetter gameSetter = new GameSetter(new TextCounter());

            gameSetter.GenerateMap();

            Assert.IsTrue(gameSetter.ShipsData.Count == 400);
        }

        [TestMethod]
        public void GameSetter_StartGameTest()
        {
            IGameSetter gameSetter = new GameSetter(new TextCounter());

            gameSetter.GenerateMap();
            gameSetter.ShipsData.FirstOrDefault().ButtonClick.Execute(new object());
            gameSetter.StartGame();

            Assert.IsTrue(gameSetter.Message.Text.Equals("Ships to destroy: 1"));
            Assert.IsTrue(gameSetter.ShipsData.Any(s => s.IsGameStarted));
        }

        [TestMethod]
        public void GameSetter_StartEmptyGameTest()
        {
            IGameSetter gameSetter = new GameSetter(new TextCounter());

            gameSetter.GenerateMap();
            gameSetter.StartGame();

            Assert.IsFalse(gameSetter.ShipsData.Any(s => s.IsGameStarted));
        }
    }
}
