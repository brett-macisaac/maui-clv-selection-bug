using colview_bug_tester.Classes;
using System.Diagnostics;
using System.Windows.Input;

namespace colview_bug_tester
{
    public partial class MainPage : ContentPage
    {
        // The list that populates the collection view.
        private StringXaml[] fStringList;
        public StringXaml[] StringList
        {
            get { return fStringList; }
            set { fStringList = value; OnPropertyChanged(nameof(StringList)); }
        }

        // The selected item.
        private StringXaml fSelectedString;
        public StringXaml SelectedString
        {
            get { return fSelectedString; }
            set { fSelectedString = value; OnPropertyChanged(nameof(SelectedString)); }
        }

        public MainPage()
        {
            StringList = new StringXaml[2]
            {
                new StringXaml("Hello"),
                new StringXaml("World")
            };

            // The initial selection (note that this isn't reflected in the CollectionView's UI).
            SelectedString = StringList[0];

            InitializeComponent();

            BindingContext = this;
        }

        // The command that's called when the selection changes.
        public ICommand CommandStringSelection => new Command(
            async () =>
            {
                //if (SelectedString != null)
                    //await App.Current.MainPage.DisplayAlert("You Selected...", SelectedString.ToString(), "OK");
            }
        );

        // The container's command.
        public ICommand CommandCon => new Command(
            async () =>
            {
                Debug.WriteLine("Hello World");
            }
        );

        // The button's command.
        public ICommand CommandBtnHelloWorld => new Command(
            async () =>
            {
                await App.Current.MainPage.DisplayAlert("Hello", "World", "OK");
            }
        );
    }

}
