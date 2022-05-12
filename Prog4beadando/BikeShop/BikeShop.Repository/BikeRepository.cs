// <copyright file="BikeRepository.cs" company="PlaceholderCompany">
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
    /// This is the bike repository.
    /// </summary>
    public class BikeRepository : MyRepository<Bike>, IBikeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BikeRepository"/> class.
        /// </summary>
        /// <param name="ctx">It is the database context.</param>
        public BikeRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public bool ChangeName(int id, string newName)
        {
            Bike bikeToChangeName = this.GetOne(id);

            bikeToChangeName.Model = newName;
            this.ctx.SaveChanges();
            return true;
        }

        /// <inheritdoc/>
        public void ChangePrice(int id, int newPrice)
        {
            Bike bike = this.GetOne(id);

            bike.BasePrice = newPrice;
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override void Delete(int id)
        {
            var toDelete = this.GetOne(id);

            this.ctx.Remove(toDelete);
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Bike GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <inheritdoc/>
        public void SellBike(int bikeId, Owner newOwner, Owner seller)
        {
            Bike bikeToSell = this.GetOne(bikeId);
            int id = bikeToSell.Id;
            var price = bikeToSell.BasePrice;
            int brandId = bikeToSell.BrandId;
            Brand brand = bikeToSell.Brand;
            string modelName = bikeToSell.Model;

            this.Delete(bikeId);

            Bike bike = new Bike()
            {
                BasePrice = price,
                BrandId = brandId,
                Brand = brand,
                Model = modelName,
                OwnerId = newOwner.Id,
            };
            newOwner.Money = newOwner.Money - (int)price;
            seller.Money += (int)price;

            this.ctx.Add(bike);
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddBike(Bike bike, Owner owner)
        {
            this.Add(bike);
            owner.Money -= (int)bike.BasePrice;
            this.ctx.SaveChanges();
        }

        public void Update(Bike item)
        {
            var old = GetOne(item.Id);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }

            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }

            this.ctx.SaveChanges();
        }
    }
}
