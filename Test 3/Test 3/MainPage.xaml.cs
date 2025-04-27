namespace Test_3
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SubmitBill(object sender, EventArgs e)
        {
            string entered_amount = BillAmount.Text;
            if(float.TryParse(entered_amount, out var price))
            {
                var billPage = new BillSplit(price);
                await Navigation.PushAsync(billPage);
            }
            
        }
    }

}
