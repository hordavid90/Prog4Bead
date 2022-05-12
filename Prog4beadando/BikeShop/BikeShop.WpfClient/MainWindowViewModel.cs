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
    public class MainWindowViewModel : ObservableRecipient
    {

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Bike> Bikes { get; set; }

        public ICommand AddBikeCommand { get; set; }
        public ICommand DeleteBikeCommand { get; set; }
        public ICommand ModifyBikeCommand { get; set; }

        private Bike selectedBike;

        public Bike SelectedBike
        {
            get { return selectedBike; }
            set 
            {
                if (value != null)
                {
                    selectedBike = new Bike()
                    {
                        BasePrice = value.BasePrice,
                        BrandId = value.BrandId,
                        Id = value.Id,
                        Model = value.Model,
                        OwnerId = value.OwnerId,
                        //Brand = value.Brand,
                        //Owner = value.Owner
                    };
                    OnPropertyChanged();
                    (DeleteBikeCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public MainWindowViewModel()
        {
            Bikes = new RestCollection<Bike>("http://localhost:34200/", "Bike");

            AddBikeCommand = new RelayCommand(() =>
            {
                Bike newBike = new Bike()
                {
                    BasePrice = SelectedBike.BasePrice,
                    Model = SelectedBike.Model,
                    OwnerId = SelectedBike.OwnerId,
                    BrandId = SelectedBike.BrandId,
                };

                Bikes.Add(newBike);
            });

            DeleteBikeCommand = new RelayCommand(() =>
            {
                Bikes.Delete(SelectedBike.Id);
            },
            () =>
            {
                return SelectedBike != null;
            }
            );

            ModifyBikeCommand = new RelayCommand(() =>
            {
                Bikes.Update(SelectedBike);
            });

            SelectedBike = new Bike();
        }
    }
}
