
Public Class NouveauCritereSurChaine(Of T As IElementFiltrable)

#Region "Initialisation du nouveau critère"

    Private _GetValeurMethode As CritereSurValeur(Of T).GetValeurDelegate
    Public Function ValeurElementAPartirDe(getValeurMethode As CritereSurValeur(Of T).GetValeurDelegate) As NouveauCritereSurChaine(Of T)
        _GetValeurMethode = getValeurMethode
        Return Me
    End Function

    Private Function Initialiser(critere As CritereSurValeur(Of T), valeur As String) As CritereSurValeur(Of T)
        critere.SetArguments(valeur)
        critere.ValeurElementApartirDe(_GetValeurMethode)
        Return critere
    End Function

#End Region

#Region "Critères"
    Public Function EgaleA(valeur As String) As Critere(Of T)
        Dim c As New ChaineEgaleA(Of T)()
        Return Initialiser(c, valeur)
    End Function

    Public Function CommencePar(valeur As String) As Critere(Of T)
        Dim c As New ChaineCommencePar(Of T)
        Return Initialiser(c, valeur)
    End Function

    Public Function Contient(valeur As String) As Critere(Of T)
        Dim c As New ChaineContient(Of T)
        Return Initialiser(c, valeur)
    End Function

    Public Function FinitPar(valeur As String) As Critere(Of T)
        Dim c As New ChaineFinitPar(Of T)
        Return Initialiser(c, valeur)
    End Function
#End Region


End Class
