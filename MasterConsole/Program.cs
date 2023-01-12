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


            //=====================================category_group==============================================

            //create category_group
            //var newcategory_group = _masterVbApi.RepositoryManager.category_group.Createcategory_Group(new VBMasterDbLib.Model.category_Group
            //{
            //    Cagro_name = "POOL",
            //    Cagro_description = "blablaablabla",
            //    Cagro_type = "facility",
            //    Cagro_icon = "",
            //    Cagro_icon_url = ""
            //});
            //Console.WriteLine($"New category_group :{newcategory_group}");

            ////delete category_group
            //var rowDelete = _masterVbApi.RepositoryManager.category_group.Deletecategory_Group(10);
            //Console.WriteLine($"Delete category_group Row : {rowDelete}");

            //find all category_group
            //var listcategory_group = _masterVbApi.RepositoryManager.category_group.FindAllcategory_Group();
            //foreach (var item in listcategory_group)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //// find category_group by id
            //var Findcategory_groupById = _masterVbApi.RepositoryManager.category_group.Findcategory_GroupById(2);
            //Console.WriteLine($"Found category_group: {Findcategory_groupById}");

            //Update category_group By ID
            //var updatecategory_group = _masterVbApi.RepositoryManager.category_group.Updatecategory_GroupById
            //(8,"SWIMMING","AAAAA","service","blabla.png","www.test.com");
            //Console.WriteLine($"{updatecategory_group}");

            //update category_group by SP
            var updatecategory_groupBySp = _masterVbApi.RepositoryManager.category_group.Updatecategory_GroupBySp(8, "SWIMMING", "BBBB", "service", "blabla.png", "www.test.com");
            //var updatecategory_groupSpResult = _masterVbApi.RepositoryManager.Regions.FindRegionsById(20);
            Console.WriteLine($"{updatecategory_groupBySp}");

            //=====================================category_group==============================================

            //=====================================policy_category_group==============================================

            //create policy_category_group
            //var newpolicy_category_group = _masterVbApi.RepositoryManager.Policy_Category_Group.CreatePolicy_Category_Group(new VBMasterDbLib.Model.Policy_Category_Group
            //{
            //    Poca_poli_id = 4,
            //    Poca_cagro_id = 4
            //});
            //Console.WriteLine($"New policy_category_group :{newpolicy_category_group}");

            ////delete policy_category_group
            //var rowDelete = _masterVbApi.RepositoryManager.Policy_Category_Group.DeletePolicy_Category_Group(2);
            //Console.WriteLine($"Delete policy_category_group Row : {rowDelete}");

            //find all policy_category_group
            //var listpolicy_category_group = _masterVbApi.RepositoryManager.Policy_Category_Group.FindAllPolicy_Category_Group();
            //foreach (var item in listpolicy_category_group)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //// find policy_category_group by id
            //var Findpolicy_category_groupById = _masterVbApi.RepositoryManager.Policy_Category_Group.FindPolicy_Category_GroupById(2);
            //Console.WriteLine($"Found policy_category_group: {Findpolicy_category_groupById}");

            //Update policy_category_group By ID
            //var updatepolicy_category_group = _masterVbApi.RepositoryManager.Policy_Category_Group.UpdatePolicy_Category_GroupById
            //(4, 7);
            //Console.WriteLine($"{updatepolicy_category_group}");

            //update policy_category_group by SP
            //var updatepolicy_category_groupBySp = _masterVbApi.RepositoryManager.Policy_Category_Group.UpdatePolicy_Category_GroupBySp(4, 3);
            ////var updatepolicy_category_groupSpResult = _masterVbApi.RepositoryManager.Regions.FindRegionsById(20);
            //Console.WriteLine($"{updatepolicy_category_groupBySp}");

            //=====================================policy_category_group==============================================

            //=====================================price_items==============================================

            //create price_items
            //var newprice_items = _masterVbApi.RepositoryManager.price_items.Createprice_Items(new VBMasterDbLib.Model.price_items
            //{
            //    Prit_name = "DIAMOND",
            //    Prit_price = 100000,
            //    Prit_description = "DIAMOND",
            //    Prit_type = "SNACK"
            //});
            //Console.WriteLine($"New price_items :{newprice_items}");

            ////delete price_items
            //var rowDelete = _masterVbApi.RepositoryManager.price_items.Deleteprice_Items(10);
            //Console.WriteLine($"Delete price_items Row : {rowDelete}");

            //find all price_items
            //var listprice_items = _masterVbApi.RepositoryManager.price_items.FindAllprice_Items();
            //foreach (var item in listprice_items)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //// find price_items by id
            //var Findprice_itemsById = _masterVbApi.RepositoryManager.price_items.Findprice_ItemsById(2);
            //Console.WriteLine($"Found price_items: {Findprice_itemsById}");

            //Update price_items By ID
            //var updateprice_items = _masterVbApi.RepositoryManager.price_items.Updateprice_ItemsById
            //(5,"BRONJE",5000, "AAAAA", "FACILITY",DateTime.Now);
            //Console.WriteLine($"{updateprice_items}");

            //update price_items by SP
            //var updateprice_itemsBySp = _masterVbApi.RepositoryManager.price_items.Updateprice_ItemsBySp(5, "anjay", 10000, "BBBB", "FACILITY", DateTime.Now);
            ////var updateprice_itemsSpResult = _masterVbApi.RepositoryManager.Regions.FindRegionsById(20);
            //Console.WriteLine($"{updateprice_itemsBySp}");

            //=====================================price_items==============================================


            //=====================================POLICY==============================================

            //create policy
            //var newpolicy = _masterVbApi.RepositoryManager.policy.CreatePolicy(new VBMasterDbLib.Model.Policy
            //{
            //    Poli_name = "DIAMOND",
            //    Poli_description = "AAAAAAAAAAAAAAAAAAA"
            //});
            //Console.WriteLine($"New policy :{newpolicy}");

            ////delete policy
            //var rowDelete = _masterVbApi.RepositoryManager.policy.DeletePolicy(1);
            //Console.WriteLine($"Delete policy Row : {rowDelete}");

            //find all policy
            //var listpolicy = _masterVbApi.RepositoryManager.policy.FindAllPolicy();
            //foreach (var item in listpolicy)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //// find policy by id
            //var FindpolicyById = _masterVbApi.RepositoryManager.policy.FindPolicyById(2);
            //Console.WriteLine($"Found policy: {FindpolicyById}");

            //Update policy By ID
            //var updatepolicy = _masterVbApi.RepositoryManager.policy.UpdatePolicyById(5, "Satpam", "asdasdasd");
            //Console.WriteLine($"{updatepolicy}");

            //update policy by SP
            //var updatepolicyBySp = _masterVbApi.RepositoryManager.policy.UpdatePolicyBySp(5, "BBBBBBBBBBBBBB", "CCCCCCCCCCC", true);
            ////var updatepolicySpResult = _masterVbApi.RepositoryManager.Regions.FindRegionsById(20);
            //Console.WriteLine($"{updatepolicyBySp}");

            //=====================================POLICY==============================================

            //=====================================Service_Task==============================================

            //create Service_Task
            //var newService_Task = _masterVbApi.RepositoryManager.ServiceTask.CreateServiceTask(new VBMasterDbLib.Model.service_task
            //{
            //    Seta_name = "Waiter",
            //    Seta_seq = 1
            //});
            //Console.WriteLine($"New Service_Task :{newService_Task}");

            ////delete Service_Task
            //var rowDelete = _masterVbApi.RepositoryManager.ServiceTask.DeleteServiceTask(6);
            //Console.WriteLine($"Delete Service_Task Row : {rowDelete}");

            //find all Service_Task
            //var listService_Task = _masterVbApi.RepositoryManager.ServiceTask.FindAllServiceTask();
            //foreach (var item in listService_Task)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //// find Service_Task by id
            //var FindService_TaskById = _masterVbApi.RepositoryManager.ServiceTask.FindServiceTaskById(1);
            //Console.WriteLine($"Found Service_Task: {FindService_TaskById}");

            //Update Service_Task By ID
            //var updateService_Task = _masterVbApi.RepositoryManager.ServiceTask.UpdateServiceTaskById(1,"Satpam",1);
            //Console.WriteLine($"{updateService_Task}");

            //update Service_Task by SP
            //var updateService_TaskBySp = _masterVbApi.RepositoryManager.ServiceTask.UpdateServiceTaskBySp(1, "BBBBBBBBBBBBBB",1, true);
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

