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
    public class OwnerMenuWindowViewModel : ObservableRecipient
    {
        public RestCollection<Owner> Owners { get; set; }

        public ICommand AddOwnerCommand { get; set; }
        public ICommand DeleteOwnerCommand { get; set; }
        public ICommand ModifyOwnerCommand { get; set; }


        private Owner selectedOwner;

        public Owner SelectedOwner
        {
            get { return selectedOwner; }
            set
            {
                if (value != null)
                {
                    selectedOwner = new Owner()
                    {
                        Id = value.Id,
                        Money = value.Money,
                        Name = value.Name,
                        Bikes = value.Bikes,
                        OwnerFBGroup = value.OwnerFBGroup
                    };
                    OnPropertyChanged();
                    (DeleteOwnerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public OwnerMenuWindowViewModel()
        {
            Owners = new RestCollection<Owner>("http://localhost:34200/", "Owner", "hub");

            AddOwnerCommand = new RelayCommand(() =>
            {
                Owner newOwner = new Owner()
                {
                    Name = SelectedOwner.Name,
                    Money = SelectedOwner.Money
                };

                Owners.Add(newOwner);
            });

            DeleteOwnerCommand = new RelayCommand(() =>
            {
                Owners.Delete(SelectedOwner.Id);
            },
            () =>
            {
                return SelectedOwner != null;
            }
            );

            ModifyOwnerCommand = new RelayCommand(() =>
            {
                if (SelectedOwner is Owner)
                {
                    Owners.Update(SelectedOwner);
                }
            });

            SelectedOwner = new Owner();
        }
    }
}
