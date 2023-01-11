Imports VBMasterDbLib.Model

Namespace Repository
    Public Interface IMembersRepository
        Function CreateMembers(ByVal Members As Members) As Members

        Function DeleteMembers(ByVal Id As String) As String

        Function FindAllMembers() As List(Of Members)

        Function FindAllMembersAsync() As Task(Of List(Of Members))

        Function FindMembersById(ByVal memb_name As String) As Members

        Function UpdateMembersById(memb_name As String, memb_description As String, Optional showCommand As Boolean = False) As Boolean

        Function UpdateMembersBySp(memb_name As String, memb_description As String, Optional showCommand As Boolean = False) As Boolean
    End Interface

End Namespace
