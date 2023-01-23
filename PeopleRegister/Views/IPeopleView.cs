using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleRegister.Views
{
    public interface IPeopleView
    {
        string PeopleId { get; set; }
        string PeopleNome { get; set; }
        string PeopleTelefone { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessfull { get; set; }
        string Message { get; set; }

        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        event EventHandler CallReportEvent;

        void SetPeopleListBindingSource(BindingSource peopleList);
        void Show();


    }
}
