using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FE12GuideNameTool.Tests
{
    [TestClass]
    public class NameFileMapperTests
    {
        private readonly string ArchaneaFileName = "name_akaneia.pkcg";
        private readonly string AlteaFileName = "name_aritia.pkcg";
        private readonly string AssassinFileName = "name_assassin.pkcg";
        private readonly string DragonsFileName = "name_dragons.pkcg";
        private readonly string DolhrFileName = "name_durhua.pkcg";
        private readonly string GraFileName = "name_gra.pkcg";

        [TestInitialize]
        public void Initialize()
        {
            NameFileMapper.InitializeNameFileMapper();
        }

        [TestMethod]
        public void TestArchaneaMapping()
        {
            List<string> expected = GetExpectedArchaneaNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(ArchaneaFileName);
            VerifyNameList(expected, actual);
        }

        [TestMethod]
        public void TestAlteaMapping()
        {
            List<string> expected = GetExpectedAlteaNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(AlteaFileName);
            VerifyNameList(expected, actual);
        }

        [TestMethod]
        public void TestAssassinMapping()
        {
            List<string> expected = GetExpectedAssassinNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(AssassinFileName);
            VerifyNameList(expected, actual);
        }

        [TestMethod]
        public void TestDragonsMapping()
        {
            List<string> expected = GetExpectedDragonsNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(DragonsFileName);
            VerifyNameList(expected, actual);
        }

        [TestMethod]
        public void TestDolhrMapping()
        {
            List<string> expected = GetExpectedDolhrNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(DolhrFileName);
            VerifyNameList(expected, actual);
        }

        [TestMethod]
        public void TestGraMapping()
        {
            List<string> expected = GetExpectedGraNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(GraFileName);
            VerifyNameList(expected, actual);
        }

        private void VerifyNameList(List<string> expected, List<string> actual)
        {
            Assert.IsFalse(expected == null);
            Assert.IsFalse(actual == null);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        private List<string> GetExpectedArchaneaNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Duke Hardin",
                "Emperor Hardin",
                "Nyna",
                "Camus",
                "Gordin",
                "Jeorge",
                "Astram",
                "Midia",
                "Linde",
                "Horace",
                "Boah",
                "Macellan",
                "Dolph",
                "Tomas",
                "Lang",
                "Beck"
            };

            return nameList;
        }

        private List<string> GetExpectedAlteaNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Eine",
                "Abel",
                "Arran",
                "Est",
                "Elice",
                "Cain",
                "Katarina",
                "Player",
                "Gordin",
                "Caeda",
                "Jagen",
                "Cecille",
                "Draug",
                "Norne",
                "Frey",
                "Merric",
                "Marth",
                "Ryan",
                "Luke",
                "Rody",
                "Hardin",
                "Jeorge"
            };

            return nameList;
        }

        private List<string> GetExpectedAssassinNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Eremiah",
                "Katarina",
                "Eine",
                "Kleine",
                "Legion"
            };

            return nameList;
        }

        private List<string> GetExpectedDragonsNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Wendell",
                "Gotoh",
                "Nagi",
                "Xane",
                "Tiki",
                "Bantu"
            };

            return nameList;
        }

        private List<string> GetExpectedDolhrNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Medeus",
                "Gharnef"
            };

            return nameList;
        }

        private List<string> GetExpectedGraNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Sheema",
                "Samson"
            };

            return nameList;
        }
    }
}
