Imports System.IO
Imports System.Text
Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Visible = False
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Datos.txt") = False Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Datos.txt", "", False)
        End If
    End Sub

    Private Sub TxtTexto_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTexto.KeyDown
        If TxtTexto.Text <> "" Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                RichTextBox1.SelectionColor = Color.BlueViolet
                RichTextBox1.AppendText("Pos Yo: " & TxtTexto.Text & vbCrLf)
                RESPUESTAS(TxtTexto.Text)
                RichTextBox1.ScrollToCaret()
                TxtTexto.Clear()
            End If
        End If
    End Sub

    Public Sub RESPUESTAS(ByVal CLAVE As String)
        Try
            If CLAVE.ToLower.Contains("Quien eres") Then
                RichTextBox1.SelectionColor = Color.OrangeRed
                RichTextBox1.AppendText("Dex: " & "Pues SOY UN PROGRAMA NO" & vbCrLf)
                RichTextBox1.ScrollToCaret()
            ElseIf CLAVE.ToLower.Contains("Vamos A Jugar XD") Then
                RichTextBox1.SelectionColor = Color.OrangeRed
                RichTextBox1.AppendText("Dex: " & "Que Soy Un PROGRAMA XD" & vbCrLf)
                RichTextBox1.ScrollToCaret()

            Else
                Dim ENCONTRADO As Boolean = False
                Dim BASE As String = Application.StartupPath & "\Datos.txt"
                For Each LINEA In File.ReadLines(BASE, Encoding.UTF8)
                    Dim DATOS As String() = LINEA.Split(":")
                    If CLAVE.ToLower.Contains(DATOS(0)) Then
                        RichTextBox1.SelectionColor = Color.OrangeRed
                        RichTextBox1.AppendText("Dex: " & DATOS(1) & vbCrLf)
                        RichTextBox1.ScrollToCaret()
                        ENCONTRADO = True
                    End If
                Next
                If ENCONTRADO = False Then
                    RichTextBox1.SelectionColor = Color.OrangeRed
                    RichTextBox1.AppendText(("Dex: " & vbCrLf))
                    RichTextBox1.ScrollToCaret()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If TxtClave.Text <> "" And TxtRes.Text <> "" Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\DATOS.txt", TxtClave.Text.ToLower & ":" & TxtRes.Text & vbCrLf, True)
            MsgBox("Guardado", MsgBoxStyle.Information, "Guardado")
            TxtClave.Clear()
            TxtRes.Clear()
        Else
            TxtClave.Text = Nothing
            TxtRes.Text = Nothing
            MsgBox("Metele Texto Mi May", MsgBoxStyle.Information, "Sin Guardar")
        End If
    End Sub
End Class