Imports System.Data.SqlClient
Imports VBMasterDbLib.context
Imports VBMasterDbLib.Model

Namespace Repository
    Public Class price_ItemsRepository
        Implements IPrice_ItemsRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function Createprice_Itemss(prit_id As price_items) As price_items Implements IPrice_ItemsRepository.Createprice_Itemss
            Dim newPrice_Items As New price_items()

            Dim stmnt As String = " 
                                    INSERT INTO Master.Price_Items(prit_id,prit_name,prit_price,prit_description,prit_type,prit_modified_date) 
                                    VALUES((@prit_id,@prit_name,@prit_price,@prit_description,@prit_type,@prit_modified_date)
                                    ;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    Dim check = If(prit_id.Prit_description Is Nothing, DBNull.Value, prit_id.Prit_description)
                    Dim check2 = If(prit_id.Prit_modified_date Is Nothing, DBNull.Value, prit_id.Prit_modified_date)

                    cmd.Parameters.AddWithValue("@prit_id", prit_id.Prit_id)
                    cmd.Parameters.AddWithValue("@prit_name", prit_id.Prit_name)
                    cmd.Parameters.AddWithValue("@prit_price", prit_id.Prit_price)
                    cmd.Parameters.AddWithValue("@prit_description", prit_id.Prit_description)
                    cmd.Parameters.AddWithValue("@prit_type", prit_id.Prit_type)
                    cmd.Parameters.AddWithValue("@prit_modified_date", prit_id.Prit_modified_date)

                    Try
                        conn.Open()
                        Dim memb_name As String = Convert.ToString(cmd.ExecuteScalar())
                        newPrice_Items = Findprice_ItemsById(prit_id.Prit_id)

                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newPrice_Items
        End Function

        Public Function Deleteprice_Items(prit_id As Integer) As Integer Implements IPrice_ItemsRepository.Deleteprice_Itemss
            Dim rowEffect As Int32 = 0

            Dim stmnt As String = "DELETE from Master.price_items WHERE prit_id = @prit_id"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@prit_id", prit_id)

                    Try
                        conn.Open()
                        rowEffect = cmd.ExecuteNonQuery()

                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return True
        End Function

        Public Function FindAllprice_Items() As List(Of price_items) Implements IPrice_ItemsRepository.FindAllprice_Itemss
            Dim Price_itemsList As New List(Of price_items)
            Dim sql As String = "
                                  SELECT * FROM Master.price_items 
                                   ORDER BY prit_id DESC;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            Price_itemsList.Add(New price_items() With {
                                .Prit_id = reader.GetInt32(0),
                                .Prit_name = reader.GetString(1),
                                .Prit_price = reader.GetDecimal(2),
                                .Prit_description = reader.GetString(3),
                                .Prit_type = reader.GetString(4),
                                .Prit_modified_date = reader.GetString(5)
                            })
                        End While

                        reader.Close()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return Price_itemsList
        End Function

        Public Function FindAllprice_ItemsAsync() As Task(Of List(Of price_items)) Implements IPrice_ItemsRepository.FindAllprice_ItemssAsync
            Throw New NotImplementedException()
        End Function

        Public Function Findprice_ItemsById(prit_id As Integer) As price_items Implements IPrice_ItemsRepository.Findprice_ItemssById
            Dim findPrice_Items As New price_items

            Dim stmnt As String = "SELECT *
                                   FROM master.Price_Items 
                                   WHERE prit_id = @prit_id;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}

                    cmd.Parameters.AddWithValue("@prit_id", prit_id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            findPrice_Items.Prit_id = reader.GetInt32(0)
                            findPrice_Items.Prit_name = reader.GetString(1)
                            findPrice_Items.Prit_price = reader.GetDecimal(2)
                            findPrice_Items.Prit_description = reader.GetString(3)
                            findPrice_Items.Prit_type = reader.GetString(4)
                            findPrice_Items.Prit_modified_date = reader.GetString(5)
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return findPrice_Items
        End Function

        Public Function Updateprice_ItemsById(prit_id As Integer, prit_name As String, prit_price As Integer, prit_description As String, prit_type As String, prit_modified_date As String, Optional showCommand As Boolean = False) As Boolean Implements IPrice_ItemsRepository.Updateprice_ItemssById
            Dim updatePrice_Items As New price_items()

            Dim stmnt As String = " UPDATE Master.Price_Items 
                                    SET 
                                    prit_id = @prit_id,
                                    prit_name = @prit_name,
                                    prit_price = @prit_price,
                                    prit_description = @prit_description,
                                    prit_type = @prit_type,
                                    prit_modified_date = @prit_modified_date,
                                    WHERE prit_id = @prit_id
                                    "

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@prit_id", prit_id)
                    cmd.Parameters.AddWithValue("@prit_name", prit_name)
                    cmd.Parameters.AddWithValue("@prit_price", prit_price)
                    cmd.Parameters.AddWithValue("@prit_description", prit_description)
                    cmd.Parameters.AddWithValue("@prit_type", prit_type)
                    cmd.Parameters.AddWithValue("@prit_modified_date", prit_modified_date)

                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return True
        End Function

        Public Function Updateprice_ItemsBySp(prit_id As Integer, prit_name As String, prit_price As Integer, prit_description As String, prit_type As String, prit_modified_date As String, Optional showCommand As Boolean = False) As Boolean Implements IPrice_ItemsRepository.Updateprice_ItemssBySp
            Dim updatePrice_Items As New price_items()

            Dim stmnt As String = "Master.SpPrice_Items"
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@prit_id", prit_id)
                    cmd.Parameters.AddWithValue("@prit_name", prit_name)
                    cmd.Parameters.AddWithValue("@prit_price", prit_price)
                    cmd.Parameters.AddWithValue("@prit_description", prit_description)
                    cmd.Parameters.AddWithValue("@prit_type", prit_type)
                    cmd.Parameters.AddWithValue("@prit_modified_date", prit_modified_date)

                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return True
        End Function
    End Class

End Namespace
