' General Procedures and Repetition Programming Assignment
' Purpose: Calculate the total cost of the meals being served based on the number of
' people And the type of service.
' Josiah Barringer

' I will not use code that was never covered in class or in our textbook. 
' If you do, you must be able to explain your code when the professor asks. 
' Using code outside of the resources provided can be flagged and reported 
' as an academic integrity violation if there is any suspicion of copying/cheating.

Public Class Form1
    ' Function to determine the cost per meal based on the serving time
    Private Function GetMealCost(ByVal servingTime As String) As Decimal
        Select Case servingTime
            Case "Breakfast"
                Return 10D
            Case "Lunch"
                Return 15D
            Case "Dinner"
                Return 20D
            Case Else
                Return 0D
        End Select
    End Function

    ' Subroutine to display the volunteer names in the ListBox
    Private Sub DisplayVolunteers(ByVal numVolunteers As Integer)
        lstOutput.Items.Add("The following is a list of volunteers:")
        lstOutput.Items.Add("_______________________________________")
        For i As Integer = 1 To numVolunteers
            Dim name As String = InputBox("Enter the name of volunteer #" & i.ToString(), "Volunteer Names")
            lstOutput.Items.Add(name)
        Next
    End Sub

    ' Calculate button click event
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        ' Clear previous output
        lstOutput.Items.Clear()

        ' Input validation
        If txtNumPeople.Text = "" Then
            MessageBox.Show("Please enter the number of people served.", "Input Error")
            txtNumPeople.Focus()
            Exit Sub
        End If

        If txtNumVolunteers.Text = "" Then
            MessageBox.Show("Please enter the number of volunteers.", "Input Error")
            txtNumVolunteers.Focus()
            Exit Sub
        End If

        If cmbServingTime.SelectedIndex = -1 Then
            MessageBox.Show("Please select a serving time.", "Input Error")
            cmbServingTime.Focus()
            Exit Sub
        End If

        ' Store inputs in variables
        Dim numPeople As Integer = CInt(txtNumPeople.Text)
        Dim numVolunteers As Integer = CInt(txtNumVolunteers.Text)
        Dim servingTime As String = cmbServingTime.SelectedItem.ToString()
        Dim costPerPerson As Decimal = GetMealCost(servingTime)
        Dim totalCost As Decimal = costPerPerson * numPeople
        Dim discount As Decimal = 0D
        Dim discountApplied As Boolean = False

        If numPeople > 10 Then
            discount = totalCost * 0.1D
            totalCost -= discount
            discountApplied = True
        End If

        ' Display the results in the ListBox
        lstOutput.Items.Add("You are volunteering to serve  " & servingTime & ".")
        lstOutput.Items.Add("Your cost per person is $" & costPerPerson.ToString("F2"))
        lstOutput.Items.Add("The total cost is $" & totalCost.ToString("F2"))
        If discountApplied Then
            lstOutput.Items.Add("A 10% discount has been applied.")
        End If
        lstOutput.Items.Add("You are bringing " & numVolunteers.ToString() & " to help serve.")

        ' Display volunteer names
        DisplayVolunteers(numVolunteers)
    End Sub

    ' Clear button click event
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtNumPeople.Clear()
        txtNumVolunteers.Clear()
        cmbServingTime.SelectedIndex = -1
        lstOutput.Items.Clear()
    End Sub

    ' Close button click event
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
