using PlacesDB.Models;

namespace PlacesDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DeleteDatabase();
            //BuildDatabase();
            Console.WriteLine(Hasher.HashPassword("password", Hasher.GenerateSalt()));
            //Test();
            Console.WriteLine($"\nApplication finished");
        }

        private static void Test()
        {
            var users = GenerateUsers(2);
            using (var db = new Context())
            {
                try
                {
                    db.Users.Add(users.FirstOrDefault());
                    db.SaveChanges();
                    Console.WriteLine($"Successfully created 50 users");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error inserting to DB - {e.Message}");
                }
            }
        }

        private static ICollection<User> GenerateUsers(int amount)
        {
            var users = new List<User>();
            Random rnd = new Random();
            string[] firstNames = new string[15] { "Adam", "Rickard", "Joseph", "Vladimir", "Mohammed", "Martin", "Dimitri", "Johanna", "Lena", "Felicia", "Ardina", "Maja", "Oscar", "Philip", "Trevor" };
            string[] lastNames = new string[15] { "Laashiri", "Meyer", "Black", "Mcdonald", "Fernandez", "Thompson", "Ramirez", "Ivanov", "Kirby", "Robinson", "Holt", "Schultz", "Griffith", "Garlinghouse", "Kennedy" };

            for (int i = 0; i < amount; i++)
            {
                var fName = firstNames[rnd.Next(0, firstNames.Length)];
                var lName = lastNames[rnd.Next(0, lastNames.Length)];
                var usn = $"{fName}.{lName}{rnd.Next(0, 1000)}";
                var psw = Hasher.HashPassword("password", Hasher.GenerateSalt());

                users.Add(
                    new User()
                    {
                        FirstName = fName,
                        LastName = lName,
                        UserGroup = 0,
                        Username = usn,
                        Password = psw,
                        Created = new DateTime()
                    }
                );
            }
            return users;
        }

        private static void BuildDatabase()
        {
            using (var db = new Context())
            {
                var res = db.Database.EnsureCreated();
                if (res) { Console.WriteLine("Successfully Created Database"); }
                else { Console.WriteLine("Failed to Create Database"); }
            }
        }

        private static void DeleteDatabase()
        {
            using (var db = new Context())
            {
                var res = db.Database.EnsureDeleted();
                if (res) { Console.WriteLine("Successfully Deleted Database"); }
                else { Console.WriteLine("Failed to Delete Database"); }
            }
        }
    }
}