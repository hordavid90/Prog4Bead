// <copyright file="BrandLogicTest.cs" company="PlaceholderCompany">
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
    /// This class is for testing the methods of the Brand Logic.
    /// </summary>
    [TestFixture]
    public class BrandLogicTest
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
        public void TestGetAllBrands()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            List<Brand> brands = new List<Brand>()
            {
                new Brand() { Name = "Ducati", Id = 1 },
                new Brand() { Name = "Yamaha", Id = 2 },
                new Brand() { Name = "Aprilia", Id = 3 },
                new Brand() { Name = "Cagiva", Id = 4 },
            };
            List<Brand> expectedBands = new List<Brand>() { brands[0], brands[1], brands[2], brands[3], };

            mockedBrandRepo.Setup(repo => repo.GetAll()).Returns(brands.AsQueryable());
            BrandLogic logic = new BrandLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            // ACT
            var result = logic.GetAll();

            // ASSERT
            Assert.That(result.Count(), Is.EqualTo(expectedBands.Count));
            Assert.That(result, Is.EquivalentTo(expectedBands));

            mockedBrandRepo.Verify(repo => repo.GetAll(), Times.Once);
            mockedBrandRepo.Verify(repo => repo.GetOne(42), Times.Exactly(0));
            mockedBrandRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// This tests the get one bike by id method.
        /// </summary>
        [Test]
        public void TestGetBrandsById()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            List<Brand> brands = new List<Brand>()
            {
                new Brand() { Name = "Ducati", Id = 1 },
                new Brand() { Name = "Yamaha", Id = 2 },
                new Brand() { Name = "Aprilia", Id = 3 },
                new Brand() { Name = "Cagiva", Id = 4 },
            };
            Brand expectedBand = brands[3];

            mockedBrandRepo.Setup(repo => repo.GetOne(4)).Returns(brands[3] as Brand);
            BrandLogic logic = new BrandLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            // ACT
            var result = logic.GetOne2(4);

            // ASSERT
            Assert.That(result, Is.EqualTo(expectedBand));
            mockedBrandRepo.Verify(repo => repo.GetAll(), Times.Never);
            mockedBrandRepo.Verify(repo => repo.GetOne(42), Times.Exactly(0));
            mockedBrandRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Once);
        }

        /// <summary>
        /// This tests the get one bike by id method.
        /// </summary>
        [Test]
        public void TestDeleteBrand()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            List<Brand> brands = new List<Brand>()
            {
                new Brand() { Name = "Ducati", Id = 1 },
                new Brand() { Name = "Yamaha", Id = 2 },
                new Brand() { Name = "Aprilia", Id = 3 },
                new Brand() { Name = "Cagiva", Id = 4 },
            };
            Brand brandToDelete = brands[2];

            mockedBrandRepo.Setup(repo => repo.Delete(3));
            BrandLogic logic = new BrandLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            // ACT
            logic.DeleteBrand(3);

            // ASSERT
            mockedBrandRepo.Verify(repo => repo.Delete(3), Times.Exactly(1));
        }

        /// <summary>
        /// This tests the AddBrand method.
        /// </summary>
        [Test]
        public void TestBrandAdd()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            mockedBrandRepo.Setup(repo => repo.Add(It.IsAny<Brand>()));
            BrandLogic logic = new BrandLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            Brand newBrand = new Brand()
            {
                Name = "Harley",
                Country = "USA",
            };

            logic.AddBrand(newBrand);
            mockedBrandRepo.Verify(repo => repo.Add(It.IsAny<Brand>()), Times.Exactly(1));
        }

        /// <summary>
        /// This tests the ChangeBikesName mathod.
        /// </summary>
        [Test]
        public void TestChangeBrandsName()
        {
            Mock<IBikeRepository> mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IServiceReporitory> mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            Mock<IFacebookGroupRepository> mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            Mock<IOwnerFacebookGroupRepository> mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            List<Brand> brands = new List<Brand>()
            {
                new Brand() { Name = "Ducati", Id = 1 },
                new Brand() { Name = "Yamaha", Id = 2 },
                new Brand() { Name = "Aprilia", Id = 3 },
                new Brand() { Name = "Cagiva", Id = 4 },
            };

            mockedBrandRepo.Setup(repo => repo.ChangeName(1, "Hyosung"));
            BrandLogic logic = new BrandLogic(mockedBikeRepo.Object, mockedBrandRepo.Object, mockedOwnerRepo.Object, mockedServiceRepo.Object, mockedFacebookGroupRepo.Object, mockedofbgRepo.Object);

            // ACT
            logic.ChangeName(1, "Hyosung");

            // ASSERT
            mockedBrandRepo.Verify(repo => repo.ChangeName(2, "Indian"), Times.Never);
            mockedBrandRepo.Verify(repo => repo.ChangeName(1, "Hyosung"), Times.Once);
        }

        /// <summary>
        /// This is the setup for the tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.mockedBikeRepo = new Mock<IBikeRepository>(MockBehavior.Loose);
            this.mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            this.mockedOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            this.mockedServiceRepo = new Mock<IServiceReporitory>(MockBehavior.Loose);
            this.mockedFacebookGroupRepo = new Mock<IFacebookGroupRepository>(MockBehavior.Loose);
            this.mockedofbgRepo = new Mock<IOwnerFacebookGroupRepository>(MockBehavior.Loose);

            ctx = new BikeDbContext();

            this.br = new BikeRepository(ctx);
            this.brr = new BrandRepository(ctx);
            this.or = new OwnerRepository(ctx);
            this.sr = new ServiceRepository(ctx);
            this.fbr = new FacebookGroupRepository(ctx);
            this.ofbgr = new OwnerFacebookGroupRepository(ctx);

            this.brl = new BrandLogic(this.br, this.brr, this.or, this.sr, this.fbr, this.ofbgr);
            this.bl = new BikeLogic(this.br, this.brr, this.or, this.sr, this.fbr, this.ofbgr);
        }

        /// <summary>
        /// This is a test for the Bike with the oldest brand method.
        /// </summary>
        [Test]
        public void TestAveragePriceOfOneBrand()
        {
            var allbikes = this.bl.GetAll();
            var allbrands = this.brl.GetAll();

            Assert.That(this.brl.AveragePriceOfOneBrand(allbikes, "Suzuki"), Is.EqualTo(22500));
            Assert.That(this.brl.AveragePriceOfOneBrand(allbikes, "BMW"), Is.EqualTo(25000));
            Assert.That(this.brl.AveragePriceOfOneBrand(allbikes, "Honda"), Is.EqualTo(12500));

            BrandLogic logic = new BrandLogic(this.mockedBikeRepo.Object, this.mockedBrandRepo.Object, this.mockedOwnerRepo.Object, this.mockedServiceRepo.Object, this.mockedFacebookGroupRepo.Object, this.mockedofbgRepo.Object);

            this.mockedBrandRepo.Setup(repo => repo.GetAll()).Returns(allbrands as IQueryable<Brand>);

            logic.AveragePriceOfOneBrand(allbikes, "Suzuki");

            this.mockedBrandRepo.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
