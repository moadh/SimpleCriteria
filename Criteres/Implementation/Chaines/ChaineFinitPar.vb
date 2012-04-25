Public Class ChaineFinitPar(Of T As IElementFiltrable)
    Inherits CritereSurValeur(Of T)


#Region "Variable de Classe"
    Private _Valeur As String
#End Region

#Region "Propriétés"
    Public Overrides ReadOnly Property SqlExpression As String
        Get
            Return " {0} Like '%" & ChainePourSql(_Valeur) & "' "
        End Get
    End Property
#End Region

#Region "Prédicat"
    Public Overrides Function Accept(element As T) As Boolean
        If IsNothing(_GetElementValeur) Then Throw New NoNullAllowedException("Pour un critère sur valeur il faut spécifié la méthode GetValeur")
        Return EstValidePour(_GetElementValeur(element))
    End Function

    Private Function EstValidePour(valeurElement As Object) As Boolean
        Return valeurElement.ToString.ToLower.EndsWith(_Valeur.ToLower)
    End Function
#End Region

#Region "Conversion"
    Private Function ChainePourSql(valeurChaine As String) As String
        Return valeurChaine.Replace("'", "''")
    End Function
#End Region

#Region "Arguments"

    Protected Overrides Sub InitValeurs(ParamArray args() As Object)
        _Valeur = CStr(args(0))
    End Sub

    Protected Overrides Function IsInvalidValeurs(ParamArray args() As Object) As Boolean
        _NbArguments = 1
        _ArgumentsInvalid = "pour le critère ChaineFinitPar il faut définir une chaine non nulle comme argument"
        Return IsNothing(args) OrElse args.Count <> _NbArguments OrElse String.IsNullOrEmpty(CStr(args(0)))
    End Function

#End Region
End Class
