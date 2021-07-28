using System;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDb;

        [SetUp]
        public void Setup()
        {
            extendedDb = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void Ctor_AddInitialPeopleLessToTheDb()
        {
            var persons = new Person[5];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"Name:{i}");
            }

            extendedDb = new ExtendedDatabase.ExtendedDatabase(persons);
            Assert.That(extendedDb.Count, Is.EqualTo(persons.Length));

            foreach (var person in persons)
            {
                Person dbPerson = extendedDb.FindById(person.Id);
                Assert.That(person, Is.EqualTo(dbPerson));
            }
        }

        [Test]
        public void Ctor_ExceptionWhenCapacityIsExceeded()
        {
            var persons = new Person[17];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"Pesho{i}");
            }

            Assert.Throws<ArgumentException>(() => extendedDb = new ExtendedDatabase.ExtendedDatabase(persons));
        }

        [Test]
        public void Add_ThrowsException_WhenCountIsExceeded()
        {
            var n = 16;
            for (int i = 0; i < n; i++)
            {
                extendedDb.Add(new Person(i, $"Name{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(16, $"Gigo")));
        }

        [Test]
        public void Add_ThrowsException_WhenUsernameExistAlraedy()
        {
            var name = "Pesho";
            extendedDb.Add(new Person(1, name));

            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(16, name)));
        }

        [Test]
        public void Add_ThrowsException_WhenIdAlraedyInUse()
        {
            var id = 1;
            extendedDb.Add((new Person(id, "Gigi")));

            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(id, "name")));
        }

        [Test]
        public void AddIncrementCountWhenAllIsvalid()
        {
            var expectedCount = 2;
            extendedDb.Add(new Person(1, "Gosho"));
            extendedDb.Add(new Person(2, "Pesho"));
            Assert.That(extendedDb.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_Throws_ExceptionDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>((() => extendedDb.Remove()));
        }

        [Test]
        public void Remove_ElementFromDB()
        {
            var n = 3;
            for (int i = 0; i < n; i++)
            {
                extendedDb.Add(new Person(i, $"Freash{i}"));
            }

            extendedDb.Remove();
            Assert.That(extendedDb.Count, Is.EqualTo(n - 1));
            Assert.Throws<InvalidOperationException>((() => extendedDb.FindById(n - 1)));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUserName_ThrowsExceptionUsernameIsInvalid(string username)
        {
            Assert.Throws<ArgumentNullException>((() => extendedDb.FindByUsername(username)));
        }

        [Test]
        public void FindByUsername_ThrowsWxceptionWhenUsernameIsNotExisting()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindByUsername("nonExisted"));
        }

        [Test]
        public void FindByUsername_ReturnsTheCorrectResult()
        {
            var person = new Person(1, "Pesho");
            extendedDb.Add(person);
            var dbPerson = extendedDb.FindByUsername(person.UserName);
            Assert.That(person, Is.EqualTo(dbPerson));
        }

        [Test]
        public void FindById_ThrowsExceptionForInvalidId()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindById(123));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-21)]

        public void FindById_ThrowsException_WhenIdIsNegativeValue(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDb.FindById(id));
        }

        [Test]
        public void FindById_ReturnsTheCorrectResult()
        {
            var person = new Person(1, "Pesho");
            extendedDb.Add(person);
            var dbPerson = extendedDb.FindById(person.Id);
            Assert.That(person, Is.EqualTo(dbPerson));
        }
    }
}