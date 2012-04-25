
Public Class FiltreProcessor(Of T As IElementFiltrable)
    Public _ListCriteres As New List(Of ICritere(Of T))
    Public _ListElementsFiltrable As New List(Of T)

    ''' <summary>revois la liste des éléments tel que tout les critères sont valide</summary>
    Public Function Run() As List(Of T)
        Return _ListElementsFiltrable.FindAll(AddressOf CriteresValides)
    End Function

    Private Function CriteresValides(elem As T) As Boolean
        Return _ListCriteres.TrueForAll(Function(c As ICritere(Of T)) c.Accept(elem))
    End Function

End Class
