Namespace Model
    Public Class Regions

        Private _region_code As Integer
        Private _region_name As String

        Public Sub New()
        End Sub

        Public Sub New(region_code As Integer, region_name As String)
            Me.Region_code = region_code
            Me.Region_name = region_name
        End Sub

        Public Property Region_code As Integer
            Get
                Return _region_code
            End Get
            Set(value As Integer)
                _region_code = value
            End Set
        End Property

        Public Property Region_name As String
            Get
                Return _region_name
            End Get
            Set(value As String)
                _region_name = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
Region code  : {Region_code} 
Region name  : {Region_name} "

        End Function
    End Class
End Namespace
