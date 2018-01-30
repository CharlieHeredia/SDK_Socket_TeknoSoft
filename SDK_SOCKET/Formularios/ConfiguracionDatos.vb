Imports System.Data.Sql
Imports System.IO
Public Class ConfiguracionDatos

    Private Sub ButtonAceptar_Click(sender As Object, e As EventArgs) Handles ButtonAceptar.Click
        If TextBoxBaseDatos.Text = "" Or TextBoxContraseña.Text = "" Or TextBoxTabla.Text = "" Or TextBoxUsuario.Text = "" Then ' VERIFICACIÓN DE TODOS LOS DATOS REQUERIDOS SE ENCUENTREN COMPLETOS.'
            MsgBox("Algun campo se encuentra vacio.") 'MENSAJE DE CAMPO VACIO.'
        Else
            Dim Texto() As String = {ComboBox1.SelectedItem.ToString.Trim() & "¬" & TextBoxBaseDatos.Text.Trim() & "¬" & TextBoxTabla.Text.Trim() & "¬" & TextBoxUsuario.Text.Trim() & "¬" & TextBoxContraseña.Text.Trim()}

            File.WriteAllLines("C:\TeknoCom\Socket\ConfiguracionSocket.txt", Texto) ' ESCRIBIR LA INFORMACIÓN AL ARCHIVO DE CONFIGURACIÓN.'
            ConfiguracionDatosCompleta = True ' 
            Me.Close() 'CERRAR EL FORMULARIO.'
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim instan As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance ' DECLARACIÓN DE VARIABLE. UTILIZADA PARA OBTENER LAS INSTANCIAS EN RED.''
        Dim talablainsta = New DataTable() ' NUEVA INSTANCIA DE UNA TABLA.'
        talablainsta = instan.GetDataSources() ' OBTIENE LA INFORMACIÓN DE LAS INSTANCIAS EN LA RED.'
        For Each row As DataRow In talablainsta.Rows
            ComboBox1.Items.Add(row.Item(0) & "\" & row.Item(1)) 'NOMBRE DEL EQUIPO \ NOMBRE DE INSTANCIA'
        Next
    End Sub

    Private Sub ConfiguracionDatos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If ConfiguracionDatosCompleta = False Then 'VERIFICACIÓN DE QUE EXISTE LA CONFIGURACIÓN DE DATOS PARA REALIZAR LA CONEXIÓN CON SQL.'
                MsgBox("No se ha realizado la configuración de la conexión, se le volverá a preguntar en el proximo inicio.")
                File.Delete("C:\TeknoCom\Socket\ConfiguracionSocket.txt") ' BORRADO DEL ARCHIVO DE CONFIGURACIÓN. SE VOLVERA A REQUERIR EN EL PROXIMO INICIO DE LA APLICACIÓN.'
                Application.ExitThread() ' TERMINAR PROCESO DE APLICACIÓN.'
            End If
            
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub ConfiguracionDatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackgroundWorker1.RunWorkerAsync()
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub
End Class