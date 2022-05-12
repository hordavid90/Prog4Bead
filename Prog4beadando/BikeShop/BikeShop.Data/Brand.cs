// <copyright file="Brand.cs" company="PlaceholderCompany">
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
    /// This is the Brand class.
    /// </summary>
    [Table("Brand")]
    public class Brand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Brand"/> class.
        /// </summary>
        public Brand()
        {
            this.Bikes = new HashSet<Bike>();
        }

        /// <summary>
        /// Gets or sets id of a brand.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("brand_id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name of a brand.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the bikes of a brand.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Bike> Bikes { get; set; }

        /// <summary>
        /// Gets or sets the country of a brand.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the establishing date of a brand.
        /// </summary>
        [MaxLength(4)]
        [Required]
        public int Established { get; set; }

        /// <summary>
        /// This method overrides the basic ToString method.
        /// </summary>
        /// <returns>It returns the id and the brand's name.</returns>
        public override string ToString()
        {
            return $"Id: = {this.Id}, márka: = {this.Name}";
        }

        /// <summary>
        /// This method decides if two brands are the same or not.
        /// </summary>
        /// <param name="obj">It is a Brand item.</param>
        /// <returns>It returns if two obejct are equal or not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Brand)
            {
                Brand other = obj as Brand;
                return this.Id == other.Id &&
                    this.Name == other.Name &&
                    this.Country == other.Country &&
                    this.Established == other.Established;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This returns the brand's id as a HashCode.
        /// </summary>
        /// <returns>The id of the brand.</returns>
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
