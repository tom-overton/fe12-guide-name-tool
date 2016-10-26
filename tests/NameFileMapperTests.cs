// Copyright (c) 2016 Tom Overton

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
        private readonly string GrustFileName = "name_grunia.pkcg";
        private readonly string KhadeinFileName = "name_khadein.pkcg";
        private readonly string MacedonFileName = "name_macedonia.pkcg";
        private readonly string SellswordsFileName = "name_mercenary.pkcg";
        private readonly string AurelisFileName = "name_orleans.pkcg";
        private readonly string OtherFileName = "name_other.pkcg";
        private readonly string TalysFileName = "name_talis.pkcg";

        [TestInitialize]
        public void Initialize()
        {
            NameFileMapper.InitializeNameFileMapper();
        }

        [TestMethod]
        public void NameFileMapperWorksWithImproperCasing()
        {
            string graPermutation1 = "NAME_GRA.PKCG";
            string graPermutation2 = "nAmE_gRa.pkcg";

            List<string> expected = GetExpectedGraNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(graPermutation1);
            VerifyNameList(expected, actual);
            
            actual = NameFileMapper.GetNamesForFile(graPermutation2);
            VerifyNameList(expected, actual);
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

        [TestMethod]
        public void TestGrustMapping()
        {
            List<string> expected = GetExpectedGrustNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(GrustFileName);
            VerifyNameList(expected, actual);
        }

        [TestMethod]
        public void TestKhadeinMapping()
        {
            List<string> expected = GetExpectedKhadeinNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(KhadeinFileName);
            VerifyNameList(expected, actual);
        }

        [TestMethod]
        public void TestMacedonMapping()
        {
            List<string> expected = GetExpectedMacedonNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(MacedonFileName);
            VerifyNameList(expected, actual);
        }

        [TestMethod]
        public void TestSellswordsMapping()
        {
            List<string> expected = GetExpectedSellswordsNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(SellswordsFileName);
            VerifyNameList(expected, actual);
        }

        [TestMethod]
        public void TestAurelisMapping()
        {
            List<string> expected = GetExpectedAurelisNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(AurelisFileName);
            VerifyNameList(expected, actual);
        }

        [TestMethod]
        public void TestOtherMapping()
        {
            List<string> expected = GetExpectedOtherNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(OtherFileName);
            VerifyNameList(expected, actual);
        }

        [TestMethod]
        public void TestTalysMapping()
        {
            List<string> expected = GetExpectedTalysNameList();
            List<string> actual = NameFileMapper.GetNamesForFile(TalysFileName);
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

        private List<string> GetExpectedGrustNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Yubello",
                "Yumina",
                "Lorenz",
                "Camus",
                "Nyna",
                "Belf",
                "Robert",
                "Leiden",
                "Roger",
                "Malicia",
                "Jake",
                "Sirius",
                "Ogma",
                "Caeda"
            };

            return nameList;
        }

        private List<string> GetExpectedKhadeinNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Gotoh",
                "Wendell",
                "Etzel",
                "Merric",
                "Elrean",
                "Elice"
            };

            return nameList;
        }

        private List<string> GetExpectedMacedonNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Minerva",
                "Michalis",
                "Maria",
                "Palla",
                "Catria",
                "Est",
                "Abel",
                "Matthis",
                "Warren",
                "Frost",
                "Lena",
                "Julian",
                "Rickard"
            };

            return nameList;
        }

        private List<string> GetExpectedSellswordsNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Dice",
                "Malice",
                "Caesar",
                "Radd",
                "Caeda",
                "Navarre",
                "Samto",
                "Feena",
                "Ogma"
            };

            return nameList;
        }

        private List<string> GetExpectedAurelisNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Marth",
                "King Aurelis",
                "Duke Hardin",
                "Emperor Hardin",
                "Wolf",
                "Sedgar",
                "Roshea",
                "Vyland"
            };

            return nameList;
        }

        private List<string> GetExpectedOtherNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Ymir",
                "Rickard",
                "Julian",
                "Feena",
                "Athena",
                "Navarre"
            };

            return nameList;
        }

        private List<string> GetExpectedTalysNameList()
        {
            List<string> nameList = new List<string>()
            {
                "Roger",
                "Jake",
                "Marth",
                "Caeda",
                "Navarre",
                "Wrys",
                "Castor",
                "Darros",
                "Ogma",
                "Bord",
                "Cord",
                "Barst",
                "Sirius",
                "Samto"
            };

            return nameList;
        }
    }
}
