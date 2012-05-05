Public Class CGroup

    Public Property group_Name() As [String]
        Get
            Return m_group_Name
        End Get
        Set(ByVal value As [String])
            m_group_Name = value
        End Set
    End Property
    Private m_group_Name As [String]
   

    Public Overrides Function ToString() As String
        Return group_Name
    End Function
    Public Sub New(ByVal groupName As [String])

        m_group_Name = groupName

    End Sub
End Class
