Imports System.Data.SqlClient
Imports VBMasterDbLib.context
Imports VBMasterDbLib.Model

Namespace Repository
    Public Class PolicyRepository
        Implements IPolicyRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function CreatePolicy(Policy As Policy) As Policy Implements IPolicyRepository.CreatePolicy
            Dim newPolicy As New Policy()

            Dim stmnt As String = " 
                                    INSERT INTO Master.Policy(poli_name,poli_description) 
                                    VALUES(@poli_name,@poli_description)
                                    SELECT cast(scope_identity() as int)
                                    ;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    Dim check = If(Policy.Poli_description Is Nothing, DBNull.Value, Policy.Poli_description)

                    cmd.Parameters.AddWithValue("@poli_id", Policy.Poli_id)
                    cmd.Parameters.AddWithValue("@poli_name", Policy.Poli_name)
                    cmd.Parameters.AddWithValue("@poli_description", check)

                    Try
                        conn.Open()
                        Dim memb_name As String = Convert.ToString(cmd.ExecuteScalar())
                        newPolicy = FindPolicyById(Policy.Poli_id)

                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newPolicy
        End Function

        Public Function DeletePolicy(poli_id As Integer) As Integer Implements IPolicyRepository.DeletePolicy
            Dim rowEffect As Int32 = 0

            Dim stmnt As String = "DELETE from Master.policy WHERE poli_id = @poli_id"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@poli_id", poli_id)

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

        Public Function FindAllPolicy() As List(Of Policy) Implements IPolicyRepository.FindAllPolicy
            Dim MemberList As New List(Of Policy)
            Dim sql As String = "
                                  SELECT * FROM Master.Policy 
                                   ORDER BY poli_id DESC;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            MemberList.Add(New Policy() With {
                                .Poli_id = reader.GetInt32(0),
                                .Poli_name = reader.GetString(1),
                                .Poli_description = If(reader.IsDBNull(2), "", reader.GetString(2))
                            })
                        End While

                        reader.Close()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return MemberList
        End Function

        Public Function FindAllPolicyAsync() As Task(Of List(Of Policy)) Implements IPolicyRepository.FindAllPolicyAsync
            Throw New NotImplementedException()
        End Function

        Public Function FindPolicyById(poli_id As Integer) As Policy Implements IPolicyRepository.FindPolicyById
            Dim findPolicy As New Policy

            Dim stmnt As String = "SELECT *
                                   FROM master.Policy 
                                   WHERE poli_id = @poli_id;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}

                    cmd.Parameters.AddWithValue("@poli_id", poli_id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            findPolicy.Poli_id = reader.GetInt32(0)
                            findPolicy.Poli_name = reader.GetString(1)
                            findPolicy.Poli_description = reader.GetString(2)
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return findPolicy
        End Function

        Public Function UpdatePolicyById(poli_id As Integer, poli_name As String, poli_description As String, Optional showCommand As Boolean = False) As Boolean Implements IPolicyRepository.UpdatePolicyById
            Dim updatePolicy As New Policy()

            Dim stmnt As String = " UPDATE Master.Policy 
                                    SET 
                                    poli_name = @poli_name,
                                    poli_description = @poli_description 
                                    WHERE poli_id = @poli_id
                                    "

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@poli_id", poli_id)
                    cmd.Parameters.AddWithValue("@poli_name", poli_name)
                    cmd.Parameters.AddWithValue("@poli_description", poli_description)

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

        Public Function UpdatePolicyBySp(poli_id As Integer, poli_name As String, poli_description As String, Optional showCommand As Boolean = False) As Boolean Implements IPolicyRepository.UpdatePolicyBySp
            Dim updatePolicy As New Policy()

            Dim stmnt As String = "Master.SpPolicy"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@poli_id", poli_id)
                    cmd.Parameters.AddWithValue("@poli_name", poli_name)
                    cmd.Parameters.AddWithValue("@poli_description", poli_description)

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
