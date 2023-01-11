Namespace Model
    Public Class service_task

        Private _seta_id As Integer
        Private _seta_name As String
        Private _seta_seq As Int16

        Public Sub New()
        End Sub

        Public Sub New(seta_id As Integer, seta_name As String, seta_seq As Short)
            Me.Seta_id = seta_id
            Me.Seta_name = seta_name
            Me.Seta_seq = seta_seq
        End Sub

        Public Property Seta_id As Integer
            Get
                Return _seta_id
            End Get
            Set(value As Integer)
                _seta_id = value
            End Set
        End Property

        Public Property Seta_name As String
            Get
                Return _seta_name
            End Get
            Set(value As String)
                _seta_name = value
            End Set
        End Property

        Public Property Seta_seq As Short
            Get
                Return _seta_seq
            End Get
            Set(value As Short)
                _seta_seq = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
seta id     : {Seta_id} 
seta name   : {Seta_name}
seta seq    : {Seta_seq}"
        End Function
    End Class

End Namespace
