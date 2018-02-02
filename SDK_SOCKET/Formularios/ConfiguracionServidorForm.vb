Imports System.IO
Public Class ConfiguracionServidorForm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'BOTON ACEPTAR'
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Un campo se encuentra vacio")
        Else
            DireccionIP = TextBox1.Text.Trim() 'DIRECCIÓN IP DEL SERVIDOR.'
            Puerto = TextBox2.Text.Trim() 'PUERTO DEL SERVIDOR'
            MsgBox("Configuración Guardada.")
            ConfiguraciónCompleta = True 'CONFIGURACIÓN DE PUERTO Y DIRECCIÓN IP REALIZADA
            Me.Close() 'CIERRE DE FORMULARIO.''
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' BOTON DE BORRAR CONFIGURACIÓN.'
        File.Delete("C:\TeknoCom\Socket\ConfiguracionSocket.txt")
        MsgBox("La aplicación se reiniciará.")
        Application.Restart()
    End Sub

    Private Sub ConfiguracionServidorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DecryptFile(DirectorioArchivoConfiguracion, Key)
        Dim datos() As String 'ARREGLO PARA ALMACENAR LOS DATOS 
        Dim Path As String = DirectorioArchivoConfiguracion  'UBICACIÓN DEL ARCHIVO.'
        Dim apuntadorArchivo As New StreamReader(Path, System.Text.Encoding.Default, False) 'APUNTADOR AL ARCHIVO.'
        Dim lineaTexto As String = "" 'VARIABLE PARA ALMACENAR LA LINEA DE TEXTO QUE SE LEA DEL ARCHIVO.'
        lineaTexto = apuntadorArchivo.ReadLine 'SE LEE LA PRIMERA LINEA DEL ARCHIVO.'
        datos = Split(lineaTexto.Trim(), "¬")

        LabelInstancia.Text = datos(0).Trim().Substring(0, datos(0).Length - 1)
        LabelBaseDatos.Text = datos(1).Trim().Substring(0, datos(1).Length - 1)
        LabelTabla.Text = datos(2).Trim().Substring(0, datos(2).Length - 1)
        LabelUsuario.Text = datos(3).Trim().Substring(0, datos(3).Length - 1)
        LabelPassword.Text = datos(4).Trim().Substring(0, datos(4).Length - 1)
        apuntadorArchivo.Close()
        EncryptFile(DirectorioArchivoConfiguracion, Key)
    End Sub
End Class