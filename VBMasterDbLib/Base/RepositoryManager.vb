Imports VBMasterDbLib.context
Imports VBMasterDbLib.Model
Imports VBMasterDbLib.Repository

Namespace Base
    Public Class RepositoryManager
        Implements IRepositoryManager

        Private _addressRepository As IAddressRepository
        Private _provincesRepository As IProvincesRepository
        Private _countryRepository As ICountryRepository
        Private _regionsRepository As IRegionsRepository
        Private _membersRepository As IMembersRepository
        Private _ServiceTaskRepository As IServiceTaskRepository
        Private _PriceItemsRepository As IPrice_ItemsRepository
        Private _PolicyRepository As IPolicyRepository
        Private _Category_GroupRepository As ICategory_GroupRepository
        Private _Policy_Category_GroupRepository As IPolicy_Category_GroupRepository

        Private ReadOnly _repositoryContext As IRepositoryContext

        Public Sub New(repositoryContext As IRepositoryContext)
            _repositoryContext = repositoryContext
        End Sub

        Public ReadOnly Property Provinces As IProvincesRepository Implements IRepositoryManager.Provinces
            Get
                If _provincesRepository Is Nothing Then
                    _provincesRepository = New ProvincesRepository(_repositoryContext)
                End If
                Return _provincesRepository
            End Get
        End Property

        Public ReadOnly Property Address As IAddressRepository Implements IRepositoryManager.Address
            Get
                If _addressRepository Is Nothing Then
                    _addressRepository = New AddressRepository(_repositoryContext)
                End If
                Return _addressRepository
            End Get
        End Property

        Public ReadOnly Property Country As ICountryRepository Implements IRepositoryManager.Country
            Get
                If _countryRepository Is Nothing Then
                    _countryRepository = New CountryRepository(_repositoryContext)
                End If
                Return _countryRepository
            End Get
        End Property

        Public ReadOnly Property Regions As IRegionsRepository Implements IRepositoryManager.Regions
            Get
                If _regionsRepository Is Nothing Then
                    _regionsRepository = New RegionsRepository(_repositoryContext)
                End If
                Return _regionsRepository
            End Get
        End Property

        Public ReadOnly Property Members As IMembersRepository Implements IRepositoryManager.Members
            Get
                If _membersRepository Is Nothing Then
                    _membersRepository = New MembersRepository(_repositoryContext)
                End If
                Return _membersRepository
            End Get
        End Property


        Private ReadOnly Property IRepositoryManager_ServiceTask As IServiceTaskRepository Implements IRepositoryManager.ServiceTask
            Get
                If _ServiceTaskRepository Is Nothing Then
                    _ServiceTaskRepository = New ServiceTaskRepository(_repositoryContext)
                End If
                Return _ServiceTaskRepository
            End Get
        End Property

        Private ReadOnly Property IRepositoryManager_price_items As Iprice_ItemsRepository Implements IRepositoryManager.price_items
            Get
                If _PriceItemsRepository Is Nothing Then
                    _PriceItemsRepository = New price_ItemsRepository(_repositoryContext)
                End If
                Return _PriceItemsRepository
            End Get
        End Property

        Private ReadOnly Property policy As IPolicyRepository Implements IRepositoryManager.policy
            Get
                If _PolicyRepository Is Nothing Then
                    _PolicyRepository = New PolicyRepository(_repositoryContext)
                End If
                Return _PolicyRepository
            End Get
        End Property


        Private ReadOnly Property Policy_Category_Group As IPolicy_Category_GroupRepository Implements IRepositoryManager.Policy_Category_Group
            Get
                If _Policy_Category_GroupRepository Is Nothing Then
                    _Policy_Category_GroupRepository = New Policy_Category_GroupRepository(_repositoryContext)
                End If
                Return _Policy_Category_GroupRepository
            End Get
        End Property

        Public ReadOnly Property category_group As ICategory_GroupRepository Implements IRepositoryManager.category_group
            Get
                If _Category_GroupRepository Is Nothing Then
                    _Category_GroupRepository = New Category_GroupRepository(_repositoryContext)
                End If
                Return _Category_GroupRepository
            End Get
        End Property
    End Class

End Namespace
