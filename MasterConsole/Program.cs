using Microsoft.Extensions.Configuration;
using Microsoft.Spatial;
using Microsoft.SqlServer.Types;
using System;
using VBMasterDbLib;

namespace RealtaMasterSolution // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        private static IConfigurationRoot? Configuration;
        static void Main(string[] args)
        {
            BuildConfig();
            IHotelRealtaVbApi _masterVbApi = new HotelRealtaVbApi(Configuration?.GetConnectionString("Hotel_Realta"));

            //=====================================Service_Task==============================================

            //create Service_Task
            var newService_Task = _masterVbApi.RepositoryManager.ServiceTask.CreateServiceTask(new VBMasterDbLib.Model.service_task
            {
                seta_name = "Waiter",
                seta_seq = 1
            });
            Console.WriteLine($"New Service_Task :{newService_Task}");

            ////delete Service_Task
            //var rowDelete = _masterVbApi.RepositoryManager.Service_Task.DeleteService_Task("platinum");
            //Console.WriteLine($"Delete Service_Task Row : {rowDelete}");

            //find all Service_Task
            //var listService_Task = _masterVbApi.RepositoryManager.Service_Task.FindAllService_Task();
            //foreach (var item in listService_Task)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //// find Service_Task by id
            //var FindService_TaskById = _masterVbApi.RepositoryManager.Service_Task.FindService_TaskById("GOLD");
            //Console.WriteLine($"Found Service_Task: {FindService_TaskById}");

            //Update Service_Task By ID
            //var updateService_Task = _masterVbApi.RepositoryManager.Service_Task.UpdateService_TaskById("platinum", "aaaaaaaaaaaaaaaaaaaa");
            //Console.WriteLine($"{updateService_Task}");

            //update Service_Task by SP
            //var updateService_TaskBySp = _masterVbApi.RepositoryManager.Service_Task.UpdateService_TaskBySp("platinum", "BBBBBBBBBBBBBB", true);
            ////var updateService_TaskSpResult = _masterVbApi.RepositoryManager.Regions.FindRegionsById(20);
            //Console.WriteLine($"{updateService_TaskBySp}");

            //=====================================Service_Task==============================================

            //=====================================MEMBERS==============================================

            //create members
            //var newMembers = _masterVbApi.RepositoryManager.Members.CreateMembers(new VBMasterDbLib.Model.Members
            //{
            //    Memb_name = "platinum",
            //    Memb_description = null
            //});
            //Console.WriteLine($"New Regions :{newMembers}");

            ////delete members
            //var rowDelete = _masterVbApi.RepositoryManager.Members.DeleteMembers("platinum");
            //Console.WriteLine($"Delete Members Row : {rowDelete}");

            //find all Members
            //var listMembers = _masterVbApi.RepositoryManager.Members.FindAllMembers();
            //foreach (var item in listMembers)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //// find members by id
            //var FindMembersById = _masterVbApi.RepositoryManager.Members.FindMembersById("GOLD");
            //Console.WriteLine($"Found Members: {FindMembersById}");

            //Update Members By ID
            //var updateMembers = _masterVbApi.RepositoryManager.Members.UpdateMembersById("platinum", "aaaaaaaaaaaaaaaaaaaa");
            //Console.WriteLine($"{updateMembers}");

            //update Members by SP
            //var updateMembersBySp = _masterVbApi.RepositoryManager.Members.UpdateMembersBySp("platinum", "BBBBBBBBBBBBBB", true);
            ////var updateMembersSpResult = _masterVbApi.RepositoryManager.Regions.FindRegionsById(20);
            //Console.WriteLine($"{updateMembersBySp}");

            //=====================================MEMBERS==============================================

            //=====================================REGIONS==============================================
            //create Regions
            //var newRegions = _masterVbApi.RepositoryManager.Regions.CreateRegions(new VBMasterDbLib.Model.Regions
            //{
            //    Region_name = "sunda"
            //});
            //Console.WriteLine($"New Regions :{newRegions}");

            ////delete Regions
            //var rowDelete = _masterVbApi.RepositoryManager.Regions.DeleteRegions(28);
            //Console.WriteLine($"Delete Regions Row : {rowDelete}");

            //find all Regions
            //var listRegions = _masterVbApi.RepositoryManager.Regions.FindAllRegions();
            //foreach (var item in listRegions)
            //{
            //    Console.WriteLine($"{item}");
            //}

            // find Regions by id
            //var FindRegionsById = _masterVbApi.RepositoryManager.Regions.FindRegionsById(27);
            //Console.WriteLine($"Found Regions: {FindRegionsById}");

            //Update Regions By ID
            //var updateRegions = _masterVbApi.RepositoryManager.Regions.UpdateRegionsById(25, "MEDAN");
            //Console.WriteLine($"{updateRegions}");

            //update Regions by SP
            //var updateRegionsBySp = _masterVbApi.RepositoryManager.Regions.UpdateRegionsBySp(27, "BOYOLALI", true);
            //var updateRegionsSpResult = _masterVbApi.RepositoryManager.Regions.FindRegionsById(20);
            //Console.WriteLine($"{updateRegionsSpResult}");


            //=====================================REGIONS==============================================

            //=====================================COUNTRY==============================================

            //create Country
            //var newCountry = _masterVbApi.RepositoryManager.Country.CreateCountry(new VBMasterDbLib.Model.Country
            //{
            //    Country_name = "LAMPOENG",
            //    Country_region_id = 9
            //});
            //Console.WriteLine($"New Country :{newCountry}");

            ////delete Country
            //var rowDelete = _masterVbApi.RepositoryManager.Country.DeleteCountry(25);
            //Console.WriteLine($"Delete Country Row : {rowDelete}");

            //find all country
            //var listcountry = _masterVbApi.RepositoryManager.Country.FindAllCountry();
            //foreach (var item in listcountry)
            //{
            //    Console.WriteLine($"{item}");
            //}

            // find country by id
            //var FindCountryById = _masterVbApi.RepositoryManager.Country.FindCountryById(22);
            //Console.WriteLine($"Found country: {FindCountryById}");

            //Update Country By ID
            //var updateCountry = _masterVbApi.RepositoryManager.Country.UpdateCountryById(22, "MEDAN", 14);
            //Console.WriteLine($"{updateCountry}");

            //update Country by SP
            //var updateCountryBySp = _masterVbApi.RepositoryManager.Country.UpdateCountryBySp(22, "BOYOLALI", 10, true);
            ////var updateCountrySpResult = _masterVbApi.RepositoryManager.Country.FindCountryById(20);
            //Console.WriteLine($"{updateCountryBySp}");

            //=====================================COUNTRY==============================================


            //=====================================PROVINCES==============================================

            //Find all Provinces Async
            //var listProvincesAsync = await _masterVbApi.RepositoryManager.Provinces.FindAllProvincesAsync();

            //foreach (var item in listProvincesAsync)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //update Provinces by SP
            //var updateProvincesBySp = _masterVbApi.RepositoryManager.Provinces.UpdateProvincesBySp(26, "Bootcamp ",3, true);
            //var updateProvincesSpResult = _masterVbApi.RepositoryManager.Provinces.FindProvincesById(26);
            //Console.WriteLine($"{updateProvincesSpResult}");

            //Update Provinces By ID
            //var updateProvinces = _masterVbApi.RepositoryManager.Provinces.UpdateProvincesById(25, "YANTO", 4);
            //Console.WriteLine($"{updateProvinces}");

            //var ProvincesUpdateResult = _masterVbApi.RepositoryManager.Provinces.FindProvincesById(25);
            //Console.WriteLine($"{ProvincesUpdateResult}");

            // find provinces by id
            //var FindProvinceById = _masterVbApi.RepositoryManager.Provinces.FindProvincesById(23);
            //Console.WriteLine($"Found Province: {FindProvinceById}");

            //find all provinces
            //var listProvinces = _masterVbApi.RepositoryManager.Provinces.FindAllProvinces();
            //foreach (var item in listProvinces)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //create Provinces
            //var newProvinces = _masterVbApi.RepositoryManager.Provinces.CreateProvinces(new VBMasterDbLib.Model.Provinces
            //{
            //    Prov_id = 26,
            //    Prov_name = "AMBON",
            //    Prov_country_id = 5
            //});

            //Console.WriteLine($"New address :{newProvinces}");

            ////delete region
            //var rowDelete = _masterVbApi.RepositoryManager.Provinces.DeleteProvinces(21);
            //Console.WriteLine($"Delete Provinces Row : {rowDelete}");

            //=====================================PROVINCES==============================================

            //=====================================ADDRESS==============================================
            ////find all address
            //var listAddress = _masterVbApi.RepositoryManager.Address.FindAllAddress();
            //foreach (var item in listAddress)
            //{
            //    Console.WriteLine($"{item}");
            //}

            ////delete Country
            //var rowDelete = _masterVbApi.RepositoryManager.Address.DeleteAddress(71);
            //Console.WriteLine($"Delete Address Row : {rowDelete}");


            //create address
            //var newAddress = _masterVbApi.RepositoryManager.Address.CreateAddress(new VBMasterDbLib.Model.Address
            //{
            //    Addr_Id = 80,
            //    Addr_line1 = "Jl. Danau Limboto",

            //});

            //Console.WriteLine($"New address :{newAddress}");


            // find address by id
            //var FindAddressById = _masterVbApi.RepositoryManager.Address.FindAddressById(20);
            //Console.WriteLine($"Found Address: {FindAddressById}");

            ////Update Address By ID
            //var updateAddress = _masterVbApi.RepositoryManager.Address.UpdateAddressById(20, "Jl. Sentul"," AEON BOGOR","12312",2);
            //Console.WriteLine($"{updateAddress}");

            //update Provinces by SP
            //var updateAddressBySp = _masterVbApi.RepositoryManager.Address.UpdateAddressBySp(20, "Jl. Sentul", " AEON BOGOR", "12312", 2);
            //var updateAddressSpResult = _masterVbApi.RepositoryManager.Address.FindAddressById(26);
            //Console.WriteLine($"{updateAddressSpResult}");

            ////=====================================ADDRESS==============================================




        }




        static void BuildConfig()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            
            Configuration = builder.Build();
            Console.WriteLine(Configuration.GetConnectionString("hotel_realta"));
        }


    }
}
