Public Class DateComprisEntre(Of T As IElementFiltrable)
    Inherits CritereSurValeur(Of T)


#Region "Variable de Classe"
    Private _BorneInferieur As Date
    Private _BorneSuperieur As Date
#End Region

#Region "Propriétés"
    Public Overrides ReadOnly Property SqlExpression As String
        Get
            Return " {0} BETWEEN " & _BorneInferieur.ToString & " AND " & _BorneSuperieur.ToString & " "
        End Get
    End Property
#End Region

#Region "Prédicat"
    Public Overrides Function Accept(element As T) As Boolean
        If IsNothing(_GetElementValeur) Then Throw New NoNullAllowedException("Pour un critère sur valeur il faut spécifié la méthode GetValeur")
        Return EstValidePour(_GetElementValeur(element))
    End Function

    Private Function EstValidePour(valeurElement As Object) As Boolean
        Return CDate(valeurElement) >= _BorneInferieur AndAlso CDate(valeurElement) <= _BorneSuperieur
    End Function
#End Region

#Region "Conversion"
    Private Function DatePourSql(valeurDate As Date) As Object
        Return " '" & valeurDate.ToShortDateString() & "' "
    End Function
#End Region

#Region "Arguments"

    Protected Overrides Sub SetValeursArguments(ParamArray args() As Object)
        _BorneInferieur = CDate(args(0))
        _BorneSuperieur = CDate(args(1))
    End Sub

    Protected Overrides Function IsArgumentsInvalid(ParamArray args() As Object) As Boolean
        _NbArguments = 2
        _ArgumentsInvalidExceptionMessage = "pour le critère DateComprisEntre il faut définir deux dates non nulle comme argument"
        Return IsNothing(args) OrElse args.Count <> _NbArguments OrElse Not IsDate(CStr(args(0))) OrElse Not IsDate(CStr(args(1)))
    End Function

#End Region

End Class