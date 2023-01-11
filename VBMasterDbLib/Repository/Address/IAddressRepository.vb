Imports Microsoft.Spatial
Imports VBMasterDbLib.Model

Namespace Repository
    Public Interface IAddressRepository
        Function CreateAddress(ByVal address As Address) As Address

        Function DeleteAddress(ByVal Id As Int32) As Int32

        Function FindAllAddress() As List(Of Address)

        Function FindAllAddressAsync() As Task(Of List(Of Address))

        Function FindAddressById(ByVal id As Int32) As Address

        Function UpdateAddressById(addr_id As Integer, addr_line1 As String, addr_line2 As String, addr_postal_code As String, addr_prov_id As Integer, Optional showCommand As Boolean = False) As Boolean

        Function UpdateAddressBySp(addr_id As Integer, addr_line1 As String, addr_line2 As String, addr_postal_code As String, addr_prov_id As Integer, Optional showCommand As Boolean = False) As Boolean

    End Interface

End Namespace
