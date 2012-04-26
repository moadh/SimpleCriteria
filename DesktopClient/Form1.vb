Imports Criteres

Public Class Form1
    Public Sub TestFiltres()
        Dim lstCRs As New List(Of CR)
        lstCRs.Add(CreateCR("AZ", 1))
        lstCRs.Add(CreateCR("AZ", 2))
        lstCRs.Add(CreateCR("BZ", 3))
        lstCRs.Add(CreateCR("CZ", 4))
        lstCRs.Add(CreateCR("CD", 5))

        Dim filtre As New FiltreProcessor(Of CR)()


        Dim c1 As Critere(Of CR) = _
            NouveauCritere(Of CR) _
                    .SurChaine _
                    .ValeurElementAPartirDe(Function(a As CR) (a._AMs(1).ValueA)) _
                    .Contient("Z")

        Dim c4 As Critere(Of CR) = _
           NouveauCritere(Of CR) _
                   .Generiques _
                   .ValeurElementAPartirDe(Function(a As CR) (a._AMs(2).ValueB)) _
                   .DifferentDeNull()

        Dim c3 As Critere(Of CR) = _
           NouveauCritere(Of CR) _
                   .SurNombre _
                   .ValeurElementAPartirDe(Function(a As CR) (a._AMs(3).ValueB)) _
                   .ComprisEntre(4, 7)



        Dim c2 As New NbStrictementSuperieurA(Of CR)
        c2.SetArguments(5)
        c2.ValeurElementApartirDe(Function(a As CR) (a._AMs(3).ValueB))



        filtre._ListElementsFiltrable.AddRange(lstCRs)
        filtre._ListCriteres.Add(c1 And (Not c2))

        Dim resultat As List(Of CR) = filtre.Run()
        MessageBox.Show("Nb de résultat filtré :" & resultat.Count.ToString)
    End Sub


    Private Function CreateCR(valeurA As String, valeurB As Integer) As CR
        Return New CR().AjouteAM(CreateNewAM(valeurA, valeurB)) _
                        .AjouteAM(CreateNewAM(valeurA, valeurB + 1)) _
                        .AjouteAM(CreateNewAM(valeurA, valeurB + 2)) _
                        .AjouteAM(CreateNewAM(valeurA, valeurB + 3)) _
                        .AjouteAM(CreateNewAM(valeurA, valeurB + 4)) _
                        .AjouteAM(CreateNewAM(valeurA, valeurB + 5))
    End Function

    Private Function CreateNewAM(valeurA As String, valeurB As Integer) As AM
        Return New AM() With {.ValueA = valeurA, .ValueB = valeurB}
    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TestFiltres()
    End Sub
End Class
