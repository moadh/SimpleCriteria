Public Class DateStrictementSuperieurA(Of T As IElementFiltrable)
    Inherits CritereSurValeur(Of T)

#Region "Variable de Classe"
    Private _Valeur As Date
#End Region

#Region "Propriétés"
    Public Overrides ReadOnly Property SqlExpression As String
        Get
            Return " {0} > " & DatePourSql(_Valeur) & " "
        End Get
    End Property
#End Region

#Region "Prédicat"
    Public Overrides Function Accept(element As T) As Boolean
        If IsNothing(_GetElementValeur) Then Throw New NoNullAllowedException("Pour un critère sur valeur il faut spécifié la méthode GetValeur")
        Return EstValidePour(_GetElementValeur(element))
    End Function

    Private Function EstValidePour(valeurElement As Object) As Boolean
        Return CDate(valeurElement) > _Valeur
    End Function
#End Region

#Region "Conversion"
    Private Function DatePourSql(valeurDate As Date) As String
        Return " '" & valeurDate.ToShortDateString() & "' "
    End Function
#End Region

#Region "Arguments"

    Protected Overrides Sub SetValeursArguments(ParamArray args() As Object)
        _Valeur = CDate(args(0))
    End Sub

    Protected Overrides Function IsArgumentsInvalid(ParamArray args() As Object) As Boolean
        _NbArguments = 1
        _ArgumentsInvalidExceptionMessage = "pour le critère DateStrictementSuperieurA il faut définir une date non nulle comme argument"
        Return IsNothing(args) OrElse args.Count <> _NbArguments OrElse Not IsDate(CStr(args(0)))
    End Function

#End Region

End Class