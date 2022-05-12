// <copyright file="FacebookGroup.cs" company="PlaceholderCompany">
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
    using System.Threading.Tasks;

    /// <summary>
    /// This is the FacebookGroup class and it will be the FacebookGroup table in the DB.
    /// </summary>
    [Table("FacebookGroup")]
    public class FacebookGroup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookGroup"/> class.
        /// </summary>
        public FacebookGroup()
        {
            this.Owners = new List<Owner>();
            this.OwnerFBGroup = new HashSet<OwnerFBGroup>();
        }

        /// <summary>
        /// Gets or sets the owners in a FacebookGroup.
        /// </summary>
        public virtual ICollection<Owner> Owners { get; set; }

        /// <summary>
        /// Gets or sets id of a FacebookGroup.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("FBGroup_id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name of a FacebookGroup.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a FacebookGroup is brand specified or not.
        /// </summary>
        public bool IsBrandSpecifiad { get; set; }

        /// <summary>
        /// Gets or sets the specified brand of a FacebookGroup.
        /// </summary>
        public string SpecifiedBrand { get; set; }

        /// <summary>
        /// Gets the number of members of a FacebookGroup.
        /// </summary>
        public int MemberCount => this.OwnerFBGroup.Count;

        /// <summary>
        /// Gets or sets the Owner-FBgroup conection.
        /// </summary>
        [NotMapped]
        public virtual ICollection<OwnerFBGroup> OwnerFBGroup { get; set; }
    }
}
