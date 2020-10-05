'changes
'
'changes
Public Class main_form
    Public state As String = "main menu"

    Public user As New user




    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        If state = main_menu_module.state_name Then
            main_menu_module.set_menu(PictureBox1, e.Graphics)
        ElseIf state = Login_module.state_name Then
            Login_module.set_menu(PictureBox1, e.Graphics)
        ElseIf state = user_menu_module.state_name Then
            user_menu_module.set_menu(PictureBox1, e.Graphics)
        ElseIf state = game_module.state_name Then
            game_module.set_menu(PictureBox1, e.Graphics)
        ElseIf state = Character_creator.state_name Then
            Character_creator.set_menu(PictureBox1, e.Graphics)
        ElseIf state = Combat_module.state_name Then
            Combat_module.set_menu(PictureBox1, e.Graphics)
        ElseIf state = in_game_menu.state_name Then
            in_game_menu.set_menu(PictureBox1, e.Graphics)
        ElseIf state = profile_menu.state_name Then
            profile_menu.set_menu(PictureBox1, e.Graphics)
        End If



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Sub main_form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim key As String = e.KeyCode.ToString.ToUpper
        ' If e.KeyCode = Keys.Escape Then
        'If state = game_module.state_name Then
        '  ElseIf state = in_game_menu.state_name Then
        '  Else
        '      Me.Close()
        '  End If
        '  End If
        Try
            If state = main_menu_module.state_name Then
                main_menu_module.key_pressed(key)
            ElseIf state = Login_module.state_name Then
                Login_module.key_pressed(key)
            ElseIf state = user_menu_module.state_name Then
                user_menu_module.key_pressed(key)
            ElseIf state = game_module.state_name Then
                game_module.key_pressed(key)
            ElseIf state = user_menu_module.state_name Then
                user_menu_module.key_pressed(key)
            ElseIf state = Character_creator.state_name Then
                Character_creator.key_pressed(key)
            ElseIf state = Combat_module.state_name Then
                Combat_module.key_pressed(key)
            ElseIf state = in_game_menu.state_name Then
                in_game_menu.key_pressed(key)
            ElseIf state = profile_menu.state_name Then
                profile_menu.key_pressed(key)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub main_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Width = Me.width
        PictureBox1.Height = Me.height

        main_menu_module.Main_menu_load()
    End Sub




    Private Sub Refresh_rate_Tick(sender As Object, e As EventArgs) Handles Refresh_rate.Tick
        PictureBox1.Refresh()
    End Sub

    Private Sub spawner_Tick(sender As Object, e As EventArgs) Handles spawner.Tick
        If state = game_module.state_name Then
            game_module.spawn_mob()
        End If
    End Sub
End Class