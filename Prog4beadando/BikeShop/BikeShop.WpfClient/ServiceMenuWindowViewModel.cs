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
    public class ServiceMenuWindowViewModel : ObservableRecipient
    {

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Service> Services { get; set; }

        public ICommand AddServiceCommand { get; set; }
        public ICommand DeleteServiceCommand { get; set; }
        public ICommand ModifyServiceCommand { get; set; }


        private Service selectedService;

        public Service SelectedService
        {
            get { return selectedService; }
            set
            {
                if (value != null)
                {
                    selectedService = new Service()
                    {
                        Id = value.Id,
                        EmployeeNumer = value.EmployeeNumer,
                        MaxSpace = value.MaxSpace,
                        Name = value.Name                        
                    };
                    OnPropertyChanged();
                    (DeleteServiceCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ServiceMenuWindowViewModel()
        {
            Services = new RestCollection<Service>("http://localhost:34200/", "Service");

            AddServiceCommand = new RelayCommand(() =>
            {
                Service newService = new Service()
                {
                    EmployeeNumer = SelectedService.EmployeeNumer,
                    MaxSpace = SelectedService.MaxSpace,
                    Name = SelectedService.Name
                };

                Services.Add(newService);
            });

            DeleteServiceCommand = new RelayCommand(() =>
            {
                Services.Delete(SelectedService.Id);
            },
            () =>
            {
                return SelectedService != null;
            }
            );

            ModifyServiceCommand = new RelayCommand(() =>
            {
                if (SelectedService is Service)
                {
                    Services.Update(SelectedService);
                }
            });

            SelectedService = new Service();
        }
    }
}
