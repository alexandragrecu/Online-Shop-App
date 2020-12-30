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

        // User table
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


        // Product table
        public static Product GetProduct(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                return conn.Table<Product>().Where(p => p.Id.Equals(id)).FirstOrDefault();
            }
        }

        public static List<Product> GetProducts()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                return conn.Table<Product>().ToList();
            }
        }

        public static bool AddProduct(Product product)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    int row = conn.Insert(product);
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

        public static bool UpdateProduct(Product product)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    int row = conn.Update(product);
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

        public static bool DeleteProduct(int Id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    Console.WriteLine(Id);
                    var product = conn.Find<Product>(p => p.Id == Id);

                    if (product == null)
                    {
                        return false;
                    }

                    int row = conn.Delete(product);

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


        // Order table
        public static Order GetOrder(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                return conn.Table<Order>().Where(o => o.Id.Equals(id)).FirstOrDefault();
            }
        }

        public static List<Order> GetOrders()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                return conn.Table<Order>().ToList();
            }
        }

        public static bool AddOrder(Order order)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    int row = conn.Insert(order);
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

        public static bool UpdateOrder(Order order)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    int row = conn.Update(order);
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

        public static bool DeleteOrder(int Id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    Console.WriteLine(Id);
                    var order = conn.Find<Order>(o => o.Id == Id);

                    if (order == null)
                    {
                        return false;
                    }

                    int row = conn.Delete(order);

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

    }

}
