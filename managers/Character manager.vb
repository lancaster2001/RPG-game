Module Character_manager
    'changes
    '
    'changes

    Function get_genders_list()
        Dim genders As String = file_reader("genders.txt")
        Dim genders_list() As String = genders.Split("�")
        Return genders_list
    End Function
    Function get_classes_name()
        Dim holder As String = file_reader("classes.txt")
        Dim classes() As String = holder.Split("�")
        Dim classes_names(classes.Length - 1) As String
        Dim class_data() As String

        For n = 0 To classes.Length - 1
            class_data = classes(n).Split(",")
            classes_names(n) = class_data(0).Remove(0, 6)
        Next


        Return classes_names
    End Function
    Function get_class_stats(ByRef character_class As String)

        Dim holder As String = file_reader("classes.txt")
        Dim classes() As String = holder.Split("�")
        Dim class_data() As String

        For n = 0 To classes.Length - 1
            class_data = classes(n).Split(",")
            If character_class = class_data(0).Remove(0, 6) Then
                Return class_data
            Else
                Return Nothing
            End If
        Next
    End Function
    Sub create_character_directories(ByVal user As user)
        My.Computer.FileSystem.CreateDirectory("Accounts\" & user.give_username & "\Characters\" & user.character.give_name)
    End Sub

    Function load_users_characters(ByVal user As String)
        Dim files() As String


        files = folder_reader("Accounts\" & user & "\Characters")
        Dim characters(files.Length) As character

        If files.Length <> 0 Then
            For n = 0 To files.Length - 1
                Dim characters_names() As String = files(n).Split("\")
                characters(n).load(user, characters_names(characters_names.Length - 1))
            Next
        End If
        Return characters
    End Function
End Module
