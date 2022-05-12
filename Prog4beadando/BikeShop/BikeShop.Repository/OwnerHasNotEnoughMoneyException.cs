// <copyright file="OwnerHasNotEnoughMoneyException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This exception is thrown when we want to take more money from an owner than he has.
    /// </summary>
    public class OwnerHasNotEnoughMoneyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerHasNotEnoughMoneyException"/> class.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public OwnerHasNotEnoughMoneyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerHasNotEnoughMoneyException"/> class.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public OwnerHasNotEnoughMoneyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerHasNotEnoughMoneyException"/> class.
        /// The constructor of the OwnerHasNotEnoughMoneyException.
        /// </summary>
        public OwnerHasNotEnoughMoneyException()
        {
        }
    }
}
