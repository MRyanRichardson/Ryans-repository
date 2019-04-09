using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibraryWebAPI.Models.Data;
using DVDLibraryWebAPI.Data;
using NUnit.Framework;
using DvdLibraryWebApi.Data.Repositories.SampleData;
using DVDLibraryWebAPI.Models.Interfaces;

namespace Test
{
    [TestFixture]
    class TestClass
    {
        private IDvdRepository _repo;

        [SetUp]
        public void Init()
        {
            _repo = new DvdRepositoryMock();
        }
        [Test]
        public void CanGetAllDvds()
        {
            List<DVD> dvds = _repo.GetAll().ToList();
            Assert.AreEqual(4, dvds.Count());
            Assert.AreEqual(1, dvds[0].dvdId);
            Assert.AreEqual("Blazing Saddles", dvds[2].title);
        }


        [Test]
        [TestCase("Holy", "Holy Grail")]
        [TestCase("aked", "Naked Gun")]
        [TestCase("z", "Blazing Saddles")]
        [TestCase("", "4")]
        public void SearchByTitle(string title, string expectedResult )
        {
            List<DVD> dvds = _repo.SearchByTitle(title);
            if (title != "")
            {
                Assert.AreEqual(dvds[0].title, expectedResult);
            }
            else {
                Assert.AreEqual(dvds.Count, Convert.ToInt32(expectedResult));
            }
        }


        [Test]
        [TestCase(1975, "Holy Grail")]
        [TestCase(1988, "Naked Gun")]
        [TestCase(1974, "Blazing Saddles")]
        [TestCase(1977, "Star Wars")]
        //making sure that program will break with bad release year
        //[TestCase(1904, "Star Wars")]
        public void SearchByReleaseYear(int year, string expectedResult)
        {
            List<DVD> dvdByYear = _repo.SearchByReleaseYear(year);
            //make sure result title is equal to the expected title
            Assert.AreEqual(dvdByYear[0].title, expectedResult);
        }

        [Test]
        [TestCase("Airplane", 1980, "David Zucker, Jim Abrahams, Jerry Zucker", "PG", "", 4)]
        [TestCase("Ferris Bueller's Day Off", 1986, "John Hughes", "PG", "Test", 4)]
       

        public void addDVD(string title, int releaseYear, string director, string rating, string notes, int index)
        {
            DVD d = new DVD();
            d.title = title;
            d.realeaseYear = releaseYear;
            d.director = director;
            d.rating = rating;
            d.notes = notes;
            _repo.Add(d);
            List<DVD> dvds = _repo.GetAll();
            Assert.AreEqual(dvds[index].title,d.title);
        }
    
}
}