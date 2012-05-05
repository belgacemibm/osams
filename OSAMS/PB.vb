Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class PB
    Public Shared Function getConnectionString() As String
        Dim connstr As String
        connstr = ConfigurationManager.ConnectionStrings("connstr").ConnectionString
        Return connstr
    End Function


    Public Shared Function getdatabasename() As String
        Dim dbname As String
        dbname = ConfigurationManager.AppSettings("databasename")
        Return dbname

    End Function

    Public Shared Function getData(ByVal sql As String) As DataTable

        Dim myds As New DataTable
        myds = New DataTable
        Dim da As New SqlDataAdapter
        Dim strConn As String
        Try
            strConn = getConnectionString()
            Dim connection As New SqlConnection(strConn)
            connection.Open()


            da.SelectCommand = New SqlCommand(sql, connection)
            da.Fill(myds)


            If myds.Rows.Count <> 0 Then

                connection.Close()

                Return myds
            Else
                'myds = Nothing
                connection.Close()
                Return myds

            End If
        Catch ex As Exception

        End Try



    End Function

    Public Shared Function extractData(ByVal sql As String) As DataSet
        Dim ds As New DataSet
        Dim myds As New DataTable
        Dim da As New SqlDataAdapter
        Dim strConn As String
        strConn = getConnectionString()
        Dim connection As New SqlConnection(strConn)
        connection.Open()


        da.SelectCommand = New SqlCommand(sql, connection)
        da.Fill(myds)


        If myds.Rows.Count <> 0 Then
            da.Fill(ds)
            connection.Close()

            Return ds
        Else
            ds = Nothing
            connection.Close()
            Return ds

        End If


    End Function
    Public Shared Function runquery(ByVal sql As String) As Boolean
        Dim inserted As Boolean = False


        Dim strConn As String
        strConn = getConnectionString()
        Dim connection As New SqlConnection(strConn)
        Dim cmd As SqlCommand

        Try
            connection.Open()

            ' Initialize the SqlCommand with the new SQL string.
            cmd = New SqlCommand(sql, connection)
            cmd.ExecuteNonQuery()


            connection.Close()
            inserted = True

        Catch ex As Exception

        End Try


        Return inserted

    End Function

    Public Shared Function getAccountType(ByVal ID As String) As String
        'Get account type
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        getAccountType = ""

        Dim str As String

        str = PB.getConnectionString()

        cnn = New SqlConnection(str)
        Try
            cnn.Open()
            cmd = New SqlCommand("Select * from account where user_name = '" & ID & "'", cnn)
            dr = cmd.ExecuteReader

            While dr.Read
                getAccountType = dr("account_type_id")
            End While

        Catch ex As Exception
            cnn.Close()
        End Try
        cnn.Close()
        Return getAccountType
    End Function

    Public Shared Function checkEsixtedData(ByVal sql As String) As Boolean
        '------------------------------------------------------------
        ' function  : checkEsixtedData
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to check the data does it existed or not
        '------------------------------------------------------------
        ' Incoming Parameters
        ' 
        '
        '
        '------------------------------------------------------------

        Dim exist As Boolean
        exist = False
        Dim myds As New DataTable
        Dim da As New SqlDataAdapter

        Dim connection As New SqlConnection(getConnectionString())
        connection.Open()


        da.SelectCommand = New SqlCommand(sql, connection)
        da.Fill(myds)

        If Not myds.Rows.Count = 0 Then
            exist = True
        End If

        connection.Close()
        Return exist

    End Function



    Public Shared Sub sendMail(ByVal fromMail As String, ByVal toMail As String, ByVal subject As String, ByVal body As StringBuilder, ByVal pass As String)

        Try
            Dim sb As StringBuilder


            Dim mail As New MailMessage(fromMail, toMail, subject, body.ToString)
            Dim smtp As New SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.EnableSsl = True
            Dim cre As New System.Net.NetworkCredential(fromMail, pass)
            smtp.Credentials = cre
            smtp.Send(mail)

        Catch ex As Exception

        End Try



    End Sub

End Class
