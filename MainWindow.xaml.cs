using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Product
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _products = new ObservableCollection<Product>()
            {
                 new Product { Image = "Фото", Name = "Товар 1", Description = "Описание 1", Manufacturer = "Производитель 1", Price = 100, StockQuantity = "В наличии"},
                new Product { Image = "Фото", Name = "Товар 2", Description = "Описание 2", Manufacturer = "Производитель 2", Price = 234, StockQuantity = "В наличии"},
                new Product { Image = "Фото", Name = "Товар 3", Description = "Описание 3", Manufacturer = "Производитель 1", Price = 256, StockQuantity = "В наличии"},
                new Product { Image = "Фото", Name = "Товар 4", Description = "Описание 4", Manufacturer = "Производитель 3", Price = 567, StockQuantity = "В наличии"},
                new Product { Image = "Фото", Name = "Товар 5", Description = "Описание 5", Manufacturer = "Производитель 2", Price = 867, StockQuantity = "В наличии"},
                new Product { Image = "Фото", Name = "Товар 6", Description = "Описание 6", Manufacturer = "Производитель 1", Price = 978, StockQuantity = "В наличии"},
                new Product { Image = "Фото", Name = "Товар 7", Description = "Описание 7", Manufacturer = "Производитель 3", Price = 123, StockQuantity = "В наличии"}
            };
            Products = new ObservableCollection<Product>(_products);
            LoadManufacturers();
        }
        private void LoadManufacturers()
        {
            var manufacturers = _products.Select(n => n.Manufacturer).Distinct().ToList();

            manufacturers.Insert(0, "Все производители");

            FilterComboBox.ItemsSource = manufacturers;
            FilterComboBox.SelectedIndex = -1;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }


        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var filt_P = _products.AsQueryable();

            if (!string.IsNullOrEmpty(SearchBox.Text))
            {
                var searchText = SearchBox.Text.ToLower();
                filt_P = filt_P.Where(n => n.Name.ToLower().Contains(searchText) || n.Description.ToLower().Contains(searchText));
            }


            if (FilterComboBox.SelectedItem != null)
            {
                var selectedManufacturer = FilterComboBox.SelectedItem.ToString();
                if (selectedManufacturer != "Все производители")
                {
                    filt_P = filt_P.Where(n => n.Manufacturer == selectedManufacturer);
                }
            }

            if (SortComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var selectedSortOption = selectedItem.Content.ToString();

                if (selectedSortOption == "По возрастанию цены")
                {
                    filt_P = filt_P.OrderBy(n => n.Price);
                }
                else if (selectedSortOption == "По убыванию цены")
                {
                    filt_P = filt_P.OrderByDescending(n => n.Price);
                }
            }

            Products.Clear();
            foreach (var product in filt_P)
            {
                Products.Add(product);
            }
        }
    }
}
