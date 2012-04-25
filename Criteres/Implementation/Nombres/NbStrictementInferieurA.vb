﻿Public Class NbStrictementInferieurA(Of T As IElementFiltrable)
    Inherits CritereSurValeur(Of T)


#Region "Variable de Classe"
    Private _Valeur As Decimal
#End Region

#Region "Propriétés"
    Public Overrides ReadOnly Property SqlExpression As String
        Get
            Return " {0} < " & _Valeur.ToString & " "
        End Get
    End Property
#End Region

#Region "Prédicat"
    Public Overrides Function Accept(element As T) As Boolean
        If IsNothing(_GetElementValeur) Then Throw New NoNullAllowedException("Pour un critère de type strictement inférieur à, il faut spécifié la méthode GetValeur")
        Return EstValidePour(_GetElementValeur(element))
    End Function

    Private Function EstValidePour(valeurElement As Object) As Boolean
        Return CDec(valeurElement) < _Valeur
    End Function

#End Region

#Region "Arguments"

    Protected Overrides Sub InitValeurs(ParamArray args() As Object)
        _Valeur = CDec(args(0))
    End Sub

    Protected Overrides Function IsInvalidValeurs(ParamArray args() As Object) As Boolean
        _NbArguments = 1
        _ArgumentsInvalid = "pour le critère NbStrictementInferieurA il faut définir un nombre non nulle comme argument"
        Return IsNothing(args) OrElse args.Count <> _NbArguments OrElse Not IsNumeric(args(0))
    End Function

#End Region

End Class