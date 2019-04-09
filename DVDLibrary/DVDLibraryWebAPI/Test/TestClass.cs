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
        //pulling in interface methods
        private IDvdRepository repository;
        [SetUp]
        //testing from mock repository since data is not changing 
        public void mockRepository()
        {
            //instantiating mockRepository
            repository = new DvdRepositoryMock();
        }
        //return all dvds
        [Test]
        public void GetAllDvdsTest()
        {
            List<DVD> dvds = repository.GetAll().ToList();
            //make sure dvd count is correct (4 dvds)
            Assert.AreEqual(4, dvds.Count());
            //make sure first record id(1) is equal to index [0]
            Assert.AreEqual(1, dvds[0].dvdId);
            //making sure blazing saddles is my 3rd dvd (index 2)
            Assert.AreEqual("Blazing Saddles", dvds[2].title);
        }
        //get by id
        [Test]
        [TestCase(1, "Holy Grail")]
        [TestCase(2, "Naked Gun")]
        [TestCase(3, "Blazing Saddles")]
        [TestCase(4, "Star Wars")]
        //making sure that program will break with bad id
        //[TestCase(6, "Star Wars")]
        public void GetDVDByIDTest(int id, string expectedResult)
        {
            //get Dvd record by id from mock repository
            DVD dvd = repository.GetById(id);
            //make sure result title is equal to the expected title
            Assert.AreEqual(dvd.title, expectedResult);
        }
        //searching by release year
        [Test]
        [TestCase(1975, "Holy Grail")]
        [TestCase(1988, "Naked Gun")]
        [TestCase(1974, "Blazing Saddles")]
        [TestCase(1977, "Star Wars")]
        //making sure that program will break with bad release year
        //[TestCase(1904, "Star Wars")]
        public void SearchByReleaseYearTest(int year, string expectedResult)
        {
            List<DVD> dvdByYear = repository.SearchByReleaseYear(year);
            //make sure result title is equal to the expected title
            Assert.AreEqual(dvdByYear[0].title, expectedResult);
        }
        //searching by title
        [Test]
        [TestCase("Holy", "Holy Grail")]
        [TestCase("aked", "Naked Gun")]
        [TestCase("z", "Blazing Saddles")]
        [TestCase("", "4")]
        public void SearchByTitleTest(string title, string expectedResult)
        {
            //knowing it will only return one due to our testcase
            //if null go to else and convert to in and print expected result
            List<DVD> dvds = repository.SearchByTitle(title);
            if (title != "")
            {
                Assert.AreEqual(dvds[0].title, expectedResult);
            }
            else
            {
                Assert.AreEqual(dvds.Count, Convert.ToInt32(expectedResult));
            }
        }
        [Test]
        [TestCase("Terry", "Terry Gilliam")]
        [TestCase("Zuck", "David Zucker")]
        [TestCase("Mel", "Mel brooks")]
        [TestCase("rge", "George Lucas")]
        [TestCase("", "4")]
        public void SearchByDirectorTest(string director, string expectedResult)
        {
            List<DVD> dvds = repository.SearchByDirector(director);
            if (director != "")
            {
                Assert.AreEqual(dvds[0].director, expectedResult);
            }
            else
            {
                Assert.AreEqual(dvds.Count, Convert.ToInt32(expectedResult));
            }
        }
        //SearchByRating
        [Test]
        [TestCase("PG-13", "PG-13")]
        [TestCase("R", "R")]
        public void SearchByRatingTest(string rating, string expectedResult)
        {
            List<DVD> dvds = repository.SearchByRating(rating);
            Assert.AreEqual(dvds[0].rating, expectedResult);
        }
        //edit dvd
        public void UpdateDVDTest(int DvdId, string expectedResult)
        {
        }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        //delete dvd by id
        public void DeleteDVDTest(int Id)
        {
            //call delete
            repository.Delete(Id);
            //check to see if dvd is still in list of dvd
            DVD dvd = repository.GetById(Id);
            Assert.IsNull(dvd);
        }
        //add a new dvd test
        [Test]
        [TestCase("Airplane", 1980, "David Zucker, Jim Abrahams, Jerry Zucker", "PG", "", 4)]
        [TestCase("Ferris Bueller's Day Off", 1986, "John Hughes", "PG", "Test", 4)]
        [TestCase("Ryans New DVD", 1981, "Ryan R", "R", "TestDVD", 4)]
        [TestCase("Marks new DVD", 1990, "Mark B", "G", "TestDVDMark", 4)]
        public void addDVD(string title, int releaseYear, string director, string rating, string notes, int index)
        {
            DVD d = new DVD();
            d.title = title;
            d.realeaseYear = releaseYear;
            d.director = director;
            d.rating = rating;
            d.notes = notes;
            repository.Add(d);
            List<DVD> dvds = repository.GetAll();
            Assert.AreEqual(dvds[index].title, d.title);
        }
        [Test]
        [TestCase(1, "Airplane", 1980, "David Zucker, Jim Abrahams, Jerry Zucker", "PG", "", 4)]
        [TestCase(2, "Ferris Bueller's Day Off", 1986, "John Hughes", "PG", "Test", 4)]
        [TestCase(3, "Ryans New DVD", 1981, "Ryan R", "R", "TestDVD", 4)]
        [TestCase(4, "Marks new DVD", 1990, "Mark B", "G", "TestDVDMark", 4)]
        public void UpdateDVDTest(int ID, string title, int releaseYear, string director, string rating, string notes, int index)
        {
            DVD d = new DVD();
            d.dvdId = ID;
            d.title = title;
            d.realeaseYear = releaseYear;
            d.director = director;
            d.rating = rating;
            d.notes = notes;
            repository.Update(d);
            //get current id 
            DVD dvds = repository.GetById(ID);
            Assert.AreEqual(dvds.title, d.title);
        }
    }
}