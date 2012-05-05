Public Class CLecturer

    Public Property full_Name() As [String]
        Get
            Return m_full_Name
        End Get
        Set(ByVal value As [String])
            m_full_Name = value
        End Set
    End Property
    Private m_full_Name As [String]
    Public Property lecturer_id() As [String]
        Get
            Return m_lecturer_id
        End Get
        Set(ByVal value As [String])
            m_lecturer_id = value
        End Set
    End Property
    Private m_lecturer_id As [String]
    Public Overrides Function ToString() As String
        Return full_Name
    End Function
    Public Sub New(ByVal lecturer_id As [String], ByVal fullName As [String])
        m_lecturer_id = lecturer_id
        m_full_Name = fullName

    End Sub


End Class
