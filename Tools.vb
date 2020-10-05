Imports System.IO
Imports System.Threading
Module Tools
 Sub file_writer(ByRef file_name As String, ByRef text As String, Optional newline As Boolean = False, Optional file_type As String = ".txt", Optional append As Boolean = False)
        Dim file As StreamWriter


        file = New StreamWriter(file_name & file_type, append)

        file.Write(text)

        If newline = True Then
            file.Write(vbCrLf)
        End If

        file.Close()


    End Sub
    Function folder_reader(ByRef folder As String)
        Dim di As New IO.DirectoryInfo(folder)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo
        Dim files(diar1.Length) As String
        Dim count = 0
        Dim index As Integer = 0
        Dim value As String = ""
        For Each dra In diar1
            index = dra.ToString.LastIndexOf(".")
            value = dra.ToString.Remove(index, 4)
            files(count) = value
            count += 1
        Next
        Return files
    End Function
    Sub save_map(ByRef map_table(,) As String, ByRef height As Integer, ByRef width As Integer)
        Dim text As String = ""

        For n = 0 To height - 1
            For m = 0 To width - 1
                text += "[" & map_table(m, n) & "]"
            Next
            If n <> height - 1 Then
                text += vbCrLf
            End If

        Next
    End Sub
    Sub load_map()

    End Sub
    Public Function file_reader(ByRef file_name As String)
        Dim file As StreamReader
        Dim text As String

        file = New StreamReader(file_name)

        text = file.ReadToEnd


        file.Close()

        Return text

    End Function

    Public Function GetBetween(ByRef sSearch As String, ByRef sStart As String, ByRef sStop As String, Optional ByRef lSearch As Integer = 1) As String
        lSearch = InStr(lSearch, sSearch, sStart)
        If lSearch > 0 Then
            lSearch = lSearch + Len(sStart)
            Dim lTemp As Long
            lTemp = InStr(lSearch, sSearch, sStop)
            If lTemp > lSearch Then
                'GetBetween = Mid$(sSearch, lSearch, lTemp - lSearch)
            End If
        End If
    End Function
End Module
