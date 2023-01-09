Imports VBMasterDbLib.Model

Namespace Repository
    Public Interface IAddressRepository
        Function CreateAddress(ByVal address As Address) As Address

        Function DeleteAddress(ByVal Id As Int32) As Int32

        Function FindAllAddress() As List(Of Address)

        Function FindAllAddressAsync() As Task(Of List(Of Address))

        Function FindAddressById(ByVal id As Int32) As Address

        Function UpdateAddressById(id As Integer, value As String, Optional showCommand As Boolean = False) As Boolean

        Function UpdateAddressBySp(id As Integer, value As String, Optional showCommand As Boolean = False) As Boolean

    End Interface

End Namespace
