Imports VBMasterDbLib.Model

Namespace Repository
    Public Interface ICategory_GroupRepository
        Function Createcategory_Group(ByVal category_Group As category_Group) As category_Group

        Function Deletecategory_Group(ByVal cagro_id As String) As String

        Function FindAllcategory_Group() As List(Of category_Group)

        Function FindAllcategory_GroupAsync() As Task(Of List(Of category_Group))

        Function Findcategory_GroupById(ByVal cagro_id As String) As category_Group

        Function Updatecategory_GroupById(cagro_id As Integer, cagro_name As String, cagro_description As String, cagro_type As String, cagro_icon As String, cagro_icon_url As String, Optional showCommand As Boolean = False) As Boolean

        Function Updatecategory_GroupBySp(cagro_id As Integer, cagro_name As String, cagro_description As String, cagro_type As String, cagro_icon As String, cagro_icon_url As String, Optional showCommand As Boolean = False) As Boolean
    End Interface

End Namespace
