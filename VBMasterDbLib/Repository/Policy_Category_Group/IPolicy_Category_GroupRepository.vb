Imports VBMasterDbLib.Model

Namespace Repository
    Public Interface IPolicy_Category_GroupRepository
        Function CreatePolicy_Category_Group(ByVal Policy_Category_Group As Policy_Category_Group) As Policy_Category_Group

        Function DeletePolicy_Category_Group(ByVal poca_poli_id As Integer) As Integer

        Function FindAllPolicy_Category_Group() As List(Of Policy_Category_Group)

        Function FindAllPolicy_Category_GroupAsync() As Task(Of List(Of Policy_Category_Group))

        Function FindPolicy_Category_GroupById(ByVal poca_poli_id As Integer) As Policy_Category_Group

        Function UpdatePolicy_Category_GroupById(poca_poli_id As Integer, poca_cagro_id As Integer, Optional showCommand As Boolean = False) As Boolean

        Function UpdatePolicy_Category_GroupBySp(poca_poli_id As Integer, poca_cagro_id As Integer, Optional showCommand As Boolean = False) As Boolean
    End Interface

End Namespace
