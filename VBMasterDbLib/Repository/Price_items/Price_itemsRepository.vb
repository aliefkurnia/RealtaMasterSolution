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

        Public Function Createprice_Items(price_items As price_items) As price_items Implements IPrice_ItemsRepository.Createprice_Items
            Dim newPrice_Items As New price_items()

            Dim stmnt As String = " 
                                    INSERT INTO Master.Price_Items(prit_name,prit_price,prit_description,prit_type,prit_modified_date) 
                                    VALUES(@prit_name,@prit_price,@prit_description,@prit_type,@prit_modified_date)
                                    SELECT cast(scope_identity() as int)
                                    ;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    Dim check = If(price_items.Prit_description Is Nothing, DBNull.Value, price_items.Prit_description)
                    Dim check2 = If(price_items.Prit_modified_date Is Nothing, DBNull.Value, price_items.Prit_modified_date)

                    cmd.Parameters.AddWithValue("@prit_id", price_items.Prit_id)
                    cmd.Parameters.AddWithValue("@prit_name", price_items.Prit_name)
                    cmd.Parameters.AddWithValue("@prit_price", price_items.Prit_price)
                    cmd.Parameters.AddWithValue("@prit_description", check)
                    cmd.Parameters.AddWithValue("@prit_type", price_items.Prit_type)
                    cmd.Parameters.AddWithValue("@prit_modified_date", check2)

                    Try
                        conn.Open()
                        Dim memb_name As String = Convert.ToString(cmd.ExecuteScalar())
                        newPrice_Items = Findprice_ItemsById(price_items.Prit_id)

                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newPrice_Items
        End Function

        Public Function Deleteprice_Items(prit_id As Integer) As Integer Implements IPrice_ItemsRepository.Deleteprice_Items
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

        Public Function FindAllprice_Items() As List(Of price_items) Implements IPrice_ItemsRepository.FindAllprice_Items
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
                                .Prit_description = If(reader.IsDBNull(3), "", reader.GetString(3)),
                                .Prit_type = reader.GetString(4),
                                .Prit_modified_date = If(reader.IsDBNull(5), "", reader.GetDateTime(5))
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

        Public Function FindAllprice_ItemsAsync() As Task(Of List(Of price_items)) Implements IPrice_ItemsRepository.FindAllprice_ItemsAsync
            Throw New NotImplementedException()
        End Function

        Public Function Findprice_ItemsById(prit_id As Integer) As price_items Implements IPrice_ItemsRepository.Findprice_ItemsById
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
                            findPrice_Items.Prit_description = If(reader.IsDBNull(3), "", reader.GetString(3))
                            findPrice_Items.Prit_type = reader.GetString(4)
                            findPrice_Items.Prit_modified_date = If(reader.IsDBNull(5), "", reader.GetDateTime(5))
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

        Public Function Updateprice_ItemsById(prit_id As Integer, prit_name As String, prit_price As Integer, prit_description As String, prit_type As String, prit_modified_date As DateTime, Optional showCommand As Boolean = False) As Boolean Implements IPrice_ItemsRepository.Updateprice_ItemsById
            Dim updatePrice_Items As New price_items()

            Dim stmnt As String = " UPDATE Master.Price_Items 
                                    SET 
                                    prit_name = @prit_name,
                                    prit_price = @prit_price,
                                    prit_description = @prit_description,
                                    prit_type = @prit_type,
                                    prit_modified_date = @prit_modified_date
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

        Public Function Updateprice_ItemsBySp(prit_id As Integer, prit_name As String, prit_price As Integer, prit_description As String, prit_type As String, prit_modified_date As DateTime, Optional showCommand As Boolean = False) As Boolean Implements IPrice_ItemsRepository.Updateprice_ItemsBySp
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
