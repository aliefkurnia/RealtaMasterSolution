Namespace Model
    Public Class price_items
        Private _prit_id As Integer
        Private _prit_name As String
        Private _prit_price As Double
        Private _prit_description As String
        Private _prit_type As String
        Private _prit_modified_date As String

        Public Sub New()
        End Sub

        Public Sub New(prit_id As Integer, prit_name As String, prit_price As Double, prit_description As String, prit_type As String, prit_modified_date As String)
            Me.Prit_id = prit_id
            Me.Prit_name = prit_name
            Me.Prit_price = prit_price
            Me.Prit_description = prit_description
            Me.Prit_type = prit_type
            Me.Prit_modified_date = prit_modified_date
        End Sub

        Public Property Prit_id As Integer
            Get
                Return _prit_id
            End Get
            Set(value As Integer)
                _prit_id = value
            End Set
        End Property

        Public Property Prit_name As String
            Get
                Return _prit_name
            End Get
            Set(value As String)
                _prit_name = value
            End Set
        End Property

        Public Property Prit_price As Double
            Get
                Return _prit_price
            End Get
            Set(value As Double)
                _prit_price = value
            End Set
        End Property

        Public Property Prit_description As String
            Get
                Return _prit_description
            End Get
            Set(value As String)
                _prit_description = value
            End Set
        End Property

        Public Property Prit_type As String
            Get
                Return _prit_type
            End Get
            Set(value As String)
                _prit_type = value
            End Set
        End Property

        Public Property Prit_modified_date As String
            Get
                Return _prit_modified_date
            End Get
            Set(value As String)
                _prit_modified_date = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
prit_id            : {Prit_id} 
prit_name          : {Prit_name}
prit_price         : {Prit_price}
prit_description   : {Prit_description}
prit_type          : {Prit_type}
prit_modified_date : {Prit_modified_date}"
        End Function
    End Class

End Namespace
