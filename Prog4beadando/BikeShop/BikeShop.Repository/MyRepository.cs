// <copyright file="MyRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This is the MyRepository.
    /// </summary>
    /// <typeparam name="T">T could be a Bike, Brand, Owner, Servicestation.</typeparam>
    public abstract class MyRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// This is the DbContext.
        /// </summary>
        protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyRepository{T}"/> class.
        /// </summary>
        /// <param name="ctx">It is the database context.</param>
        public MyRepository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <inheritdoc/>
        public void Add(T newItem)
        {
            this.ctx.Add(newItem);
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public abstract void Delete(int id);

        /// <inheritdoc/>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <inheritdoc/>
        public abstract T GetOne(int id);
    }
}
