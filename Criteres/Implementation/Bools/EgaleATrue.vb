Public Class EgaleATrue(Of T As IElementFiltrable)
    Inherits CritereSurValeur(Of T)

#Region "Propriétés"
    Public Overrides ReadOnly Property SqlExpression As String
        Get
            Return " {0} = 1 "
        End Get
    End Property
#End Region

#Region "Prédicat"
    Public Overrides Function Accept(element As T) As Boolean
        If IsNothing(_GetElementValeur) Then Throw New NoNullAllowedException("Pour un critère sur booléen il faut spécifié la méthode GetValeur")
        Return EstValidePour(_GetElementValeur(element))
    End Function

    Private Function EstValidePour(valeurElement As Object) As Boolean
        Return CBool(valeurElement) = False
    End Function
#End Region

End Class
