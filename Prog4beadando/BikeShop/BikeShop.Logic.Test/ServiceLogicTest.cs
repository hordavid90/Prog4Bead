// <copyright file="ServiceLogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Logic.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BikeShop.Data;
    using BikeShop.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// This class is for testing the methods of the Service Logic.
    /// </summary>
    [TestFixture]
    public class ServiceLogicTest
    {
        private static BikeDbContext ctx;
        private ServiceLogic sl;
        private BikeRepository br;
        private BrandRepository brr;
        private OwnerRepository or;
        private ServiceRepository sr;
        private FacebookGroupRepository fbr;
        private OwnerFacebookGroupRepository ofbgr;

        private Mock<IBikeRepository> mockedBikeRepo;
        private Mock<IBrandRepository> mockedBrandRepo;
        private Mock<IOwnerRepository> mockedOwnerRepo;
        private Mock<IServiceReporitory> mockedServiceRepo;
        private Mock<IFacebookGroupRepository> mockedFacebookGroupRepo;
        private Mock<IOwnerFacebookGroupRepository> mockedofbgRepo;

        /// <summary>
        /// This is the setup for the tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            ctx = new BikeDbContext();

            this.br = new BikeRepository(ctx);
            this.brr = new BrandRepository(ctx);
            this.or = new OwnerRepository(ctx);
            this.sr = new ServiceRepository(ctx);
            this.fbr = new FacebookGroupRepository(ctx);
            this.ofbgr = new OwnerFacebookGroupRepository(ctx);

            this.mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            this.mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            this.mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            this.mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            this.mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            this.mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            this.sl = new ServiceLogic(this.br, this.brr, this.or, this.sr, this.fbr, this.ofbgr);
        }

        /// <summary>
        /// This is a test for the Bike with the oldest brand method.
        /// </summary>
        [Test]
        public void TestMostLikedServiceStation()
        {
            var mostLiked = this.sl.MostLikedServiceStation();
            var allServices = this.sl.GetAll();

            Assert.That(this.sl.MostLikedServiceStation(), Is.EqualTo(mostLiked));

            ServiceLogic logic = new ServiceLogic(this.mockedBikeRepo.Object, this.mockedBrandRepo.Object, this.mockedOwnerRepo.Object, this.mockedServiceRepo.Object, this.mockedFacebookGroupRepo.Object, this.mockedofbgRepo.Object);

            this.mockedServiceRepo.Setup(r => r.GetAll()).Returns(allServices as IQueryable<Service>);

            logic.MostLikedServiceStation();

            this.mockedServiceRepo.Verify(r => r.GetAll(), Times.Exactly(1));
        }
    }
}
