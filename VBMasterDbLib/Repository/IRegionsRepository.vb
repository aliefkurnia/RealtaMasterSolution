Imports VBMasterDbLib.Model

Namespace Repository
    Public Interface IRegionsRepository

        Function CreateRegions(ByVal Regions As Regions) As Regions

        Function DeleteRegions(ByVal Id As Int32) As Int32

        Function FindAllRegions() As List(Of Regions)

        Function FindAllRegionsAsync() As Task(Of List(Of Regions))

        Function FindRegionsById(ByVal id As Int32) As Regions

        Function UpdateRegionsById(region_code As Integer, region_name As String, Optional showCommand As Boolean = False) As Boolean

        Function UpdateRegionsBySp(region_code As Integer, region_name As String, Optional showCommand As Boolean = False) As Boolean
    End Interface

End Namespace
