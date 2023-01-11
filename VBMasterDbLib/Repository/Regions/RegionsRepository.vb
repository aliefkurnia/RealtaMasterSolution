Imports System.Data.SqlClient
Imports VBMasterDbLib.context
Imports VBMasterDbLib.Model

Namespace Repository
    Public Class RegionsRepository
        Implements IRegionsRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function CreateRegions(region As Regions) As Regions Implements IRegionsRepository.CreateRegions
            Dim newRegion As New Regions()

            Dim stmnt As String = " 
                                    INSERT INTO Master.Regions(Region_name) 
                                    VALUES(@Region_name)
                                    SELECT cast(scope_identity() as int)
                                  "

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@Region_code", region.Region_code)
                    cmd.Parameters.AddWithValue("@Region_name", region.Region_name)


                    Try
                        conn.Open()
                        Dim Region_code As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
                        newRegion = FindRegionsById(Region_code)

                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return newRegion
        End Function

        Public Function DeleteRegions(Id As Integer) As Integer Implements IRegionsRepository.DeleteRegions
            Dim rowEffect As Int32 = 0

            'declare statement
            Dim stmnt As String = "DELETE from Master.regions WHERE Region_code = @id"


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

        Public Function FindAllRegions() As List(Of Regions) Implements IRegionsRepository.FindAllRegions
            Dim RegionsList As New List(Of Regions)
            Dim sql As String = "SELECT Region_code, Region_name FROM Master.Regions 
                                 ORDER BY Region_code DESC;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            RegionsList.Add(New Regions() With {
                                .Region_code = reader.GetInt32(0),
                                .Region_name = reader.GetString(1)
                            })
                        End While

                        reader.Close()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return RegionsList
        End Function

        Public Async Function FindAllRegionsAsync() As Task(Of List(Of Regions)) Implements IRegionsRepository.FindAllRegionsAsync
            Dim RegionsList As New List(Of Regions)
            Dim sql As String = "SELECT Region_code, Region_name                                              FROM Master.Regions 
                                 ORDER BY Region_code DESC;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = Await cmd.ExecuteReaderAsync()

                        While reader.Read()
                            RegionsList.Add(New Regions() With {
                                .Region_code = reader.GetInt32(0),
                                .Region_name = reader.GetString(1)
                            })
                        End While

                        reader.Close()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return RegionsList
        End Function

        Public Function FindRegionsById(id As Integer) As Regions Implements IRegionsRepository.FindRegionsById
            Dim findRegion As New Regions With {.Region_code = id}

            Dim stmnt As String = "SELECT Region_code,Region_name from master.Regions 
                                  WHERE Region_code = @Region_code;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}

                    cmd.Parameters.AddWithValue("@Region_code", id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            findRegion.Region_name = reader.GetString(1)
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return findRegion
        End Function

        Public Function UpdateRegionsById(region_code As Integer, region_name As String, Optional showCommand As Boolean = False) As Boolean Implements IRegionsRepository.UpdateRegionsById
            Dim updateRegions As New Regions()

            Dim stmnt As String = " UPDATE Master.regions 
                                    SET region_name = @region_name 
                                    WHERE region_code = @region_code
                                    "

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@Region_code", region_code)
                    cmd.Parameters.AddWithValue("@Region_name", region_name)

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

        Public Function UpdateRegionsBySp(region_code As Integer, region_name As String, Optional showCommand As Boolean = False) As Boolean Implements IRegionsRepository.UpdateRegionsBySp
            Dim updateRegions As New Regions()

            Dim stmnt As String = "[Master].[SpRegions]"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@Region_code", region_code)
                    cmd.Parameters.AddWithValue("@Region_name", region_name)

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
