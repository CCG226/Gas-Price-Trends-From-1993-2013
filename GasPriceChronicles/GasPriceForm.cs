namespace GasPriceChronicles
{
    public partial class Gas_Price_Analyzer : Form
    {
        private GasPriceChronicle gasPriceChronicle;

        public Gas_Price_Analyzer()
        {
            InitializeComponent();
            closeBtn.BackColor = Color.Red;
          
            string pathToStaticImg = AppDomain.CurrentDomain.BaseDirectory + @"\gas_pump.png";
            gasPumpImg.Image = Image.FromFile(pathToStaticImg);

            gasPriceChronicle = new GasPriceChronicle("GasPrices.txt");
        }

        private void APPY_Btn_Click(object sender, EventArgs e)
        {
            List<string> results = new List<string>();
            Dictionary<int, decimal> data = gasPriceChronicle.AveragePricePerYear();

            foreach (var pair in data)
            {
                results.Add($"{pair.Key}: ${pair.Value}");
            }
            outputBox.DataSource = results;
        }

        private void APPM_Click(object sender, EventArgs e)
        {
            List<string> results = new List<string>();
            Dictionary<string, decimal> data = gasPriceChronicle.AveragePricePerMonth();

            foreach (var pair in data)
            {
                results.Add($"{pair.Key}: ${pair.Value}");
            }

            outputBox.DataSource = results;
        }
        private void PLH_Btn_Click(object sender, EventArgs e)
        {
            OrderByPrice(false);
        }

        private void PHL_Btn_Click(object sender, EventArgs e)
        {
            OrderByPrice(true);
        }
        private void OrderByPrice(bool descending)
        {
            List<string> results = new List<string>();

            Dictionary<DateOnly, decimal> data = new Dictionary<DateOnly, decimal>();

            if (descending)
            {
                data = gasPriceChronicle.SortByPriceDescending();
                gasPriceChronicle.StoreModifiedGasPriceChronicleInFile(data, "HighLowGasPrices.txt");
            }
            else
            {
                data = gasPriceChronicle.SortByPriceAscending();
                gasPriceChronicle.StoreModifiedGasPriceChronicleInFile(data, "LowHighGasPrices.txt");
            }
            foreach (var pair in data)
            {
                results.Add($"{pair.Key.ToString("MM-dd-yyyy")}: ${Utils.RoundAtMid(pair.Value)}");
            }

            outputBox.DataSource = results;
        }
        private void HLPPY_Btn_Click(object sender, EventArgs e)
        {
            List<string> results = new List<string>();

            Dictionary<int, (DateOnly date, decimal price)> highestPriceData = gasPriceChronicle.HighestPricePerYear();

            Dictionary<int, (DateOnly date, decimal price)> lowestPriceData = gasPriceChronicle.LowestPricePerYear();


            if (highestPriceData.Keys.SequenceEqual(lowestPriceData.Keys) == false)
            {
                throw new Exception("Error: Failed Operation. Inconsistent data results");
            }

            foreach (int year in highestPriceData.Keys)
            {
                results.Add($"{year} highest: ${highestPriceData[year].price} on {highestPriceData[year].date}");

                results.Add($"{year} lowest: ${lowestPriceData[year].price} on {lowestPriceData[year].date}");
            }

            outputBox.DataSource = results;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void themeBtn_Click(object sender, EventArgs e)
        {
            if (themeBtn.Text == "Light Mode")
            {

                themeBtn.Text = "Dark Mode";
                this.BackColor = Color.Black;
                titleLabel.ForeColor = Color.White;
                displayLabel.ForeColor = Color.White;
                ChangeInputOutputTheme(Color.FromArgb(255, 50, 50, 50), Color.White);
            }
            else
            {
                themeBtn.Text = "Light Mode";
                this.BackColor = Color.White;
                titleLabel.ForeColor = Color.Black;
                displayLabel.ForeColor = Color.Black;

                ChangeInputOutputTheme(Color.White, Color.FromArgb(255, 50, 50, 50));
            }
          
        }
        private void ChangeInputOutputTheme(Color backColor, Color foreColor)
        {

            APPY_Btn.BackColor = backColor;
            APPY_Btn.ForeColor = foreColor;

            APPM_Btn.BackColor = backColor;
            APPM_Btn.ForeColor = foreColor;

            HLPPY_Btn.BackColor = backColor;
            HLPPY_Btn.ForeColor = foreColor;

            PLH_Btn.BackColor = backColor;
            PLH_Btn.ForeColor = foreColor;

            PHL_Btn.BackColor = backColor;
            PHL_Btn.ForeColor = foreColor;

            themeBtn.BackColor = backColor;
            themeBtn.ForeColor = foreColor;

            outputBox.BackColor = backColor;
            outputBox.ForeColor = foreColor;
        }
    }
}
