using PeopleRegister.Models;
using PeopleRegister.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleRegister.Presenters
{
    public class PeoplePresenter
    {
        private IPeopleView view;
        private IPeopleRepository repository;
        private BindingSource peopleBindingSource;
        private IEnumerable<People> peopleList;
        private DataTable peopleListReport;

        public PeoplePresenter(IPeopleView view, IPeopleRepository repository)
        {
            this.peopleBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            this.view.SearchEvent += SearchPeople;
            this.view.AddNewEvent += AddNewPeople;
            this.view.EditEvent += LoadSelectedPeopleToEdit;
            this.view.DeleteEvent += DeleteSelectedPeople;
            this.view.SaveEvent += SavePeople;
            this.view.CancelEvent += CancelAction;            

            this.view.SetPeopleListBindingSource(peopleBindingSource);
            LoadAllPeopleList();
            this.view.Show();
        }

        private void LoadAllPeopleList()
        {
            peopleList = repository.GetAll();
            peopleBindingSource.DataSource = peopleList;
        }

        private void SearchPeople(object? sender, EventArgs e)
        {
            bool emptyValues = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValues == false)
            {
                peopleList = repository.GetByValue(this.view.SearchValue);
            }
            else
            {
                peopleList = repository.GetAll();
            }
            peopleBindingSource.DataSource = peopleList;
        }
        private void AddNewPeople(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadSelectedPeopleToEdit(object? sender, EventArgs e)
        {
            var people = (People)peopleBindingSource.Current;
            view.PeopleId = people.Id.ToString();
            view.PeopleNome = people.Nome;
            view.PeopleTelefone = people.Telefone;
            view.IsEdit = true;
        }

        private void SavePeople(object? sender, EventArgs e)
        {
            var model = new People();
            model.Id = Convert.ToInt32(view.PeopleId);
            model.Nome = view.PeopleNome;
            model.Telefone = view.PeopleTelefone;

            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)
                {
                    repository.Edit(model);
                    view.Message = "Pessoa alterada com sucesso";
                }
                else // Add new people
                {
                    repository.Add(model);
                    view.Message = "Pessoa adicionada com sucesso";
                }

                view.IsSuccessfull = true;
                LoadAllPeopleList();
                CleanViewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessfull = false;
                view.Message = ex.Message;
            }
        }

        private void CleanViewFields()
        {
            view.PeopleNome = string.Empty;
            view.PeopleTelefone = string.Empty;
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void DeleteSelectedPeople(object? sender, EventArgs e)
        {
            try
            {
                var people = (People)peopleBindingSource.Current;
                repository.Delete(people.Id);
                view.IsSuccessfull = true;
                view.Message = "Pessoa deletada com sucesso";
                LoadAllPeopleList();
            }
            catch (Exception ex)
            {
                view.IsSuccessfull = false;
                view.Message = "Um erro foi encontrado, não foi possível deletar essa pessoa.";
                throw;
            }
        }


    }
}
