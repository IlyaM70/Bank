using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<string> charCodes;
        string selectedItem1;
        string selectedItem2;
        string valuteName1;
        string valuteName2;
        double valute1;
        double valute2;

        ParseSite parseSite;
        void Change([CallerMemberName] string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<string> CharCodes
        {
            get { return charCodes; }
            set
            {
                charCodes = value;
                Change("CharCodes");
            }
        }
        public string SelectedItem1
        {
            get { return selectedItem1; }
            set
            {
                selectedItem1 = value;
                Change();
                ValuteName1 = parseSite.Valute[selectedItem1].Name;
                Valute1 = valute1;
            }
        }
        public string SelectedItem2
        {
            get { return selectedItem2; }
            set
            {
                selectedItem2 = value;
                Change();
                ValuteName2 = parseSite.Valute[selectedItem2].Name;
                Valute2 = valute2;
            }
        }
        public string ValuteName1
        {
            get { return valuteName1; }
            set
            {
                valuteName1 = value;
                Change();

            }
        }
        public string ValuteName2
        {
            get { return valuteName2; }
            set
            {
                valuteName2 = value;
                Change();

            }
        }

        public double Valute1
        {
            get { return valute1; }
            set {
                valute1 = value;
                Change("Valute1");
                valute2 = Converter.Convert
                    (parseSite.Valute[SelectedItem1],
                    parseSite.Valute[SelectedItem2])*valute1;
                Change("Valute2");
            }
        }
        public double Valute2
        {
            get { return valute2; }
            set
            {
                valute2 = value;
                Change("Valute2");
                valute1 = Converter.Convert
                    (parseSite.Valute[SelectedItem2],
                    parseSite.Valute[SelectedItem1])*valute2;
                Change("Valute1");
            }
        }
        public ViewModel()
        {
            CharCodes = new ObservableCollection<string>();
            parseSite = new ParseSite();
            foreach (KeyValuePair<string,Coin> key in parseSite.Valute)
            {
                CharCodes.Add(key.Key);
            }
            selectedItem2 = "RUB";
            SelectedItem1 = "RUB";
            SelectedItem2 = "RUB";
        }
    }
}
