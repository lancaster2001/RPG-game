Imports System.Xml.Schema

Module assets_manager
    Function get_image(name As String)
        Dim holder() As String = name.Split("_")
        Dim image As Image = Image.FromFile("Images\" & holder(0) & "\" & name & ".png")
        Return image
    End Function
End Module
