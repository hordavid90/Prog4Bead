// <copyright file="FacebookGroupRepository.cs" company="PlaceholderCompany">
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
    /// This is the FacebookGroup repository.
    /// </summary>
    public class FacebookGroupRepository : MyRepository<FacebookGroup>, IFacebookGroupRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookGroupRepository"/> class.
        /// </summary>
        /// <param name="ctx">It is the database context.</param>
        public FacebookGroupRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public void AddOwnerToGroup(int groupid, Owner owner)
        {
            var group = this.GetOne(groupid);
            var bikes = owner.Bikes;

            OwnerFBGroup ofbgi = new OwnerFBGroup()
            {
                FBGroupId = groupid,
                OwnerId = owner.Id,
            };
            group.OwnerFBGroup.Add(ofbgi);

            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeName(int id, string newName)
        {
            var groupToModify = this.GetOne(id);

            groupToModify.Name = newName;
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override void Delete(int id)
        {
            var groupToDelete = this.GetOne(id);

            this.ctx.Remove(groupToDelete);
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override FacebookGroup GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <inheritdoc/>
        public void RemoveOwnerFromGroup(int groupid, Owner owner)
        {
            var group = this.GetOne(groupid);

            group.Owners.Remove(owner);
            this.ctx.SaveChanges();
        }
    }
}
