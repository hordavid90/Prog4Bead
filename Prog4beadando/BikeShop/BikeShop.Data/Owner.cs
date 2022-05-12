// <copyright file="Owner.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    /// <summary>
    /// The owner table.
    /// </summary>
    [Table("Owner")]
    public class Owner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Owner"/> class.
        /// </summary>
        public Owner()
        {
            this.Bikes = new HashSet<Bike>();
            this.OwnerFBGroup = new HashSet<OwnerFBGroup>();
        }

        /// <summary>
        /// Gets or sets id of an owner.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("owner_id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of an owner.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the money of an owner.
        /// </summary>
        [Required]
        public int Money { get; set; }

        /// <summary>
        /// Gets or sets the bikes of an owner.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Bike> Bikes { get; set; }

        /// <summary>
        /// Gets or sets the Owner-FBgroup.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<OwnerFBGroup> OwnerFBGroup { get; set; }

        /// <summary>
        /// This method overrides the basic ToString method.
        /// </summary>
        /// <returns>It returns the id and the owner's name.</returns>
        public override string ToString()
        {
            return $"Id: = {this.Id}, neve: = {this.Name}";
        }

        /// <summary>
        /// This method decides if two owner are the same or not.
        /// </summary>
        /// <param name="obj">It is an Owner item.</param>
        /// <returns>It returns if two obejct are equal or not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Owner)
            {
                Owner other = obj as Owner;
                return this.Id == other.Id &&
                    this.Name == other.Name &&
                    this.Money == other.Money;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This returns the owner's id as a HashCode.
        /// </summary>
        /// <returns>The id of the owner.</returns>
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
