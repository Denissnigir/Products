using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prototype1.model;

namespace Prototype1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<MaterialType> materialTypeList = new List<MaterialType>();

        List<Material> materialList = new List<Material>();

        List<String> sortList = new List<String>()
        {
            "Наименование (по возрастранию)",
            "Наименование (по убыванию)",
            "Цена (по возрастанию)",
            "Цена (по убыванию)",
            "Остаток на складе (по возрастанию)",
            "Остаток на складе (по убыванию)"
        };

        List<String> pageList = new List<String>();

        int materialsPerPage = 15;
        int materialsCount;
        int totalPages;

        public MainWindow()
        {
            InitializeComponent();
            
            SearchBox.Text = "Введите название материала";

            // Типы материалов
            materialTypeList = connect.context.MaterialType.ToList();
            materialTypeList.Insert(0, new MaterialType{MaterialTypeName  = "Все типы"});
            
            // Выбор типа материала
            TypeBox.ItemsSource = materialTypeList;
            TypeBox.SelectedIndex = 0;

            // Выбор параметра сортировки
            SortBox.ItemsSource = sortList;
            SortBox.SelectedIndex = 0;

            // Список страниц
            PageBox.SelectedIndex = 0;

            Filter();
            Listing();
        }

        private void Filter()
        {
            // Фильтрация
            materialList = connect.context.Material.ToList();
            if(TypeBox.SelectedIndex != 0)
            {
                materialList = materialList.Where(p => p.MaterialType1.Id == TypeBox.SelectedIndex).ToList();
            }
            Materials.ItemsSource = materialList;

            // Поиск
            if(SearchBox.Text != String.Empty)
            {
                if(SearchBox.Text != "Введите название материала")
                {
                    materialList = materialList.Where(p => p.MaterialName.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
                }
            }
            Materials.ItemsSource = materialList;

            // Соритровка
            switch (SortBox.SelectedIndex)
            {
                case 0:
                    Materials.ItemsSource = materialList.OrderBy(p => p.MaterialName).ToList();
                    break;
                case 1:
                    Materials.ItemsSource = materialList.OrderByDescending(p => p.MaterialName).ToList();
                    break;
                case 2:
                    Materials.ItemsSource = materialList.OrderBy(p => p.MaterialPRice).ToList();
                    break;
                case 3:
                    Materials.ItemsSource = materialList.OrderByDescending(p => p.MaterialPRice).ToList();
                    break;
                case 4:
                    Materials.ItemsSource = materialList.OrderBy(p => p.MaterialStorageAmount).ToList();
                    break;
                case 5:
                    Materials.ItemsSource = materialList.OrderByDescending(p => p.MaterialStorageAmount).ToList();
                    break;
                default:
                    Materials.ItemsSource = materialList.OrderBy(p => p.MaterialName).ToList();
                    break;
            }

        }

        private void TypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
            Listing();
        }

        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
            Listing();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
            Listing();
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(SearchBox.Text == String.Empty)
            {
                SearchBox.Text = "Введите название материала";
            }
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(SearchBox.Text == "Введите название материала")
            {
                SearchBox.Text = String.Empty;
            }
        }

        private void Listing()
        {
            pageList.Clear();

            materialsCount = materialList.Count();

            totalPages = materialsCount / materialsPerPage;

            for (int i = 1; i <= totalPages + 1; i++)
            {
                pageList.Add(Convert.ToString(i));
            }
            PageBox.ItemsSource = pageList;

            Materials.ItemsSource = materialList.Skip(PageBox.SelectedIndex * materialsPerPage).Take(materialsPerPage);

            MaterialsCount.Text = Convert.ToString(Materials.Items.Count) + " материалов из " + materialList.Count();
        }

        private void PageBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
            Listing();
        }
    }
}
