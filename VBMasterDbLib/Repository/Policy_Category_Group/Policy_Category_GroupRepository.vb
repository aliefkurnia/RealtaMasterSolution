Imports System.Data.SqlClient
Imports VBMasterDbLib.context
Imports VBMasterDbLib.Model

Namespace Repository
    Public Class Policy_Category_GroupRepository
        Implements IPolicy_Category_GroupRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function CreatePolicy_Category_Group(Policy_Category_Group As Policy_Category_Group) As Policy_Category_Group Implements IPolicy_Category_GroupRepository.CreatePolicy_Category_Group
            Dim newpolicy_category_group As New Policy_Category_Group()

            Dim stmnt As String = " 
                                    INSERT INTO Master.policy_category_group(poca_poli_id,poca_cagro_id) 
                                    VALUES(@poca_poli_id,@poca_cagro_id)
                                    
                                    ;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}

                    cmd.Parameters.AddWithValue("@poca_poli_id", Policy_Category_Group.Poca_poli_id)
                    cmd.Parameters.AddWithValue("@poca_cagro_id", Policy_Category_Group.Poca_cagro_id)

                    Try
                        conn.Open()
                        Dim poca_poli_id As String = Convert.ToInt32(cmd.ExecuteScalar())
                        newpolicy_category_group = FindPolicy_Category_GroupById(Policy_Category_Group.Poca_poli_id)

                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newpolicy_category_group
        End Function

        Public Function DeletePolicy_Category_Group(poca_poli_id As Integer) As Integer Implements IPolicy_Category_GroupRepository.DeletePolicy_Category_Group
            Dim rowEffect As Int32 = 0

            Dim stmnt As String = "DELETE from Master.policy_category_group WHERE poca_poli_id = @poca_poli_id"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@poca_poli_id", poca_poli_id)

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

        Public Function FindAllPolicy_Category_Group() As List(Of Policy_Category_Group) Implements IPolicy_Category_GroupRepository.FindAllPolicy_Category_Group
            Dim policy_category_groupList As New List(Of Policy_Category_Group)
            Dim sql As String = "
                                  SELECT * FROM Master.policy_category_group 
                                   ORDER BY poca_poli_id DESC;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            policy_category_groupList.Add(New Policy_Category_Group() With {
                                .Poca_poli_id = reader.GetInt32(0),
                                .Poca_cagro_id = reader.GetInt32(1)
                            })
                        End While

                        reader.Close()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return policy_category_groupList
        End Function

        Public Function FindAllPolicy_Category_GroupAsync() As Task(Of List(Of Policy_Category_Group)) Implements IPolicy_Category_GroupRepository.FindAllPolicy_Category_GroupAsync
            Throw New NotImplementedException()
        End Function

        Public Function FindPolicy_Category_GroupById(poca_poli_id As Integer) As Policy_Category_Group Implements IPolicy_Category_GroupRepository.FindPolicy_Category_GroupById
            Dim findpolicy_category_group As New Policy_Category_Group

            Dim stmnt As String = "SELECT *
                                   FROM master.policy_category_group 
                                   WHERE poca_poli_id = @poca_poli_id;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}

                    cmd.Parameters.AddWithValue("@poca_poli_id", poca_poli_id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            findpolicy_category_group.Poca_poli_id = reader.GetInt32(0)
                            findpolicy_category_group.Poca_cagro_id = reader.GetInt32(1)
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return findpolicy_category_group
        End Function

        Public Function UpdatePolicy_Category_GroupById(poca_poli_id As Integer, poca_cagro_id As Integer, Optional showCommand As Boolean = False) As Boolean Implements IPolicy_Category_GroupRepository.UpdatePolicy_Category_GroupById
            Dim updatepolicy_category_group As New Policy_Category_Group()

            Dim stmnt As String = " UPDATE Master.policy_category_group 
                                    SET 
                                    poca_poli_id = @poca_poli_id,
                                    poca_cagro_id = @poca_cagro_id 
                                    WHERE poca_poli_id = @poca_poli_id
                                    "

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@poca_poli_id", poca_poli_id)
                    cmd.Parameters.AddWithValue("@poca_cagro_id", poca_cagro_id)

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

        Public Function UpdatePolicy_Category_GroupBySp(poca_poli_id As Integer, poca_cagro_id As Integer, Optional showCommand As Boolean = False) As Boolean Implements IPolicy_Category_GroupRepository.UpdatePolicy_Category_GroupBySp
            Dim updatepolicy_category_group As New Policy_Category_Group()

            Dim stmnt As String = "Master.SPPolicy_Category_Group"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@poca_poli_id", poca_poli_id)
                    cmd.Parameters.AddWithValue("@poca_cagro_id", poca_cagro_id)

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
