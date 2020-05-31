using System.ComponentModel;
using System.Collections.Generic;
using UnitechMobileApp.Models;
using UnitechMobileApp.Views;
using UnitechMobileApp.Model;
using UnitechMobileApp.mvvm.Academ;
using UnitechMobileApp.mvvm.General;

namespace UnitechMobileApp.ViewModels
{
    class JournalViewModel : ViewModelBase
    {
        public List<IAcademic> Academics { get; private set; }

        private JournalPage journalPage;


        private IAcademic item;
        public IAcademic SelectedItem
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
                if (value != null)
                {
                    journalPage.Navigation.PushModalAsync(new AcademPage(item));
                    journalPage.Unselect();
                }
            }
        }

        public void Update()
        {
            Academics = Workspace.ActiveUser.JsonToListAcademics(Client.StudentPlan());
            SelectedItem = null;
            OnPropertyChanged("Academics");
        }


        public JournalViewModel(JournalPage page)
        {
            journalPage = page;
            Update();
        }
    }
}
