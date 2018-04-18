Imports System.Data.Odbc
Public Class DBAccess
    Private ConnectionString As String = " Driver={MySQL ODBC 5.3 ANSI Driver}; server=141.209.241.47; database=bis698c1g2; user=bis698c1g2; password=firstpass"

    'creating a connection for new database
    Private DBConnection As New OdbcConnection(ConnectionString)

    Private DBCommand As OdbcCommand

    Public DBDataAdapter As OdbcDataAdapter
    Public DBDataTable As DataTable

    'to pull parameters and detail information from database'
    Public params As New List(Of OdbcParameter)

    'public variables 
    Public Recordcount As Integer
    Public Exception As String

    Public Sub ExecuteQuery(QueryString As String)
        Recordcount = 0
        Exception = String.Empty
        'try catch parameters loop
        Try
            DBConnection.Open()
            DBCommand = New OdbcCommand(QueryString, DBConnection)
            ' for each is a parameter 
            For Each p As OdbcParameter In params
                DBCommand.Parameters.Add(p)
            Next
            'to clear the parameters which went wrong 
            params.Clear()

            DBDataTable = New DataTable
            DBDataAdapter = New OdbcDataAdapter(DBCommand)

            'records the data entered into the table in database
            Recordcount = DBDataAdapter.Fill(DBDataTable)

        Catch ex As Exception
            'to excempt the errors in the data entered, will catch the error and gives an error message
            Exception = ex.Message

        End Try

        ' auto close database
        If DBConnection.State = ConnectionState.Open Then
            DBConnection.Close()
        End If

    End Sub

    Public Sub AddParam(Name As String, value As Object)
        Dim NewParam As New OdbcParameter(Name, value)
        params.Add(NewParam)

    End Sub

End Class
