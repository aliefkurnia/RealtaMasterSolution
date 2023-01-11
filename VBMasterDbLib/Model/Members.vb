Namespace Model
    Public Class Members

        Private _memb_name As String
        Private _memb_description As String

        Public Sub New()
            _memb_name = ""
            _memb_description = ""
        End Sub

        Public Sub New(memb_name As String, memb_description As String)
            Me.Memb_name = memb_name
            Me.Memb_description = memb_description
        End Sub

        Public Property Memb_name As String
            Get
                Return _memb_name
            End Get
            Set(value As String)
                _memb_name = value
            End Set
        End Property

        Public Property Memb_description As String
            Get
                Return _memb_description
            End Get
            Set(value As String)
                _memb_description = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
membName        : {Memb_name} 
membDescription : {Memb_description} "
        End Function
    End Class
End Namespace
