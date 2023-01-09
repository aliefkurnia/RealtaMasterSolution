Imports VBMasterDbLib.context
Imports VBMasterDbLib.Repository

Namespace Base
    Public Class RepositoryManager
        Implements IRepositoryManager

        Private _addressRepository As IAddressRepository
        Private _provincesRepository As IProvincesRepository
        Private _countryRepository As ICountryRepository
        Private _regionsRepository As IRegionsRepository

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

        Public ReadOnly Property Address As IAddressRepository Implements IRepositoryManager.address
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

    End Class

End Namespace
