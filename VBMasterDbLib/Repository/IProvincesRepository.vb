Imports VBMasterDbLib.Model

Namespace Repository
    Public Interface IProvincesRepository
        Function CreateProvinces(ByVal provinces As Provinces) As Provinces

        Function DeleteProvinces(ByVal Id As Int32) As Int32

        Function FindAllProvinces() As List(Of Provinces)

        Function FindAllProvincesAsync() As Task(Of List(Of Provinces))

        Function FindProvincesById(ByVal id As Int32) As Provinces

        Function UpdateProvincesById(id As Integer, prov_name As String, prov_country_id As Integer, Optional showCommand As Boolean = False) As Boolean

        Function UpdateProvincesBySp(prov_id As Integer, prov_name As String, prov_country_id As Integer, Optional showCommand As Boolean = False) As Boolean

    End Interface

End Namespace
