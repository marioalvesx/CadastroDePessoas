using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleRegister.Models
{
    public interface IPeopleRepository
    {
        void Add(People people);
        void Edit(People people);
        void Delete(int id);
        IEnumerable<People> GetAll();
        IEnumerable<People> GetByValue(string value);
    }
}
