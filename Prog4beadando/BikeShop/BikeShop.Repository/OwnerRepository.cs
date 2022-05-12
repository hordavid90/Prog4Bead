// <copyright file="OwnerRepository.cs" company="PlaceholderCompany">
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
    /// This is the owner repository.
    /// </summary>
    public class OwnerRepository : MyRepository<Owner>, IOwnerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerRepository"/> class.
        /// </summary>
        /// <param name="ctx">It is the database context.</param>
        public OwnerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public void AddMoney(int id, int amount)
        {
            Owner owner = this.GetOne(id);

            owner.Money += amount;
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeName(int id, string newName)
        {
            Owner owner = this.GetOne(id);

            owner.Name = newName;
            this.ctx.SaveChanges();
        }

        public void ChangeFortune(int id, int newAmount)
        {
            Owner owner = this.GetOne(id);

            owner.Money = newAmount;
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override void Delete(int id)
        {
            Owner owner = this.GetOne(id);

            this.ctx.Remove(owner);
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Owner GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <inheritdoc/>
        public void TakeMoney(int id, int amount)
        {
            Owner owner = this.GetOne(id);

            owner.Money -= amount;
            this.ctx.SaveChanges();
        }
    }
}
