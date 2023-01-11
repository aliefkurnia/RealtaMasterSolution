Imports VBMasterDbLib.Model

Namespace Repository
    Public Interface IPrice_ItemsRepository
        Function Createprice_Itemss(ByVal prit_id As price_items) As price_items

        Function Deleteprice_Itemss(ByVal prit_id As Integer) As Integer

        Function FindAllprice_Itemss() As List(Of price_items)

        Function FindAllprice_ItemssAsync() As Task(Of List(Of price_items))

        Function Findprice_ItemssById(ByVal prit_id As Integer) As price_items

        Function Updateprice_ItemssById(prit_id As Integer, prit_name As String, prit_price As Integer, prit_description As String, prit_type As String, prit_modified_date As String, Optional showCommand As Boolean = False) As Boolean

        Function Updateprice_ItemssBySp(prit_id As Integer, prit_name As String, prit_price As Integer, prit_description As String, prit_type As String, prit_modified_date As String, Optional showCommand As Boolean = False) As Boolean

    End Interface

End Namespace
