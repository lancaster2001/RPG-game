Public Class mob

    Dim name As String = "???"
    Dim level As Integer = 1
    Dim moves() As move

    Public on_screen_id As Integer = 0
    Public defeat As Boolean = False


    Dim sprite As Image = get_image("blank")

    Public location As Point = New Point(0, 0)

    Dim drops() As String = {"Gold:5-5", "Experience:5-5"}
    ReadOnly level_in_10s() As Integer = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
    ReadOnly experience_in_10s() As Integer = {100, 100, 100, 100, 100, 100, 100, 100, 100, 100}
    ReadOnly max_level As Integer = 100
    Dim current_health_percent As Double = 1

    Dim hp As Integer = 1
    Dim attack As Integer = 1
    Dim defence As Integer = 1
    Dim magic_attack As Integer = 1
    Dim magic_defence As Integer = 1
    Dim speed As Integer = 1

    Dim Base_Health_points As Integer = 1
    Dim Base_Attack As Integer = 1
    Dim Base_Magic_attack As Integer = 1
    Dim Base_Defence As Integer = 1
    Dim Base_Magic_defence As Integer = 1
    Dim Base_Speed As Integer = 1

    Dim Base_critical_chance As Decimal = 0
    Dim Base_critical_damage As Decimal = 0
    Dim Base_dodge_chance As Decimal = 0
    Dim Base_regeneration As Integer = 0
    Dim Base_experience_boost As Decimal = 0
    Dim Base_gold_boost As Decimal = 0

    Dim hidden_HP As Integer = 31
    Dim hidden_attack As Integer = 31
    Dim hidden_Defence As Integer = 31
    Dim hidden_magic_attack As Integer = 31
    Dim hidden_magic_defence As Integer = 31
    Dim hidden_speed As Integer = 31

    Dim effort_HP As Integer = 31
    Dim effort_attack As Integer = 31
    Dim effort_Defence As Integer = 31
    Dim effort_magic_attack As Integer = 31
    Dim effort_magic_defence As Integer = 31
    Dim effort_speed As Integer = 31

    Function give_current_health_percent()
        Return current_health_percent
    End Function
    Function give_hp()
        hp = ((((Base_Health_points * 2 + hidden_HP + (effort_HP / 4)) * level) / 100) + level + 10) \ 1
        Return hp
    End Function
    Function give_other_stat(ByRef stat As Integer, ByVal base_stat As Integer, ByVal hidden_stat As Integer, ByVal effort_stat As Integer)
        stat = ((((base_stat * 2 + hidden_stat + (effort_stat / 4)) * level) / 100) + 5) \ 1
        Return stat
    End Function
    Function give_attack()
        attack = give_other_stat(attack, Base_Attack, hidden_attack, effort_attack)
        Return attack
    End Function

    Function give_defence()
        defence = give_other_stat(defence, Base_Defence, hidden_Defence, effort_Defence)
        Return defence
    End Function
    Function give_magic_attack()
        magic_attack = give_other_stat(magic_attack, Base_Magic_attack, hidden_magic_attack, effort_magic_attack)
        Return magic_attack
    End Function
    Function give_magic_defence()
        magic_defence = give_other_stat(magic_defence, Base_Magic_defence, hidden_magic_defence, effort_magic_defence)
        Return magic_defence
    End Function
    Function give_speed()
        speed = give_other_stat(speed, Base_Speed, hidden_speed, effort_speed)
        Return speed
    End Function
    Sub defeated(player As character)
        defeat = True
        Dim rnd As Random = New Random
        Dim bounds() As String


        bounds = drops(1).Split("-")
        player.gold += rnd.Next(bounds(0), bounds(1))

        bounds = drops(0).Split("-")
        player.experience += rnd.Next(bounds(0), bounds(1))


    End Sub
    Sub ran()
        defeat = True
    End Sub

    Sub attacked2(a_attack As Integer, a_weapon_attack As Integer)
        Dim rnd As New Random
        Dim hold As Integer = (a_attack + a_weapon_attack + (rnd.Next(-(a_weapon_attack \ 10), a_weapon_attack \ 10) - defence))
        If hold <= 0 Then
            hold = 1
        End If
        hp -= hold
    End Sub
    Sub attacked(damage As Integer)
        current_health_percent -= damage / give_hp()
    End Sub
    Sub load(mob As String, lvl As Integer, loc As Point)
        Dim holder As String
        Dim details() As String
        location = loc
        name = mob
        level = lvl
        sprite = Image.FromFile("Images\" & name & ".png")
        holder = file_reader("Mobs\" & name & ".txt")
        details = holder.Split("�")
        ReDim drops(details.Length - 5)
        For n = 0 To details.Length - 1
            If details(n).StartsWith("Experience:") = True Then
                drops(0) = details(n).Remove(0, 11)
            ElseIf details(n).StartsWith("Gold:") = True Then
                drops(1) = details(n).Remove(0, 5)
            ElseIf details(n).StartsWith("Healthpoints:") = True Then
                Base_Health_points = details(n).Remove(0, 13)
            ElseIf details(n).StartsWith("Attack:") = True Then
                Base_Attack = details(n).Remove(0, 7)
            ElseIf details(n).StartsWith("Magicattack:") = True Then
                Base_Magic_attack = details(n).Remove(0, 12)
            ElseIf details(n).StartsWith("Defence:") = True Then
                Base_Defence = details(n).Remove(0, 8)
            ElseIf details(n).StartsWith("Magicdefence:") = True Then
                Base_Magic_defence = details(n).Remove(0, 13)
            ElseIf details(n).StartsWith("Speed:") = True Then
                Base_Speed = details(n).Remove(0, 6)
            ElseIf details(n).StartsWith("Moves:") Then
                Dim moves_holder() As String = details(n).Split(".")
                moves_holder(0) = moves_holder(0).Remove(0, 6)
                For m = 0 To moves_holder.Length - 1
                    ReDim Preserve moves(m)
                    moves(m) = New move
                    moves(m).load(moves_holder(m))
                Next
            Else
                Dim next_space As Integer
                For m = 1 To drops.Length - 1
                    If drops(m) Is Nothing Then
                        next_space = m
                        Exit For
                    End If
                Next
            End If
        Next

    End Sub
    Function give_name()
        Return name
    End Function
    Function give_sprite()
        Return sprite
    End Function
    Function give_level()
        Return level
    End Function
    Function give_moves()
        Return moves
    End Function
    Function select_move()
        Dim selected_move As Integer
        Dim rnd As New Random
        selected_move = rnd.Next(0, moves.Length - 1)
        Return selected_move
    End Function
End Class
