// <copyright file="ServiceLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BikeShop.Data;
    using BikeShop.Repository;

    /// <summary>
    /// This is the service logic.
    /// </summary>
    public class ServiceLogic : IServiceLogic
    {
        private readonly IBikeRepository bikeRepo;
        private readonly IBrandRepository brandRepo;
        private readonly IOwnerRepository ownerRepo;
        private readonly IServiceReporitory serviceRepo;
        private readonly IFacebookGroupRepository facebookGroupRepo;
        private readonly IOwnerFacebookGroupRepository ownerFacebookGroupRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLogic"/> class.
        /// </summary>
        /// <param name="bikeRepo">The IBikeRepository.</param>
        /// <param name="brandRepo">The IBrandRepository.</param>
        /// <param name="ownerRepo">The IOwnerRepository.</param>
        /// <param name="serviceRepo">The IServiceRepository.</param>
        /// <param name="facebookGroupRepo">The IFacebookGroupRepository.</param>
        /// <param name="ofbgRepo">The OwnerFacebookGroupRepository.</param>
        public ServiceLogic(IBikeRepository bikeRepo, IBrandRepository brandRepo, IOwnerRepository ownerRepo, IServiceReporitory serviceRepo, IFacebookGroupRepository facebookGroupRepo, IOwnerFacebookGroupRepository ofbgRepo)
        {
            this.bikeRepo = bikeRepo;
            this.brandRepo = brandRepo;
            this.ownerRepo = ownerRepo;
            this.serviceRepo = serviceRepo;
            this.facebookGroupRepo = facebookGroupRepo;
            this.ownerFacebookGroupRepo = ofbgRepo;
        }

        /// <inheritdoc/>
        public void AddBikeToServicestation(int serviceId, Bike bike)
        {
            Service s = this.serviceRepo.GetOne(serviceId);
            if (s != null)
            {
                if (bike != null)
                {
                    if (s.MaxSpace > s.BikesInService.Count)
                    {
                        this.serviceRepo.AddBikeToService(serviceId, bike);
                    }
                    else
                    {
                        throw new Exception("Nem fér több motor a szervízbe!");
                    }
                }
                else
                {
                    throw new Exception("Motor nem található!");
                }
            }
            else
            {
                throw new Exception("Szervíz nem található!");
            }
        }

        /// <inheritdoc/>
        public void AddServicestation(Service newServicestation)
        {
            this.serviceRepo.Add(newServicestation);
        }

        /// <inheritdoc/>
        public void ChangeName(int id, string newName)
        {
            Service s = this.serviceRepo.GetOne(id);
            if (s != null)
            {
                this.serviceRepo.ChangeName(id, newName);
            }
            else
            {
                throw new Exception("Szervíz nem található!");
            }
        }

        /// <inheritdoc/>
        public void DeleteBikeFromServicestation(int serviceId, Bike bike)
        {
            Service s = this.serviceRepo.GetOne(serviceId);
            if (s != null)
            {
                if (bike != null)
                {
                    this.serviceRepo.DeleteBikeFromService(serviceId, bike);
                }
                else
                {
                    throw new Exception("A motor nem található!");
                }
            }
            else
            {
                throw new Exception("Szervíz nem található!");
            }
        }

        /// <inheritdoc/>
        public void DeleteServicestation(int id)
        {
            Service s = this.serviceRepo.GetOne(id);
            if (s != null)
            {
                if (s.BikesInService.Count > 0)
                {
                    throw new Exception("Nem törölhető, még vannak szervizelendő motorok!");
                }
                else
                {
                    this.serviceRepo.Delete(id);
                }
            }
            else
            {
                throw new Exception("Szervíz nem található!");
            }
        }

        /// <inheritdoc/>
        public void FireWorker(int id)
        {
            Service s = this.serviceRepo.GetOne(id);
            if (s != null)
            {
                this.serviceRepo.FireEmployee(id);
            }
            else
            {
                throw new Exception("Szervíz nem található!");
            }
        }

        /// <inheritdoc/>
        public Service GetOne2(int id)
        {
            return this.serviceRepo.GetOne(id);
        }

        /// <inheritdoc/>
        public void HireNewWorker(int id)
        {
            Service s = this.serviceRepo.GetOne(id);
            if (s != null)
            {
                this.serviceRepo.HireNewEmployee(id);
            }
            else
            {
                throw new Exception("Szervíz nem található!");
            }
        }

        /// <inheritdoc/>
        public void ChangeCapacity(int id, int amount)
        {
            Service s = this.serviceRepo.GetOne(id);
            if (s != null)
            {
                this.serviceRepo.ChangeCapacity(id, amount);
            }
            else
            {
                throw new Exception("Szervíz nem található!");
            }
        }

        /// <inheritdoc/>
        public void ListAllServicestations()
        {
            this.serviceRepo.GetAll();
        }

        /// <summary>
        /// This method returns all the service stations in the Db.
        /// </summary>
        /// <returns>It return all of the service stations.</returns>
        public IQueryable<Service> GetAll()
        {
            return this.serviceRepo.GetAll();
        }

        /// <summary>
        /// This method return the most liked servicestation or stations.
        /// </summary>
        /// <returns>It return one or more service stations id, name and the number of the bikes in the servicestation.</returns>
        public IQueryable MostLikedServiceStation()
        {
            var services = from service in this.serviceRepo.GetAll()
                      let maxx = this.serviceRepo.GetAll().OrderByDescending(x => x.BikesInService.Count).Select(x => x.BikesInService.Count).FirstOrDefault()
                      where service.BikesInService.Count == maxx
                      select service.Id + " " + service.Name + " " + service.BikesInService.Count;

            return services;
        }

        /// <summary>
        /// This method returns the most liked service station(s).
        /// </summary>
        /// <returns>It returns a task.</returns>
        public Task<IQueryable> MostLikedServiceStationTask()
        {
            return Task.Run(() => this.MostLikedServiceStation());
        }

        public IEnumerable<Service> GetAlll()
        {
            return this.serviceRepo.GetAll();
        }

        public void ChangeEmpCount(int id, int newValue)
        {
            this.serviceRepo.ChangeEmpCount(id, newValue);
        }
    }
}
