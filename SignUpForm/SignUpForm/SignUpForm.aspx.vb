Public Class SignUpForm
    Inherits System.Web.UI.Page
    Private DB As New DBAccess

    Private Const ALREADY_IN_DB As String = "Already in DB"

    'Adding Years to the drop down
    Private Sub AddYearsToYearDropDown()
        For i As Integer = 0 To 6
            GraduationYearDropDownList.Items.Add(Date.Today.Year + i)
        Next
    End Sub



    'Method to clear all text boxes
    Private Sub ClearAll()
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        EmailTextBox.Text = ""
        MajorCourseTextBox.Text = ""
        ClassStandingDropDown.SelectedIndex = -1
        MinorTextBox.Text = ""
        clubTextBox.Text = ""
        GraduationMonthDropDownList.SelectedIndex = -1
        GraduationYearDropDownList.Items.Clear()
        ' CompanyDropDownList.SelectedIndex = -1
        TShirtSizeDropDownList.SelectedIndex = -1
        desiredTeamMateOneTextBox.Text = ""
        desiredTeamMateTwoTextBox.Text = ""
        desiredTeamMateThreeTextBox.Text = ""
    End Sub

    'Clear button click method
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ClearAll()
    End Sub

    'Method to validate inputs
    Private Function ValidateInputs() As String
        If String.IsNullOrEmpty(FirstNameTextBox.Text) Then
            Return "Please enter first Name"
        ElseIf String.IsNullOrEmpty(LastNameTextBox.Text) Then
            Return "Please enter last name"
        ElseIf String.IsNullOrEmpty(EmailTextBox.Text) Then
            Return "Please enter email"
        ElseIf ClassStandingDropDown.SelectedIndex = -1 Then
            Return "Please select proper class standing"
        ElseIf String.IsNullOrEmpty(MajorCourseTextBox.Text) Then
            Return "Please enter Major or Course or None if you do not have any"

        ElseIf String.IsNullOrEmpty(MinorTextBox.Text) Then
            Return "Please enter minor or None if you don't have any minor"
        ElseIf String.IsNullOrEmpty(clubTextBox.Text) Then
            Return "Please enter club or None if you don't have any club"
        ElseIf GraduationMonthDropDownList.SelectedIndex = -1 Or GraduationYearDropDownList.SelectedIndex = -1 Then
            Return "Please enter valid graduation date"
        ElseIf TShirtSizeDropDownList.SelectedIndex = -1 Then
            Return "Please enter valid t-shirt size"
        End If

        Return "All correct"
    End Function

    'Method to insert participants
    Private Sub AddParticipant()
        Dim grad As String
        grad = GraduationMonthDropDownList.SelectedItem.ToString + " " + GraduationYearDropDownList.SelectedItem.ToString
        DB.AddParam("@firstname", FirstNameTextBox.Text)
        DB.AddParam("@lastname", LastNameTextBox.Text)
        DB.AddParam("@email", EmailTextBox.Text)
        DB.AddParam("tshirtsize", TShirtSizeDropDownList.SelectedItem.Text)
        DB.AddParam("major", MajorCourseTextBox.Text)
        DB.AddParam("minor", MinorTextBox.Text)

        DB.AddParam("grad", grad)
        DB.AddParam("classstanding", ClassStandingDropDown.SelectedItem.Text)
        DB.AddParam("club", clubTextBox.Text)
        DB.AddParam("liason", 0)
        ' DB.AddParam("team_id", 6)

        DB.ExecuteQuery("insert into participant(first_name,last_name,cmu_email,shirt_size,major_program,minor,expected_graduation,class_standing
,club,liaison) values(?,?,?,?,?,?,?,?,?,?)")
        If DB.Exception <> String.Empty Then
            MsgBox(DB.Exception)
            Exit Sub
        End If

    End Sub

    Private Function CheckIfUserExsists(email As String) As String
        Dim s As Integer = -1
        DB.AddParam("email", email)

        DB.ExecuteQuery("select * from participant where cmu_email=?")
        Try
            s = Integer.Parse(DB.DBDataTable(0)!id)
        Catch ex As Exception

        End Try

        If s = -1 Then
            Return "Not in DB"
        Else
            Return ALREADY_IN_DB
        End If


        Return ALREADY_IN_DB

    End Function

    Private Function CheckIfUserPresentInEvent(email As String) As String
        Dim s As String
        DB.AddParam("email", email)
        DB.ExecuteQuery("select * from participant 
join participation on participant.id = participation.participant_id
join event on participation.event_id=event.id
where participant.cmu_email=? and event.date > current_date()")
        Try
            s = DB.DBDataTable(0)!cmu_email
        Catch ex As Exception
            Return "User not in event"
        End Try

        If String.IsNullOrEmpty(s) Then
            Return " User not in event "
        Else
            Return "Already Registered"
        End If

    End Function

    'Method to handle save button click
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim checkUser As String
        Dim succuess_registration As String
        Dim checkIfRegistered As String
        ValidateInputs()

        If ValidateInputs() <> "All correct" Then
            MsgBox(ValidateInputs())
            Exit Sub
        End If
        checkUser = CheckIfUserExsists(EmailTextBox.Text)
        If checkUser = ALREADY_IN_DB Then
            checkIfRegistered = CheckIfUserPresentInEvent(EmailTextBox.Text)
            If checkIfRegistered = "Already Registered" Then
                Response.Redirect("AlreadyRegistered.html")
                Exit Sub
            End If
            AddDesiredTeamMates()
            AddToEvent(EmailTextBox.Text)
            Response.Redirect("ThankYou.aspx")
            Exit Sub
        End If
        AddParticipant()
        succuess_registration = AddToEvent(EmailTextBox.Text)
        AddDesiredTeamMates()
        If succuess_registration = "success" Then

            Response.Redirect("ThankYou.aspx")
        Else
            Response.Redirect("No_game_exsists.html")
        End If

    End Sub

    Private Sub AddDesiredTeamMates()
        Dim s As Integer = -1
        DB.AddParam("email", EmailTextBox.Text)

        DB.ExecuteQuery("select * from participant where cmu_email=?")
        Try
            s = Integer.Parse(DB.DBDataTable(0)!id)
        Catch ex As Exception

        End Try

        If s = -1 Then
            Exit Sub
        Else
            If Not String.IsNullOrWhiteSpace(desiredTeamMateOneTextBox.Text) Then
                AddDesired(s, desiredTeamMateOneTextBox.Text)
            End If
            If Not String.IsNullOrWhiteSpace(desiredTeamMateTwoTextBox.Text) Then
                AddDesired(s, desiredTeamMateTwoTextBox.Text)
            End If
            If Not String.IsNullOrWhiteSpace(desiredTeamMateThreeTextBox.Text) Then
                AddDesired(s, desiredTeamMateThreeTextBox.Text)
            End If
        End If


    End Sub

    Private Sub AddDesired(id As Integer, name As String)
        DB.AddParam("id", id)
        DB.AddParam("name", name)
        DB.ExecuteQuery("insert into desired_teammates(participant_id,desired_teammate) values(?,?)")
    End Sub

    Private Function AddToEvent(email As String) As String
        Dim id, event_id As Integer
        DB.AddParam("email", email)
        DB.ExecuteQuery("select * from participant where cmu_email=?")
        Try
            id = Integer.Parse(DB.DBDataTable(0)!id)
        Catch ex As Exception

        End Try


        DB.ExecuteQuery("select id from event where date > curdate() ")
        Try
            event_id = DB.DBDataTable(0)!id
        Catch ex As Exception
            Return "No game"
        End Try
        DB.AddParam("parti_id", id)
        DB.AddParam("event_id", event_id)
        DB.ExecuteQuery("insert into participation(participant_id,event_id) values(?,?) ")
        Return "success"
    End Function

    'Adding years to the drop down
    Private Sub SignUpForm_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        AddYearsToYearDropDown()

    End Sub




End Class