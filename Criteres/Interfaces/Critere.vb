Public MustInherit Class Critere(Of T As IElementFiltrable)
    Implements ICritere(Of T)

#Region "Propriétés"
    Public MustOverride ReadOnly Property SqlExpression As String Implements ICritere(Of T).SqlExpression
    'Public MustOverride Property Libelle As String
#End Region

#Region "Prédicat"
    Public MustOverride Function Accept(element As T) As Boolean Implements ICritere(Of T).Accept
#End Region

#Region "Arguments"
    ''' <summary>raison pour laquelle l'argument est invalide</summary>
    Protected _ArgumentsInvalidExceptionMessage As String = "Arguments invalides pour ce prédicat"
    Protected _NbArguments As Integer = 0

    ''' <summary>définit les valeurs sur lesquelles ce critère va tester</summary>
    Public Sub SetArguments(ByVal ParamArray args() As Object)
        If IsArgumentsInvalid(args) Then
            Throw New ArgumentException(_ArgumentsInvalidExceptionMessage)
        Else
            SetValeursArguments(args)
        End If
    End Sub

    ''' <summary>On vérifie si tout les arguments attendus ont été bien renseigner</summary>
    Protected Overridable Function IsArgumentsInvalid(ParamArray args As Object()) As Boolean
        Return False
    End Function

    ''' <summary>Définit les valeurs de ce critère</summary>
    Protected Overridable Sub SetValeursArguments(ByVal ParamArray args() As Object)

    End Sub

#End Region

#Region "Opérations"

    Public Function ET(critereB As ICritere(Of T)) As ICritere(Of T) Implements ICritere(Of T).ET
        Return New AndCritere(Me, critereB)
    End Function

    Public Function OU(critereB As ICritere(Of T)) As ICritere(Of T) Implements ICritere(Of T).OU
        Return New OrCritere(Me, critereB)
    End Function

    Public Function Non() As ICritere(Of T) Implements ICritere(Of T).Non
        Return New NotCritere(Me)
    End Function

#End Region

#Region "Opérateurs"
    Public Overloads Shared Operator And(critereA As Critere(Of T), critereB As Critere(Of T)) As Critere(Of T)
        Return New AndCritere(critereA, critereB)
    End Operator

    Public Overloads Shared Operator Or(critereA As Critere(Of T), critereB As Critere(Of T)) As Critere(Of T)
        Return New OrCritere(critereA, critereB)
    End Operator

    Public Overloads Shared Operator Not(critereA As Critere(Of T)) As Critere(Of T)
        Return New NotCritere(critereA)
    End Operator
#End Region


#Region "Classes Internes de liaison"

    Private Class AndCritere
        Inherits Critere(Of T)

#Region "Constructeur"
        Public Sub New(critereA As ICritere(Of T), critereB As ICritere(Of T))
            MyBase.New()
            _CritereA = critereA
            _CritereB = critereB
        End Sub
#End Region

#Region "Variables de class"
        Private _CritereA As ICritere(Of T)
        Private _CritereB As ICritere(Of T)
#End Region

#Region "Prédicat"
        Public Overrides Function Accept(element As T) As Boolean
            Return _CritereA.Accept(element) AndAlso _CritereB.Accept(element)
        End Function
#End Region

#Region "Propriétés"
        Public Overrides ReadOnly Property SqlExpression As String
            Get
                Return " ( " & _CritereA.SqlExpression & " AND " & _CritereB.SqlExpression & " ) "
            End Get
        End Property
#End Region

    End Class

    Private Class OrCritere
        Inherits Critere(Of T)

#Region "Constructeur"
        Public Sub New(critereA As ICritere(Of T), critereB As ICritere(Of T))
            MyBase.New()
            _CritereA = critereA
            _CritereB = critereB
        End Sub
#End Region

#Region "Variables de class"
        Private _CritereA As ICritere(Of T)
        Private _CritereB As ICritere(Of T)
#End Region

#Region "Prédicat"
        Public Overrides Function Accept(element As T) As Boolean
            Return _CritereA.Accept(element) OrElse _CritereB.Accept(element)
        End Function
#End Region

#Region "Propriétés"
        Public Overrides ReadOnly Property SqlExpression As String
            Get
                Return " ( " & _CritereA.SqlExpression & " OR " & _CritereB.SqlExpression & " ) "
            End Get
        End Property
#End Region

    End Class

    Private Class NotCritere
        Inherits Critere(Of T)

#Region "Constructeur"
        Public Sub New(critereDOrigine As ICritere(Of T))
            MyBase.New()
            _CritereDOrigine = critereDOrigine
        End Sub
#End Region

#Region "Variables de class"
        Private _CritereDOrigine As ICritere(Of T)
#End Region

#Region "Prédicat"
        Public Overrides Function Accept(element As T) As Boolean
            Return Not _CritereDOrigine.Accept(element)
        End Function
#End Region

#Region "Propriétés"
        Public Overrides ReadOnly Property SqlExpression As String
            Get
                Return " Not ( " & _CritereDOrigine.SqlExpression & " ) "
            End Get
        End Property
#End Region

    End Class

#End Region

End Class
