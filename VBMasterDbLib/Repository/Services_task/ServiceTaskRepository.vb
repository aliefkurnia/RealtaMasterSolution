Imports System.Data.SqlClient
Imports VBMasterDbLib.context
Imports VBMasterDbLib.Model

Namespace Repository
    Public Class ServiceTaskRepository
        Implements IServiceTaskRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function CreateServiceTask(ServiceTask As service_task) As service_task Implements IServiceTaskRepository.CreateServiceTask
            Dim newserviceTask As New service_task()

            Dim stmnt As String = " 
                                    INSERT INTO Master.serviceTask(seta_id,seta_name,seta_seq) 
                                    VALUES(@seta_id,@seta_name,@seta_seq    )
                                    ;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    Dim check = If(ServiceTask.Seta_seq.Equals(0), DBNull.Value, ServiceTask.Seta_seq)

                    cmd.Parameters.AddWithValue("@seta_id", ServiceTask.Seta_id)
                    cmd.Parameters.AddWithValue("@seta_name", ServiceTask.Seta_name)
                    cmd.Parameters.AddWithValue("@seta_seq", check)

                    Try
                        conn.Open()
                        Dim memb_name As String = Convert.ToString(cmd.ExecuteScalar())
                        newserviceTask = FindServiceTaskById(ServiceTask.Seta_id)

                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newserviceTask
        End Function

        Public Function DeleteServiceTask(seta_id As Integer) As Integer Implements IServiceTaskRepository.DeleteServiceTask
            Dim rowEffect As Int32 = 0

            Dim stmnt As String = "DELETE from Master.service_task WHERE seta_id = @seta_id"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@seta_id", seta_id)

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

        Public Function FindAllServiceTask() As List(Of service_task) Implements IServiceTaskRepository.FindAllServiceTask
            Dim ServiceTaskList As New List(Of service_task)
            Dim sql As String = "
                                  SELECT * FROM Master.serviceTask 
                                   ORDER BY seta_id DESC;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            ServiceTaskList.Add(New service_task() With {
                                .Seta_id = reader.GetInt32(0),
                                .Seta_name = reader.GetString(1),
                                .Seta_seq = reader.GetInt16(2)
                            })
                        End While

                        reader.Close()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return ServiceTaskList
        End Function

        Public Function FindAllServiceTaskAsync() As Task(Of List(Of service_task)) Implements IServiceTaskRepository.FindAllServiceTaskAsync
            Throw New NotImplementedException()
        End Function

        Public Function FindServiceTaskById(seta_id As Integer) As service_task Implements IServiceTaskRepository.FindServiceTaskById
            Dim findServiceTask As New service_task

            Dim stmnt As String = "SELECT *
                                   FROM master.ServiceTask 
                                   WHERE seta_id = @seta_id;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}

                    cmd.Parameters.AddWithValue("@seta_id", seta_id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            findServiceTask.Seta_id = reader.GetInt32(0)
                            findServiceTask.Seta_name = reader.GetString(1)
                            findServiceTask.Seta_seq = reader.GetInt16(0)
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return findServiceTask
        End Function

        Public Function UpdateServiceTaskById(seta_id As Integer, seta_name As String, seta_seq As Short, Optional showCommand As Boolean = False) As Boolean Implements IServiceTaskRepository.UpdateServiceTaskById
            Dim updateServiceTask As New service_task()

            Dim stmnt As String = " UPDATE Master.ServiceTask 
                                    SET 
                                    seta_id = @seta_id,
                                    seta_name = @seta_name,
                                    seta_seq = @seta_seq 
                                    WHERE seta_id = @seta_id
                                    "

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt}
                    cmd.Parameters.AddWithValue("@seta_id", seta_id)
                    cmd.Parameters.AddWithValue("@seta_name", seta_name)
                    cmd.Parameters.AddWithValue("@seta_seq", seta_seq)

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

        Public Function UpdateServiceTaskBySp(seta_id As Integer, seta_name As String, seta_seq As Short, Optional showCommand As Boolean = False) As Boolean Implements IServiceTaskRepository.UpdateServiceTaskBySp
            Dim updateServiceTask As New service_task()

            Dim stmnt As String = "Master.SpServiceTask"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmnt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@seta_id", seta_id)
                    cmd.Parameters.AddWithValue("@seta_name", seta_name)
                    cmd.Parameters.AddWithValue("@seta_seq", seta_seq)

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
