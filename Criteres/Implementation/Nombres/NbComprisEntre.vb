Public Class NbComprisEntre(Of T As IElementFiltrable)
    Inherits CritereSurValeur(Of T)


#Region "Variable de Classe"
    Private _BorneInferieur As Decimal
    Private _BorneSuperieur As Decimal
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
        If IsNothing(_GetElementValeur) Then Throw New NoNullAllowedException("Pour un critère de type compris entre, il faut spécifié la méthode GetValeur")
        Return EstValidePour(_GetElementValeur(element))
    End Function

    Private Function EstValidePour(valeurElement As Object) As Boolean
        Return CDec(valeurElement) >= _BorneInferieur AndAlso CDec(valeurElement) <= _BorneSuperieur
    End Function

#End Region

#Region "Arguments"

    Protected Overrides Sub SetValeursArguments(ParamArray args() As Object)
        _BorneInferieur = CDec(args(0))
        _BorneSuperieur = CDec(args(1))
    End Sub

    Protected Overrides Function IsArgumentsInvalid(ParamArray args() As Object) As Boolean
        _NbArguments = 2
        _ArgumentsInvalidExceptionMessage = "pour le critère NbComprisEntre il faut définir deux nombres non nulle comme argument"
        Return IsNothing(args) OrElse args.Count <> _NbArguments OrElse Not IsNumeric(args(0)) OrElse Not IsNumeric(args(1))
    End Function

#End Region

End Class
