Imports System.IO
Module map_manager
    Public Const max_map_width = 20
    Public Const max_map_height = 20
    Public map_table(max_map_width, max_map_height) As String
    Public ReadOnly restricted_areas() As String = {"wall"}
    Public spawn_point As Point

    Dim default_map As String = "maps\map_test.txt"
    Dim assets_names() As Object
    Dim assets_images() As Image



    Sub read_map2(ByRef map As String)
        Dim map_text As String = file_reader("maps\" & map)
        Dim map_lines() As String = map_text.Split(vbCr)
        Dim map_lines_temp() As String
        Dim slot() As String

        Dim map_height As Integer = map_lines.Length
        Dim map_width As Integer = 0

        For y = 0 To map_height - 1
            Try
                map_lines_temp = map_lines(y).Split("*")
                For it = 0 To map_lines_temp.Length - 1
                    map_lines_temp(it) = map_lines_temp(it).Trim(vbLf)
                    If map_width < map_lines_temp.Length Then
                        map_width = map_lines_temp.Length
                    End If
                    slot = map_lines_temp(it).Split(",")
                    If slot.Length > 1 Then
                        For a = 0 To slot.Length - 1
                            If slot(a) = "worldspawn" Then
                                spawn_point = New Point(it, y)
                            End If
                        Next
                    End If
                Next
            Catch ex As IndexOutOfRangeException
                map_lines_temp = Nothing
            End Try



            Try
                For m = 0 To map_lines_temp.Length - 1
                    Try
                        map_table(m, y) = map_lines_temp(m)
                    Catch ex As IndexOutOfRangeException
                        'map_table(m, y) = "blank"
                    End Try

                Next

            Catch ex As NullReferenceException

            End Try

        Next
        'ReDim Preserve map_table(0 To map_width - 1, 0 To map_height - 1)
    End Sub
    Sub read_map(ByRef map As String)
        Dim map_details As String = file_reader("maps\" & map & "\details.txt")
        Dim map_text As String = file_reader("maps\" & map & "\map.txt")
        Dim map_spawns As String = file_reader("maps\" & map & "\spawns.txt")
        Dim map_lines() As String = map_text.Split(vbCr)
        Dim map_lines_temp() As String
        Dim slot() As String

        Dim map_height As Integer = map_lines.Length
        Dim map_width As Integer = 0

        Dim details() As String = map_details.Split(",")
        For n = 0 To details.Length - 1
            If details(n).StartsWith("width:") Then
                map_width = details(n).Remove(0, 6)
            ElseIf details(n).StartsWith("width:") Then
                map_height = details(n).Remove(0, 7)
            End If
        Next

        ReDim map_table(map_width - 1, map_height - 1)

        For y = 0 To map_height - 1
            Try
                map_lines_temp = map_lines(y).Split("*")
                For it = 0 To map_lines_temp.Length - 1
                    map_lines_temp(it) = map_lines_temp(it).Trim(vbLf)
                    If map_width < map_lines_temp.Length Then
                        map_width = map_lines_temp.Length
                    End If
                    slot = map_lines_temp(it).Split(",")
                    If slot.Length > 1 Then
                        For a = 0 To slot.Length - 1
                            If slot(a) = "worldspawn" Then
                                spawn_point = New Point(it, y)
                            End If
                        Next
                    End If
                Next
            Catch ex As IndexOutOfRangeException
                map_lines_temp = Nothing
            End Try



            Try
                For m = 0 To map_lines_temp.Length - 1
                    Try
                        map_table(m, y) = map_lines_temp(m)
                    Catch ex As IndexOutOfRangeException
                        'map_table(m, y) = "blank"
                    End Try

                Next

            Catch ex As NullReferenceException

            End Try

        Next
        Dim checker As Boolean = False
        Dim slot_holder() As String
        For y = 0 To map_height - 1
            For x = 0 To map_width - 1
                If map_table Is Nothing = False Then
                    slot_holder = map_table(x, y).Split(",")
                    For n = 0 To slot_holder.Length - 1
                        checker = False
                        For m = 0 To assets_names.Length - 1
                            If assets_names(m) = slot_holder(n) Then
                                checker = True
                            End If
                        Next
                        If checker = True Then
                            If assets_names Is Nothing = False Then
                                ReDim Preserve assets_names(assets_names.Length)
                                assets_names(assets_names.Length - 1) = slot_holder(n)
                                ReDim Preserve assets_images(assets_images.Length)
                                assets_images(assets_images.Length - 1) = get_image(assets_names(assets_images.Length - 1))
                            Else
                                ReDim assets_names(0)
                                assets_names(0) = slot_holder(n)
                                ReDim assets_images(0)
                                assets_images(0) = get_image(slot_holder(n))
                            End If
                        End If
                    Next
                End If
            Next
        Next
        'ReDim Preserve map_table(0 To map_width - 1, 0 To map_height - 1)
    End Sub
    Function give_map_table()
        Return map_table
    End Function

End Module
