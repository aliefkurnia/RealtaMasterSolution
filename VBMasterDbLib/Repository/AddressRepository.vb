Imports System.Data.SqlClient
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
                    cmd.Parameters.AddWithValue("@Addr_Id", address.Addr_Id)
                    cmd.Parameters.AddWithValue("@Addr_line1", address.Addr_line1)
                    cmd.Parameters.AddWithValue("@Addr_line2", address.Addr_line2)
                    cmd.Parameters.AddWithValue("@Addr_postal_code", address.Addr_postal_code)
                    cmd.Parameters.AddWithValue("@Addr_spatial_location", address.Addr_spatial_location)
                    cmd.Parameters.AddWithValue("@Addr_prov_id", address.Addr_prov_id)

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
            Throw New NotImplementedException()
        End Function

        Public Function FindAlladdress() As List(Of Address) Implements IAddressRepository.FindAllAddress
            Dim addressList As New List(Of Address)

            'Declare Statement
            Dim sql As String = "SELECT addr_id, addr_line1, addr_line2, addr_postal_code, addr_spatial_location, addr_prov_id " &
                                "FROM Master.address " &
                                "ORDER BY addr_id DESC;"

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
                                .Addr_spatial_location = reader.ToString(4),
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
            Throw New NotImplementedException()
        End Function

        Public Function UpdateaddressById(id As Integer, value As String, Optional showCommand As Boolean = False) As Boolean Implements IAddressRepository.UpdateAddressById
            Throw New NotImplementedException()
        End Function

        Public Function UpdateaddressBySp(id As Integer, value As String, Optional showCommand As Boolean = False) As Boolean Implements IAddressRepository.UpdateAddressBySp
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace
