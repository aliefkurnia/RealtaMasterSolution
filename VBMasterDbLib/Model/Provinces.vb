Namespace Model
    Public Class Provinces

        Private _prov_id As Integer
        Private _prov_name As String
        Private _prov_country_id As Integer



        Public Sub New()
        End Sub

        Public Sub New(prov_id As Integer, prov_name As String, prov_country_id As String)
            Me.Prov_id = prov_id
            Me.Prov_name = prov_name
            Me.Prov_country_id = prov_country_id
        End Sub

        Public Property Prov_id As Integer
            Get
                Return _prov_id
            End Get
            Set(value As Integer)
                _prov_id = value
            End Set
        End Property

        Public Property Prov_name As String
            Get
                Return _prov_name
            End Get
            Set(value As String)
                _prov_name = value
            End Set
        End Property

        Public Property Prov_country_id As Integer
            Get
                Return _prov_country_id
            End Get
            Set(value As Integer)
                _prov_country_id = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
provincesId     : {Prov_id}
provincesName   : {Prov_name} 
provCountryId   : {Prov_country_id}"

        End Function
    End Class
End Namespace
