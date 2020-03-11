using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.Models;
using UnitechMobileApp.Views;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using ClientApi;

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
