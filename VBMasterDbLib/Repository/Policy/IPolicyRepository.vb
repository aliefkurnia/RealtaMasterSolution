Imports VBMasterDbLib.Model

Namespace Repository
    Public Interface IPolicyRepository
        Function CreatePolicy(ByVal Policy As Policy) As Policy

        Function DeletePolicy(ByVal poli_id As Integer) As Integer

        Function FindAllPolicy() As List(Of Policy)

        Function FindAllPolicyAsync() As Task(Of List(Of Policy))

        Function FindPolicyById(ByVal poli_id As Integer) As Policy

        Function UpdatePolicyById(poli_id As Integer, poli_name As String, poli_description As String, Optional showCommand As Boolean = False) As Boolean

        Function UpdatePolicyBySp(poli_id As Integer, poli_name As String, poli_description As String, Optional showCommand As Boolean = False) As Boolean
    End Interface

End Namespace
