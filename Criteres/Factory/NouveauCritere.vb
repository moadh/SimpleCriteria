Public Class NouveauCritere(Of T As IElementFiltrable)

#Region "types des critères"

    Public Shared Function SurChaine() As NouveauCritereSurChaine(Of T)
        Return New NouveauCritereSurChaine(Of T)()
    End Function

    Public Shared Function SurNombre() As NouveauCritereSurNombre(Of T)
        Return New NouveauCritereSurNombre(Of T)()
    End Function

    Public Shared Function SurDate() As NouveauCritereSurDate(Of T)
        Return New NouveauCritereSurDate(Of T)()
    End Function

    Public Shared Function SurBools() As NouveauCritereSurBools(Of T)
        Return New NouveauCritereSurBools(Of T)()
    End Function

    Public Shared Function Generiques() As NouveauCritereGenerique(Of T)
        Return New NouveauCritereGenerique(Of T)()
    End Function

#End Region


End Class
