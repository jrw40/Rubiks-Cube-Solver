Public Class Form1

    'stores values in moves box and layout for when a solve step by step is being carried out
    Dim temp1 As String
    Dim temp2 As String
    Dim holder(5, 7) As Color

    'used to know if validation needs to be used for if a face has been rotated twice in a row
    Public stepbystep As Boolean = False

    'stores values used to change colours of the cube by the user
    'if it is true then the picture box that is clicked will become that colour
    Dim red As Boolean = False
    Dim yellow As Boolean = False
    Dim white As Boolean = False
    Dim blue As Boolean = False
    Dim lime As Boolean = False
    Dim orange As Boolean = False

    'shows whether the cube is currently 2x2 or 3x3
    Dim two As Boolean = False
    Dim three As Boolean = False

    'used to know when to display a warning message
    Dim checked As Boolean = False

    'shows if the cube has been scrambled or not
    Dim scramble As Boolean = False

    'creates a new 3x3 cube
    Public currentCube As New Cube3x3

    'keeps track of the number of lines that have been used in the richtextbox1
    Dim lineNumber As Integer

    'stores if the user is making moves or the program is making moves
    Public userMoves As Boolean = False

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'next step button is hidden because  it cant be used yet
        Button30.Hide()
        'all help information is hidden
        RichTextBox2.Hide()
        Label20.Hide()
        Label21.Hide()
        Label22.Hide()



        'assigns the colours of the cube to an array on start up
        currentCube.startUp()

        'checks radio buttons on startup so correct start screen is shown
        RadioButton1.Checked = True
        RadioButton4.Checked = True
    End Sub


    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
        'shows a title which indicates which moves have been made by the scramble function
        RichTextBox1.Text = RichTextBox1.Text & vbNewLine & "Scramble: " & vbNewLine

        'shows how many movees have been made in the scramble
        Dim number As Integer = currentCube.scramble()

        scramble = True

        'adds the number of moves made by the scramble function to the total number of moves
        lineNumber += number
        userMoves = False
        Label3.Text = 0
    End Sub

    'resets the cube to the solved state
    Private Sub Button21_Click_1(sender As System.Object, e As System.EventArgs) Handles Button21.Click
        resetCube()
        currentCube.notSolved()
    End Sub

    Private Sub resetCube()
        'resets the cube to its original solved state
        currentCube.startUp()
        RichTextBox1.Text = ""

        'indicates that the cube has been reset and removes all previous moves
        RichTextBox1.Text = vbNewLine & "Cube Reset" & vbNewLine
        userMoves = False

        'sets the number of moves to zero
        currentCube.movesEqualZero()
        Label3.Text = 0
    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click
        Button20.Enabled = False
        'used to close the program if the cube cant be solved within the given time



        'updates move counters and the box showing what moveds have been made
        Dim store As Integer = Label2.Text
        RichTextBox1.Text = RichTextBox1.Text & vbNewLine & "Solve: " & vbNewLine

        'solves the white cross on the bottom of the cube
        currentCube.solver()

        'displays the number of moves the solve uses
        Dim other As Integer = Label2.Text
        Label3.Text = other - store
        Button20.Enabled = True
    End Sub

    'switches between buttons to chnage cube and changing each colour individually
    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Dim validate As Boolean = False

        'sets the layout array to equal the colours thta the user has inputted
        currentCube.setColourValidate()
        'checks that there is the correct number of colours on the cube
        validate = currentCube.numberOfColours


        If validate = True Then
            Panel3.Hide()
            Panel2.Show()
            Panel4.Show()

            If checked = True Then
                If RadioButton1.Checked = True Then
                    MessageBox.Show("Please check that you have entered the correct layout. Once you initiate the solving, if the cube can't be solved the program will close.")
                End If
            End If

        Else
            wrong()
        End If
        checked = True

    End Sub

    'if the user has inputted a completely impossible cube layout
    Private Sub wrong()
        RadioButton2.Checked = True
        MessageBox.Show("Please enter a valid cube layout.")
    End Sub

    'switches between buttons to chnage cube and changing each colour individually
    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Panel2.Hide()
        Panel3.Show()
        Panel4.Hide()

    End Sub




    ' all buttons containing this format are for changing colours on the cube manually
    'it saves which colour is required so when a square on the cube is clicked, it will chnage to the save colour

    Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles Button25.Click
        red = False
        yellow = False
        white = False
        blue = True
        lime = False
        orange = False
    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click
        red = False
        yellow = True
        white = False
        blue = False
        lime = False
        orange = False
    End Sub

    Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles Button23.Click
        red = True
        yellow = False
        white = False
        blue = False
        lime = False
        orange = False
    End Sub

    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles Button24.Click
        red = False
        yellow = False
        white = True
        blue = False
        lime = False
        orange = False
    End Sub

    Private Sub Button26_Click(sender As System.Object, e As System.EventArgs) Handles Button26.Click
        red = False
        yellow = False
        white = False
        blue = False
        lime = True
        orange = False
    End Sub

    Private Sub Button27_Click(sender As System.Object, e As System.EventArgs) Handles Button27.Click
        red = False
        yellow = False
        white = False
        blue = False
        lime = False
        orange = True
    End Sub





    'uses the saved colour to change the clicked square on the cube to that colour

    Private Sub PictureBox9_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox9.MouseClick, PictureBox8.MouseClick, PictureBox7.MouseClick, PictureBox6.MouseClick, PictureBox5.MouseClick, PictureBox48.MouseClick, PictureBox47.MouseClick, PictureBox46.MouseClick, PictureBox45.MouseClick, PictureBox44.MouseClick, PictureBox43.MouseClick, PictureBox42.MouseClick, PictureBox41.MouseClick, PictureBox40.MouseClick, PictureBox4.MouseClick, PictureBox39.MouseClick, PictureBox38.MouseClick, PictureBox37.MouseClick, PictureBox36.MouseClick, PictureBox35.MouseClick, PictureBox34.MouseClick, PictureBox33.MouseClick, PictureBox32.MouseClick, PictureBox31.MouseClick, PictureBox30.MouseClick, PictureBox3.MouseClick, PictureBox29.MouseClick, PictureBox28.MouseClick, PictureBox27.MouseClick, PictureBox26.MouseClick, PictureBox25.MouseClick, PictureBox24.MouseClick, PictureBox23.MouseClick, PictureBox22.MouseClick, PictureBox21.MouseClick, PictureBox20.MouseClick, PictureBox2.MouseClick, PictureBox19.MouseClick, PictureBox18.MouseClick, PictureBox17.MouseClick, PictureBox16.MouseClick, PictureBox15.MouseClick, PictureBox14.MouseClick, PictureBox13.MouseClick, PictureBox12.MouseClick, PictureBox11.MouseClick, PictureBox10.MouseClick, PictureBox1.MouseClick
        If red = True Then
            sender.backcolor = Color.Red
        ElseIf yellow = True Then
            sender.backcolor = Color.Yellow
        ElseIf white = True Then
            sender.backcolor = Color.White
        ElseIf blue = True Then
            sender.backcolor = Color.RoyalBlue
        ElseIf lime = True Then
            sender.backcolor = Color.Lime
        ElseIf orange = True Then
            sender.backcolor = Color.Orange
        End If
    End Sub


    'switches from 2x2 cube to 3x3 cube
    Private Sub RadioButton4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton4.CheckedChanged
        currentCube = New Cube3x3
        resetCube()
        three = True
        two = False
        transition3x3()
    End Sub

    'switches from 3x3 cube to 2x2 cube
    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged
        currentCube = New Cube2x2
        resetCube()
        two = False
        three = False
        transition2x2()
    End Sub

    'if the cube is switched the 3x3 then the pictureboxes are arranged so that they correspond the the net of a 3x3 cube
    Private Sub transition3x3()
        PictureBox2.Show()
        PictureBox4.Show()
        PictureBox6.Show()
        PictureBox8.Show()

        PictureBox10.Show()
        PictureBox12.Show()
        PictureBox14.Show()
        PictureBox16.Show()

        PictureBox18.Show()
        PictureBox20.Show()
        PictureBox22.Show()
        PictureBox24.Show()

        PictureBox26.Show()
        PictureBox28.Show()
        PictureBox30.Show()
        PictureBox32.Show()

        PictureBox34.Show()
        PictureBox36.Show()
        PictureBox38.Show()
        PictureBox40.Show()

        PictureBox42.Show()
        PictureBox44.Show()
        PictureBox46.Show()
        PictureBox48.Show()

        PictureBox49.Show()
        PictureBox50.Show()
        PictureBox51.Show()
        PictureBox52.Show()
        PictureBox53.Show()
        PictureBox54.Show()

        Label5.Show()
        Label6.Show()
        Label7.Show()
        Label8.Show()
        Label9.Show()
        Label10.Show()

        Label13.Hide()
        Label14.Hide()
        Label15.Hide()
        Label16.Hide()
        Label17.Hide()
        Label18.Hide()

        PictureBox1.Location = New Point(137, 26)
        PictureBox3.Location = New Point(193, 26)
        PictureBox5.Location = New Point(193, 82)
        PictureBox7.Location = New Point(137, 82)

        PictureBox9.Location = New Point(137, 144)
        PictureBox11.Location = New Point(193, 144)
        PictureBox13.Location = New Point(193, 200)
        PictureBox15.Location = New Point(137, 200)

        PictureBox17.Location = New Point(137, 260)
        PictureBox19.Location = New Point(193, 260)
        PictureBox21.Location = New Point(193, 316)
        PictureBox23.Location = New Point(137, 316)

        PictureBox25.Location = New Point(14, 144)
        PictureBox27.Location = New Point(70, 144)
        PictureBox29.Location = New Point(70, 200)
        PictureBox31.Location = New Point(14, 200)

        PictureBox33.Location = New Point(254, 144)
        PictureBox35.Location = New Point(310, 144)
        PictureBox37.Location = New Point(310, 200)
        PictureBox39.Location = New Point(254, 200)

        PictureBox41.Location = New Point(365, 144)
        PictureBox43.Location = New Point(421, 144)
        PictureBox45.Location = New Point(421, 200)
        PictureBox47.Location = New Point(365, 200)

        PictureBox1.Size = New Size(22, 22)
        PictureBox3.Size = New Size(22, 22)
        PictureBox5.Size = New Size(22, 22)
        PictureBox7.Size = New Size(22, 22)

        PictureBox9.Size = New Size(22, 22)
        PictureBox11.Size = New Size(22, 22)
        PictureBox13.Size = New Size(22, 22)
        PictureBox15.Size = New Size(22, 22)

        PictureBox17.Size = New Size(22, 22)
        PictureBox19.Size = New Size(22, 22)
        PictureBox21.Size = New Size(22, 22)
        PictureBox23.Size = New Size(22, 22)

        PictureBox25.Size = New Size(22, 22)
        PictureBox27.Size = New Size(22, 22)
        PictureBox29.Size = New Size(22, 22)
        PictureBox31.Size = New Size(22, 22)

        PictureBox33.Size = New Size(22, 22)
        PictureBox35.Size = New Size(22, 22)
        PictureBox37.Size = New Size(22, 22)
        PictureBox39.Size = New Size(22, 22)

        PictureBox41.Size = New Size(22, 22)
        PictureBox43.Size = New Size(22, 22)
        PictureBox45.Size = New Size(22, 22)
        PictureBox47.Size = New Size(22, 22)

    End Sub

    'if the cube is switched the 2x2 then the pictureboxes are arranged so that they correspond the the net of a 2x2 cube
    Private Sub transition2x2()
        PictureBox2.Hide()
        PictureBox4.Hide()
        PictureBox6.Hide()
        PictureBox8.Hide()

        PictureBox10.Hide()
        PictureBox12.Hide()
        PictureBox14.Hide()
        PictureBox16.Hide()

        PictureBox18.Hide()
        PictureBox20.Hide()
        PictureBox22.Hide()
        PictureBox24.Hide()

        PictureBox26.Hide()
        PictureBox28.Hide()
        PictureBox30.Hide()
        PictureBox32.Hide()

        PictureBox34.Hide()
        PictureBox36.Hide()
        PictureBox38.Hide()
        PictureBox40.Hide()

        PictureBox42.Hide()
        PictureBox44.Hide()
        PictureBox46.Hide()
        PictureBox48.Hide()

        PictureBox49.Hide()
        PictureBox50.Hide()
        PictureBox51.Hide()
        PictureBox52.Hide()
        PictureBox53.Hide()
        PictureBox54.Hide()

        Label5.Hide()
        Label6.Hide()
        Label7.Hide()
        Label8.Hide()
        Label9.Hide()
        Label10.Hide()

        Label13.Show()
        Label14.Show()
        Label15.Show()
        Label16.Show()
        Label17.Show()
        Label18.Show()

        PictureBox1.Size = New Size(36, 36)
        PictureBox3.Size = New Size(36, 36)
        PictureBox5.Size = New Size(36, 36)
        PictureBox7.Size = New Size(36, 36)

        PictureBox9.Size = New Size(36, 36)
        PictureBox11.Size = New Size(36, 36)
        PictureBox13.Size = New Size(36, 36)
        PictureBox15.Size = New Size(36, 36)

        PictureBox17.Size = New Size(36, 36)
        PictureBox19.Size = New Size(36, 36)
        PictureBox21.Size = New Size(36, 36)
        PictureBox23.Size = New Size(36, 36)

        PictureBox25.Size = New Size(36, 36)
        PictureBox27.Size = New Size(36, 36)
        PictureBox29.Size = New Size(36, 36)
        PictureBox31.Size = New Size(36, 36)

        PictureBox33.Size = New Size(36, 36)
        PictureBox35.Size = New Size(36, 36)
        PictureBox37.Size = New Size(36, 36)
        PictureBox39.Size = New Size(36, 36)

        PictureBox41.Size = New Size(36, 36)
        PictureBox43.Size = New Size(36, 36)
        PictureBox45.Size = New Size(36, 36)
        PictureBox47.Size = New Size(36, 36)

        PictureBox1.Location = New Point(137, 26)
        PictureBox3.Location = New Point(177, 26)
        PictureBox5.Location = New Point(177, 66)
        PictureBox7.Location = New Point(137, 66)

        PictureBox9.Location = New Point(137, 144)
        PictureBox11.Location = New Point(177, 144)
        PictureBox13.Location = New Point(177, 184)
        PictureBox15.Location = New Point(137, 184)

        PictureBox17.Location = New Point(137, 248)
        PictureBox19.Location = New Point(177, 248)
        PictureBox21.Location = New Point(177, 288)
        PictureBox23.Location = New Point(137, 288)

        PictureBox25.Location = New Point(14, 144)
        PictureBox27.Location = New Point(54, 144)
        PictureBox29.Location = New Point(54, 184)
        PictureBox31.Location = New Point(14, 184)

        PictureBox33.Location = New Point(254, 144)
        PictureBox35.Location = New Point(294, 144)
        PictureBox37.Location = New Point(294, 184)
        PictureBox39.Location = New Point(254, 184)

        PictureBox41.Location = New Point(365, 144)
        PictureBox43.Location = New Point(405, 144)
        PictureBox45.Location = New Point(405, 184)
        PictureBox47.Location = New Point(365, 184)
    End Sub



    'worker is used to detect if the cube is solved yet and if it isnt then it will terminate the program and the user willl need to reopen it to continue
    'backgroundworker was used so it can check if the cube is solved while other processes are still running
    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        'waits 1.2 seconds before carrying out
        System.Threading.Thread.Sleep(1200)
        If stepbystep <> True Then
            If currentCube.isCubeSolved = True Then

            Else
                'if cube isnt solved then program ends
                MessageBox.Show("The cube has not been solved within the time limit." & vbNewLine & vbNewLine & "It may be that this cube layout is impossible to solve. Please check that you have entered the colours correctly and try again." & vbNewLine & vbNewLine & "The program will now close.")
                End
            End If
        End If
        scramble = False
        stepbystep = False
    End Sub

    'saves the scarmbled cube, solves the cube, saves the moves used to solve the cube, returns the cube back to original scrambled state
    Private Sub Button28_Click(sender As System.Object, e As System.EventArgs) Handles Button28.Click

        stepbystep = False
        'checks if cube can be solved

        'button is shown which displays the next step in solving
        Button30.Show()
        Dim length As Integer

        Dim store As Integer = Label2.Text

        'stores the scrambled state
        For j = 0 To 5
            For i = 0 To 7
                holder(j, i) = currentCube.layout(j, i)
            Next
        Next

        length = RichTextBox1.Text.Length

        'solves the cube
        currentCube.solver()
        stepbystep = True
        'displays the number of moves the solve uses
        Dim other As Integer = Label2.Text
        Label3.Text = other - store

        'returns the cube to scrambled state
        For j = 0 To 5
            For i = 0 To 7
                currentCube.layout(j, i) = holder(j, i)
            Next
        Next

        'updates the colours on the cube so the picture boxes display what is held in layout array
        currentCube.updateColours()



        'removes the scrambleinstructions and the solve instructions from the moves box
        temp1 = RichTextBox1.Text.Remove(0, length)
        RichTextBox1.Text = "Solver:" & vbNewLine
        MessageBox.Show("Go through each step slowly to ensure that the solver can keep up with the outputs.")

    End Sub

    'displays help about the program depending on if the user is manually setting colours or rotating faces
    Private Sub Button29_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button29.MouseHover
        If RadioButton1.Checked = True Then
            Label20.Show()
            Label21.Show()
        ElseIf RadioButton2.Checked = True Then
            Label22.Show()
        End If
    End Sub

    'hides the help information
    Private Sub Button29_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button29.MouseLeave
        Label20.Hide()
        Label21.Hide()
        Label22.Hide()
    End Sub

    'displays and carries out the next step in solving the cube is solve step by step has been selected
    Private Sub Button30_Click(sender As System.Object, e As System.EventArgs) Handles Button30.Click

        'if there are moves left to show then
        If temp1 <> "" Then

            'temp2 = first two characters of temp1 which is the next move
            Dim number As Integer = temp1.Length - 2
            temp2 = temp1.Remove(2, number)

            'adds next move to moves box
            RichTextBox1.Text = RichTextBox1.Text & temp2 & vbNewLine

            'carries out the move in temp2 without the validation that cecks if the same face has been rotated more than once in a row
            'this is because this has already been carried out in the original solve
            currentCube.solverWithoutValidation(temp2)

            'removes the move just carried out from the list of remaining moves and also removes the newline character
            temp1 = temp1.Remove(0, 3)

        Else
            'if there are no moves left then solve ends
            Button30.Hide()
            MessageBox.Show("End of solve.")
            stepbystep = False
        End If
    End Sub


    'when info button is clicked it displays information.
    'if it is clicked again then it hides the information
    Dim clicked As Boolean = False
    Private Sub Button31_Click(sender As System.Object, e As System.EventArgs) Handles Button31.Click
        'clciked stores if the buton has been clicked already or not

        'hide info
        If clicked = True Then
            RichTextBox2.Hide()
            clicked = False
        Else
            'show info
            RichTextBox2.Show()
            clicked = True
        End If
    End Sub

    'if any buttons are clicked during a solve step by step then the next step button dissapears because that solve will no longer work
    Private Sub Button8_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Button9.MouseClick, Button8.MouseClick, Button7.MouseClick, Button6.MouseClick, Button5.MouseClick, Button4.MouseClick, Button3.MouseClick, Button21.MouseClick, Button20.MouseClick, Button2.MouseClick, Button19.MouseClick, Button18.MouseClick, Button17.MouseClick, Button16.MouseClick, Button15.MouseClick, Button14.MouseClick, Button13.MouseClick, Button12.MouseClick, Button11.MouseClick, Button10.MouseClick, Button1.MouseClick
        Button30.Hide()
        'converts the button press into string which identifies which face must be turned and which way
        Dim face As String = sender.text

        'if the user hasnt previously been making moves then a title will be displayed which indicates which moves are being made by the user
        If userMoves = False Then
            RichTextBox1.Text = RichTextBox1.Text & vbNewLine & "User Input:" & vbNewLine
            userMoves = True
        End If
        stepbystep = True

        'initiates the turning of the face
        currentCube.clockwise(face)
        lineNumber += 1

        'resets all values associated with the cube when it is solved so it will not disaply as solved 
        currentCube.notSolved()
    End Sub


End Class
