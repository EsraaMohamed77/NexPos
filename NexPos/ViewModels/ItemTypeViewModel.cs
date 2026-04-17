using NexPos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NexPos.ViewModels
{
    public class ItemTypeViewModel : INotifyPropertyChanged
    {
        private readonly ItemTypeRepository _repository = new ItemTypeRepository();

        public ObservableCollection<ItemType> ItemTypes { get; set; } = new ObservableCollection<ItemType>();

        private ItemType _selectedItemType;
        public ItemType SelectedItemType
        {
            get => _selectedItemType;
            set { _selectedItemType = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RefreshCommand { get; }

        public ItemTypeViewModel()
        {
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
            RefreshCommand = new RelayCommand(LoadData);

            LoadData();
        }

        private void LoadData()
        {
            ItemTypes.Clear();
            var list = _repository.GetAll();
            foreach (var item in list)
                ItemTypes.Add(item);
        }

        private void Add()
        {
            // هتفتح ويندو إضافة جديدة
            var newType = new ItemType();
            if (new ItemTypeWindow(newType).ShowDialog() == true)
            {
                _repository.Add(newType);
                LoadData();
            }
        }

        private void Edit()
        {
            if (SelectedItemType == null) return;

            var copy = new ItemType
            {
                Id = SelectedItemType.Id,
                Name = SelectedItemType.Name,
                BgColor = SelectedItemType.BgColor,
                BgImage = SelectedItemType.BgImage,
                UseBgImage = SelectedItemType.UseBgImage
            };

            if (new ItemTypeWindow(copy).ShowDialog() == true)
            {
                _repository.Update(copy);
                LoadData();
            }
        }

        private void Delete()
        {
            if (SelectedItemType == null) return;

            if (MessageBox.Show("هتحذف النوع ده؟", "تأكيد الحذف", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _repository.Delete(SelectedItemType.Id);
                LoadData();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
