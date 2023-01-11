Imports System.Data.SqlClient
Imports VBMasterDbLib.context
Imports VBMasterDbLib.Model

Namespace Repository
    Public Class CountryRepository
        Implements ICountryRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function CreateCountry(Country As Country) As Country Implements ICountryRepository.CreateCountry
            Dim newCountry As New Country()

            Dim stmnt As String = " 
                                    INSERT INTO Master.Country(country_name, country_region_id) 
                                    VALUES(@country_name,@country_region_id)
                                    SELECT cast(scope_identity() as int)
                                  "

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    Dim check = If(Country.Country_region_id.Equals(0), DBNull.Value, Country.Country_region_id)
                    cmd.Parameters.AddWithValue("@country_name", Country.Country_name)
                    cmd.Parameters.AddWithValue("@country_region_id", check)

                    Try
                        conn.Open()
                        Dim country_id As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
                        newCountry = FindCountryById(Country.Country_id)

                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return newCountry
        End Function

        Public Function DeleteCountry(Id As Integer) As Integer Implements ICountryRepository.DeleteCountry
            Dim rowEffect As Int32 = 0

            'declare statement
            Dim stmnt As String = "DELETE from Master.country WHERE country_id = @id"


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

        Public Function FindAllCountry() As List(Of Country) Implements ICountryRepository.FindAllCountry

            Dim CountryList As New List(Of Country)
            Dim sql As String = "SELECT country_id, country_name, country_region_id 
                                FROM Master.country 
                                ORDER BY country_id DESC;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            CountryList.Add(New Country() With {
                                .Country_id = reader.GetInt32(0),
                                .Country_name = reader.GetString(1),
                                .Country_region_id = If(reader.IsDBNull(2), Nothing, reader.GetInt32(2))
                            })
                        End While

                        reader.Close()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return CountryList
        End Function

        Public Async Function FindAllCountryAsync() As Task(Of List(Of Country)) Implements ICountryRepository.FindAllCountryAsync
            Dim CountryList As New List(Of Country)
            Dim sql As String = "SELECT country_id, country_name, country_region_id 
                                FROM Master.country 
                                ORDER BY country_id DESC;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = Await cmd.ExecuteReaderAsync()

                        While reader.Read()
                            CountryList.Add(New Country() With {
                                .Country_id = reader.GetInt32(0),
                                .Country_name = reader.GetString(1),
                                .Country_region_id = reader.GetInt32(2)
                            })
                        End While

                        reader.Close()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return CountryList
        End Function

        Public Function FindCountryById(id As Integer) As Country Implements ICountryRepository.FindCountryById
            Dim findCountry As New Country With {.Country_id = id}

            Dim stmnt As String = "SELECT country_id,country_name,country_region_id from master.country 
                                  WHERE country_id = @country_id;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}

                    cmd.Parameters.AddWithValue("@country_id", id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            findCountry.Country_name = reader.GetString(1)
                            findCountry.Country_region_id = reader.GetInt32(2)
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return findCountry
        End Function

        Public Function UpdateCountryById(id As Integer, country_name As String, country_region_id As Integer, Optional showCommand As Boolean = False) As Boolean Implements ICountryRepository.UpdateCountryById
            Dim updateCountry As New Country()

            Dim stmnt As String = " 
                                    UPDATE Master.country 
                                    SET country_name = @country_name, 
                                    country_region_id = @country_region_id
                                    WHERE country_id = @country_id
                                    "

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@country_id", id)
                    cmd.Parameters.AddWithValue("@country_name", country_name)
                    cmd.Parameters.AddWithValue("@country_region_id", country_region_id)

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

        Public Function UpdateCountryBySp(country_id As Integer, country_name As String, country_region_id As Integer, Optional showCommand As Boolean = False) As Boolean Implements ICountryRepository.UpdateCountryBySp
            Dim updateCountry As New Country()

            Dim stmnt As String = "[Master].[SpCountry1]"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@country_id", country_id)
                    cmd.Parameters.AddWithValue("@country_name", country_name)
                    cmd.Parameters.AddWithValue("@country_region_id", country_region_id)

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
