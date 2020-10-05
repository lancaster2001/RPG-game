Module Quest_manager

    Function read_quest_type(ByVal quest_details As String)
        Dim type() As String = quest_details.Split("¦")
        Return type(0)
    End Function

    Function read_kill_quest(ByVal quest_details As String)
        Dim quest() As String = quest_details.Split("¦")
        If quest(0) = "kill" Then

        End If
    End Function
End Module
