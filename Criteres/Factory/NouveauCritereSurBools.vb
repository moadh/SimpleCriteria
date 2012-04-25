
Public Class NouveauCritereSurBools(Of T As IElementFiltrable)

#Region "Initialisation du nouveau critère"

    Private _GetValeurMethode As CritereSurValeur(Of T).GetValeurDelegate
    Public Function ValeurElementAPartirDe(getValeurMethode As CritereSurValeur(Of T).GetValeurDelegate) As NouveauCritereSurBools(Of T)
        _GetValeurMethode = getValeurMethode
        Return Me
    End Function

    Private Function Initialiser(critere As CritereSurValeur(Of T)) As CritereSurValeur(Of T)
        critere.ValeurElementApartirDe(_GetValeurMethode)
        Return critere
    End Function

#End Region

#Region "Critères"

    Public Function EgaleATrue() As Critere(Of T)
        Dim c As New EgaleATrue(Of T)()
        Return Initialiser(c)
    End Function

    Public Function EgaleAFalse() As Critere(Of T)
        Dim c As New EgaleATrue(Of T)
        Return Not Initialiser(c)
    End Function

#End Region


End Class