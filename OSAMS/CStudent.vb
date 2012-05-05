Public Class CStudent
    Private m_regdno As String
    Private m_sname As String

    Public Sub New(ByVal r As String, ByVal n As String)
        regdno = r
        sname = n
    End Sub
    Public Property regdno() As String
        Get
            Return m_regdno
        End Get
        Set(ByVal Value As String)
            m_regdno = Value
        End Set
    End Property

    Public Property sname() As String
        Get
            Return m_sname
        End Get
        Set(ByVal Value As String)
            m_sname = Value
        End Set
    End Property
End Class
