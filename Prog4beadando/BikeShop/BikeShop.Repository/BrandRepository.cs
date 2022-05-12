// <copyright file="BrandRepository.cs" company="PlaceholderCompany">
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
    /// The BrandRepository.
    /// </summary>
    public class BrandRepository : MyRepository<Brand>, IBrandRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrandRepository"/> class.
        /// </summary>
        /// <param name="ctx">It is the database context.</param>
        public BrandRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public void ChangeName(int id, string newBrandName)
        {
            var brandToModify = this.GetOne(id);

            brandToModify.Name = newBrandName;
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override void Delete(int id)
        {
            var brandToDelete = this.GetOne(id);

            this.ctx.Remove(brandToDelete);
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Brand GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        public void ChangeCountry(int id, string newValue)
        {
            var brandToModify = this.GetOne(id);

            brandToModify.Country = newValue;

            this.ctx.SaveChanges();
        }

        public void ChangeEstablished(int id, int newValue)
        {
            var brandToModify = this.GetOne(id);

            brandToModify.Established = newValue;

            this.ctx.SaveChanges();
        }
    }
}
