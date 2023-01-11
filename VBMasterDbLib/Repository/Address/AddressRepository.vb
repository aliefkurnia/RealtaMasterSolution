Imports System.Data.SqlClient
Imports Microsoft.Spatial
Imports Microsoft.SqlServer.Types
Imports VBMasterDbLib.context
Imports VBMasterDbLib.Model

Namespace Repository
    Public Class AddressRepository
        Implements IAddressRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function Createaddress(address As Address) As Address Implements IAddressRepository.CreateAddress
            Dim newAddress As New Address()

            Dim stmnt As String = " SET IDENTITY_INSERT Master.address ON;
                                    INSERT INTO Master.address(Addr_Id,addr_line1, addr_line2, addr_postal_code, addr_spatial_location, addr_prov_id) 
                                    VALUES
                                    (@Addr_Id,@Addr_line1,@Addr_line2,@Addr_postal_code,@Addr_spatial_location,@Addr_prov_id)
                                    SET IDENTITY_INSERT Master.address OFF;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    Dim check4 = If(address.Addr_line2, DBNull.Value)
                    Dim check3 = If(address.Addr_postal_code, DBNull.Value)
                    Dim check2 = If(address.Addr_spatial_location, DBNull.Value)
                    Dim check1 = If(address.Addr_prov_id.Equals(0), DBNull.Value, address.Addr_prov_id)

                    cmd.Parameters.AddWithValue("@Addr_Id", address.Addr_Id)
                    cmd.Parameters.AddWithValue("@Addr_line1", address.Addr_line1)
                    cmd.Parameters.AddWithValue("@Addr_line2", check4)
                    cmd.Parameters.AddWithValue("@Addr_postal_code", check3)
                    cmd.Parameters.AddWithValue("@Addr_spatial_location", check2)
                    cmd.Parameters.AddWithValue("@Addr_prov_id", check1)

                    Try
                        conn.Open()
                        Dim addr_Id As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
                        newAddress = FindaddressById(address.Addr_Id)

                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newAddress
        End Function

        Public Function Deleteaddress(Id As Integer) As Integer Implements IAddressRepository.DeleteAddress
            Dim rowEffect As Int32 = 0

            'declare statement
            Dim stmnt As String = "DELETE from Master.address WHERE addr_id = @id"


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

        Public Function FindAlladdress() As List(Of Address) Implements IAddressRepository.FindAllAddress
            Dim addressList As New List(Of Address)

            'Declare Statement
            Dim sql As String = "SELECT addr_id, addr_line1, addr_line2, addr_postal_code,                                      addr_spatial_location, addr_prov_id 
                                FROM Master.address 
                                ORDER BY addr_id DESC;"

            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            addressList.Add(New Address() With {
                                .Addr_Id = reader.GetInt32(0),
                                .Addr_line1 = reader.GetString(1),
                                .Addr_line2 = reader.GetString(2),
                                .Addr_postal_code = reader.GetString(3),
                                .Addr_spatial_location = reader.GetInt32(4),
                                .Addr_prov_id = reader.GetInt32(5)
                            })
                        End While

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return addressList
        End Function

        Public Function FindAlladdressAsync() As Task(Of List(Of Address)) Implements IAddressRepository.FindAllAddressAsync
            Throw New NotImplementedException()
        End Function

        Public Function FindaddressById(id As Integer) As Address Implements IAddressRepository.FindAddressById
            Dim findAddress As New Address With {.Addr_Id = id}

            Dim stmnt As String = "SELECT addr_id,addr_line1,addr_line2,addr_postal_code,addr_spatial_location                     FROM master.address 
                                   WHERE addr_id = @addr_id;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}

                    cmd.Parameters.AddWithValue("@addr_id", id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            findAddress.Addr_Id = reader.GetInt32(0)
                            findAddress.Addr_line1 = reader.GetString(1)
                            findAddress.Addr_line2 = reader.GetString(2)
                            findAddress.Addr_postal_code = reader.GetString(3)
                            findAddress.Addr_spatial_location = reader.GetInt32(4)
                            findAddress.Addr_prov_id = reader.GetInt32(5)
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return findAddress
        End Function

        Public Function UpdateaddressById(addr_id As Integer, addr_line1 As String, addr_line2 As String, addr_postal_code As String, addr_prov_id As Integer, Optional showCommand As Boolean = False) As Boolean Implements IAddressRepository.UpdateAddressById
            Dim updateaddress As New Address()

            Dim stmnt As String = " 
                                    UPDATE Master.address 
                                    SET addr_line1 = @addr_line1,
                                    addr_line2 = @addr_line2, 
                                    addr_postal_code = @addr_postal_code, 
                                    addr_prov_id = @addr_prov_id
                                    WHERE addr_id = @addr_id
                                    "

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@addr_id", addr_id)
                    cmd.Parameters.AddWithValue("@addr_line1", addr_line1)
                    cmd.Parameters.AddWithValue("@addr_line2", addr_line2)
                    cmd.Parameters.AddWithValue("@addr_postal_code", addr_postal_code)
                    cmd.Parameters.AddWithValue("@addr_prov_id", addr_prov_id)

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

        Public Function UpdateaddressBySp(addr_id As Integer, addr_line1 As String, addr_line2 As String, addr_postal_code As String, addr_prov_id As Integer, Optional showCommand As Boolean = False) As Boolean Implements IAddressRepository.UpdateAddressBySp
            Dim updateaddress As New Address()

            Dim stmnt As String = "Master.SpAddress"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@addr_id", addr_id)
                    cmd.Parameters.AddWithValue("@addr_line1", addr_line1)
                    cmd.Parameters.AddWithValue("@addr_line2", addr_line2)
                    cmd.Parameters.AddWithValue("@addr_postal_code", addr_postal_code)
                    cmd.Parameters.AddWithValue("@addr_prov_id", addr_prov_id)

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
