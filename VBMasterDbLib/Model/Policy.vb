Namespace Model
    Public Class Policy
        Private _poli_id As Integer
        Private _poli_name As String
        Private _poli_description As String

        Public Sub New()
        End Sub

        Public Sub New(poli_id As Integer, poli_name As String, poli_description As String)
            Me.Poli_id = poli_id
            Me.Poli_name = poli_name
            Me.Poli_description = poli_description
        End Sub

        Public Property Poli_id As Integer
            Get
                Return _poli_id
            End Get
            Set(value As Integer)
                _poli_id = value
            End Set
        End Property

        Public Property Poli_name As String
            Get
                Return _poli_name
            End Get
            Set(value As String)
                _poli_name = value
            End Set
        End Property

        Public Property Poli_description As String
            Get
                Return _poli_description
            End Get
            Set(value As String)
                _poli_description = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
poli_id          : {Poli_id} 
poli_name        : {Poli_name} 
poli_description : {Poli_description} "
        End Function
    End Class

End Namespace
