
Public Class Cube3x3

    'creates a 2D array that represents the 6 faces on the cube and the 8 movable squares on each face
    Public layout(5, 7) As Color

    Public storage As String = "A"

    'used to check if the white corss on the bottom is complete
    Dim bottomComplete As Boolean = false

    'used to check if each bottom corner is complete
    Dim bottomCornersComplete As Boolean

    'used to count the number of moves made
    Dim numberOfMoves As Integer


    Dim middleLayerComplete As Boolean

    'is the top all yellow
    Dim allYellow As Boolean = False

    'is there a yellow L shape on top
    Dim isLOnTop As Boolean = False

    'represents each top corner
    Dim corner1 As Boolean = False
    Dim corner2 As Boolean = False
    Dim corner3 As Boolean = False
    Dim corner4 As Boolean = False
    Public numberOnTop As Integer = 0

    'represents the number of each colour square on the cube
    Dim redNumber As Integer = 0
    Dim yellowNumber As Integer = 0
    Dim whiteNumber As Integer = 0
    Dim blueNumber As Integer = 0
    Dim limeNumber As Integer = 0
    Dim orangeNumber As Integer = 0

    'after the user has manually changed the colour on the cube then it will save this in the layout array
    Public Sub setColourValidate()

        layout(0, 0) = Form1.PictureBox1.BackColor
        layout(0, 1) = Form1.PictureBox2.BackColor
        layout(0, 2) = Form1.PictureBox3.BackColor
        layout(0, 3) = Form1.PictureBox4.BackColor
        layout(0, 4) = Form1.PictureBox5.BackColor
        layout(0, 5) = Form1.PictureBox6.BackColor
        layout(0, 6) = Form1.PictureBox7.BackColor
        layout(0, 7) = Form1.PictureBox8.BackColor

        layout(1, 0) = Form1.PictureBox9.BackColor
        layout(1, 1) = Form1.PictureBox10.BackColor
        layout(1, 2) = Form1.PictureBox11.BackColor
        layout(1, 3) = Form1.PictureBox12.BackColor
        layout(1, 4) = Form1.PictureBox13.BackColor
        layout(1, 5) = Form1.PictureBox14.BackColor
        layout(1, 6) = Form1.PictureBox15.BackColor
        layout(1, 7) = Form1.PictureBox16.BackColor

        layout(2, 0) = Form1.PictureBox17.BackColor
        layout(2, 1) = Form1.PictureBox18.BackColor
        layout(2, 2) = Form1.PictureBox19.BackColor
        layout(2, 3) = Form1.PictureBox20.BackColor
        layout(2, 4) = Form1.PictureBox21.BackColor
        layout(2, 5) = Form1.PictureBox22.BackColor
        layout(2, 6) = Form1.PictureBox23.BackColor
        layout(2, 7) = Form1.PictureBox24.BackColor

        layout(3, 0) = Form1.PictureBox25.BackColor
        layout(3, 1) = Form1.PictureBox26.BackColor
        layout(3, 2) = Form1.PictureBox27.BackColor
        layout(3, 3) = Form1.PictureBox28.BackColor
        layout(3, 4) = Form1.PictureBox29.BackColor
        layout(3, 5) = Form1.PictureBox30.BackColor
        layout(3, 6) = Form1.PictureBox31.BackColor
        layout(3, 7) = Form1.PictureBox32.BackColor

        layout(4, 0) = Form1.PictureBox33.BackColor
        layout(4, 1) = Form1.PictureBox34.BackColor
        layout(4, 2) = Form1.PictureBox35.BackColor
        layout(4, 3) = Form1.PictureBox36.BackColor
        layout(4, 4) = Form1.PictureBox37.BackColor
        layout(4, 5) = Form1.PictureBox38.BackColor
        layout(4, 6) = Form1.PictureBox39.BackColor
        layout(4, 7) = Form1.PictureBox40.BackColor

        layout(5, 0) = Form1.PictureBox41.BackColor
        layout(5, 1) = Form1.PictureBox42.BackColor
        layout(5, 2) = Form1.PictureBox43.BackColor
        layout(5, 3) = Form1.PictureBox44.BackColor
        layout(5, 4) = Form1.PictureBox45.BackColor
        layout(5, 5) = Form1.PictureBox46.BackColor
        layout(5, 6) = Form1.PictureBox47.BackColor
        layout(5, 7) = Form1.PictureBox48.BackColor

    End Sub

    'finds out the number of each colour on the cube and if each has 8 tehn it is okay
    Public Function numberOfColours()
        Dim redNumber As Integer = 0
        Dim yellowNumber As Integer = 0
        Dim whiteNumber As Integer = 0
        Dim blueNumber As Integer = 0
        Dim limeNumber As Integer = 0
        Dim orangeNumber As Integer = 0

        Dim okay As Boolean = False

        'if a square is a certain colour then the corresponfing integer variable will have 1 added to it
        For j = 0 To 5
            For i = 0 To 7
                If layout(j, i) = Color.Red Then
                    redNumber += 1
                ElseIf layout(j, i) = Color.Yellow Then
                    yellowNumber += 1
                ElseIf layout(j, i) = Color.White Then
                    whiteNumber += 1
                ElseIf layout(j, i) = Color.RoyalBlue Then
                    blueNumber += 1
                ElseIf layout(j, i) = Color.Lime Then
                    limeNumber += 1
                ElseIf layout(j, i) = Color.Orange Then
                    orangeNumber += 1
                End If
            Next
        Next
        'there are 8 changeable squares on each face so if there is 8 of each colour then it is correct
        If redNumber = 8 And yellowNumber = 8 And whiteNumber = 8 And blueNumber = 8 And limeNumber = 8 And orangeNumber = 8 Then
            okay = True
        Else
            okay = False
        End If

        Return okay

    End Function


    'checks to see if each square is in the correct place
    'if each square is then the cube is solved
    Overridable Function isCubeSolved()
        Dim completed As Boolean = False
        Dim count As Integer = 0
        For j = 0 To 5
            For i = 0 To 7
                If j = 0 Then
                    If layout(j, i) = Color.Yellow Then
                        count += 1
                    End If
                ElseIf j = 1 Then
                    If layout(j, i) = Color.Red Then
                        count += 1
                    End If
                ElseIf j = 2 Then
                    If layout(j, i) = Color.White Then
                        count += 1
                    End If
                ElseIf j = 3 Then
                    If layout(j, i) = Color.RoyalBlue Then
                        count += 1
                    End If
                ElseIf j = 4 Then
                    If layout(j, i) = Color.Lime Then
                        count += 1
                    End If
                ElseIf j = 5 Then
                    If layout(j, i) = Color.Orange Then
                        count += 1
                    End If
                End If
            Next
        Next
        '48 changeable squares so if 48 are okay then it is solved
        If count = 48 Then
            completed = True
        End If
        Return completed

    End Function





    'called when the cube is reset the reset the number of moves
    Public Sub movesEqualZero()
        numberOfMoves = 0
        Form1.Label2.Text = numberOfMoves
    End Sub

    'assigns the color of each side of the cube to the array
    Public Sub startUp()
        'on startup the cub is in its solved state so every square on each face is the same colour
        For i = 0 To 7
            layout(0, i) = Color.Yellow
            layout(1, i) = Color.Red
            layout(2, i) = Color.White
            layout(3, i) = Color.RoyalBlue
            layout(4, i) = Color.Lime
            layout(5, i) = Color.Orange
        Next
        updateColours()
    End Sub

    'updates the cube colours according to the array
    'will be called after every turn that is made
    Public Sub updateColours()
        Form1.PictureBox1.BackColor = layout(0, 0)
        Form1.PictureBox2.BackColor = layout(0, 1)
        Form1.PictureBox3.BackColor = layout(0, 2)
        Form1.PictureBox4.BackColor = layout(0, 3)
        Form1.PictureBox5.BackColor = layout(0, 4)
        Form1.PictureBox6.BackColor = layout(0, 5)
        Form1.PictureBox7.BackColor = layout(0, 6)
        Form1.PictureBox8.BackColor = layout(0, 7)

        Form1.PictureBox9.BackColor = layout(1, 0)
        Form1.PictureBox10.BackColor = layout(1, 1)
        Form1.PictureBox11.BackColor = layout(1, 2)
        Form1.PictureBox12.BackColor = layout(1, 3)
        Form1.PictureBox13.BackColor = layout(1, 4)
        Form1.PictureBox14.BackColor = layout(1, 5)
        Form1.PictureBox15.BackColor = layout(1, 6)
        Form1.PictureBox16.BackColor = layout(1, 7)

        Form1.PictureBox17.BackColor = layout(2, 0)
        Form1.PictureBox18.BackColor = layout(2, 1)
        Form1.PictureBox19.BackColor = layout(2, 2)
        Form1.PictureBox20.BackColor = layout(2, 3)
        Form1.PictureBox21.BackColor = layout(2, 4)
        Form1.PictureBox22.BackColor = layout(2, 5)
        Form1.PictureBox23.BackColor = layout(2, 6)
        Form1.PictureBox24.BackColor = layout(2, 7)

        Form1.PictureBox25.BackColor = layout(3, 0)
        Form1.PictureBox26.BackColor = layout(3, 1)
        Form1.PictureBox27.BackColor = layout(3, 2)
        Form1.PictureBox28.BackColor = layout(3, 3)
        Form1.PictureBox29.BackColor = layout(3, 4)
        Form1.PictureBox30.BackColor = layout(3, 5)
        Form1.PictureBox31.BackColor = layout(3, 6)
        Form1.PictureBox32.BackColor = layout(3, 7)

        Form1.PictureBox33.BackColor = layout(4, 0)
        Form1.PictureBox34.BackColor = layout(4, 1)
        Form1.PictureBox35.BackColor = layout(4, 2)
        Form1.PictureBox36.BackColor = layout(4, 3)
        Form1.PictureBox37.BackColor = layout(4, 4)
        Form1.PictureBox38.BackColor = layout(4, 5)
        Form1.PictureBox39.BackColor = layout(4, 6)
        Form1.PictureBox40.BackColor = layout(4, 7)

        Form1.PictureBox41.BackColor = layout(5, 0)
        Form1.PictureBox42.BackColor = layout(5, 1)
        Form1.PictureBox43.BackColor = layout(5, 2)
        Form1.PictureBox44.BackColor = layout(5, 3)
        Form1.PictureBox45.BackColor = layout(5, 4)
        Form1.PictureBox46.BackColor = layout(5, 5)
        Form1.PictureBox47.BackColor = layout(5, 6)
        Form1.PictureBox48.BackColor = layout(5, 7)
    End Sub

    'identifies which face of the cube is being turned by the user
    Private Sub identify(face)
        'when the face is determined, the leftTurn sub is called with the identifying face information
        If face.StartsWith("U") Then
            leftTurn(0)
        ElseIf face.startswith("F") Then
            leftTurn(1)
        ElseIf face.startswith("D") Then
            leftTurn(2)
        ElseIf face.startswith("L") Then
            leftTurn(3)
        ElseIf face.startswith("R") Then
            leftTurn(4)
        ElseIf face.startswith("B") Then
            leftTurn(5)
        End If
        updateColours()
    End Sub

    'twists a given face of the cube left by one position
    Private Sub leftTurn(side)
        'takes the squares on the given face and shifts them down 2 places in the array
        'when the cube is turned, each square on the given face will rotate 2 squares to the left
        Dim temp(1) As Color
        temp(0) = layout(side, 0)
        temp(1) = layout(side, 1)
        For i = 0 To 5
            layout(side, i) = layout(side, i + 2)
        Next
        layout(side, 6) = temp(0)
        layout(side, 7) = temp(1)

        'the edge sqaures connected to the given face are rotated around to the next face
        'each 3 sqaures in each array are replaced by the 3 squares in the next array
        If side = 0 Then
            Dim store(2) As Color
            For i = 0 To 2
                store(i) = layout(5, i)
                layout(5, i) = layout(4, i)
                layout(4, i) = layout(1, i)
                layout(1, i) = layout(3, i)
                layout(3, i) = store(i)
            Next
        End If

        If side = 1 Then
            Dim store(2) As Color
            store(0) = layout(0, 6)
            store(1) = layout(0, 5)
            store(2) = layout(0, 4)
            layout(0, 6) = layout(4, 0)
            layout(0, 5) = layout(4, 7)
            layout(0, 4) = layout(4, 6)
            layout(4, 0) = layout(2, 2)
            layout(4, 7) = layout(2, 1)
            layout(4, 6) = layout(2, 0)
            layout(2, 2) = layout(3, 4)
            layout(2, 1) = layout(3, 3)
            layout(2, 0) = layout(3, 2)
            layout(3, 4) = store(0)
            layout(3, 3) = store(1)
            layout(3, 2) = store(2)
        End If

        If side = 2 Then
            Dim store(2) As Color
            For i = 4 To 6
                store(i - 4) = layout(3, i)
                layout(3, i) = layout(1, i)
                layout(1, i) = layout(4, i)
                layout(4, i) = layout(5, i)
                layout(5, i) = store(i - 4)
            Next
        End If

        If side = 3 Then
            Dim store(2) As Color
            store(0) = layout(5, 2)
            store(1) = layout(5, 3)
            store(2) = layout(5, 4)
            layout(5, 4) = layout(0, 0)
            layout(5, 3) = layout(0, 7)
            layout(5, 2) = layout(0, 6)
            layout(0, 0) = layout(1, 0)
            layout(0, 7) = layout(1, 7)
            layout(0, 6) = layout(1, 6)
            layout(1, 0) = layout(2, 0)
            layout(1, 7) = layout(2, 7)
            layout(1, 6) = layout(2, 6)
            layout(2, 0) = store(2)
            layout(2, 7) = store(1)
            layout(2, 6) = store(0)
        End If

        If side = 4 Then
            Dim store(2) As Color
            For i = 2 To 4
                store(i - 2) = layout(2, i)
                layout(2, i) = layout(1, i)
                layout(1, i) = layout(0, i)
            Next
            layout(0, 2) = layout(5, 6)
            layout(0, 3) = layout(5, 7)
            layout(0, 4) = layout(5, 0)
            layout(5, 6) = store(0)
            layout(5, 7) = store(1)
            layout(5, 0) = store(2)
        End If

        If side = 5 Then
            Dim store(2) As Color
            store(0) = layout(0, 0)
            store(1) = layout(0, 1)
            store(2) = layout(0, 2)
            layout(0, 0) = layout(3, 6)
            layout(0, 1) = layout(3, 7)
            layout(0, 2) = layout(3, 0)
            layout(3, 6) = layout(2, 4)
            layout(3, 7) = layout(2, 5)
            layout(3, 0) = layout(2, 6)
            layout(2, 4) = layout(4, 2)
            layout(2, 5) = layout(4, 3)
            layout(2, 6) = layout(4, 4)
            layout(4, 2) = store(0)
            layout(4, 3) = store(1)
            layout(4, 4) = store(2)
        End If

    End Sub

   
    'works out how the user wants the cube to be rotated
    Public Sub clockwise(face)

        bottomComplete = False
        'the ' character means that the face is rotated anticlockwise
        'if the information in the string contains the ' character at the end then the identify sub is called
        'the identify sub is called once because it calls the leftTurn sub once which turns the face left (anticlockwise) once
        If face.Chars(1) = "'" Then
            identify(face)

            'if the information has 2 at the end then the face should be rotated twice
            'the identify sub is called twice because it calls the leftTurn sub once each time
        ElseIf face.Chars(1) = "2" Then
            identify(face)
            identify(face)

            'if the information doesnt contain 2 or ' then the cube should be rotated once clockwise
            'the identify sub is called three times because it calls the leftTurn sub once each time
            'three left turns = one right (clockwise) turn
        Else
            identify(face)
            identify(face)
            identify(face)
        End If

        'gets the string of the last three characters from richtextbox1
        Dim temp1 As String = Form1.RichTextBox1.Text.Remove(0, Form1.RichTextBox1.Text.Length - 3)

        'gets the string of characters from richtextbox1 excluding the last 3 characters
        Dim temp2 As String = Form1.RichTextBox1.Text.Remove(Form1.RichTextBox1.Text.Length - 3, 3)

        'removes the last character from temp1 because it is a new line character adn converts the result into a charcater array
        Dim store1 As Char() = temp1.Remove(2, 1).ToCharArray

        'converts the current move being performed into a charcater array
        Dim store2 As Char() = face.toCharArray

        'if the first character of the current move is the same as the first character of the previous move then the two moves can be made into one
        If store1(0) = store2(0) Then

            'calls the append subroutine which determines what the combined move will be
            If append(store1, store2) = "" Then
                Form1.RichTextBox1.Text = temp2

                'decreases the move number by one because the append subroutine has determined that the moves cancel out so two moves are exchanged for no moves
                numberOfMoves -= 1
            Else
                'inputs the move determined by append into richtextbox1
                Form1.RichTextBox1.Text = temp2 & append(store1, store2) & vbNewLine
            End If
        Else
            'if the first characters arent the same then the current move is inputted by itself
            Form1.RichTextBox1.Text = Form1.RichTextBox1.Text & face & vbNewLine
            numberOfMoves += 1
        End If

        Form1.Label2.Text = numberOfMoves



        Form1.RichTextBox1.AppendText("")
    End Sub

    'the same as clockwise but it doesnt have validation to check if the last face to be rotated is the same as the current face
    Public Sub solverWithoutValidation(face)
        'the ' character means that the face is rotated anticlockwise
        'if the information in the string contains the ' character at the end then the identify sub is called
        'the identify sub is called once because it calls the leftTurn sub once which turns the face left (anticlockwise) once
        If face.Chars(1) = "'" Then
            identify(face)

            'if the information has 2 at the end then the face should be rotated twice
            'the identify sub is called twice because it calls the leftTurn sub once each time
        ElseIf face.Chars(1) = "2" Then
            identify(face)
            identify(face)

            'if the information doesnt contain 2 or ' then the cube should be rotated once clockwise
            'the identify sub is called three times because it calls the leftTurn sub once each time
            'three left turns = one right (clockwise) turn
        Else
            identify(face)
            identify(face)
            identify(face)
        End If

    End Sub




    'determines if a shorter number of moves can be used depending on the moves already outputted by the program
    'this sub is only called if two consecutives moves are rotating the same face
    'created to optimise the solving of the cube
    Private Function append(store1, store2)
        Dim hold As String = ""

        If store1(1) = store2(1) Then
            'if both moves are rotating 180 degrees then they cancel out and append returns nothing
            If store1(1) = "2" Then
                hold = ""


                'if both moves are the same but only  rotate 90 degrees then append returns the face that is being rotated and 2 to show it is being rotated 180 degrees
            Else
                hold = store1(0) & "2"

            End If
        End If

        'if both rotations arent rotating 180 degrees and they are both different then they cancel out and append returns nothing
        If store1(1) <> store2(1) And store1(1) <> "2" And store2(1) <> "2" Then
            hold = ""
        End If

        'if one move rotates 180 degrees and the other rotates 90 degrees clockwise then it is the same as a 90 degree turn anticlockwise
        If store1(1) = "2" And store2(1) = " " Or store1(1) = " " And store2(1) = "2" Then
            hold = store1(0) & "'"
        End If

        'if one move rotates 180 degrees and the other rotates 90 degrees anticlockwise then it is the same as a 90 degree turn clockwise
        If store1(1) = "2" And store2(1) = "'" Or store1(1) = "'" And store2(1) = "2" Then
            hold = store1(0) & " "
        End If

        Return hold
    End Function

    'scrambles the cube using a random numbre of turns on random faces
    Overridable Function scramble()
        notSolved()
        Dim random As New Random
        'generates a random integer between 17 and 23 which is the number of turns that will be performed
        Dim z As Decimal = random.Next(17, 23)

        For i = 1 To z
Line238:
            'generates a random number which is used to determine which side will be rotated
            Dim x As Decimal = random.Next(0, 7)

            'generates a random number whih is used to specify how the face will be rotated
            Dim y As Decimal = random.Next(0, 6)

            Dim turn As String
            If x > 5 Then
                turn = "U"
            ElseIf x > 4 Then
                turn = "F"
            ElseIf x > 3 Then
                turn = "D"
            ElseIf x > 2 Then
                turn = "L"
            ElseIf x > 1 Then
                turn = "R"
            Else
                turn = "B"
            End If

            If y > 3 Then
                turn = turn & " "
            ElseIf y > 1 Then
                turn = turn & "'"
            Else
                turn = turn & "2"
            End If

            'if the side that is selected is the same as the previous side that was selected then the process is restarted 
            If storage.StartsWith(turn.Chars(0)) Then
                GoTo Line238
            Else
                'inputs the generated turn into the sub which carries out the turn
                clockwise(turn)
                storage = turn
            End If


        Next
        'returns the number of moves used so it can be added to the move number
        Return z
    End Function



    ' *** SOLVER ***


    'solves the cube using the steps in the subroutines
    Overridable Sub solver()
        Dim failSafe As Integer = 0
        While isCubeSolved() = False
            clockwise("U ")
            clockwise("U'")
            failSafe += 1
            If failSafe > 300 Then
                MessageBox.Show("Unable to solve cube. This may happen when solving the last layer and only 2 or 3 pieces need to be re-oriented to the correct position.")
                Exit While
            End If
            'solves white cross on bototm
            getWhiteCross()
            'solves the bottom white corners of the cube
            getWhiteCorners()

            'solves the middle edges
            solveMiddle()

            'solves the top layer (yellow cross and yellow corners)
            topLayer()

        End While
    End Sub


    'finds the bottom cross squares and rotates the faces until the squares are in the correct position
    Public Sub getWhiteCross()
        Dim hold As Color
Line291:
        'checks if the bottom cross is complete
        isBottomFaceComplete()

        'if the bottom cross isnt complete then it will find a square that belongs in the bottom cross and move it there
        While bottomComplete = False

            'j represents which face the square is on
            For j = 0 To 5

                'i represents which square is the correct one
                For i = 1 To 4
                    'i is changed so that it represents the syntax of the layout array variable and selects the right squares
                    If layout(j, (i * 2 - 1)) = Color.White Then
                        Select Case i
                            Case 1
                                If j = 0 Then
                                    hold = layout(5, 1)
                                ElseIf j = 1 Then
                                    hold = layout(0, 5)
                                ElseIf j = 2 Then
                                    hold = layout(1, 5)
                                ElseIf j = 3 Then
                                    hold = layout(0, 7)
                                ElseIf j = 4 Then
                                    hold = layout(0, 3)
                                ElseIf j = 5 Then
                                    hold = layout(0, 1)
                                End If

                            Case 2

                                If j = 0 Then
                                    hold = layout(4, 1)
                                ElseIf j = 1 Then
                                    hold = layout(4, 7)
                                ElseIf j = 2 Then
                                    hold = layout(4, 5)
                                ElseIf j = 3 Then
                                    hold = layout(1, 7)
                                ElseIf j = 4 Then
                                    hold = layout(5, 7)
                                ElseIf j = 5 Then
                                    hold = layout(3, 7)
                                End If

                            Case 3

                                If j = 0 Then
                                    hold = layout(1, 1)
                                ElseIf j = 1 Then
                                    hold = layout(2, 1)
                                ElseIf j = 2 Then
                                    hold = layout(5, 5)
                                ElseIf j = 3 Then
                                    hold = layout(2, 7)
                                ElseIf j = 4 Then
                                    hold = layout(2, 3)
                                ElseIf j = 5 Then
                                    hold = layout(2, 5)
                                End If

                            Case 4

                                If j = 0 Then
                                    hold = layout(3, 1)
                                ElseIf j = 1 Then
                                    hold = layout(3, 3)
                                ElseIf j = 2 Then
                                    hold = layout(3, 5)
                                ElseIf j = 3 Then
                                    hold = layout(5, 3)
                                ElseIf j = 4 Then
                                    hold = layout(1, 3)
                                ElseIf j = 5 Then
                                    hold = layout(4, 3)
                                End If

                        End Select
                        isBottomFaceComplete()
                        If bottomComplete = True Then
                            GoTo Line291
                        Else
                            'if an edge piece with white on it is found then its position and the colour of the aadjacent square are put through the whiteCross sub
                            whiteCross(hold, i, j)
                        End If

                    End If
                Next
            Next
            'checks if the bottom cross is complete before going through the loop again
            isBottomFaceComplete()

        End While

    End Sub

    'depending on which face the white edge piece is on will determine which sub is called
    Private Sub whiteCross(colour, square, face)
        If face = 0 Then
            topFaceWhiteCross(colour, square)
        End If
        If face = 2 Then
            bottomFaceWhiteCross(colour, square)
        End If
        If face = 1 Or face = 3 Or face = 4 Or face = 5 Then
            sideFaceWhiteCross(colour, square, face)
        End If
    End Sub

    'if the white edge piece is on the top face
    Private Sub topFaceWhiteCross(colour, square)

        For i = 1 To 4
            Dim x As Color
            Dim y As Color = colour

            'uses the colour of the adjacent square to get an i value
            If i = 1 Then
                x = Color.Orange
            ElseIf i = 2 Then
                x = Color.Lime
            ElseIf i = 3 Then
                x = Color.Red
            ElseIf i = 4 Then
                x = Color.RoyalBlue
            End If

            If y = x Then
                'which square the piece is on and the i value are used to determine how many times the top face should be rotated so the piece is on the correct face
                Dim turns As Integer = square - i
                Dim finalMove As String
                Dim firstMove As String

                'uses the position of the square to determine the final move to put the white square in the correct place
                If i = 1 Then
                    finalMove = ("B2")
                ElseIf i = 2 Then
                    finalMove = ("R2")
                ElseIf i = 3 Then
                    finalMove = ("F2")
                Else
                    finalMove = ("L2")
                End If
                'the turn value determines how far the top face must be turned in order to get the edge piece to the correct side
                If turns = 2 Or turns = -2 Then
                    firstMove = "U2"
                ElseIf turns = 3 Or turns = -1 Then
                    firstMove = "U "
                ElseIf turns = -3 Or turns = 1 Then
                    firstMove = "U'"
                Else
                    firstMove = ""
                End If
                'carries out the moves that have just been worked out
                If firstMove = "" Then
                    clockwise(finalMove)
                Else
                    clockwise(firstMove)
                    clockwise(finalMove)

                End If
            End If
        Next
    End Sub

    'if a white edge piece is found on the bottom it is moved to the top face and the topFaceWhiteCross sub is run to move it to the correct position
    Private Sub bottomFaceWhiteCross(colour, square)
        Dim x As Color
        Dim y As Color = colour

        If square = 1 Then
            x = Color.Red
        ElseIf square = 2 Then
            x = Color.Lime
        ElseIf square = 3 Then
            x = Color.Orange
        ElseIf square = 4 Then
            x = Color.RoyalBlue
        End If

        'if the piece isnt already in the right place then...
        If colour = Color.Red And square = 1 Then
        ElseIf colour = Color.Lime And square = 2 Then
        ElseIf colour = Color.Orange And square = 3 Then
        ElseIf colour = Color.RoyalBlue And square = 4 Then
        ElseIf y <> x Then
            'the face is turned 180 degrees so the bototm piece is now on top
            Dim turn As String
            If square = 1 Then
                turn = "F2"
            ElseIf square = 2 Then
                turn = "R2"
            ElseIf square = 3 Then
                turn = "B2"
            Else
                turn = "L2"
            End If
            clockwise(turn)
            'the square number is changed so it matches the correct square on the top face
            If square = 1 Then
                square = 3
            ElseIf square = 3 Then
                square = 1
            End If
            'after the piece has been moved to the top, topfacewhitecross is called so that the piece is moved to the correct place
            topFaceWhiteCross(colour, square)
        End If
        isBottomFaceComplete()

    End Sub

    'checks all the edge pices on the bottom to see if they are correct or not
    Private Sub isBottomFaceComplete()
        If layout(2, 1) = Color.White And layout(1, 5) = Color.Red Then
            If layout(2, 3) = Color.White And layout(4, 5) = Color.Lime Then
                If layout(2, 5) = Color.White And layout(5, 5) = Color.Orange Then
                    If layout(2, 7) = Color.White And layout(3, 5) = Color.RoyalBlue Then
                        bottomComplete = True
                    End If
                End If
            End If
        End If
    End Sub

    'if there is a white edge piece on one of the side faces then it is moved to the top and the solve process is repeated
    Private Sub sideFaceWhiteCross(colour, square, face)
        Dim spin As String
        Dim change As Boolean = False

        Dim side As String
        If face = 0 Then
            side = "U"
        ElseIf face = 1 Then
            side = "F"
        ElseIf face = 2 Then
            side = "D"
        ElseIf face = 3 Then
            side = "L"
        ElseIf face = 4 Then
            side = "R"
        Else
            side = "B"
        End If

        'if the edge piec is in position 1 or 3 then the face is rotated so it is in position 2 or 4
        If square = 1 Then
            clockwise(side & " ")
            change = True

        ElseIf square = 3 Then
            clockwise(side & " ")
            change = True

        End If

        'edge piece is moved to the top
        If square = 1 Or square = 2 Then
            If face = "1" Then
                spin = "R"
                square = 2
            ElseIf face = "4" Then
                spin = "B"
                square = 1
            ElseIf face = "5" Then
                spin = "L"
                square = 4
            Else
                spin = "F"
                square = 3
            End If
            clockwise(spin & " ")

        Else
            If face = "1" Then
                spin = "L"
                square = 4
            ElseIf face = "3" Then
                spin = "B"
                square = 3
            ElseIf face = "5" Then
                spin = "R"
                square = 2
            Else
                spin = "F"
                square = 1
            End If
            clockwise(spin & "'")

        End If
        'after the piece has been moved to the top, topfacewhitecross is called so that the piece is moved to the correct place
        topFaceWhiteCross(colour, square)
    End Sub


    'finds a corner with a white square on it
    Public Sub getWhiteCorners()
        Dim hold1 As Color
        Dim hold2 As Color
        isBottomCornersComplete()
        'carries out the sub until all the white corners on the bottom have been completed
        While bottomCornersComplete = False
            For j = 0 To 5
                'changes the order that the j variable is used so that sides are prioritised
                If j = 0 Then
                    j = 3
                ElseIf j = 1 Then
                    j = 1
                ElseIf j = 2 Then
                    j = 4
                ElseIf j = 3 Then
                    j = 5
                ElseIf j = 4 Then
                    j = 0
                ElseIf j = 5 Then
                    j = 2
                End If
                For i = 1 To 4
                    If layout(j, (i * 2 - 2)) = Color.White Then
                        Select Case i
                            Case 1
                                If j = 0 Then
                                    hold1 = layout(5, 2)
                                    hold2 = layout(3, 0)
                                ElseIf j = 1 Then
                                    hold1 = layout(0, 6)
                                    hold2 = layout(3, 2)
                                ElseIf j = 2 Then
                                    hold1 = layout(1, 6)
                                    hold2 = layout(3, 4)
                                ElseIf j = 3 Then
                                    hold1 = layout(0, 0)
                                    hold2 = layout(5, 2)
                                ElseIf j = 4 Then
                                    hold1 = layout(0, 4)
                                    hold2 = layout(1, 2)
                                ElseIf j = 5 Then
                                    hold1 = layout(0, 2)
                                    hold2 = layout(4, 2)
                                End If

                            Case 2

                                If j = 0 Then
                                    hold2 = layout(5, 0)
                                    hold1 = layout(4, 2)
                                ElseIf j = 1 Then
                                    hold2 = layout(0, 4)
                                    hold1 = layout(4, 0)
                                ElseIf j = 2 Then
                                    hold2 = layout(1, 4)
                                    hold1 = layout(4, 6)
                                ElseIf j = 3 Then
                                    hold2 = layout(0, 6)
                                    hold1 = layout(1, 0)
                                ElseIf j = 4 Then
                                    hold2 = layout(0, 2)
                                    hold1 = layout(5, 0)
                                ElseIf j = 5 Then
                                    hold2 = layout(0, 0)
                                    hold1 = layout(3, 0)
                                End If

                            Case 3

                                If j = 0 Then
                                    hold1 = layout(1, 2)
                                    hold2 = layout(4, 0)
                                ElseIf j = 1 Then
                                    hold1 = layout(2, 2)
                                    hold2 = layout(4, 6)
                                ElseIf j = 2 Then
                                    hold1 = layout(5, 6)
                                    hold2 = layout(4, 4)
                                ElseIf j = 3 Then
                                    hold1 = layout(2, 0)
                                    hold2 = layout(1, 6)
                                ElseIf j = 4 Then
                                    hold1 = layout(2, 4)
                                    hold2 = layout(5, 6)
                                ElseIf j = 5 Then
                                    hold1 = layout(2, 6)
                                    hold2 = layout(3, 6)
                                End If

                            Case 4

                                If j = 0 Then
                                    hold1 = layout(3, 2)
                                    hold2 = layout(1, 0)
                                ElseIf j = 1 Then
                                    hold1 = layout(3, 4)
                                    hold2 = layout(2, 0)
                                ElseIf j = 2 Then
                                    hold1 = layout(3, 6)
                                    hold2 = layout(5, 4)
                                ElseIf j = 3 Then
                                    hold1 = layout(5, 4)
                                    hold2 = layout(2, 6)
                                ElseIf j = 4 Then
                                    hold1 = layout(1, 4)
                                    hold2 = layout(2, 2)
                                ElseIf j = 5 Then
                                    hold1 = layout(4, 4)
                                    hold2 = layout(2, 4)
                                End If

                        End Select
                        whiteCorners(hold1, hold2, i, j)
                    End If
                Next
            Next
            'checks if the bottom is complete to determine whether thr process should be repeated
            isBottomCornersComplete()

        End While
    End Sub

    'the face determines which sub is called
    Private Sub whiteCorners(colour1, colour2, square, face)
        If face = 0 Then
            topFaceWhiteCorners(colour1, colour2, square)
        End If
        If face = 2 Then
            bottomFaceWhiteCorners(colour1, colour2, square)
        End If
        If face = 1 Or face = 3 Or face = 4 Or face = 5 Then
            sideFaceWhiteCorners(colour1, colour2, square, face)
        End If
    End Sub

    'moves white corner pieces from the top to the side
    Private Sub topFaceWhiteCorners(colour1, colour2, square)
        'square refers to which corner it is
        '1 is top left, 2 is top right, 3 is bottom right, 4 is bottom left
        If square = 1 Then
            clockwise("L ")
            clockwise("U2")
            clockwise("L'")
        End If
        If square = 2 Then
            clockwise("R'")
            clockwise("U2")
            clockwise("R ")
        End If
        If square = 3 Then
            clockwise("R ")
            clockwise("U2")
            clockwise("R'")
        End If
        If square = 4 Then
            clockwise("L'")
            clockwise("U2")
            clockwise("L ")
        End If
    End Sub

    'moves white corner pieces from the bottom to the side if they are not already in the correct position
    Private Sub bottomFaceWhiteCorners(colour1, colour2, square)
        If square = 1 And colour1 <> Color.Red Then
            clockwise("L'")
            clockwise("U2")
            clockwise("L ")
        ElseIf square = 2 And colour1 <> Color.Lime Then
            clockwise("R ")
            clockwise("U2")
            clockwise("R'")
        ElseIf square = 3 And colour1 <> Color.Orange Then
            clockwise("R'")
            clockwise("U2")
            clockwise("R ")
        ElseIf square = 4 And colour1 <> Color.RoyalBlue Then
            clockwise("L ")
            clockwise("U2")
            clockwise("L'")
        End If
    End Sub

    'moves white corner pieces from the side to the correct position on the bottom
    Private Sub sideFaceWhiteCorners(colour1, colour2, square, face)
        Dim rotate As Integer
        Dim side As String
        If face = 1 Then
            side = "F"
            rotate = 3
        ElseIf face = 3 Then
            side = "L"
            rotate = 4
        ElseIf face = 4 Then
            side = "R"
            rotate = 2
        Else
            side = "B"
            rotate = 1
        End If

        'if the corner on one of the side faces is at the bottom row of the side face then it will be moved to the top row
        If square = 3 Then
            clockwise(side & "'")
            clockwise("U2")
            clockwise(side & " ")
        End If
        If square = 4 Then
            clockwise(side & " ")
            clockwise("U2")
            clockwise(side & "'")
        End If

        'if the corner is on the top row then it will be moved into the correct position on the bottom row
        If square = 1 Then

            For i = 1 To 4
                Dim x As Color
                Dim y As Color = colour2

                If i = 1 Then
                    x = Color.Orange
                ElseIf i = 2 Then
                    x = Color.Lime
                ElseIf i = 3 Then
                    x = Color.Red
                ElseIf i = 4 Then
                    x = Color.RoyalBlue
                End If

                'determines how far the top should be rotated so that the corner is on the right side of the cube
                If y = x Then
                    Dim turns As Integer = rotate - i
                    If turns = 2 Or turns = -2 Then
                        clockwise("U ")
                        If face = 1 Then
                            face = 3
                        ElseIf face = 3 Then
                            face = 5
                        ElseIf face = 4 Then
                            face = 1
                        Else
                            face = 4
                        End If
                    ElseIf turns = 3 Or turns = -1 Then

                    ElseIf turns = -3 Or turns = 1 Then
                        clockwise("U2")
                        If face = 1 Then
                            face = 5
                        ElseIf face = 3 Then
                            face = 4
                        ElseIf face = 4 Then
                            face = 3
                        Else
                            face = 1
                        End If
                    Else
                        clockwise("U'")
                        If face = 1 Then
                            face = 4
                        ElseIf face = 3 Then
                            face = 1
                        ElseIf face = 4 Then
                            face = 5
                        Else
                            face = 3
                        End If
                    End If

                    'when the corner is on the right side it will be inserted into the bottom row in the correct orientation
                    If face = 1 Then
                        side = "F"
                        rotate = 3
                    ElseIf face = 3 Then
                        side = "L"
                        rotate = 4
                    ElseIf face = 4 Then
                        side = "R"
                        rotate = 2
                    Else
                        side = "B"
                        rotate = 1
                    End If

                    clockwise(side & " ")
                    clockwise("U ")
                    clockwise(side & "'")
                End If
            Next




        End If

        'if the corner is on the top row then it will be moved into the correct position on the bottom row
        If square = 2 Then

            For i = 1 To 4
                Dim x As Color
                Dim y As Color = colour1

                If i = 1 Then
                    x = Color.Orange
                ElseIf i = 2 Then
                    x = Color.Lime
                ElseIf i = 3 Then
                    x = Color.Red
                ElseIf i = 4 Then
                    x = Color.RoyalBlue
                End If

                'determines how far the top should be rotated so that the corner is on the right side of the cube
                If y = x Then
                    Dim turns As Integer = rotate - i - 1

                    If turns = 2 Or turns = -2 Then
                        clockwise("U2")
                        If face = 1 Then
                            face = 5
                        ElseIf face = 3 Then
                            face = 4
                        ElseIf face = 4 Then
                            face = 3
                        Else
                            face = 1
                        End If
                    ElseIf turns = 3 Or turns = -1 Then
                        clockwise("U ")
                        If face = 1 Then
                            face = 3
                        ElseIf face = 3 Then
                            face = 5
                        ElseIf face = 4 Then
                            face = 1
                        Else
                            face = 4
                        End If
                    ElseIf turns = -3 Or turns = 1 Then
                        clockwise("U'")
                        If face = 1 Then
                            face = 4
                        ElseIf face = 3 Then
                            face = 1
                        ElseIf face = 4 Then
                            face = 5
                        Else
                            face = 3
                        End If
                    Else

                    End If

                    'when the corner is on the right side it will be inserted into the bottom row in the correct orientation
                    If face = 1 Then
                        side = "F"
                        rotate = 3
                    ElseIf face = 3 Then
                        side = "L"
                        rotate = 4
                    ElseIf face = 4 Then
                        side = "R"
                        rotate = 2
                    Else
                        side = "B"
                        rotate = 1
                    End If
                    clockwise(side & "'")
                    clockwise("U'")
                    clockwise(side & " ")
                End If
            Next

        End If

    End Sub


    'if all bottom corners are in the correct place then it returns bottomCornersComplete as true otherwise it is false
    Private Sub isBottomCornersComplete()
        If layout(2, 0) = Color.White And layout(1, 6) = Color.Red And layout(3, 4) = Color.RoyalBlue Then
            If layout(2, 2) = Color.White And layout(4, 6) = Color.Lime And layout(1, 4) = Color.Red Then
                If layout(2, 4) = Color.White And layout(5, 6) = Color.Orange And layout(4, 4) = Color.Lime Then
                    If layout(2, 6) = Color.White And layout(3, 6) = Color.RoyalBlue And layout(5, 4) = Color.Orange Then
                        bottomCornersComplete = True
                        Return
                    End If
                End If
            End If
        End If
        bottomCornersComplete = False
    End Sub


    'solves the edge pieces on the middle layer
    'only the edge pieces need to be solved because the middle squares on each face cant be moved
    Public Sub solveMiddle()
        'attempts to solve all of the middle layer
        middleLayer()

        'checks if middle layer complete
        isMiddleLayerComplete()

        'if it isnt then it will check the edges to see if it is hidden from the middlelayer sub
        While middleLayerComplete = False
            hiddenMiddle()
            middleLayer()
            isMiddleLayerComplete()
        End While
    End Sub

    'moves edge pieces on the top layer to correct position on the middle layer
    Private Sub middleLayer()

        Dim j As Integer
        Dim i As Integer

        'checks all 4 edge pieces on top layer
        For h = 1 To 4

            Dim moved1 As Boolean = False
            Dim moved2 As Boolean = False


            For i = 1 To 4
                Dim colour1 As Color = Color.Black
                Dim colour2 As Color = Color.Black
                j = i
                If j = 1 Then
                    j = 5
                ElseIf j = 2 Then
                    j = 4
                ElseIf j = 3 Then
                    j = 1
                ElseIf j = 4 Then
                    j = 3
                End If
                'if its not a yellow piece then it needs to be moved
                If layout(0, i * 2 - 1) <> Color.Yellow And layout(j, 1) <> Color.Yellow Then
                    colour1 = layout(0, i * 2 - 1)
                    colour2 = layout(j, 1)
                End If

                'if the colour has been detected then it will start moving it
                If colour1 <> Color.Black Or colour2 <> Color.Black Then
                    Dim x As Color
                    Dim y As Color
                    Dim hold1 As String
                    Dim hold2 As String

                    'finds the face it is meant to be on
                    For q = 1 To 4
                        If q = 1 Then
                            x = Color.Orange
                        ElseIf q = 2 Then
                            x = Color.Lime
                        ElseIf q = 3 Then
                            x = Color.Red
                        ElseIf q = 4 Then
                            x = Color.RoyalBlue
                        End If

                        If colour2 = x Then
                            hold1 = q
                            Dim turns As Integer = i - q
                            Dim nextMove As String = ""
                            If turns = 0 Then
                                nextMove = ""
                            ElseIf turns = 2 Or turns = -2 Then
                                nextMove = "U2"
                                i += 2
                            ElseIf turns = -1 Or turns = 3 Then
                                nextMove = "U "
                                i += 1
                            Else
                                nextMove = "U'"
                                i -= 1
                            End If
                            If nextMove <> "" Then
                                clockwise(nextMove)
                            End If

                            If i > 4 Then
                                i -= 4
                            End If
                            If i < 1 Then
                                i += 4
                            End If

                            'finds the edge corner it is supposed to be on
                            For t = 1 To 4
                                If t = 1 Then
                                    y = Color.Orange
                                ElseIf t = 2 Then
                                    y = Color.Lime
                                ElseIf t = 3 Then
                                    y = Color.Red
                                ElseIf t = 4 Then
                                    y = Color.RoyalBlue
                                End If

                                Dim verify As Boolean = False

                                If y = colour1 Then
                                    hold2 = t
                                    Dim change As String = ""
                                    If t - i = 1 Or t - i = -3 Then
                                        change = "U'"
                                        verify = True
                                    ElseIf t - i = -1 Or t - i = 3 Then
                                        change = "U "
                                        verify = True
                                    Else
                                    End If
                                    If change <> "" Then
                                        clockwise(change)
                                    End If


                                    Dim move1 As String
                                    Dim move2 As String

                                    If hold1 = 1 Then
                                        move1 = "B"
                                    ElseIf hold1 = 2 Then
                                        move1 = "R"
                                    ElseIf hold1 = 3 Then
                                        move1 = "F"
                                    Else
                                        move1 = "L"
                                    End If

                                    If hold2 = 1 Then
                                        move2 = "B"
                                    ElseIf hold2 = 2 Then
                                        move2 = "R"
                                    ElseIf hold2 = 3 Then
                                        move2 = "F"
                                    Else
                                        move2 = "L"
                                    End If

                                    'moves the piece to the correct position using the algorithm
                                    If verify = True Then
                                        If change = "U " Then
                                            clockwise(move2 & " ")
                                            clockwise("U ")
                                            clockwise(move2 & "'")
                                            clockwise("U'")
                                            clockwise(move1 & "'")
                                            clockwise("U'")
                                            clockwise(move1 & " ")
                                            verify = False
                                            move1 = ""
                                            move2 = ""
                                        End If

                                        If change = "U'" Then
                                            clockwise(move2 & "'")
                                            clockwise("U'")
                                            clockwise(move2 & " ")
                                            clockwise("U ")
                                            clockwise(move1 & " ")
                                            clockwise("U ")
                                            clockwise(move1 & "'")
                                            verify = False
                                            move1 = ""
                                            move2 = ""
                                        End If
                                        change = ""
                                    End If
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        Next

    End Sub

    'checks to see if the middle has met condition of middlelayer sub but is still not complete
    'moves edge pieces to the top then middlelayer is called again from the parent sub
    Private Sub hiddenMiddle()

        If layout(3, 3) <> Color.RoyalBlue And layout(1, 7) <> Color.Red Then
            clockwise("F ")
            clockwise("U ")
            clockwise("F'")
            clockwise("U'")
            clockwise("L'")
            clockwise("U'")
            clockwise("L ")

        End If

        If layout(1, 3) <> Color.Red And layout(4, 7) <> Color.Lime Then
            clockwise("R ")
            clockwise("U ")
            clockwise("R'")
            clockwise("U'")
            clockwise("F'")
            clockwise("U'")
            clockwise("F ")

        End If

        If layout(4, 3) <> Color.Lime And layout(5, 7) <> Color.Orange Then
            clockwise("B ")
            clockwise("U ")
            clockwise("B'")
            clockwise("U'")
            clockwise("R'")
            clockwise("U'")
            clockwise("R ")

        End If

        If layout(5, 3) <> Color.Orange And layout(3, 7) <> Color.Red Then
            clockwise("L ")
            clockwise("U ")
            clockwise("L'")
            clockwise("U'")
            clockwise("B'")
            clockwise("U'")
            clockwise("B ")

        End If

    End Sub

    'checks to see if the middle layer has all the right colours in the right places
    Private Sub isMiddleLayerComplete()
        If layout(3, 3) = Color.RoyalBlue And layout(1, 7) = Color.Red Then
            If layout(1, 3) = Color.Red And layout(4, 7) = Color.Lime Then
                If layout(4, 3) = Color.Lime And layout(5, 7) = Color.Orange Then
                    If layout(5, 3) = Color.Orange And layout(3, 7) = Color.RoyalBlue Then
                        middleLayerComplete = True
                    Else
                        middleLayerComplete = False
                    End If
                Else
                    middleLayerComplete = False
                End If
            Else
                middleLayerComplete = False
            End If
        Else
            middleLayerComplete = False
        End If

    End Sub


    'carries out all subs to solve the top layer
    Public Sub topLayer()
        topCross()
        topEdgeOrientation()
        solveTopCorners()
        finalStage()

    End Sub

    'arranges pieces into a yellow cross on top of the  cube
    Private Sub topCross()
Line1335:
        'stores values about the cross on top and if a yellow corner is in the correct place
        Dim yellowCross(4) As Boolean
        Dim singleYellow As Boolean = True
        Dim yellowCount As Integer = 0

        'checks to see how many yellow squares are on top
        For i = 1 To 4
            If layout(0, 1) = Color.Yellow Then
                yellowCross(i) = True
                singleYellow = False
                yellowCount += 1
            End If
            clockwise("U'")
        Next

        'if ther is only the yellow centerpiece on top then it changes the cube so there are more using the ddefault sub
        If singleYellow = True Then
            topDefault()
            topDefault()
            'goes back to start of sub to check top pieces again
            GoTo Line1335
        End If

        'if the top corss is already complete then it skips to the end of the subroutine
        If yellowCross(1) = True And yellowCross(2) = True And yellowCross(3) = True And yellowCross(4) = True Then
            GoTo Line1379
        End If

        'if there is a yellow line across the top of the cube then it carries out the default sub once which gives a cross
        If yellowCross(2) = True And yellowCross(4) = True Or yellowCross(1) = True And yellowCross(3) = True Then
            If yellowCross(1) = True And yellowCross(3) = True Then
                clockwise("U ")
            End If
            topDefault()
            'skips to the end of the sub whena it has a cross
            GoTo Line1379
        End If


        lCheck()
        'if there is an L sha[e on top then it roatets the top so the L is in the top left and carries out default twice which gives a cross on top
        If isLOnTop = False Then
            clockwise("U'")
            topDefault()
            GoTo Line1335
        Else
            topDefault()
            topDefault()
        End If



Line1379:
    End Sub

    ''checks that the L on top is in the right place to solve it to a yellow cross
    Private Sub lCheck()
        If layout(0, 1) = Color.Yellow And layout(0, 7) = Color.Yellow Then
            isLOnTop = True
        End If
    End Sub

    'the algorithm that is used for all manipulation of the top to achieve a yellow cross
    Private Sub topDefault()
        clockwise("F ")
        clockwise("R ")
        clockwise("U ")
        clockwise("R'")
        clockwise("U'")
        clockwise("F'")
    End Sub

    'checks that each piece in the cross is in the correct place
    Private Sub topEdgeOrientation()

        For i = 1 To 4
            If layout(1, 1) = Color.Red Then
                GoTo Line1408
            Else
                clockwise("U ")
            End If
        Next

Line1408:

        Dim count As Integer
        Dim externalCount As Integer
        Dim store As Integer
        Dim red As Boolean = False
        Dim lime As Boolean = False
        Dim orange As Boolean = False
        Dim royalBlue As Boolean = False
        Dim Wred As Boolean = False
        Dim Wlime As Boolean = False
        Dim Worange As Boolean = False
        Dim WroyalBlue As Boolean = False

        For i = 1 To 4

            clockwise("U ")

            If layout(1, 1) = Color.Red Then
                count += 1
                red = True
            End If
            If layout(4, 1) = Color.Lime Then
                count += 1
                lime = True
            End If
            If layout(5, 1) = Color.Orange Then
                count += 1
                orange = True
            End If
            If layout(3, 1) = Color.RoyalBlue Then
                count += 1
                royalBlue = True
            End If

            'if two pieces are in the correct place then it stores the relevant information
            If count = 2 Then
                store = i
                externalCount = 2
                Wred = red
                Wlime = lime
                Worange = orange
                WroyalBlue = royalBlue
            End If

            If count = 4 Then
                store = i
                externalCount = 4
            End If

            red = False
            lime = False
            orange = False
            royalBlue = False
            count = 0

        Next

        '4 pieces are in the correct placee so this stage is finsihed after rotating to the correct position
        If externalCount = 4 Then
            For i = 1 To store
                clockwise("U ")
            Next
        End If

        'if two are corect then the top is rotated to the correct position and the algorithm is used once
        If externalCount = 2 Then
            For i = 1 To store
                clockwise("U ")
            Next

            If Wred = True And Wlime = True Then
                manipulate("F")
            ElseIf Wlime = True And Worange = True Then
                manipulate("R")
            ElseIf Worange = True And WroyalBlue = True Then
                manipulate("B")
            ElseIf WroyalBlue = True And Wred = True Then
                manipulate("L")
            ElseIf WroyalBlue = True And Wlime = True Or Wred = True And Worange = True Then
                manipulate("F")
                GoTo Line1408
            End If


        End If

    End Sub

    'changes the top corss from two pieces being correct to 4 pieces being correct or 0 pieces to 2 pieces
    Private Sub manipulate(side)
        clockwise(side & " ")
        clockwise("U ")
        clockwise(side & "'")
        clockwise("U ")
        clockwise(side & " ")
        clockwise("U2")
        clockwise(side & "'")
        clockwise("U ")

    End Sub

    'puts all the yellow corners in the correct corner
    Public Sub solveTopCorners()

        'checks to see how many corners are in the right place
        isOneCorner()

        'if there are less than 4 in the corect place then it keeps gouing until therre is 4
        While numberOnTop <> 4
            If corner1 = True Then
                carryOut("F", "B")
            ElseIf corner2 = True Then
                carryOut("R", "L")
            ElseIf corner3 = True Then
                carryOut("B", "F")
            ElseIf corner4 = True Then
                carryOut("L", "R")
            Else
                carryOut("F", "B")
            End If
            isOneCorner()
        End While



    End Sub

    'checks to see how many corners are in the right place
    'it does not check if they are in the correct orientation
    Public Sub isOneCorner()
        If layout(0, 6) = Color.Yellow And layout(1, 0) = Color.Red And layout(3, 2) = Color.RoyalBlue Or layout(0, 6) = Color.Red And layout(1, 0) = Color.RoyalBlue And layout(3, 2) = Color.Yellow Or layout(0, 6) = Color.RoyalBlue And layout(1, 0) = Color.Yellow And layout(3, 2) = Color.Red Then
            If corner1 = False Then
                corner1 = True
                numberOnTop += 1
            End If
        Else
            corner1 = False
        End If

        If layout(0, 4) = Color.Yellow And layout(4, 0) = Color.Lime And layout(1, 2) = Color.Red Or layout(0, 4) = Color.Lime And layout(4, 0) = Color.Red And layout(1, 2) = Color.Yellow Or layout(0, 4) = Color.Red And layout(4, 0) = Color.Yellow And layout(1, 2) = Color.Lime Then
            If corner2 = False Then
                corner2 = True
                numberOnTop += 1
            End If
        Else
            corner2 = False
        End If

        If layout(0, 2) = Color.Yellow And layout(5, 0) = Color.Orange And layout(4, 2) = Color.Lime Or layout(0, 2) = Color.Lime And layout(5, 0) = Color.Yellow And layout(4, 2) = Color.Orange Or layout(0, 2) = Color.Orange And layout(5, 0) = Color.Lime And layout(4, 2) = Color.Yellow Then
            If corner3 = False Then
                corner3 = True
                numberOnTop += 1
            End If
        Else
            corner3 = False
        End If

        If layout(0, 0) = Color.Yellow And layout(3, 0) = Color.RoyalBlue And layout(5, 2) = Color.Orange Or layout(0, 0) = Color.Orange And layout(3, 0) = Color.Yellow And layout(5, 2) = Color.RoyalBlue Or layout(0, 0) = Color.RoyalBlue And layout(3, 0) = Color.Orange And layout(5, 2) = Color.Yellow Then
            If corner4 = False Then
                corner4 = True
                numberOnTop += 1
            End If
        Else
            corner4 = False
        End If
    End Sub

    'rotates the corners around the top face 
    Public Sub carryOut(side1, side2)
        clockwise("U ")
        clockwise(side1 & " ")
        clockwise("U'")
        clockwise(side2 & "'")
        clockwise("U ")
        clockwise(side1 & "'")
        clockwise("U'")
        clockwise(side2 & " ")
    End Sub

    'orientates the corners so that the yellow face is complete which ends up completing all other faces
    'if it does the algorithm and it reaults in the yellow square of the corner being on top then it rotates until it finds another yellow corner that needs to be changed
    Public Sub finalStage()
        For i = 1 To 4
            While layout(0, 6) <> Color.Yellow
                clockwise("L ")
                clockwise("D ")
                clockwise("L'")
                clockwise("D'")
            End While
            clockwise("U ")
        Next
    End Sub



    'resets the cubes variables to the not solved values 
    'this is called when the cube has been solved then an addditional random butotn has been pressed
    Public Sub notSolved()
        numberOnTop = 0
        bottomCornersComplete = False
        bottomComplete = False
        middleLayerComplete = False
        allYellow = False
        isLOnTop = False
        corner1 = False
        corner2 = False
        corner3 = False
        corner4 = False
        redNumber = 0
        yellowNumber = 0
        whiteNumber = 0
        blueNumber = 0
        limeNumber = 0
        orangeNumber = 0
    End Sub

End Class
