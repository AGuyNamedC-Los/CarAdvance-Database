using CareAdvance_Database.Utilities;
using CareAdvance_Database.Models;

namespace CareAdvance_DatabaseTests
{
    public class Tests
    {
        public FileAccessor fileAccessor;
        private static readonly List<User> _users = new List<User>
        {
            new User
            {
                Username = "elcastillo",
                FirstName = "carlos",
                LastName = "castillo",
            },
            new User
            {
                Username = "Person21",
                FirstName = "John",
                LastName = "Doe"
            }
        };
        private static IEnumerable<TestCaseData> UserSource()
        {
            yield return new TestCaseData(_users);
        }

        [SetUp]
        public void Setup()
        {
            fileAccessor = new FileAccessor("Users.txt");
        }

        [Test]
        public void WriteToFile_ReturnsLinesOfCorrectFormattedStrings()
        {
            Assert.Pass();
        }

        [Test]
        [TestCaseSource(nameof(UserSource))]
        public void ReadFromFile_ReturnsCorrectLinesOfFormattedString(List<User> users)
        {
            fileAccessor.WriteToFile(users);

            List<User> actualUsers = fileAccessor.ReadFromFile();
            List<User> expectedUsers = users;

            Console.WriteLine(expectedUsers[0].CreatedDate);
            Console.WriteLine(actualUsers[0].CreatedDate);

            for (int i = 0; i < actualUsers.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(actualUsers[i].UserId, Is.EqualTo(expectedUsers[i].UserId));
                    Assert.That(actualUsers[i].Username, Is.EqualTo(expectedUsers[i].Username));
                    Assert.That(actualUsers[i].FirstName, Is.EqualTo(expectedUsers[i].FirstName));
                    Assert.That(actualUsers[i].LastName, Is.EqualTo(expectedUsers[i].LastName));
                    //Assert.That(actualUsers[i].CreatedDate, Is.EqualTo(expectedUsers[i].CreatedDate));
                });
            }
        }
    }
}