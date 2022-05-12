// <copyright file="Programm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using BikeShop.Data;
    using BikeShop.Logic;
    using BikeShop.Program;
    using BikeShop.Repository;
    using ConsoleTools;

    /// <summary>
    /// This is the main program.
    /// </summary>
    internal class Programm
    {
        private static BikeDbContext ctx = CreateCtx.CreateBikeDbContext();

        private static BikeRepository bikeRepo = CreateRepo.CreateBikeRepo(ctx);
        private static BrandRepository brandRepo = CreateRepo.CreateBrandRepo(ctx);
        private static OwnerRepository ownerRepo = CreateRepo.CreateOwnerRepo(ctx);
        private static ServiceRepository serviceRepo = CreateRepo.CreateServiceRepo(ctx);
        private static FacebookGroupRepository fbRepo = CreateRepo.CreateFacebookGroupRepo(ctx);
        private static OwnerFacebookGroupRepository g = CreateRepo.CreateOwnerFacebookGroupRepo(ctx);

        private static BikeLogic bikeLogic = CreateLogic.CreateBikeLogic(bikeRepo, brandRepo, ownerRepo, serviceRepo, fbRepo, g);
        private static BrandLogic brandLogic = CreateLogic.CreateBrandLogic(bikeRepo, brandRepo, ownerRepo, serviceRepo, fbRepo, g);
        private static OwnerLogic ownerLogic = CreateLogic.CreateOwnerLogic(bikeRepo, brandRepo, ownerRepo, serviceRepo, fbRepo, g);
        private static ServiceLogic serviceLogic = CreateLogic.CreateServiceLogic(bikeRepo, brandRepo, ownerRepo, serviceRepo, fbRepo, g);
        private static FacebookGroupLogic fbLogic = CreateLogic.CreateFacebookGroupLogic(bikeRepo, brandRepo, ownerRepo, serviceRepo, fbRepo, g);
        private static OwnerFacebookGroupLogic ofbLogic = CreateLogic.CreateOwnerFacebookGroupLogic(bikeRepo, brandRepo, ownerRepo, serviceRepo, fbRepo, g);

        /// <summary>
        /// This is the main method.
        /// </summary>
        private static void Main()
        {
            string valasztas;
            do
            {
                Console.WriteLine("1 - Motor menü");
                Console.WriteLine("2 - Márka menü");
                Console.WriteLine("3 - Tulajdonos menü");
                Console.WriteLine("4 - Szervíz menü");
                Console.WriteLine("5 - Facebook");
                Console.WriteLine("6 - Kilépés");
                Console.Write("Az ön választása: ");
                valasztas = Console.ReadLine();

                switch (valasztas)
                {
                    case "1":
                        Console.Clear();
                        var bikeMenu = new ConsoleMenu()
                            .Add("List all bikes", () => ListAllBikes())
                            .Add("List one bikes", () => ListOneBike())
                            .Add("Add a new bike", () => AddNewBike())
                            .Add("DeleteBike", () => DeleteBike())
                            .Add("Change a bike's price", () => ChangeBikePrice())
                            .Add("Change a bike's name", () => ChangeBikeName())
                            .Add("Sell a bike", () => SellBike())
                            .Add("Motorok a legrégebbi gyártóval (Logic)", () => BikesWithTheOldestBrandLogic())
                            .Add("Motorok a legrégebbi gyártóval (Logic, egybe)", () => BikesWithTheOldestBrandLogic2())
                            .Add("Motorok a legrégebbi gyártóval (Task)", () => BikesWithTheOldestBrandTask())
                            .Add("Átlagos árak márkánként (Logic)", () => AveragePriceByBrandLogic())
                            .Add("Átlagos árak márkánként (Test)", () => AveragePriceByBrandTask())
                            .Add("Close", ConsoleMenu.Close);
                        bikeMenu.Show();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        var brandMenu = new ConsoleMenu()
                            .Add("Márkák listázása", () => ListAllBrands())
                            .Add("Márka hozzáadása", () => AddBrand())
                            .Add("Márka nevének módosítása", () => ChangeBrandName())
                            .Add("Márka törlése", () => DeleteBrand())
                            .Add("Átlagos ára egy márkának (Logic)", () => AveragePriceOfOneBrandLogic())
                            .Add("Átlagos ára egy márkának (Task)", () => AveragePriceOfOneBrandTask())
                            .Add("Close", ConsoleMenu.Close);
                        brandMenu.Show();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        var ownerMenu = new ConsoleMenu()
                            .Add("Tulajdonosok listázása", () => ListAllOwners())
                            .Add("Egy tulajdonos lekérdezése", () => GetOneOwner())
                            .Add("Tulajdonos hozzáadása", () => AddOwner())
                            .Add("Tulajdonos vagyonánka növelése", () => AddMoney())
                            .Add("Tulajdonos vagyonának csökkentése", () => TakeMoney())
                            .Add("Tulajdonos eltávolítása", () => DeleteOwner())
                            .Add("Tulajdonos kedvenc márkája (Logic)", () => OwnersFavouriteBrandLogic())
                            .Add("Close", ConsoleMenu.Close);
                        ownerMenu.Show();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        var serviceMenu = new ConsoleMenu()
                            .Add("Szervizek listázása", () => ListAllServiceStations())
                            .Add("Egy szervíz listázása", () => GetOneServiceStation())
                            .Add("Szervízállomás hozzáadása", () => AddServiceStation())
                            .Add("Szervízállomás törlése", () => DeleteServiceStation())
                            .Add("Motor szervizelése", () => AddBikeToServiceStation())
                            .Add("Motor törlése szervízből", () => DeleteBikeFromServiceStation())
                            .Add("Szervízállomás nevének megváltoztatása", () => ChangeServiceStationsName())
                            .Add("Munkás felvétele", () => HireWOrker())
                            .Add("Munkás elbocsátása", () => FireWOrker())
                            .Add("Szervízállomás kapacitásának megváltoztatása", () => ModifyCapacty())
                            .Add("Legkedveltebb szervízállomás", () => MostLikedServiceStation())
                            .Add("Legkedveltebb szervízállomás (Task)", () => MostLikedServiceStationTask())
                            .Add("Close", ConsoleMenu.Close);
                        serviceMenu.Show();
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        var facebookGroupMenu = new ConsoleMenu()
                            .Add("Facebook csoportok listázása", () => ListAllFacebookGroups())
                            .Add("Egy Facebook csoport listázása", () => GetOneFacebookGroup())
                            .Add("Facebook csoport hozzáadása", () => AddNewFacebookGroup())
                            .Add("Facebook csoport törlése", () => DeleteFacebookGroup())
                            .Add("Tulajdonos Facebook csoporthoz adása", () => AddOwnerToGroup())
                            .Add("Tulajdonos törlése Facebook csoportból", () => RemoveOwnerFromGroup())
                            .Add("Facebook csoport nevének megváltoztatása", () => ChangeGroupsName())
                            .Add("Motorok egy Facebook csoportban", () => BikesByFBGroup())
                            .Add("Motorok egy Facebook csoportban2", () => BikesByFBGroup2())
                            .Add("Motorok egy Facebook csoportban (Task)", () => BikesByFBGroupTask())
                            .Add("Close", ConsoleMenu.Close);
                        facebookGroupMenu.Show();
                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Viszlát!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Helytelen választás!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            while (valasztas != "6");
        }

        private static void ListAllBikes()
        {
            var bikes = bikeLogic.GetAll();

            foreach (var bike in bikes)
            {
                Console.WriteLine(bike.Id + " " + bike.Brand.Name + " " + bike.Model + " " + bike.BasePrice + " "
                    + bike.Owner.Name);
            }

            Console.ReadKey();
        }

        private static void ListOneBike()
        {
            Console.WriteLine("Melyik motort keresi? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            var bike = bikeLogic.GetOne2(id);

            Console.WriteLine(bike.Id + " " + bike.Brand.Name + " " + bike.Model + " " + bike.BasePrice + " "
                    + bike.Owner.Name);

            Console.ReadKey();
        }

        private static void AddNewBike()
        {
            Console.WriteLine("Melyik márkához tartozik az új motor? (id)");
            int brandId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Mi legyen az új motor modell neve?");
            string modelName = Console.ReadLine();

            Console.WriteLine("Ki legyen a tulajdonosa? (id)");
            int ownerId = Convert.ToInt32(Console.ReadLine());
            Owner buyer = ownerLogic.GetOne2(ownerId);

            Console.WriteLine("Mi legyen az új motor ára?");
            int price = Convert.ToInt32(Console.ReadLine());

            Bike newBike = new Bike()
            {
                BasePrice = price,
                Model = modelName,
                OwnerId = ownerId,
                BrandId = brandId,
            };
            try
            {
                bikeLogic.AddBike(newBike, buyer);
                Console.WriteLine("Sikeres vásárlás!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private static void DeleteBike()
        {
            Console.WriteLine("Melyik motort szeretné törölni? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            Bike bikeToDelete = bikeLogic.GetOne2(id);

            try
            {
                bikeLogic.DeleteBike(id);
                Console.WriteLine("Motor sikeresen törölve!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private static void ChangeBikePrice()
        {
            Console.WriteLine("Melyik motort keresi? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            Bike bike = bikeLogic.GetOne2(id);

            Console.WriteLine("Mi legyen az új ára?");
            int newPrice = Convert.ToInt32(Console.ReadLine());

            try
            {
                bikeLogic.ChangePrice(id, newPrice);
                Console.WriteLine("Sikeres módosítás!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private static void ChangeBikeName()
        {
            Console.WriteLine("Melyik motort keresi? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            Bike bike = bikeLogic.GetOne2(id);

            Console.WriteLine("Mi legyen az új neve?");
            string newName = Console.ReadLine();

            try
            {
                bikeLogic.ChangeName(id, newName);
                Console.WriteLine("Sikeres módosítás!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private static void SellBike()
        {
            Console.WriteLine("Melyik motort szeretné eladni? (id)");
            int bikeId = Convert.ToInt32(Console.ReadLine());
            Bike bikeToSell = bikeLogic.GetOne2(bikeId);

            Console.WriteLine("Ki a vevő? (id)");
            int buyerId = Convert.ToInt32(Console.ReadLine());

            if (bikeToSell != null)
            {
                int sellerid = bikeToSell.OwnerId;
                Owner seller = ownerLogic.GetOne2(sellerid);
                Owner owner = ownerLogic.GetOne2(buyerId);

                if (owner != null)
                {
                    try
                    {
                        bikeLogic.SellBike(bikeId, owner, seller);
                        Console.WriteLine("Az eladás sikeres volt!");
                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Tulajdonos nem található, kérem ellenőrizze az adatokat!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Motor nem található, kérem ellenőrizze az adatokat!");
                Console.ReadKey();
            }
        }

        private static void AddBrand()
        {
            Console.WriteLine("Mi az új márka neve?");
            string name = Console.ReadLine();
            Console.WriteLine("Mi az alapítási órszág?");
            string country = Console.ReadLine();
            Console.WriteLine("Mikor alapították?");
            int date = Convert.ToInt32(Console.ReadLine());

            Brand brand = new Brand()
            {
                Name = name,
                Country = country,
                Established = date,
            };

            brandLogic.AddBrand(brand);
        }

        private static void ChangeBrandName()
        {
            Console.WriteLine("Melyik márka nevét szeretné megváltoztatni? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            Brand brand = brandLogic.GetOne2(id);
            if (brand != null)
            {
                Console.WriteLine("Mi legyen a márka új neve?");
                string newName = Console.ReadLine();

                brandLogic.ChangeName(id, newName);
                Console.WriteLine("Sikeres módosítás!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ilyen márka nem létezik, kérem ellenőrizze az adatokat.");
                Console.ReadKey();
            }
        }

        private static void DeleteBrand()
        {
            Console.WriteLine("Melyik márkát szeretné törölni? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            Brand brandToDelete = brandLogic.GetOne2(id);
            if (brandToDelete != null)
            {
                brandLogic.DeleteBrand(id);
                Console.WriteLine("Márka sikeresen törölve!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ilyen márka nem létezik, kérem ellenőrizze az adatokat.");
                Console.ReadKey();
            }
        }

        private static void ListAllBrands()
        {
            foreach (var brand in brandLogic.GetAll())
            {
                Console.WriteLine(brand.Id + " " + brand.Name + " " + brand.Country + " " + brand.Established);
            }

            Console.ReadKey();
        }

        private static void AddOwner()
        {
            Console.WriteLine("Az új tulajdonos neve:");
            string nev = Console.ReadLine();

            Console.WriteLine("Az új tulajdonos vagyona:");
            int money = Convert.ToInt32(Console.ReadLine());

            Owner newOwner = new Owner()
            {
                Money = money,
                Name = nev,
            };

            ownerLogic.AddOwner(newOwner);
        }

        private static void AddMoney()
        {
            Console.WriteLine("Meliyk tulajnak szeretne pénz utalni? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            Owner owner = ownerLogic.GetOne2(id);

            if (owner != null)
            {
                Console.WriteLine("Mennyi pénzt szeretne utalni?");
                int amount = Convert.ToInt32(Console.ReadLine());

                ownerLogic.AddMoney(id, amount);

                Console.WriteLine("Az átutalás sikeresen megtörtént!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nem található tulajdonos!");
                Console.ReadKey();
            }
        }

        private static void TakeMoney()
        {
            Console.WriteLine("Meliyk tulajtól szeretne pénz elvenni? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            Owner owner = ownerLogic.GetOne2(id);

            try
            {
                Console.WriteLine("Mennyi pénzt szeretne elvenni?");
                int amount = Convert.ToInt32(Console.ReadLine());

                ownerLogic.TakeMoney(id, amount);

                Console.WriteLine("Az átutalás sikeresen megtörtént!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private static void DeleteOwner()
        {
            Console.WriteLine("Melyik tulajdonost szeretné eltávolítani? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            Owner owner = ownerLogic.GetOne2(id);

            if (owner != null)
            {
                try
                {
                    ownerLogic.DeleteOwner(id);
                    Console.WriteLine("A törlés sikeresen megtörtént!");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nem található tulajdonos!");
                Console.ReadKey();
            }
        }

        private static void ListAllOwners()
        {
            foreach (var owner in ownerLogic.GetAll())
            {
                Console.WriteLine(owner.Id + " " + owner.Name + " " + owner.Money);
            }

            Console.ReadKey();
        }

        private static void GetOneOwner()
        {
            Console.WriteLine("Melyik tulajdonost szeretbé lekérdezni?");
            int id = Convert.ToInt32(Console.ReadLine());
            var owner = ownerLogic.GetOne2(id);

            if (owner != null)
            {
                Console.WriteLine(owner.Id + " " + owner.Name + " " + owner.Money);
                Console.WriteLine("-------------------------------------------\n" +
                    "Motrojai:");
                if (owner.Bikes.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("A tulajdonosnak nincsenek motorjai....");
                    Console.ReadKey();
                }
                else
                {
                    foreach (var bike in owner.Bikes)
                    {
                        Console.WriteLine(bike.Id + " " + bike.Brand.Name + " " + bike.Model);
                    }

                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nem található tulajdonos!");
                Console.ReadKey();
            }
        }

        private static void ListAllServiceStations()
        {
            foreach (var item in serviceLogic.GetAll())
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.MaxSpace + " munkások száma:" + item.EmployeeNumer);
            }

            Console.ReadLine();
        }

        private static void GetOneServiceStation()
        {
            Console.WriteLine("Melyik szervíz állomás adatait szeretné lekérni? (id)");
            int id = Convert.ToInt32(Console.ReadLine());

            var service = serviceLogic.GetOne2(id);

            Console.WriteLine(service.Id + " neve:" + service.Name + " kapacitás" + service.MaxSpace
                + " dolgozók száma:" + service.EmployeeNumer + " ");
            Console.WriteLine("---------------------------------------\n" +
                "A szervízben található motorok:");
            if (service.BikesInService.Count != 0)
            {
                foreach (var bike in service.BikesInService)
                {
                    Console.WriteLine(bike.Id + " " + bike.Brand.Name + " " + bike.Model + " " + bike.Owner.Name);
                }

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("A szervízben nem található motor.");
                Console.ReadLine();
            }
        }

        private static void AddServiceStation()
        {
            Console.WriteLine("Az új szervíz neve:");
            string nev = Console.ReadLine();
            Console.WriteLine("Az új szervíz dolgozóinak száma:");
            int dszam = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Az új szervíz kapacitása:");
            int kapacitas = Convert.ToInt32(Console.ReadLine());

            Service service = new Service()
            {
                Name = nev,
                MaxSpace = kapacitas,
                EmployeeNumer = dszam,
                BikesInService = new List<Bike>(),
            };

            serviceLogic.AddServicestation(service);

            Console.Clear();
            Console.WriteLine("Szervízállomás sikeresen hozzáadva!");
            Console.ReadKey();
        }

        private static void DeleteServiceStation()
        {
            Console.WriteLine("Melyik szervízállomást szeretné törölni? (id)");
            int id = Convert.ToInt32(Console.ReadLine());

            var service = serviceLogic.GetOne2(id);

            try
            {
                serviceLogic.DeleteServicestation(id);
                Console.Clear();
                Console.WriteLine("Szervíz törölve!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private static void AddBikeToServiceStation()
        {
            Console.WriteLine("Melyik motort szeretné szervizelni?");
            int id = Convert.ToInt32(Console.ReadLine());
            var bike = bikeLogic.GetOne2(id);

            if (bike != null)
            {
                Console.WriteLine("Melyik szervízben szeretné szervizelni?");
                int serviceid = Convert.ToInt32(Console.ReadLine());
                var service = serviceLogic.GetOne2(serviceid);
                if (service != null)
                {
                    serviceLogic.AddBikeToServicestation(serviceid, bike);
                    Console.Clear();
                    Console.WriteLine("Motor sikeresen hozzáadva!");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ez a szervíz nem található!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ez a motor nem található!");
                Console.ReadKey();
            }
        }

        private static void DeleteBikeFromServiceStation()
        {
            Console.WriteLine("Melyik motort szeretné törölni a szervízből?");
            int id = Convert.ToInt32(Console.ReadLine());
            var bike = bikeLogic.GetOne2(id);

            Console.WriteLine("Melyik szervízből szeretné törölni?");
            int serviceid = Convert.ToInt32(Console.ReadLine());
            var service = serviceLogic.GetOne2(serviceid);
            try
            {
                serviceLogic.DeleteBikeFromServicestation(serviceid, bike);
                Console.Clear();
                Console.WriteLine("Motor sikeresen törölve a szervízből!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private static void ChangeServiceStationsName()
        {
            Console.WriteLine("Melyik szervíz nevét szeretné módosítani? (id)");
            int serviceid = Convert.ToInt32(Console.ReadLine());
            var service = serviceLogic.GetOne2(serviceid);

            if (service != null)
            {
                Console.WriteLine("Mi legyen a szervízállomás  új neve?");
                string newName = Console.ReadLine();
                serviceLogic.ChangeName(serviceid, newName);
                Console.Clear();
                Console.WriteLine("A szervíz neve megváltozott!");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ez a szervíz nem található!");
                Console.ReadKey();
            }
        }

        private static void HireWOrker()
        {
            Console.WriteLine("Melyik szervízbe szeretne új munkást felvenni? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            var service = serviceLogic.GetOne2(id);
            if (service != null)
            {
                serviceLogic.HireNewWorker(id);
                Console.Clear();
                Console.WriteLine("Munkás felvéve!");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ez a szervíz nem található!");
                Console.ReadKey();
            }
        }

        private static void FireWOrker()
        {
            Console.WriteLine("Melyik szervízből szeretne munkást kirúgni? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            var service = serviceLogic.GetOne2(id);
            if (service != null)
            {
                serviceLogic.FireWorker(id);
                Console.Clear();
                Console.WriteLine("Munkás elbocsátva...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ez a szervíz nem található!");
                Console.ReadKey();
            }
        }

        private static void ModifyCapacty()
        {
            Console.WriteLine("Melyik szervíz kapacitását szeretné megváltoztatni? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            var service = serviceLogic.GetOne2(id);
            if (service != null)
            {
                Console.WriteLine("Mi legyen a szervíz új kapacitása?");
                int db = Convert.ToInt32(Console.ReadLine());
                serviceLogic.ChangeCapacity(id, db);
                Console.Clear();
                Console.WriteLine("A szervíz kapacitása megváltozott...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ez a szervíz nem található!");
                Console.ReadKey();
            }
        }

        private static void ListAllFacebookGroups()
        {
            Console.Clear();
            foreach (var group in fbRepo.GetAll())
            {
                Console.WriteLine(group.Id + " " + group.Name + " " + group.MemberCount + " " + group.IsBrandSpecifiad
                    + " " + group.SpecifiedBrand);
                Console.WriteLine("Tulajdonosok a csoportban:\n---------------------------");
                var tulajok2 = group.OwnerFBGroup;
                if (tulajok2 != null)
                {
                    foreach (var owner in tulajok2)
                    {
                        Console.WriteLine(owner.Owner.Id + " " + owner.Owner.Name);
                        Console.WriteLine("\tA tulaj motorjai:");
                        Console.WriteLine("\t--------------------");
                        foreach (var bike in owner.Owner.Bikes)
                        {
                            Console.WriteLine("\t" + bike.Id + " " + bike.Brand.Name + " " + bike.Model);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nincs tualj");
                }

                Console.WriteLine("\n");
            }

            Console.ReadKey();
        }

        private static void GetOneFacebookGroup()
        {
            Console.Clear();
            Console.WriteLine("Melyik csoportot szeretné lekérdezni? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            var fbgroup = fbLogic.GetOne2(id);

            if (fbgroup != null)
            {
                var tulajok = fbgroup.OwnerFBGroup;
                Console.WriteLine(fbgroup.Id + " " + fbgroup.Name + " " + fbgroup.MemberCount + " " + fbgroup.IsBrandSpecifiad
                    + " " + fbgroup.SpecifiedBrand);
                Console.WriteLine("Tulajdonosok a csoportban:\n---------------------------");
                foreach (var owner in tulajok)
                {
                    Console.WriteLine(owner.Owner.Id + " " + owner.Owner.Name);
                    Console.WriteLine("A tulaj motorjai:");
                    Console.WriteLine("--------------------");
                    foreach (var bike in owner.Owner.Bikes)
                    {
                        Console.WriteLine(bike.Id + " " + bike.Brand.Name + " " + bike.Model);
                    }
                }
            }
            else
            {
                Console.WriteLine("Ez a csoport nem található!");
            }

            Console.ReadKey();
        }

        private static void AddNewFacebookGroup()
        {
            Console.WriteLine("Mi legyen az új csoport neve?");
            string nev = Console.ReadLine();
            Console.WriteLine("Márkaspecifikus legyen a csoport? (i/n)");
            string valasz = Console.ReadLine();
            bool isBrandSpecific = false;
            string valaszMarka = string.Empty;
            if (valasz == "i")
            {
                Console.WriteLine("Mi legyen a csoport márkája?");
                valaszMarka = Console.ReadLine();
                isBrandSpecific = true;
            }

            var group = new FacebookGroup()
            {
                Name = nev,
                IsBrandSpecifiad = isBrandSpecific,
                SpecifiedBrand = valaszMarka,
            };

            fbLogic.AddFacebookGroup(group);

            Console.Clear();
            Console.WriteLine("Csoport sikeresen hozzáadva!");
            Console.ReadKey();
        }

        private static void DeleteFacebookGroup()
        {
            Console.WriteLine("Melyik csoportot szeretné törölni? (id)");
            int id = Convert.ToInt32(Console.ReadLine());
            FacebookGroup fbg = fbLogic.GetOne2(id);

            try
            {
                fbLogic.DeleteFacebookGroup(id);
                Console.Clear();
                Console.WriteLine("Csoport sikeresen törölve!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private static void AddOwnerToGroup()
        {
            Console.WriteLine("Melyik csoporthoz szeretne új tagot hozzáadni? (id)");
            int groupId = Convert.ToInt32(Console.ReadLine());
            var fbgroup = fbLogic.GetOne2(groupId);

            Console.WriteLine("Melyik tulajdonost szeretné hozzáadni a csoporthoz? (id)");
            int ownerId = Convert.ToInt32(Console.ReadLine());
            var owner = ownerLogic.GetOne2(ownerId);

            try
            {
                fbLogic.AddOwnerToGroup(groupId, owner);
                Console.WriteLine("Tulajdonos sikeresen hozzáadva");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private static void RemoveOwnerFromGroup()
        {
            Console.WriteLine("Melyik csoportból szeretne tagot eltávolítani? (id)");
            int groupId = Convert.ToInt32(Console.ReadLine());
            var fbgroup = fbLogic.GetOne2(groupId);

            Console.WriteLine("Melyik tulajdonost szeretné eltávolítani? (id)");
            int ownerId = Convert.ToInt32(Console.ReadLine());
            var owner = ownerLogic.GetOne2(ownerId);

            try
            {
                ofbLogic.DeleteOwner(groupId, ownerId);
                Console.WriteLine("Tulajdonos sikeresen eltávolítva");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private static void ChangeGroupsName()
        {
            Console.WriteLine("Melyik csoport nevét szeretné megváltoztatni? (id)");
            int groupId = Convert.ToInt32(Console.ReadLine());
            var fbgroup = fbLogic.GetOne2(groupId);

            try
            {
                Console.WriteLine("Mi legyen a csoport új neve?");
                string newName = Console.ReadLine();

                fbLogic.ChangeName(groupId, newName);
                Console.Clear();
                Console.WriteLine("Csoport sikeresen módosítva!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private static void AveragePriceByBrandLogic()
        {
            var avg = bikeLogic.AverageBikePriceByBrandLogic();

            foreach (var item in avg)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void AveragePriceOfOneBrandLogic()
        {
            var allbikes = bikeLogic.GetAll();

            Console.WriteLine("Melyik márka átlagos árát szeretné lekérdezni?");
            string brand = Console.ReadLine();

            var atlagar = brandLogic.AveragePriceOfOneBrand(allbikes, brand);

            Console.WriteLine(atlagar);

            Console.ReadLine();
        }

        private static void BikesWithTheOldestBrandLogic()
        {
            var bikes = bikeLogic.BikesWithTheOldestBrandLogic();

            foreach (var bike in bikes)
            {
                Console.WriteLine(bike);
            }

            Console.ReadLine();
        }

        private static void BikesWithTheOldestBrandLogic2()
        {
            var bikes = bikeLogic.BikesWithTheOldestBrandLogic2();

            foreach (var bike in bikes)
            {
                Console.WriteLine(bike);
            }

            Console.ReadLine();
        }

        private static void OwnersFavouriteBrandLogic()
        {
            Console.WriteLine("Melyik tulajdonos kedvenc márkáját szeretné lekérni? (id)");
            Console.WriteLine("----------------------------");
            var owners = ownerLogic.GetAll();
            foreach (var owner in owners)
            {
                Console.WriteLine(owner.Id + " " + owner.Name);
            }

            Console.WriteLine("----------------------------");

            Console.Write("Az ön választása:");
            int id = Convert.ToInt32(Console.ReadLine());

            var asd = ownerLogic.OwnersFavoriteBrandLogic(id);

            Console.WriteLine(asd);

            Console.ReadKey();
        }

        private static void MostLikedServiceStation()
        {
            var services = serviceLogic.MostLikedServiceStation();

            foreach (var service in services)
            {
                Console.WriteLine(service);
            }

            Console.ReadLine();
        }

        private static void BikesByFBGroup()
        {
            Console.WriteLine("Melyik Facebook csoport motorojait szeretné lekérni?");
            int id = Convert.ToInt32(Console.ReadLine());

            var bikes = bikeLogic.GetAll()
                .Join(
                ofbLogic.GetAll(),
                bike => bike.OwnerId,
                group => group.OwnerId,
                (b, g) => new
                {
                    bikeModel = b.Model,
                    brandId = b.BrandId,
                    brandName = b.Brand.Name,
                    groupid = g.FBGroupId,
                    ownerid = g.OwnerId,
                    group = g.FacebookGroup.Name,
                    owner = b.Owner.Name,
                })
                .Where(x => x.groupid == id)
                .Select(x => x.group + ", márka id: " + x.brandId + ", márka: " + x.brandName + ", modell: " + x.bikeModel + ", tulajdonos: " + x.owner);

            foreach (var item in bikes)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void BikesByFBGroup2()
        {
            Console.WriteLine("Melyik Facebook csoport motorojait szeretné lekérni?");
            int id = Convert.ToInt32(Console.ReadLine());

            var bikes = ofbLogic.BikesByFbGroup(id);

            foreach (var item in bikes)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void BikesWithTheOldestBrandTask()
        {
            var bikes = bikeLogic.BikesWithOldestBrandTask();
            var taskResult = bikes.Result;

            foreach (var bike in taskResult)
            {
                Console.WriteLine(bike);
            }

            Console.ReadLine();
        }

        private static void AveragePriceByBrandTask()
        {
            var avg = bikeLogic.AveragePriceByBrandTask();
            var testResult = avg.Result;

            foreach (var item in testResult)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void AveragePriceOfOneBrandTask()
        {
            Console.WriteLine("Melyik márka átlagos árát szeretné lekérdezni?");
            string brand = Console.ReadLine();

            var atlagar = brandLogic.AveragePriceOfOneBrandTask(brand);
            var taskResult = atlagar.Result;

            Console.WriteLine(taskResult);

            Console.ReadLine();
        }

        private static void MostLikedServiceStationTask()
        {
            var services = serviceLogic.MostLikedServiceStationTask();
            var taskResult = services.Result;

            foreach (var service in taskResult)
            {
                Console.WriteLine(service);
            }

            Console.ReadLine();
        }

        private static void BikesByFBGroupTask()
        {
            Console.WriteLine("Melyik Facebook csoport motorojait szeretné lekérni?");
            int id = Convert.ToInt32(Console.ReadLine());

            var bikes = ofbLogic.BikesByFBGroupTask(id);
            var taskResult = bikes.Result;

            foreach (var item in taskResult)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
