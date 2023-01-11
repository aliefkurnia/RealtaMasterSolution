Imports VBMasterDbLib.Model

Namespace Repository
    Public Interface IServiceTaskRepository

        Function CreateServiceTask(ByVal ServiceTask As service_task) As service_task

        Function DeleteServiceTask(ByVal seta_id As Integer) As Integer

        Function FindAllServiceTask() As List(Of service_task)

        Function FindAllServiceTaskAsync() As Task(Of List(Of service_task))

        Function FindServiceTaskById(ByVal seta_id As Integer) As service_task

        Function UpdateServiceTaskById(seta_id As Integer, seta_name As String, seta_seq As Int16, Optional showCommand As Boolean = False) As Boolean

        Function UpdateServiceTaskBySp(seta_id As Integer, seta_name As String, seta_seq As Int16, Optional showCommand As Boolean = False) As Boolean

    End Interface

End Namespace
