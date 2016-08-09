Sub Main()
        Console.WriteLine(sumsquares(100).ToString)
        Console.WriteLine(SquareOfSums(100).ToString)
        Console.WriteLine(SquareOfSums(100) - (sumsquares(100)).ToString)
        Console.ReadKey()

    End Sub
    Private Function sumsquares(ByVal i As Integer) As Object
        Dim temp As Object = 0
        For n As Integer = 1 To i
            temp = temp + (n ^ 2)
        Next
        Return temp
    End Function
    Private Function SquareOfSums(ByVal i As Integer) As Object
        Dim temp As Object = 0
        For n As Integer = 1 To i
            temp = temp + n
        Next
        Return (temp * temp)
    End Function
