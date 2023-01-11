Imports System.Data.SqlClient
Imports VBMasterDbLib.context
Imports VBMasterDbLib.Model

Namespace Repository
    Public Class Category_GroupRepository
        Implements ICategory_GroupRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function Createcategory_Group(category_Group As category_Group) As category_Group Implements ICategory_GroupRepository.Createcategory_Group
            Dim newCategory_Group As New category_Group()

            Dim stmnt As String = " 
                                    INSERT INTO Master.Category_Group(cagro_id,cagro_name,cagro_description,cagro_type,cagro_icon,cagro_icon_url) 
                                    VALUES(@cagro_id,@cagro_name,@cagro_description,@cagro_type,@cagro_icon,@cagro_icon_url)
                                    ;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    Dim check = If(category_Group.Cagro_description Is Nothing, DBNull.Value, category_Group.Cagro_description)
                    Dim check1 = If(category_Group.Cagro_icon Is Nothing, DBNull.Value, category_Group.Cagro_icon)
                    Dim check2 = If(category_Group.Cagro_icon_url Is Nothing, DBNull.Value, category_Group.Cagro_icon_url)

                    cmd.Parameters.AddWithValue("@memb_name", category_Group.Cagro_id)
                    cmd.Parameters.AddWithValue("@memb_name", category_Group.Cagro_name)
                    cmd.Parameters.AddWithValue("@memb_description", check)
                    cmd.Parameters.AddWithValue("@memb_name", category_Group.Cagro_type)
                    cmd.Parameters.AddWithValue("@memb_description", check1)
                    cmd.Parameters.AddWithValue("@memb_description", check2)

                    Try
                        conn.Open()
                        Dim cagro_id As String = Convert.ToString(cmd.ExecuteScalar())
                        newCategory_Group = Findcategory_GroupById(category_Group.Cagro_id)

                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newCategory_Group
        End Function

        Public Function Deletecategory_Group(cagro_id As String) As String Implements ICategory_GroupRepository.Deletecategory_Group
            Dim rowEffect As Int32 = 0

            Dim stmnt As String = "DELETE from Master.category_group WHERE cagro_id = @cagro_id"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@cagro_id", cagro_id)

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

        Public Function FindAllcategory_Group() As List(Of category_Group) Implements ICategory_GroupRepository.FindAllcategory_Group
            Dim Category_GroupList As New List(Of category_Group)
            Dim sql As String = "
                                  SELECT * FROM Master.category_group 
                                   ORDER BY cagro_id DESC;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            Category_GroupList.Add(New category_Group() With {
                                .Cagro_id = reader.GetInt32(0),
                                .Cagro_name = reader.GetString(1),
                                .Cagro_description = If(reader.IsDBNull(1), "", reader.GetString(2)),
                                .Cagro_type = reader.GetString(3),
                                .Cagro_icon = If(reader.IsDBNull(1), "", reader.GetString(4)),
                                .Cagro_icon_url = If(reader.IsDBNull(1), "", reader.GetString(5))
                            })
                        End While

                        reader.Close()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return Category_GroupList
        End Function

        Public Function FindAllcategory_GroupAsync() As Task(Of List(Of category_Group)) Implements ICategory_GroupRepository.FindAllcategory_GroupAsync
            Throw New NotImplementedException()
        End Function

        Public Function Findcategory_GroupById(cagro_id As String) As category_Group Implements ICategory_GroupRepository.Findcategory_GroupById
            Dim findCategory_Group As New category_Group

            Dim stmnt As String = "SELECT *
                                   FROM master.Category_Group 
                                   WHERE memb_name = @memb_name;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}

                    cmd.Parameters.AddWithValue("@Cagro_id", cagro_id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            findCategory_Group.Cagro_id = reader.GetInt32(0)
                            findCategory_Group.Cagro_name = reader.GetString(1)
                            findCategory_Group.Cagro_description = If(reader.IsDBNull(1), "", reader.GetString(2))
                            findCategory_Group.Cagro_type = reader.GetString(3)
                            findCategory_Group.Cagro_icon = If(reader.IsDBNull(1), "", reader.GetString(4))
                            findCategory_Group.Cagro_icon_url = If(reader.IsDBNull(1), "", reader.GetString(5))
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return findCategory_Group
        End Function

        Public Function Updatecategory_GroupById(cagro_id As Integer, cagro_name As String, cagro_description As String, cagro_type As String, cagro_icon As String, cagro_icon_url As String, Optional showCommand As Boolean = False) As Boolean Implements ICategory_GroupRepository.Updatecategory_GroupById
            Dim updateCategory_Group As New category_Group()

            Dim stmnt As String = " UPDATE Master.Category_Group 
                                    SET 
                                    cagro_id = @cagro_id
                                    cagro_name = @cagro_name
                                    cagro_description = @cagro_description
                                    cagro_type = @cagro_type
                                    cagro_icon = @cagro_icon
                                    cagro_icon_url = @cagro_icon_url
                                    WHERE cagro_id = @cagro_id
                                    "

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@cagro_id", cagro_id)
                    cmd.Parameters.AddWithValue("@cagro_name", cagro_name)
                    cmd.Parameters.AddWithValue("@cagro_description", cagro_description)
                    cmd.Parameters.AddWithValue("@cagro_type", cagro_type)
                    cmd.Parameters.AddWithValue("@cagro_icon", cagro_icon)
                    cmd.Parameters.AddWithValue("@cagro_icon_url", cagro_icon_url)
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

        Public Function Updatecategory_GroupBySp(cagro_id As Integer, cagro_name As String, cagro_description As String, cagro_type As String, cagro_icon As String, cagro_icon_url As String, Optional showCommand As Boolean = False) As Boolean Implements ICategory_GroupRepository.Updatecategory_GroupBySp
            Dim updateCategory_Group As New category_Group()

            Dim stmnt As String = "Master.SpCategory_Group"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@cagro_id", cagro_id)
                    cmd.Parameters.AddWithValue("@cagro_name", cagro_name)
                    cmd.Parameters.AddWithValue("@cagro_description", cagro_description)
                    cmd.Parameters.AddWithValue("@cagro_type", cagro_type)
                    cmd.Parameters.AddWithValue("@cagro_icon", cagro_icon)
                    cmd.Parameters.AddWithValue("@cagro_icon_url", cagro_icon_url)
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
