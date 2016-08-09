'paste into an ide or decent editor (n++) to see proper code without arbitrary line breaks.


Sub Main()
        Dim arrHV(101, 101) As Integer                          ' i personally hate zero index so i always delcare 1 more than i intend to write to.
        loadArray(arrHV)                                        ' this makes visualizing the data easier since everything on earth is one indexed.
        For i As Integer = 99 To 1 Step -1                      ' start at the penultimate row
            For j As Integer = 1 To i + 1                       ' start at the leftmost number
                If arrHV(i + 1, j) > arrHV(i + 1, j + 1) Then   ' if left is greater than right below current number
                    arrHV(i, j) += arrHV(i + 1, j)              ' add it to the current number
                Else
                    arrHV(i, j) += arrHV(i + 1, j + 1)          ' likewise vice versa (this should work even if they are equal)
                End If
                arrHV(i + 1, j) = 0                             ' clear left number
                If j = i Then
                    arrHV(i + 1, j + 1) = 0                     ' done with this line clear rightmost number
                End If
            Next
        Next
        Console.WriteLine("top result = " + arrHV(1, 1).ToString)
        Console.ReadKey()
    End Sub
    Private Sub loadArray(ByRef a As Object)
        Dim calca As New Integer
        Dim wholeFile As String
        Dim lineData() As String
        Dim fieldData() As String
        Dim filePath As String = My.Computer.FileSystem.CurrentDirectory & "\triangle.txt"
        wholeFile = My.Computer.FileSystem.ReadAllText(filePath)
        lineData = Split(wholeFile, vbNewLine)
        Dim i As Integer = 1                                    ' vertical (row)
        Dim j As Integer = 1                                    ' horizontal (columns)
        For Each lineOfText As String In lineData
            fieldData = lineOfText.Split(" ")
            j = 1                                               ' always reset
            For Each twoDigit As String In fieldData
                If Integer.TryParse(twoDigit, Nothing) Then     ' if it parses it's not EOF/EOL or "", null, NOTHING, or whatever.

                    calca = Integer.Parse(twoDigit.ToString)    ' this parses from string to integer, obviously, can't do it next line
                    a(i, j) = calca                             ' vb will complain that there's an uninstantiated variable or object.
                    j += 1                                      ' track the location in the file. For Each has same drawbacks as while and do loops
                Else
                    Return
                End If
            Next twoDigit

            i += 1                                              ' keep track. See above comment.
        Next lineOfText
    End Sub
