using ADONETExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ADONETExample.Repository
{
    public interface IHomeRepository
    {
        void SearchCustomer();
        void SeacrhItem();
        IEnumerable<Customer> Results(string fName);
        string LinkResults();
        IEnumerable<Customer> SendAsJson(string name);
        IEnumerable<Customer> GetTable();
    /*    IEnumerable<Customer> Details(int id);*/
    }

    public class HomeRepository : IHomeRepository
    {
        /*MyMusicDBEntities db = new MyMusicDBEntities();*/

        private MyMusicDBEntities db;
        public MyMusicDBEntities dbEntities {
            get { return db; }
            set { db = value; }
        }
        public HomeRepository(MyMusicDBEntities dbcontext)
        {
            db = dbcontext;
         }
        public void SearchCustomer()
        {
            db.Customers.Select(x => x.Country).Distinct();
        }

        public void SeacrhItem()
        {
            db.Customers.Select(x => x.Country).Distinct();
        }
       
        public IEnumerable<Customer> Results(string fName)
        {
            return  db.Customers.Where(x => x.FirstName.Contains(fName)).ToList();
        }

        public string LinkResults()
        {
            return db.Customers.Select(x => x.Country).Distinct().ToString();
        }

        public IEnumerable<Customer> SendAsJson(string name)
        {
            return db.Customers.Where(x => x.FirstName.Contains(name)).ToList();
        }


        public IEnumerable<Customer> GetTable()
        {
           return db.Customers.ToList();
        }

        /*public IEnumerable<Customer> Details(int id)
        {
           return db.Customers.FirstOrDefault(x => x.CustomerId == id);
        }*/
    }
}