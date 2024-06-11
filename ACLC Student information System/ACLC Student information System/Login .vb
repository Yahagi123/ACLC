Imports MySql.Data.MySqlClient
Public Class L
    Dim Connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=admin_db")

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Password.UseSystemPasswordChar Then
            Password.UseSystemPasswordChar = False
        Else
            Password.UseSystemPasswordChar = True

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New MySqlCommand("SELECT * FROM `admin` WHERE `username` = @user  AND `Password` = @pass", Connection)

        command.Parameters.Add("@user", MySqlDbType.VarChar).Value = TextBox1.Text
        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password.Text


        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count Then
            Dim fmain As New Dashboard()
            fmain.Show()
            Me.Close()
        Else
            MessageBox.Show("User or Password Invalid")

        End If
    End Sub


End Class