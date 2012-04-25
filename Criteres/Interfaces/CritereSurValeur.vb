Public MustInherit Class CritereSurValeur(Of T As IElementFiltrable)
    Inherits Critere(Of T)

#Region "Définition de type"
    Delegate Function GetValeurDelegate(element As T) As Object
#End Region

#Region "Variable de Classe"
    Protected _GetElementValeur As GetValeurDelegate
#End Region

#Region "Dépendance"
    Public Sub ValeurElementApartirDe(getValeurMethode As GetValeurDelegate)
        _GetElementValeur = getValeurMethode
    End Sub
#End Region

#Region "Arguments"
    ''' <summary>raison pour laquelle l'argument est invalide</summary>
    Protected _ArgumentsInvalid As String = "Arguments invalides pour ce prédicat"
    Protected _NbArguments As Integer = 0

    ''' <summary>définit les valeurs sur lesquelles ce critère va tester</summary>
    Public Sub SetValeurCondition(ByVal ParamArray args() As Object)
        If IsInvalidValeurs(args) Then Throw New ArgumentException(_ArgumentsInvalid)
        InitValeurs(args)
    End Sub

    ''' <summary>On vérifie si tout les arguments attendus ont été bien renseigner</summary>
    Protected Overridable Function IsInvalidValeurs(ParamArray args As Object()) As Boolean
        Return False
    End Function

    ''' <summary>Définit les valeurs de ce critère</summary>
    Protected Overridable Sub InitValeurs(ByVal ParamArray args() As Object)

    End Sub

#End Region

End Class
