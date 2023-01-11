Namespace Model
    Public Class category_Group
        Private _cagro_id As Integer
        Private _cagro_name As String
        Private _cagro_description As String
        Private _cagro_type As String
        Private _cagro_icon As String
        Private _cagro_icon_url As String

        Public Sub New()
        End Sub

        Public Sub New(cagro_id As Integer, cagro_name As String, cagro_description As String, cagro_type As String, cagro_icon As String, cagro_icon_url As String)
            Me.Cagro_id = cagro_id
            Me.Cagro_name = cagro_name
            Me.Cagro_description = cagro_description
            Me.Cagro_type = cagro_type
            Me.Cagro_icon = cagro_icon
            Me.Cagro_icon_url = cagro_icon_url
        End Sub

        Public Property Cagro_id As Integer
            Get
                Return _cagro_id
            End Get
            Set(value As Integer)
                _cagro_id = value
            End Set
        End Property

        Public Property Cagro_name As String
            Get
                Return _cagro_name
            End Get
            Set(value As String)
                _cagro_name = value
            End Set
        End Property

        Public Property Cagro_description As String
            Get
                Return _cagro_description
            End Get
            Set(value As String)
                _cagro_description = value
            End Set
        End Property

        Public Property Cagro_type As String
            Get
                Return _cagro_type
            End Get
            Set(value As String)
                _cagro_type = value
            End Set
        End Property

        Public Property Cagro_icon As String
            Get
                Return _cagro_icon
            End Get
            Set(value As String)
                _cagro_icon = value
            End Set
        End Property

        Public Property Cagro_icon_url As String
            Get
                Return _cagro_icon_url
            End Get
            Set(value As String)
                _cagro_icon_url = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
cagro_id           : {cagro_id} 
cagro_name         : {Cagro_name} 
cagro_description  : {Cagro_description} 
cagro_type         : {Cagro_type} 
cagro_icon         : {Cagro_icon} 
cagro_icon_url     : {Cagro_icon_url} "

        End Function
    End Class

End Namespace
