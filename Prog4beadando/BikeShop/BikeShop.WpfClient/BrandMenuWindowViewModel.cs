using BikeShop.Data;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BikeShop.WpfClient
{

    public class BrandMenuWindowViewModel : ObservableRecipient
    {
        public RestCollection<Brand> Brands { get; set; }

        public ICommand AddBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand ModifyBrandCommand { get; set; }


        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Country = value.Country,
                        Established = value.Established,
                        Bikes = value.Bikes
                    };
                    OnPropertyChanged();
                    (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public BrandMenuWindowViewModel()
        {
            Brands = new RestCollection<Brand>("http://localhost:34200/", "Brand");

            AddBrandCommand = new RelayCommand(() =>
            {
                Brand newBrand = new Brand()
                {
                    Id = SelectedBrand.Id,
                    Name = SelectedBrand.Name,
                    Country = SelectedBrand.Country,
                    Established = SelectedBrand.Established,
                    Bikes = SelectedBrand.Bikes
                   
                };

                Brands.Add(newBrand);
            });

            DeleteBrandCommand = new RelayCommand(() =>
            {
                Brands.Delete(SelectedBrand.Id);
            },
            () =>
            {
                return SelectedBrand != null;
            }
            );

            ModifyBrandCommand = new RelayCommand(() =>
            {
                if (SelectedBrand is Brand)
                {
                    Brands.Update(SelectedBrand);
                }
            });

            SelectedBrand = new Brand();
        }
    }
}
