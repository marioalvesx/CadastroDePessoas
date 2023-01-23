using PeopleRegister.Models;
using PeopleRegister.Presenters;
using PeopleRegister.Repositories;
using PeopleRegister.Views;
using System.Configuration;

namespace PeopleRegister
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            IPeopleView view = new PeopleView();
            IPeopleRepository repository = new PeopleRepository(sqlConnectionString);
            new PeoplePresenter(view, repository);
            Application.Run((Form)view);
        }
    }
}