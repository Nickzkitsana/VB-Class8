Public Class Form1

    Private Sub LabelResult_Click(sender As Object, e As EventArgs) Handles LabelResult.Click

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Try
            Dim balance As Double = CDbl(TextBalance.Text)
            If Double.TryParse(TextWithdraw.Text, 0) = False Then
                MessageBox.Show("กรุณากรอกจำนวนเงินที่จะถอนเป็นตัวเลข" & vbNewLine & "Ex. 0-999", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextWithdraw.Text = ""
                LabelResult.Text = ""
                Exit Sub
            End If
            Dim WD As New Withdrawal(CDbl(TextWithdraw.Text))
            Dim withdraw As Double = CDbl(TextWithdraw.Text)
            Dim message As String = ""


            If withdraw > balance Then
                MessageBox.Show("ยอดเงินคงเหลือไม่พอ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextWithdraw.Text = ""
                LabelResult.Text = ""
            ElseIf withdraw > 20000 Then
                MessageBox.Show("ถอนได้ไม่เกิน 20,000 บาท", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextWithdraw.Text = ""
                LabelResult.Text = ""
            ElseIf withdraw < 100 Then
                MessageBox.Show("ยอดขั้นต่ำต้องเป็นหลักร้อยเท่านั้น", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextWithdraw.Text = ""
                LabelResult.Text = ""
            ElseIf WD.Foundcash100under Mod 100 Then
                MessageBox.Show("ไม่สามารถถอนเศษต้ำกว่า 100 ได้", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextWithdraw.Text = ""
                LabelResult.Text = ""
            Else
                LabelResult.Text = "1000 : " & WD.Foundcash1000 & vbNewLine &
                                   "500  : " & WD.Foundcash500 & vbNewLine &
                                   "100  : " & WD.Foundcash100
                TextBalance.Text = balance - withdraw
            End If
        Catch ex As Exception
            MessageBox.Show("Error with : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
