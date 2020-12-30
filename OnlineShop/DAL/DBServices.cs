using OnlineShop.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.DAL
{
    public class DBServices
    {
        private static string connString = Path.Combine(Directory.GetCurrentDirectory(), "onlineShopDB.sqlite");
        public static User GetUser(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                return conn.Table<User>().Where(u => u.Id.Equals(id)).FirstOrDefault();
            }
        }

        public static List<User> GetUsers()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                return conn.Table<User>().ToList();
            }
        }

        public static bool AddUser(User user)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    int row = conn.Insert(user);
                    if (row > 0)
                        return true;
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool UpdateUser(User user)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    int row = conn.Update(user);
                    if (row > 0)
                        return true;
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool DeleteUser (int Id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    Console.WriteLine(Id);
                    var user = conn.Find<User>(u => u.Id == Id);
                    
                    if (user == null)
                    {
                        return false;
                    }

                    int row = conn.Delete(user);
                    
                    if (row > 0)
                        return true;
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                { return false;
                }
            }
        }
      
        // Order table

        // Item table
    }

}
