Public Class ChaineEgaleA(Of T As IElementFiltrable)
    Inherits CritereSurValeur(Of T)


#Region "Variable de Classe"
    Private _Valeur As String
#End Region

#Region "Propriétés"
    Public Overrides ReadOnly Property SqlExpression As String
        Get
            Return " {0} = '" & ChainePourSql(_Valeur) & "' "
        End Get
    End Property
#End Region

#Region "Prédicat"
    Public Overrides Function Accept(element As T) As Boolean
        If IsNothing(_GetElementValeur) Then Throw New NoNullAllowedException("Pour un critère sur valeur il faut spécifié la méthode GetValeur")
        Return EstValidePour(_GetElementValeur(element))
    End Function

    Private Function EstValidePour(valeurElement As Object) As Boolean
        Return valeurElement.ToString.ToLower = _Valeur.ToLower
    End Function
#End Region

#Region "Conversion"
    Private Function ChainePourSql(valeurChaine As String) As String
        Return valeurChaine.Replace("'", "''")
    End Function
#End Region

#Region "Arguments"

    Protected Overrides Sub SetValeursArguments(ParamArray args() As Object)
        _Valeur = CStr(args(0))
    End Sub

    Protected Overrides Function IsArgumentsInvalid(ParamArray args() As Object) As Boolean
        _NbArguments = 1
        _ArgumentsInvalidExceptionMessage = "pour le critère ChaineEgaleA il faut définir une chaine non nulle comme argument"
        Return IsNothing(args) OrElse args.Count <> _NbArguments
    End Function

#End Region

End Class
