// <copyright file="TestOwnerLogic.cs" company="PlaceholderCompany">
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
    public class TestOwnerLogic
    {
        private static BikeDbContext ctx;
        private OwnerLogic ol;
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
        /// This tests the Take money method.
        /// </summary>
        [Test]
        public void TestTakeMoneyFromOwner()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            List<Owner> owners = new List<Owner>()
            {
                new Owner() { Name = "John", Id = 1, Money = 100 },
                new Owner() { Name = "Bill", Id = 2, Money = 200 },
                new Owner() { Name = "Tony", Id = 3, Money = 300 },
            };
            Owner owner1 = owners[1];
            Owner owner2 = owners[0];

            mockedOwnerRepo.Setup(repo => repo.GetOne(2)).Returns(owner1 as Owner);
            mockedOwnerRepo.Setup(repo => repo.GetOne(1)).Returns(owner2 as Owner);
            mockedOwnerRepo.Setup(repo => repo.TakeMoney(2, 50));
            mockedOwnerRepo.Setup(repo => repo.TakeMoney(1, 200));
            OwnerLogic logic = new OwnerLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            // ACT
            logic.TakeMoney(2, 50);

            // ASSERT
            mockedOwnerRepo.Verify(repo => repo.TakeMoney(2, 50), Times.Once);
            mockedOwnerRepo.Verify(repo => repo.TakeMoney(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(1));
        }

        /// <summary>
        /// This tests the Add money method.
        /// </summary>
        [Test]
        public void TestAddMoneyToOwner()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            List<Owner> owners = new List<Owner>()
            {
                new Owner() { Name = "John", Id = 1, Money = 100 },
                new Owner() { Name = "Bill", Id = 2, Money = 200 },
                new Owner() { Name = "Tony", Id = 3, Money = 300 },
            };
            Owner ownerToDelete = owners[1];

            // Setup
            mockedOwnerRepo.Setup(repo => repo.GetOne(1)).Returns(ownerToDelete as Owner);
            mockedOwnerRepo.Setup(repo => repo.AddMoney(1, 50));
            OwnerLogic logic = new OwnerLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            // ACT
            logic.AddMoney(1, 50);

            // ASSERT
            mockedOwnerRepo.Verify(repo => repo.AddMoney(99, 50), Times.Never);
            mockedOwnerRepo.Verify(repo => repo.AddMoney(1, 50), Times.Once);
        }

        /// <summary>
        /// This tests the Add money method.
        /// </summary>
        [Test]
        public void TestDeleteOwner()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            Bike bike = new Bike()
            {
                BrandId = 1,
                Model = "Teszt",
                BasePrice = 100,
                OwnerId = 2,
            };

            List<Bike> bikes = new List<Bike>() { bike };

            List<Owner> owners = new List<Owner>()
            {
                new Owner() { Name = "John", Id = 1, Money = 100 },
                new Owner() { Name = "Bill", Id = 2, Money = 200, Bikes = bikes },
                new Owner() { Name = "Tony", Id = 3, Money = 300 },
            };
            Owner ownerToDelete = owners[0];
            Owner ownerToDelete2 = owners[1];

            // Setup
            mockedOwnerRepo.Setup(repo => repo.GetOne(1)).Returns(ownerToDelete as Owner);
            mockedOwnerRepo.Setup(repo => repo.Delete(1));
            OwnerLogic logic = new OwnerLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            // ACT
            logic.DeleteOwner(1);

            // ASSERT
            mockedOwnerRepo.Verify(repo => repo.Delete(1), Times.Once);
            mockedOwnerRepo.Verify(repo => repo.Delete(3), Times.Never);
        }

        /// <summary>
        /// The setup for the non crud tests.
        /// It creates a Db context, an owner repository and an owner logic.
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

            this.ol = new OwnerLogic(this.br, this.brr, this.or, this.sr, this.fbr, this.ofbgr);
        }

        /// <summary>
        /// This test the OwnersFavoriteBrand method.
        /// </summary>
        [Test]
        public void TestGetOwnersFavoriteBrand()
        {
            Assert.That(this.ol.OwnersFavoriteBrandLogic(2), Is.EqualTo("BMW"));
            Assert.That(this.ol.OwnersFavoriteBrandLogic(1), Is.EqualTo("A tulajdonosnak nincs kedvenc motorja."));
            Assert.That(this.ol.OwnersFavoriteBrandLogic(5), Is.EqualTo("A tulajdonosnak nincs motorja."));

            OwnerLogic logic = new OwnerLogic(this.mockedBikeRepo.Object, this.mockedBrandRepo.Object, this.mockedOwnerRepo.Object, this.mockedServiceRepo.Object, this.mockedFacebookGroupRepo.Object, this.mockedofbgRepo.Object);

            Brand brand = new Brand() { Id = 1, Name = "Suzuki" };

            List<Bike> bikes = new List<Bike>()
            {
                new Bike() { Id = 1, BrandId = 1, OwnerId = 1, Brand = brand, Model = "GSXR" },
            };

            Owner owner = new Owner()
            {
                Id = 1,
                Bikes = bikes,
            };

            this.mockedOwnerRepo.Setup(r => r.GetOne(1)).Returns(owner);

            logic.OwnersFavoriteBrandLogic(1);

            this.mockedOwnerRepo.Verify(l => l.GetOne(1), Times.Exactly(2));
        }
    }
}
