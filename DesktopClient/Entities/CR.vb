Imports Criteres
Public Class CR
    Implements IElementFiltrable

    Public _AMs As New List(Of AM)
    Public Function AjouteAM(am As AM) As CR
        _AMs.Add(am)
        Return Me
    End Function
End Class
