using System;
using DataAccessLayer.Options;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ServiceLayer
    {
        DataAccessLayer.DataAccessLayer DAL;
        public ServiceLayer(ConnectionOptions options)
        {
            DAL = new DataAccessLayer.DataAccessLayer(options);
        }

        public List<Human> GetHumen()
        {
            List<Person> list = DAL.GetAllInstances<Person>();
            List<Human> humen = new List<Human>();
            foreach(Person person in list)
            {
                humen.Add(new Human()
                {
                    Person = person,
                    Email = DAL.GetInstance<Email>(person.BusinessEntityID),
                    Password = DAL.GetInstance<Password>(person.BusinessEntityID),
                    PersonPhone = DAL.GetInstance<PersonPhone>(person.BusinessEntityID),
                    Address = DAL.GetInstance<Address>(person.BusinessEntityID)
                });
                Console.WriteLine(humen.Count);
            }
            return humen;
        }
    }
}
