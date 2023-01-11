Namespace Model
    Public Class Policy_Category_Group

        Private _poca_poli_id As Integer
        Private _poca_cagro_id As Integer

        Public Sub New()
        End Sub

        Public Sub New(poca_poli_id As Integer, poca_cagro_id As Integer)
            Me.poca_poli_id = poca_poli_id
            Me.poca_cagro_id = poca_cagro_id
        End Sub

        Public Property Poca_poli_id As Integer
            Get
                Return _poca_poli_id
            End Get
            Set(value As Integer)
                _poca_poli_id = value
            End Set
        End Property

        Public Property Poca_cagro_id As Integer
            Get
                Return _poca_cagro_id
            End Get
            Set(value As Integer)
                _poca_cagro_id = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
Poca_poli_id  : {Poca_poli_id} 
Poca_cagro_id : {Poca_cagro_id} "
        End Function
    End Class

End Namespace
