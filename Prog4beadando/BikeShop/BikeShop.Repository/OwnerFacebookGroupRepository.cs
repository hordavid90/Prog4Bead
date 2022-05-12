// <copyright file="OwnerFacebookGroupRepository.cs" company="PlaceholderCompany">
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
    /// asd.
    /// </summary>
    public class OwnerFacebookGroupRepository : MyRepository<OwnerFBGroup>, IOwnerFacebookGroupRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerFacebookGroupRepository"/> class.
        /// </summary>
        /// <param name="ctx">It is the database context.</param>
        public OwnerFacebookGroupRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// This method deletes an OwnerFBGroup item.
        /// </summary>
        /// <param name="id">The id of the item we want to delete.</param>
        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method deletes an owner from a FB group.
        /// </summary>
        /// <param name="groupId">The group id we want to delete from.</param>
        /// <param name="ownerId">The id of the owner we want to delete from the FB group.</param>
        public void Delete2(int groupId, int ownerId)
        {
            var toDelete = this.GetAll().Where(x => x.FBGroupId == groupId && x.OwnerId == ownerId).FirstOrDefault();
            this.ctx.Remove(toDelete);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// This gets one OwnerFBGroup item.
        /// </summary>
        /// <param name="id">The id of the item we want to get.</param>
        /// <returns>It returns an OwnerFBGroup.</returns>
        public override OwnerFBGroup GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.ConId == id);
        }
    }
}
