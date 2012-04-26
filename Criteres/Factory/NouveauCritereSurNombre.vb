
Public Class NouveauCritereSurNombre(Of T As IElementFiltrable)

#Region "Initialisation du nouveau critère"

    Private _GetValeurMethode As CritereSurValeur(Of T).GetValeurDelegate
    Public Function ValeurElementAPartirDe(getValeurMethode As CritereSurValeur(Of T).GetValeurDelegate) As NouveauCritereSurNombre(Of T)
        _GetValeurMethode = getValeurMethode
        Return Me
    End Function

    Private Function Initialiser(critere As CritereSurValeur(Of T), valeur As Decimal) As CritereSurValeur(Of T)
        critere.SetArguments(valeur)
        critere.ValeurElementApartirDe(_GetValeurMethode)
        Return critere
    End Function

    Private Function Initialiser(critere As CritereSurValeur(Of T), valeurA As Decimal, valeurB As Decimal) As CritereSurValeur(Of T)
        critere.SetArguments(valeurA, valeurB)
        critere.ValeurElementApartirDe(_GetValeurMethode)
        Return critere
    End Function
#End Region

#Region "Critères"
    Public Function EgaleA(valeur As Decimal) As Critere(Of T)
        Dim c As New NbEgaleA(Of T)()
        Return Initialiser(c, valeur)
    End Function

    Public Function ComprisEntre(valeurA As Decimal, valeurB As Decimal) As Critere(Of T)
        Dim c As New NbComprisEntre(Of T)
        Return Initialiser(c, valeurA, valeurB)
    End Function

    Public Function InferieurOuEgaleA(valeur As Decimal) As Critere(Of T)
        Dim c As New NbInferieurOuEgaleA(Of T)
        Return Initialiser(c, valeur)
    End Function

    Public Function SuperieurOuEgaleA(valeur As Decimal) As Critere(Of T)
        Dim c As New NbSuperieurOuEgaleA(Of T)
        Return Initialiser(c, valeur)
    End Function

    Public Function StrictementInferieurA(valeur As Decimal) As Critere(Of T)
        Dim c As New NbStrictementInferieurA(Of T)
        Return Initialiser(c, valeur)
    End Function

    Public Function StrictementSuperieurA(valeur As Decimal) As Critere(Of T)
        Dim c As New NbStrictementSuperieurA(Of T)
        Return Initialiser(c, valeur)
    End Function

#End Region


End Class