
Public Class NouveauCritereSurDate(Of T As IElementFiltrable)

#Region "Initialisation du nouveau critère"

    Private _GetValeurMethode As CritereSurValeur(Of T).GetValeurDelegate
    Public Function ValeurElementAPartirDe(getValeurMethode As CritereSurValeur(Of T).GetValeurDelegate) As NouveauCritereSurDate(Of T)
        _GetValeurMethode = getValeurMethode
        Return Me
    End Function

    Private Function Initialiser(critere As CritereSurValeur(Of T), valeur As Date) As CritereSurValeur(Of T)
        critere.SetArguments(valeur)
        critere.ValeurElementApartirDe(_GetValeurMethode)
        Return critere
    End Function

    Private Function Initialiser(critere As CritereSurValeur(Of T), valeurA As Date, valeurB As Date) As CritereSurValeur(Of T)
        critere.SetArguments(valeurA, valeurB)
        critere.ValeurElementApartirDe(_GetValeurMethode)
        Return critere
    End Function

#End Region

#Region "Critères"
    Public Function EgaleA(valeur As Date) As Critere(Of T)
        Dim c As New DateEgaleA(Of T)()
        Return Initialiser(c, valeur)
    End Function

    Public Function ComprisEntre(valeurA As Date, valeurB As Date) As Critere(Of T)
        Dim c As New DateComprisEntre(Of T)
        Return Initialiser(c, valeurA, valeurB)
    End Function

    Public Function InferieurOuEgaleA(valeur As Date) As Critere(Of T)
        Dim c As New DateInferieurOuEgaleA(Of T)
        Return Initialiser(c, valeur)
    End Function

    Public Function SuperieurOuEgaleA(valeur As Date) As Critere(Of T)
        Dim c As New DateSuperieurOuEgaleA(Of T)
        Return Initialiser(c, valeur)
    End Function

    Public Function StrictementInferieurA(valeur As Date) As Critere(Of T)
        Dim c As New DateStrictementInferieurA(Of T)
        Return Initialiser(c, valeur)
    End Function

    Public Function StrictementSuperieurA(valeur As Date) As Critere(Of T)
        Dim c As New DateStrictementSuperieurA(Of T)
        Return Initialiser(c, valeur)
    End Function

#End Region

End Class