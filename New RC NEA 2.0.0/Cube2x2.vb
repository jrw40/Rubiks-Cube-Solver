Public Class Cube2x2
    Inherits Cube3x3

    'overrides the solver because less has to be done for a 2x2 cube to solve it
    Overrides Sub solver()

        Form1.stepbystep = True


        'while the cube isnt solved
        'solves bottom corners, then top corners, then orients them correctly
        Dim failSafe As Integer = 0
        While isCubeSolved() = False
            failSafe += 1
            If failSafe > 120 Then
                MessageBox.Show("Unable to solve cube. This may happen when solving the last layer and only 2 or 3 pieces need to be re-oriented to the correct position.")
                Exit While
            End If
            getWhiteCorners()

            isOneCorner()

            'if no corners in correct place then rotate until there is
            While numberOnTop = 0
                clockwise("U ")
                isOneCorner()
            End While

            solveTopCorners()

            finalStage()

        End While
    End Sub


    'different to 3x3 scramble because it doesnt require as many moves
    'scrambles the cube using a random number of turns on random faces
    Overrides Function scramble()
        notSolved()
        Dim random As New Random
        'generates a random integer between 7 and 13 which is the number of turns that will be performed
        Dim z As Decimal = random.Next(7, 13)

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



    'finds out if the cube is solved
    Overrides Function isCubeSolved()
        Dim completed As Boolean = False
        Dim count As Integer = 0
        For j = 0 To 5
            For i = 1 To 4

                If j = 0 Then
                    If layout(j, i * 2 - 2) = Color.Yellow Then
                        count += 1
                    End If
                ElseIf j = 1 Then
                    If layout(j, i * 2 - 2) = Color.Red Then
                        count += 1
                    End If
                ElseIf j = 2 Then
                    If layout(j, i * 2 - 2) = Color.White Then
                        count += 1
                    End If
                ElseIf j = 3 Then
                    If layout(j, i * 2 - 2) = Color.RoyalBlue Then
                        count += 1
                    End If
                ElseIf j = 4 Then
                    If layout(j, i * 2 - 2) = Color.Lime Then
                        count += 1
                    End If
                ElseIf j = 5 Then
                    If layout(j, i * 2 - 2) = Color.Orange Then
                        count += 1
                    End If
                End If
            Next
        Next

        'count increases by one if a square is in the correct place
        'if count is 24 (number of squares on a 2x2 cube) then it is solved
        If count = 24 Then
            completed = True
        End If
        Return completed
    End Function



End Class
