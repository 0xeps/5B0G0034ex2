using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfDrinkOrder
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            sliderMilkTea.ValueChanged += Slider_ValueChanged;
            sliderGreenTea.ValueChanged += Slider_ValueChanged;
            sliderLemonJuice.ValueChanged += Slider_ValueChanged;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelMilkTeaQty.Content = $"{(int)sliderMilkTea.Value}杯";
            labelGreenTeaQty.Content = $"{(int)sliderGreenTea.Value}杯";
            labelLemonJuiceQty.Content = $"{(int)sliderLemonJuice.Value}杯";
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int total = 0;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("【訂單明細】");

            if (rbDineIn.IsChecked == true)
                sb.AppendLine("用餐方式：內用");
            else if (rbTakeOut.IsChecked == true)
                sb.AppendLine("用餐方式：外帶");
            else
                sb.AppendLine("用餐方式：未選擇");

            if (cbMilkTea.IsChecked == true)
            {
                int qty = (int)sliderMilkTea.Value;
                int price = 50 * qty;
                total += price;
                sb.AppendLine($"珍珠奶茶 x{qty} 杯：${price}");
            }

            if (cbGreenTea.IsChecked == true)
            {
                int qty = (int)sliderGreenTea.Value;
                int price = 40 * qty;
                total += price;
                sb.AppendLine($"綠茶 x{qty} 杯：${price}");
            }

            if (cbLemonJuice.IsChecked == true)
            {
                int qty = (int)sliderLemonJuice.Value;
                int price = 60 * qty;
                total += price;
                sb.AppendLine($"檸檬汁 x{qty} 杯：${price}");
            }

            sb.AppendLine($"原始總金額：${total}");

            double discountRate = 1.0;
            if (total >= 500)
                discountRate = 0.8;
            else if (total >= 300)
                discountRate = 0.85;
            else if (total >= 200)
                discountRate = 0.9;

            int finalPrice = (int)(total * discountRate);
            int discount = total - finalPrice;

            sb.AppendLine($"折扣後金額：${finalPrice}");
            sb.AppendLine($"您共節省：${discount}");

            txtResult.Text = sb.ToString();
        }
    }
}
