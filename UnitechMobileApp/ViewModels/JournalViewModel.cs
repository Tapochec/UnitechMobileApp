using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.Models;
using UnitechMobileApp.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace UnitechMobileApp.ViewModels
{
    class JournalViewModel : INotifyPropertyChanged
    {
        public List<Academic> Academics { get; private set; }

        private JournalPage journalPage;

        public event PropertyChangedEventHandler PropertyChanged;

        


        public JournalViewModel(JournalPage page) {
            journalPage = page;
            Academics = new List<Academic>() { new Academic() { name = "Математика" }, new Academic() { name = "Биология" }, 
                new Academic() { name = "Химия" }, new Academic() { name = "Физика" }, new Academic() { name = "Физ-ра" },
                new Academic() { name = "Химия" }, new Academic() { name = "Физика" }, new Academic() { name = "Физ-ра" },
                new Academic() { name = "Химия" }, new Academic() { name = "Физика" }, new Academic() { name = "Физ-ра" },
                new Academic() { name = "Химия" }, new Academic() { name = "Физика" }, new Academic() { name = "Физ-ра" },
                new Academic() { name = "Химия" }, new Academic() { name = "Физика" }, new Academic() { name = "Физ-ра" },
                new Academic() { name = "Химия" }, new Academic() { name = "Физика" }, new Academic() { name = "Физ-ра" },
                new Academic() { name = "Химия" }, new Academic() { name = "Физика" }, new Academic() { name = "Физ-ра" }};
            //PropertyChanged(this, new PropertyChangedEventArgs("Academics"));
        }
    }
}
