using ICT13580059EndB.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT13580059EndB
{
   
    public partial class ProductNewPage : ContentPage
    {
        private Product product;

        public ProductNewPage(Product product=null)
        {
            InitializeComponent();
            this.product = product;
            titleLabel.Text = product == null ? "เพิ่มรายการ" : "แก้ไขสินค้า";


            categoryCarPicker.Items.Add("รถเก๋ง");
            categoryCarPicker.Items.Add("รถกะบะ");
            categoryCarPicker.Items.Add("รถตู้");

            carNamePicker.Items.Add("นิสสัน");
            carNamePicker.Items.Add("อีซูซุ");
            carNamePicker.Items.Add("บีเอ็มดับเบิลยู");

            carColorPicker.Items.Add("แดง");
            carColorPicker.Items.Add("ขาว");
            carColorPicker.Items.Add("ดำ");
            carColorPicker.Items.Add("เงิน");

            provincePicker.Items.Add("กรุงเทพ");
            provincePicker.Items.Add("ปทุมธานี");
            provincePicker.Items.Add("พระนครศรีอยุธยา");
            provincePicker.Items.Add("เพรชบุรี");

            
            submitButton.Clicked += SubmitButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;


            if (product != null)
            {

                categoryCarPicker.SelectedItem = product.Category;
                carNamePicker.SelectedItem = product.Brand;
                productGenEntry.Text = product.Gen;
                yearCarEntry.Text = product.Years.ToString();
                mileCarEntry.Text = product.Miles.ToString();
                carColorPicker.SelectedItem = product.Color;
                productCardelerEntry.Text = product.Deler;
                productDetailEntry.Text = product.Description;
                productPriceEntry.Text = product.Price.ToString();
                provincePicker.SelectedItem = product.Province;
                phoneEntry.Text = product.Tel.ToString();
            }

        }

       

        async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");

            if (isOk)
            {
                if(product == null)
                { 
                product = new Product();
                product.Category = categoryCarPicker.SelectedItem.ToString();
                product.Brand = carNamePicker.SelectedItem.ToString();
                product.Gen = productGenEntry.Text;
                product.Years = decimal.Parse(yearCarEntry.Text);
                product.Miles = decimal.Parse(mileCarEntry.Text);
                product.Color = carColorPicker.SelectedItem.ToString();

                product.Deler = productCardelerEntry.Text;
                product.Description = productDetailEntry.Text;
                product.Price = decimal.Parse(productPriceEntry.Text);
                product.Province = provincePicker.SelectedItem.ToString();
                product.Tel = decimal.Parse(phoneEntry.Text);

                var id = App.DbHelper.AddProduct(product);
                await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
                }
                else
                {
                    product = new Product();
                    product.Category = categoryCarPicker.SelectedItem.ToString();
                    product.Brand = carNamePicker.SelectedItem.ToString();
                    product.Gen = productGenEntry.Text;
                    product.Years = decimal.Parse(yearCarEntry.Text);
                    product.Miles = decimal.Parse(mileCarEntry.Text);
                    product.Color = carColorPicker.SelectedItem.ToString();

                    product.Deler = productCardelerEntry.Text;
                    product.Description = productDetailEntry.Text;
                    product.Price = decimal.Parse(productPriceEntry.Text);
                    product.Province = provincePicker.SelectedItem.ToString();
                    product.Tel = decimal.Parse(phoneEntry.Text);

                    var id = App.DbHelper.AddProduct(product);
                    await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสำเร็จ #"+ id, "ตกลง");

                }


                await Navigation.PopModalAsync();
            }
        }


        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}