// <copyright file="BikeLogicTest.cs" company="PlaceholderCompany">
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
    /// This class is for testing the methods of the bike Logic.
    /// </summary>
    [TestFixture]
    public class BikeLogicTest
    {
        private static BikeDbContext ctx;
        private BikeLogic bl;
        private BrandLogic brl;
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
        /// This tests the get all bikes method.
        /// </summary>
        [Test]
        public void TestGetAllBikes()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            List<Bike> bikes = new List<Bike>()
            {
                new Bike() { Model = "Penigale", BrandId = 1 },
                new Bike() { Model = "Touno", BrandId = 2 },
                new Bike() { Model = "K1600", BrandId = 3 },
                new Bike() { Model = "R1", BrandId = 4 },
            };
            List<Bike> expectedBikes = new List<Bike>() { bikes[0], bikes[1], bikes[2], bikes[3], };

            mockedBikeRepo.Setup(repo => repo.GetAll()).Returns(bikes.AsQueryable());
            BikeLogic logic = new BikeLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            // ACT
            var result = logic.GetAll();

            // ASSERT
            Assert.That(result.Count(), Is.EqualTo(expectedBikes.Count));
            Assert.That(result, Is.EquivalentTo(expectedBikes));

            mockedBikeRepo.Verify(repo => repo.GetAll(), Times.Once);
            mockedBikeRepo.Verify(repo => repo.GetOne(42), Times.Exactly(0));
            mockedBikeRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// This tests the get one bike by id method.
        /// </summary>
        [Test]
        public void TestGetBikesById()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            List<Bike> bikes = new List<Bike>()
            {
                new Bike() { Model = "Penigale", Id = 1 },
                new Bike() { Model = "Touno", Id = 2 },
                new Bike() { Model = "K1600", Id = 3 },
                new Bike() { Model = "R1", Id = 4 },
            };
            Bike expectedBike = bikes[2];

            mockedBikeRepo.Setup(repo => repo.GetOne(3)).Returns(expectedBike as Bike);
            BikeLogic logic = new BikeLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            // ACT
            Bike result = logic.GetOne2(3);

            // ASSERT
            Assert.That(result, Is.EqualTo(expectedBike));
            mockedBikeRepo.Verify(repo => repo.GetOne(1), Times.Exactly(0));
            mockedBikeRepo.Verify(repo => repo.GetOne(3), Times.Exactly(1));
        }

        /// <summary>
        /// This tests the get one bike by id method.
        /// </summary>
        [Test]
        public void TestDeleteBike()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            List<Bike> bikes = new List<Bike>()
            {
                new Bike() { Model = "Penigale", Id = 1 },
                new Bike() { Model = "Touno", Id = 2 },
                new Bike() { Model = "K1600", Id = 3 },
                new Bike() { Model = "R1", Id = 4 },
            };
            Bike bikeToDelete = bikes[0];

            mockedBikeRepo.Setup(repo => repo.GetOne(1)).Returns(bikeToDelete as Bike);
            mockedBikeRepo.Setup(repo => repo.Delete(1));
            BikeLogic logic = new BikeLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            // ACT
            logic.DeleteBike(1);

            // ASSERT
            mockedBikeRepo.Verify(repo => repo.Delete(1), Times.Exactly(1));
        }

        /// <summary>
        /// This tests the AddBike method.
        /// </summary>
        [Test]
        public void TestBikeAdd()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            mockedBikeRepo.Setup(repo => repo.AddBike(It.IsAny<Bike>(), It.IsAny<Owner>()));
            BikeLogic logic = new BikeLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            Owner owner = new Owner()
            {
                Name = "Béla",
            };

            Owner poorOwner = new Owner()
            {
                Name = "PoorOwner",
            };

            Bike newBike = new Bike()
            {
                BrandId = 1,
                Model = "Tiger",
                OwnerId = 1,
                BasePrice = 99999,
            };

            logic.AddBike(newBike, owner);
            logic.AddBike(newBike, poorOwner);
            mockedBikeRepo.Verify(repo => repo.AddBike(It.IsAny<Bike>(), It.IsAny<Owner>()), Times.Exactly(2));
            mockedBikeRepo.Verify(repo => repo.AddBike(newBike, owner), Times.Once);
            mockedBikeRepo.Verify(repo => repo.AddBike(newBike, poorOwner), "A vevőnek nincs elég pénze!");
        }

        /// <summary>
        /// This tests the ChangeBikesName mathod.
        /// </summary>
        [Test]
        public void TesChangeBikesName()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            List<Bike> bikes = new List<Bike>()
            {
                new Bike() { Model = "Penigale", Id = 1 },
                new Bike() { Model = "Touno", Id = 2 },
                new Bike() { Model = "K1600", Id = 3 },
                new Bike() { Model = "R1", Id = 4 },
            };
            Bike expectedBike = bikes[1];

            mockedBikeRepo.Setup(repo => repo.GetOne(2)).Returns(expectedBike as Bike);
            mockedBikeRepo.Setup(repo => repo.ChangeName(2, "RSV4"));
            BikeLogic logic = new BikeLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            // ACT
            logic.ChangeName(2, "RSV4");

            // ASSERT
            mockedBikeRepo.Verify(repo => repo.ChangeName(2, "RSV4"), Times.Once);
        }

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

            this.brl = new BrandLogic(this.br, this.brr, this.or, this.sr, this.fbr, this.ofbgr);
            this.bl = new BikeLogic(this.br, this.brr, this.or, this.sr, this.fbr, this.ofbgr);
        }

        /// <summary>
        /// This is a test for the Bike with the oldest brand method.
        /// </summary>
        [Test]
        public void TestBikesWithTheOldestBrand()
        {
            var output = this.bl.GetAll()
                .Where(x => x.Brand.Name == "Suzuki")
                .Select(x => x.Brand.Name + " " + x.Model + " " + x.Brand.Established);

            Assert.That(this.bl.BikesWithTheOldestBrandLogic2(), Is.EqualTo(output));

            BikeLogic logic = new BikeLogic(this.mockedBikeRepo.Object, this.mockedBrandRepo.Object, this.mockedOwnerRepo.Object, this.mockedServiceRepo.Object, this.mockedFacebookGroupRepo.Object, this.mockedofbgRepo.Object);

            logic.BikesWithTheOldestBrandLogic2();
            this.mockedBikeRepo.Setup(r => r.GetAll());
            this.mockedBikeRepo.Verify(l => l.GetAll(), Times.Once);

            this.mockedBrandRepo.Setup(r => r.GetAll());
            this.mockedBikeRepo.Verify(l => l.GetAll(), Times.Once);
        }
    }
}
