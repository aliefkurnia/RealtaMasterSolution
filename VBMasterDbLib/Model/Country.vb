Namespace Model
    Public Class Country

        Private _country_id As Integer
        Private _country_name As String
        Private _country_region_id As Integer

        Public Sub New()
        End Sub

        Public Sub New(country_id As Integer, country_name As String, country_region_id As Integer)
            Me.Country_id = country_id
            Me.Country_name = country_name
            Me.Country_region_id = country_region_id
        End Sub

        Public Property Country_id As Integer
            Get
                Return _country_id
            End Get
            Set(value As Integer)
                _country_id = value
            End Set
        End Property

        Public Property Country_name As String
            Get
                Return _country_name
            End Get
            Set(value As String)
                _country_name = value
            End Set
        End Property

        Public Property Country_region_id As Integer
            Get
                Return _country_region_id
            End Get
            Set(value As Integer)
                _country_region_id = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
CountryId   : {Country_id}
CountryName : {Country_name} 
counRegId   : {Country_region_id}"
        End Function
    End Class


End Namespace
