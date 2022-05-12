// <copyright file="ServiceRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BikeShop.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This is the service reporitory.
    /// </summary>
    public class ServiceRepository : MyRepository<Service>, IServiceReporitory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRepository"/> class.
        /// </summary>
        /// <param name="ctx">It is the database context.</param>
        public ServiceRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public void AddBikeToService(int serviceId, Bike bike)
        {
            var service = this.GetOne(serviceId);

            service.BikesInService.Add(bike);
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeCapacity(int id, int newCapacity)
        {
            var serviceToModify = this.GetOne(id);

            serviceToModify.MaxSpace = newCapacity;
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeName(int id, string newName)
        {
            var serviceToModify = this.GetOne(id);

            serviceToModify.Name = newName;
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override void Delete(int id)
        {
            var serviceToDelete = this.GetOne(id);

            this.ctx.Remove(serviceToDelete);
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void DeleteBikeFromService(int serviceId, Bike bike)
        {
            var service = this.GetOne(serviceId);

            service.BikesInService.Remove(bike);
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void FireEmployee(int id)
        {
            var serviceToModify = this.GetOne(id);

            serviceToModify.EmployeeNumer -= 1;
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Service GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <inheritdoc/>
        public void HireNewEmployee(int id)
        {
            var serviceToModify = this.GetOne(id);

            serviceToModify.EmployeeNumer += 1;
            this.ctx.SaveChanges();
        }

        public void ChangeEmpCount(int id, int newCount)
        {
            var serviceToModify = this.GetOne(id);
            serviceToModify.EmployeeNumer = newCount;
            this.ctx.SaveChanges();
        }
    }
}
