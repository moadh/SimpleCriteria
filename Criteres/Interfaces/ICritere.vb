Public Interface ICritere(Of T As IElementFiltrable)
    Function Accept(element As T) As Boolean
    ReadOnly Property SqlExpression As String
    Function ET(critereB As ICritere(Of T)) As ICritere(Of T)
    Function OU(critereB As ICritere(Of T)) As ICritere(Of T)
    Function Non() As ICritere(Of T)
End Interface