Public Class Form1
    Structure Stunde
        Public start As Integer()
        Public ende As Integer()
        Public Sub New(s As Integer(), e As Integer())
            start = s
            ende = e
        End Sub
    End Structure
    Dim stunden() As Stunde = New Stunde() {
        New Stunde(New Integer() {0, 0}, New Integer() {0, 0}),
        New Stunde(New Integer() {7, 40}, New Integer() {8, 25}),
        New Stunde(New Integer() {8, 30}, New Integer() {9, 15}),
        New Stunde(New Integer() {9, 35}, New Integer() {10, 20}),
        New Stunde(New Integer() {10, 25}, New Integer() {11, 10}),
        New Stunde(New Integer() {11, 20}, New Integer() {12, 5}),
        New Stunde(New Integer() {12, 10}, New Integer() {12, 55}),
        New Stunde(New Integer() {12, 56}, New Integer() {13, 59}),
        New Stunde(New Integer() {14, 0}, New Integer() {14, 45}),
        New Stunde(New Integer() {14, 50}, New Integer() {15, 35}),
        New Stunde(New Integer() {15, 50}, New Integer() {16, 35})
    }
    Dim index As Integer
    Private Sub Timer1_Tick() Handles Timer1.Tick
        Dim h = Date.Now.TimeOfDay.Hours
        Dim m = Date.Now.TimeOfDay.Minutes
        Label2.Text = IntToString(h) + ":" + IntToString(m) + ":" + IntToString(Date.Now.TimeOfDay.Seconds)

    End Sub
    Function IntToString(x As Integer) As String
        If x.ToString.Length = 1 Then
            Return "0" + x.ToString
        End If
        Return x.ToString
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1_Tick()
        Timer2_Tick()
    End Sub
    Private Sub Timer2_Tick() Handles Timer2.Tick
        Dim h = Date.Now.TimeOfDay.Hours
        Dim m = Date.Now.TimeOfDay.Minutes
        For i As Integer = 0 To stunden.Count - 1
            If New TimeSpan(stunden(i).start(0), stunden(i).start(1), 0) <= New TimeSpan(h, m, 0) Then
                index = i
            End If
        Next
        Dim a = New TimeSpan(stunden(index).ende(0), stunden(index).ende(1), 0) - New TimeSpan(h, m, 0)
        Label1.Text = IntToString(a.Hours) + ":" + IntToString(Math.Abs(a.Minutes))
    End Sub
End Class