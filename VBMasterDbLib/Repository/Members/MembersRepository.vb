Imports System.Data.SqlClient
Imports VBMasterDbLib.context
Imports VBMasterDbLib.Model

Namespace Repository
    Public Class MembersRepository
        Implements IMembersRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function CreateMembers(Members As Members) As Members Implements IMembersRepository.CreateMembers
            Dim newMembers As New Members()

            Dim stmnt As String = " 
                                    INSERT INTO Master.Members(Memb_name,Memb_description) 
                                    VALUES(@Memb_name,@Memb_description)
                                    ;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    Dim check = If(Members.Memb_description Is Nothing, DBNull.Value, Members.Memb_description)

                    cmd.Parameters.AddWithValue("@memb_name", Members.Memb_name)
                    cmd.Parameters.AddWithValue("@memb_description", check)

                    Try
                        conn.Open()
                        Dim memb_name As String = Convert.ToString(cmd.ExecuteScalar())
                        newMembers = FindMembersById(Members.Memb_name)

                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newMembers
        End Function

        Public Function DeleteMembers(Id As String) As String Implements IMembersRepository.DeleteMembers
            Dim rowEffect As Int32 = 0

            Dim stmnt As String = "DELETE from Master.members WHERE memb_name = @id"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@id", Id)

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

        Public Function FindAllMembers() As List(Of Members) Implements IMembersRepository.FindAllMembers
            Dim MemberList As New List(Of Members)
            Dim sql As String = "
                                  SELECT * FROM Master.members 
                                   ORDER BY memb_name DESC;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            MemberList.Add(New Members() With {
                                .Memb_name = reader.GetString(0),
                                .Memb_description = If(reader.IsDBNull(1), "", reader.GetString(1))
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

        Public Function FindAllMembersAsync() As Task(Of List(Of Members)) Implements IMembersRepository.FindAllMembersAsync
            Throw New NotImplementedException()
        End Function

        Public Function FindMembersById(memb_name As String) As Members Implements IMembersRepository.FindMembersById
            Dim findMembers As New Members

            Dim stmnt As String = "SELECT *
                                   FROM master.Members 
                                   WHERE memb_name = @memb_name;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}

                    cmd.Parameters.AddWithValue("@memb_name", memb_name)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            findMembers.Memb_name = reader.GetString(0)
                            findMembers.Memb_description = reader.GetString(1)
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return findMembers
        End Function

        Public Function UpdateMembersById(memb_name As String, memb_description As String, Optional showCommand As Boolean = False) As Boolean Implements IMembersRepository.UpdateMembersById
            Dim updateMembers As New Members()

            Dim stmnt As String = " UPDATE Master.Members 
                                    SET 
                                    memb_name = @memb_name,
                                    memb_description = @memb_description 
                                    WHERE memb_name = @memb_name
                                    "

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@memb_name", memb_name)
                    cmd.Parameters.AddWithValue("@memb_description", memb_description)

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

        Public Function UpdateMembersBySp(memb_name As String, memb_description As String, Optional showCommand As Boolean = False) As Boolean Implements IMembersRepository.UpdateMembersBySp
            Dim updateMembers As New Members()

            Dim stmnt As String = "Master.SpMembers"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@memb_name", memb_name)
                    cmd.Parameters.AddWithValue("@memb_description", memb_description)

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
