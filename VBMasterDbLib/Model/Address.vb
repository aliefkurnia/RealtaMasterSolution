Namespace Model
    Public Class Address

        Private _addr_Id As Integer
        Private _addr_line1 As String
        Private _addr_line2 As String
        Private _addr_postal_code As String
        Private _addr_spatial_location As String
        Private _addr_prov_id As Integer

        Public Sub New()
        End Sub

        Public Sub New(addrId As Integer, addr_line1 As String, addr_line2 As String, addr_postal_code As String, addr_spatial_location As String, addr_prov_id As Integer)
            Me.Addr_Id = addrId
            Me.Addr_line1 = addr_line1
            Me.Addr_line2 = addr_line2
            Me.Addr_postal_code = addr_postal_code
            Me.Addr_spatial_location = addr_spatial_location
            Me.Addr_prov_id = addr_prov_id
        End Sub

        Public Property Addr_Id As Integer
            Get
                Return _addr_Id
            End Get
            Set(value As Integer)
                _addr_Id = value
            End Set
        End Property

        Public Property Addr_line1 As String
            Get
                Return _addr_line1
            End Get
            Set(value As String)
                _addr_line1 = value
            End Set
        End Property

        Public Property Addr_line2 As String
            Get
                Return _addr_line2
            End Get
            Set(value As String)
                _addr_line2 = value
            End Set
        End Property

        Public Property Addr_postal_code As String
            Get
                Return _addr_postal_code
            End Get
            Set(value As String)
                _addr_postal_code = value
            End Set
        End Property

        Public Property Addr_spatial_location As String
            Get
                Return _addr_spatial_location
            End Get
            Set(value As String)
                _addr_spatial_location = value
            End Set
        End Property

        Public Property Addr_prov_id As Integer
            Get
                Return _addr_prov_id
            End Get
            Set(value As Integer)
                _addr_prov_id = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
addresId              : {Addr_Id} 
addressLine1          : {Addr_line1} 
addressLine2          : {Addr_line2} 
addressPostalCode     : {Addr_postal_code} 
addressSpatialLocation: {Addr_spatial_location} 
addressProvId         : {Addr_prov_id} "
        End Function

    End Class
End Namespace
