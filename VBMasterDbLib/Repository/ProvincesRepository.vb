Imports System.Data.SqlClient
Imports VBMasterDbLib.context
Imports VBMasterDbLib.Model

Namespace Repository
    Public Class ProvincesRepository
        Implements IProvincesRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function CreateProvinces(provinces As Provinces) As Provinces Implements IProvincesRepository.CreateProvinces
            Dim newProvinces As New Provinces()

            Dim stmnt As String = " SET IDENTITY_INSERT Master.Provinces ON;
                                    INSERT INTO Master.Provinces(prov_id, prov_name, prov_country_id) 
                                    VALUES
                                    (@prov_id,@prov_name,@prov_country_id)
                                    SET IDENTITY_INSERT Master.Provinces OFF;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@prov_id", provinces.Prov_id)
                    cmd.Parameters.AddWithValue("@prov_name", provinces.Prov_name)
                    cmd.Parameters.AddWithValue("@prov_country_id", provinces.Prov_country_id)

                    Try
                        conn.Open()
                        Dim prov_id As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
                        newProvinces = FindProvincesById(provinces.Prov_id)

                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return newProvinces
        End Function

        Public Function DeleteProvinces(Id As Integer) As Integer Implements IProvincesRepository.DeleteProvinces
            Dim rowEffect As Int32 = 0

            'declare statement
            Dim stmnt As String = "DELETE from Master.Provinces WHERE Prov_id = @id"


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

        Public Function FindAllProvinces() As List(Of Provinces) Implements IProvincesRepository.FindAllProvinces

            Dim ProvincesList As New List(Of Provinces)
            Dim sql As String = "SELECT prov_id, prov_name, prov_country_id " &
                                "FROM Master.Provinces " &
                                "ORDER BY prov_id DESC;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            ProvincesList.Add(New Provinces() With {
                                .Prov_id = reader.GetInt32(0),
                                .Prov_name = reader.GetString(1),
                                .Prov_country_id = reader.GetInt32(2)
                            })
                        End While

                        reader.Close()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return ProvincesList
        End Function

        Public Async Function FindAllProvincesAsync() As Task(Of List(Of Provinces)) Implements IProvincesRepository.FindAllProvincesAsync
            Dim ProvincesList As New List(Of Provinces)
            Dim sql As String = "SELECT prov_id, prov_name, prov_country_id " &
                                "FROM Master.Provinces " &
                                "ORDER BY prov_id DESC;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = Await cmd.ExecuteReaderAsync()

                        While reader.Read()
                            ProvincesList.Add(New Provinces() With {
                                .Prov_id = reader.GetInt32(0),
                                .Prov_name = reader.GetString(1),
                                .Prov_country_id = reader.GetInt32(2)
                            })
                        End While

                        reader.Close()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return ProvincesList
        End Function

        Public Function FindProvincesById(id As Integer) As Provinces Implements IProvincesRepository.FindProvincesById
            Dim findProvinces As New Provinces With {.Prov_id = id}

            'sql statement
            Dim stmnt As String = "SELECT prov_id,prov_name,prov_country_id from master.provinces " &
                                  "WHERE prov_id = @prov_id;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}

                    cmd.Parameters.AddWithValue("@prov_id", id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            findProvinces.Prov_name = reader.GetString(1)
                            findProvinces.Prov_country_id = reader.GetInt32(2)
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return findProvinces
        End Function

        Public Function UpdateProvincesById(id As Integer, prov_name As String, prov_country_id As Integer, Optional showCommand As Boolean = False) As Boolean Implements IProvincesRepository.UpdateProvincesById
            Dim updateProvinces As New Provinces()

            Dim stmnt As String = " SET IDENTITY_INSERT Master.Provinces ON; " &
                                    "UPDATE Master.provinces " &
                                    "SET " &
                                    "prov_name = @prov_name, " &
                                    "prov_country_id = @prov_country_id " &
                                    "WHERE prov_id = @prov_id " &
                                    "SET IDENTITY_INSERT Master.Provinces OFF;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@prov_id", id)
                    cmd.Parameters.AddWithValue("@prov_name", prov_name)
                    cmd.Parameters.AddWithValue("@prov_country_id", prov_country_id)

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

        Public Function UpdateProvincesBySp(prov_id As Integer, prov_name As String, prov_country_id As Integer, Optional showCommand As Boolean = False) As Boolean Implements IProvincesRepository.UpdateProvincesBySp
            Dim updateProvinces As New Provinces()

            Dim stmnt As String = "Master.SpProvinces"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@prov_id", prov_id)
                    cmd.Parameters.AddWithValue("@prov_name", prov_name)
                    cmd.Parameters.AddWithValue("@prov_country_id", prov_country_id)

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
