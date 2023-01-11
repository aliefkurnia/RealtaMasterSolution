Imports VBMasterDbLib.Repository

Namespace Base
    Public Interface IRepositoryManager

        ReadOnly Property Regions As IRegionsRepository
        ReadOnly Property Country As ICountryRepository
        ReadOnly Property Provinces As IProvincesRepository
        ReadOnly Property Address As IAddressRepository
        ReadOnly Property Members As IMembersRepository
        ReadOnly Property ServiceTask As IServiceTaskRepository
        ReadOnly Property price_items As IPrice_ItemsRepository
        ReadOnly Property policy As IPolicyRepository
        ReadOnly Property category_group As ICategory_GroupRepository
        ReadOnly Property Policy_Category_Group As IPolicy_Category_GroupRepository

    End Interface

End Namespace
