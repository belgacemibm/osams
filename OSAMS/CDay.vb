Public Class CDay

    Public Property GroupID() As [String]
        Get
            Return m_group_id
        End Get
        Set(ByVal value As [String])
            m_group_id = value
        End Set
    End Property
    Private m_group_id As [String]

    Public Property GroupName() As [String]
        Get
            Return m_group_Name
        End Get
        Set(ByVal value As [String])
            m_group_Name = value
        End Set
    End Property
    Private m_group_Name As [String]
    
    Public Property NumberOfStudent() As Integer
        Get
            Return m_number_of_student
        End Get
        Set(ByVal value As Integer)
            m_number_of_student = value
        End Set
    End Property
    Private m_number_of_student As Integer

    Public Property CourseID() As [String]
        Get
            Return m_course_id
        End Get
        Set(ByVal value As [String])
            m_course_id = value
        End Set
    End Property
    Private m_course_id As [String]

    Public Property SemesterName() As [String]
        Get
            Return m_semester_name
        End Get
        Set(ByVal value As [String])
            m_semester_name = value
        End Set
    End Property
    Private m_semester_name As [String]

    Public Property LecturerName() As [String]
        Get
            Return m_lecturer_name
        End Get
        Set(ByVal value As [String])
            m_lecturer_name = value
        End Set
    End Property
    Private m_lecturer_name As [String]

    Public Property Day_1() As [String]
        Get
            Return m_day1
        End Get
        Set(ByVal value As [String])
            m_day1 = value
        End Set
    End Property
    Private m_day1 As [String]

    Public Property StartTime_1() As [String]
        Get
            Return m_start_time1
        End Get
        Set(ByVal value As [String])
            m_start_time1 = value
        End Set
    End Property
    Private m_start_time1 As [String]


    Public Property EndTime_1() As [String]
        Get
            Return m_end_time1
        End Get
        Set(ByVal value As [String])
            m_end_time1 = value
        End Set
    End Property
    Private m_end_time1 As [String]

    Public Property Type_1() As [String]
        Get
            Return m_type1
        End Get
        Set(ByVal value As [String])
            m_type1 = value
        End Set
    End Property
    Private m_type1 As [String]


    Public Property Day_2() As [String]
        Get
            Return m_day2
        End Get
        Set(ByVal value As [String])
            m_day2 = value
        End Set
    End Property
    Private m_day2 As [String]

   
    Public Property StartTime_2() As [String]
        Get
            Return m_start_time2
        End Get
        Set(ByVal value As [String])
            m_start_time2 = value
        End Set
    End Property
    Private m_start_time2 As [String]

    Public Property EndTime_2() As [String]
        Get
            Return m_end_time2
        End Get
        Set(ByVal value As [String])
            m_end_time2 = value
        End Set
    End Property
    Private m_end_time2 As [String]

    
    Public Property Type_2() As [String]
        Get
            Return m_type2
        End Get
        Set(ByVal value As [String])
            m_type2 = value
        End Set
    End Property
    Private m_type2 As [String]


    Public Overrides Function ToString() As String
        Return GroupName
    End Function

    Public Sub New()

    End Sub
    Public Sub New(ByVal groupName As [String], ByVal groupID As [String], ByVal numberOfStudent As [String], ByVal courseID As [String], ByVal semesterName As [String], ByVal lecturerName As [String], ByVal day1 As [String], ByVal startTime1 As [String], ByVal endTime1 As [String], ByVal type1 As [String], ByVal day2 As [String], ByVal startTime2 As [String], ByVal endTime2 As [String], ByVal type2 As [String])
        m_group_id = groupID
        m_group_Name = groupName
        m_number_of_student = numberOfStudent
        m_course_id = courseID
        m_semester_name = semesterName
        m_lecturer_name = lecturerName
        m_day1 = day1
        m_start_time1 = startTime1
        m_end_time1 = endTime1
        m_type1 = type1
        m_day2 = day2
        m_start_time2 = startTime2
        m_end_time2 = endTime2
        m_type2 = type2

    End Sub
End Class

