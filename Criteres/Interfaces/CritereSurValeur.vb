''' <summary>Un critère qui récupère la valeur de l'élément à vérifier à l'aide d'une fonction déléguée</summary>
''' <typeparam name="T">Le type de l'élément à vérifier</typeparam>
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



End Class
