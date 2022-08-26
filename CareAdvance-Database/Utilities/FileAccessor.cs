using CareAdvance_Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CareAdvance_Database.Utilities
{
    public class FileAccessor
    {
        public string FilePath { get; set; }

        public FileAccessor(string filePath)
        {
            FilePath = filePath;
        }

        public void WriteToFile(List<User> users)
        {
            File.WriteAllText(FilePath, String.Empty);

            using StreamWriter sw = File.CreateText(FilePath);
            foreach (User u in users)
            {
                sw.WriteLine($"{u.Username} {u.FirstName} {u.LastName} {u.CreatedDate}");
            }
        }

        public List<User> ReadFromFile()
        {
            List<User> users = new List<User>();
            string s;

            using (StreamReader sr = File.OpenText(FilePath))
            {
                while ((s = sr.ReadLine()) != null)
                {
                    string[] sArray = s.Split(" ");
                    users.Add(new User {
                        Username = sArray[0], 
                        FirstName = sArray[1], 
                        LastName = sArray[2], 
                        CreatedDate = DateTime.Parse($"{sArray[3]} {sArray[4]} {sArray[5]}") 
                    });
                }
            }

            return users;
        }

        public void SaveDatabaseToFile(string fileName, List<User> users)
        {
            if (File.Exists(fileName))
            {
                File.WriteAllText(fileName, String.Empty);
            }

            using StreamWriter sw = File.CreateText(fileName);
            foreach (User u in users)
            {
                sw.WriteLine($"{u.Username} {u.FirstName} {u.LastName} {u.CreatedDate}");
            }
        }
    }
}
