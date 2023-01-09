Imports VBMasterDbLib.Repository

Namespace Base
    Public Interface IRepositoryManager

        ReadOnly Property Regions As IRegionsRepository
        ReadOnly Property Country As ICountryRepository
        ReadOnly Property Provinces As IProvincesRepository
        ReadOnly Property Address As IAddressRepository

    End Interface

End Namespace
