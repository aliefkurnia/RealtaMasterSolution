Imports VBMasterDbLib.Model

Namespace Repository
    Public Interface ICountryRepository
        Function CreateCountry(ByVal Country As Country) As Country

        Function DeleteCountry(ByVal Id As Int32) As Int32

        Function FindAllCountry() As List(Of Country)

        Function FindAllCountryAsync() As Task(Of List(Of Country))

        Function FindCountryById(ByVal id As Int32) As Country

        Function UpdateCountryById(id As Integer, country_name As String, country_region_id As Integer, Optional showCommand As Boolean = False) As Boolean

        Function UpdateCountryBySp(country_id As Integer, country_name As String, country_region_id As Integer, Optional showCommand As Boolean = False) As Boolean
    End Interface

End Namespace
