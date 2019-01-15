Public Class Form1

    Private Sub LabelResult_Click(sender As Object, e As EventArgs) Handles LabelResult.Click

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Dim balance As Integer = CInt(TextBalance.Text)
        If Integer.TryParse(TextWithdraw.Text, 0) = False Then
            MessageBox.Show("กรุณากรอกจำนวนเงินที่จะถอนเป็นตัวเลข" & vbNewLine & "Ex. 0-999")
            TextWithdraw.Text = ""
            LabelResult.Text = ""
            Exit Sub
        End If
        Dim WD As New Withdrawal(CInt(TextWithdraw.Text))
        Dim withdraw As Integer = CInt(TextWithdraw.Text)
        Dim message As String = ""


        If withdraw > balance Then
            MessageBox.Show("ยอดเงินคงเหลือไม่พอ")
            TextWithdraw.Text = ""
            LabelResult.Text = ""
        ElseIf withdraw > 20000 Then
            MessageBox.Show("ถอนได้ไม่เกิน 20,000 บาท")
            TextWithdraw.Text = ""
            LabelResult.Text = ""
        ElseIf withdraw < 100 Then
            MessageBox.Show("ยอดขั้นต่ำต้องเป็นหลักร้อยเท่านั้น")
            TextWithdraw.Text = ""
            LabelResult.Text = ""
        Else
            LabelResult.Text = "1000 : " & WD.Foundcash1000 & vbNewLine &
                               "500  : " & WD.Foundcash500 & vbNewLine &
                               "100  : " & WD.Foundcash100
        End If

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ran As Random = New Random
        TextBalance.Text = ran.Next(1, 9) * 100000
        TextWithdraw.Select()
    End Sub

    Private Sub TextWithdraw_TextChanged(sender As Object, e As EventArgs) Handles TextWithdraw.TextChanged
        If TextWithdraw.Text <> "" Then
            ButtonOK.Enabled = True
        Else
            ButtonOK.Enabled = False
        End If
    End Sub
End Class
