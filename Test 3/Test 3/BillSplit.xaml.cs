using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Test_3
{
    public partial class BillSplit : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<int> PeopleList { get; set; }

        private float bill;
        private int selectedPeople;
        private float tip;
        private float tipPercentage;
        private bool updatingTip;

        public string TipPercentageString { get; set; }
        public string IndividualAmount { get; set; }

        public int People
        {
            get => selectedPeople;
            set
            {
                if (selectedPeople != value)
                {
                    selectedPeople = value;
                    OnPropertyChanged();
                    CalculateIndividualBill();
                }
            }
        }

        public float TipPercentage
        {
            get => tipPercentage;
            set
            {
                if (Math.Abs(tipPercentage - value) > 0.001f)
                {
                    tipPercentage = value;
                    float roundTipPercentage = (float)Math.Round(TipPercentage, 2);
                    OnPropertyChanged();
                    if (!updatingTip)
                        UpdateTipFromPercentage();
                    TipPercentageString = $"Tip percentage: {roundTipPercentage}";
                    OnPropertyChanged(nameof(TipPercentageString));
                    CalculateIndividualBill();
                }
            }
        }

        public float Tip
        {
            get => tip;
            set
            {
                float rounded = (float)Math.Round(value, 2);
                if (Math.Abs(tip - rounded) > 0.001f)
                {
                    tip = rounded;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TipString));
                    if (!updatingTip)
                        UpdatePercentageFromTip();
                }
            }
        }

        public string TipString
        {
            get => Tip.ToString("F2");
            set
            {
                if (float.TryParse(value, out float parsed))
                {
                    Tip = parsed;
                    CalculateIndividualBill();
                }
                else
                {
                    Tip = 0;
                }
            }
        }

        public BillSplit(float bill)
        {
            InitializeComponent();
            this.bill = bill;
            billAmount.Text = bill.ToString("C");
            PeopleList = Enumerable.Range(1, 10).ToList();
            People = 1;
            updatingTip = false;

            TipPercentage = 10;
            Tip = (bill * TipPercentage) / 100;

            BindingContext = this;
        }

        private void UpdateTipFromPercentage()
        {
            updatingTip = true;
            Tip = (bill * TipPercentage) / 100;
            updatingTip = false;
        }

        private void UpdatePercentageFromTip()
        {
            updatingTip = true;
            TipPercentage = (Tip / bill) * 100;
            updatingTip = false;
        }

        private void CalculateIndividualBill()
        {
            if(People < 1)
            {
                return;
            }
            IndividualAmount = "Amount to be paid by each person is: "+((Tip + bill) / People).ToString("C");
            OnPropertyChanged(nameof(IndividualAmount));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
