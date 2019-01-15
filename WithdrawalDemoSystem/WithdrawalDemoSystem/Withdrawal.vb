Public Class Withdrawal
    Private _Withdraw, _Balance As Double
    Public Sub New(withdraw)
        _Withdraw = withdraw
    End Sub

    Public Function Foundcash1000() As Double
        Return _Withdraw \ 1000
    End Function

    Public Function Foundcash500() As Double
        Return (_Withdraw Mod 1000) \ 500
    End Function

    Public Function Foundcash100() As Double
        Return ((_Withdraw Mod 1000) Mod 500) \ 100
    End Function

End Class
