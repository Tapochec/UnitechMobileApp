using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitechMobileApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.mvvm.Academ
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectView : ContentView
    {
        Subject subject;

        public Subject Subject
        {
            get { return subject; }
            set
            {
                subject = value;
                string id = Workspace.ActiveUser.id.ToString();
                LessDays.ItemsSource = subject.SubjectToLessons(id);
                Fio.Text = subject.GetPeople(id).fio;
                SubjectResults results = subject.Results(id);
                Resulst.Text = $"Сум:{results.sum}	Пос:{results.pos}	Ауд:{results.aud}	Атт:{results.att}	Итог:{results.itg}";
            }
        }
        public static readonly BindableProperty SubjectProperty = BindableProperty.Create(
                                                         propertyName: "Subject",
                                                         returnType: typeof(Subject),
                                                         declaringType: typeof(SubjectView),
                                                         defaultValue: null,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: SubjectPropertyChenged);

        private static void SubjectPropertyChenged(BindableObject bindable, object oldValue, object newValue) {
            var control = (SubjectView)bindable;
            if(newValue != null)
                control.Subject = (Subject)newValue;
        }

        public SubjectView()
        {
            InitializeComponent();
        }
    }
}