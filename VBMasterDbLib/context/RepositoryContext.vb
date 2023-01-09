
Namespace context
    Public Class RepositoryContext
        Implements IRepositoryContext

        Private ReadOnly _connString As String

        Public Sub New(connString As String)
            _connString = connString
        End Sub

        Public Function GetConnectionString() As Object Implements IRepositoryContext.GetConnectionString
            Return _connString
        End Function
    End Class

End Namespace
