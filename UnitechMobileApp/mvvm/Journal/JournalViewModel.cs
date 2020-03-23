using System.ComponentModel;
using System.Collections.Generic;
using UnitechMobileApp.Models;
using UnitechMobileApp.Views;
using UnitechMobileApp.Model;
using UnitechMobileApp.mvvm.Academ;

namespace UnitechMobileApp.ViewModels
{
    class JournalViewModel : INotifyPropertyChanged
    {
        public List<IAcademic> Academics { get; private set; }

        private JournalPage journalPage;

        public event PropertyChangedEventHandler PropertyChanged;


        private IAcademic item;
        public IAcademic SelectedItem { get {
                return item;
            }
            set {
                item = value;
                journalPage.Navigation.PushModalAsync(new AcademPage(item));                
            }
        }

        public void Update() {
            Academics = Workspace.ActiveUser.JsonToListAcademics(Client.StudentPlan());

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Academics"));
        }


        public JournalViewModel(JournalPage page) {
            journalPage = page;
            Update();
        }
    }
}
