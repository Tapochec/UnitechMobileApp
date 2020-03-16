using System.ComponentModel;
using System.Collections.Generic;
using UnitechMobileApp.Models;
using UnitechMobileApp.Views;
using UnitechMobileApp.Model;

namespace UnitechMobileApp.ViewModels
{
    class JournalViewModel : INotifyPropertyChanged
    {
        public List<Academic> Academics { get; private set; }

        private JournalPage journalPage;

        public event PropertyChangedEventHandler PropertyChanged;

        public void Update() {
            Academics = Academic.JsonToListAcademics(Client.StudentPlan());

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Academics"));
        }


        public JournalViewModel(JournalPage page) {
            journalPage = page;
            Update();
        }
    }
}
