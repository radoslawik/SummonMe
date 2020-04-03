using Microsoft.VisualStudio.TestTools.UnitTesting;
using SummonMe.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummonMe.Models;

namespace SummonMe.API.Tests
{
    [TestClass]
    public class ChampionInfoHandlerTests
    {
        readonly ChampionInfoHandler myHandler = new ChampionInfoHandler();

        [TestMethod]
        public void PCD_SingleChampion()
        {
            Dictionary<string, Champion> myDict = new Dictionary<string, Champion>();
            Champion myOneChampion = new Champion();
            myOneChampion.Id = "QuiteLongChampionName";
            myOneChampion.Key = "1";
            myDict.Add("someStringHere", myOneChampion);
            Dictionary<string, string> retDict = myHandler.ParseChampionData(myDict);

            Assert.AreEqual(retDict["1"], "QuiteLongChampionName");
            Assert.AreEqual(retDict.Count, 1);
        }

        [TestMethod]
        public void PCD_MultipleChampions()
        {
            Dictionary<string, Champion> myDict = new Dictionary<string, Champion>();
            Champion firstChamp = new Champion();
            firstChamp.Id = "FirstChampionName";
            firstChamp.Key = "1";
            Champion secondChamp = new Champion();
            secondChamp.Id = "SecondChampionName";
            secondChamp.Key = "2";
            myDict.Add("oneString", firstChamp);
            myDict.Add("otherString", secondChamp);
            Dictionary<string, string> retDict = myHandler.ParseChampionData(myDict);

            Assert.AreEqual(retDict["1"], "FirstChampionName");
            Assert.AreEqual(retDict["2"], "SecondChampionName");
            Assert.AreEqual(retDict.Count, 2);
        }

        [TestMethod]
        public void PCD_NullData()
        {
            Dictionary<string, string> retDict = myHandler.ParseChampionData(null);
            Assert.IsNotNull(retDict);
            Assert.AreEqual(retDict.Count, 0);
        }
    }
}