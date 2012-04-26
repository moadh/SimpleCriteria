Public Class NbInferieurOuEgaleA(Of T As IElementFiltrable)
    Inherits CritereSurValeur(Of T)

#Region "Variable de Classe"
    Private _Valeur As Decimal
#End Region

#Region "Propriétés"
    Public Overrides ReadOnly Property SqlExpression As String
        Get
            Return " {0} <= " & _Valeur.ToString & " "
        End Get
    End Property
#End Region

#Region "Prédicat"
    Public Overrides Function Accept(element As T) As Boolean
        If IsNothing(_GetElementValeur) Then Throw New NoNullAllowedException("Pour un critère de type inférieur à, il faut spécifié la méthode GetValeur")
        Return EstValidePour(_GetElementValeur(element))
    End Function

    Private Function EstValidePour(valeurElement As Object) As Boolean
        Return CDec(valeurElement) <= _Valeur
    End Function

#End Region

#Region "Arguments"

    Protected Overrides Sub SetValeursArguments(ParamArray args() As Object)
        _Valeur = CDec(args(0))
    End Sub

    Protected Overrides Function IsArgumentsInvalid(ParamArray args() As Object) As Boolean
        _NbArguments = 1
        _ArgumentsInvalidExceptionMessage = "pour le critère NbInferieurA il faut définir un nombre non nulle comme argument"
        Return IsNothing(args) OrElse args.Count <> _NbArguments OrElse Not IsNumeric(args(0))
    End Function

#End Region


End Class