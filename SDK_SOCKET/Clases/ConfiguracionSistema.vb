Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.Sql
Public Class ConfiguracionSistema

    Public Function CargarDatosConfiguracion()
        Try
            If Directory.Exists(DirectorioConfiguracion) = False Then 'VERIFICACIÓN DE EXISTENCIA DEL DIRECTORIO.'
                Directory.CreateDirectory(DirectorioConfiguracion) 'CREACIÓN DEL DIRECTORIO.'
            End If
            If File.Exists(DirectorioArchivoConfiguracion) = False Then 'VERIFICACIÓN DE EXISTENCIA DEL ARCHIVO.'
                Dim Path = File.Create(DirectorioArchivoConfiguracion) 'CREACIÓN DEL ARCHIVO CON LOS DARTOS DE CONEXIÓN.'
                Path.Close() 'CIERRA EL ARCHIVO PARA QUE PUEDA SER UTILIZADO.'
                Dim Formulario As New ConfiguracionDatos()

                Do Until ConfiguracionDatosCompleta = True
                    Formulario.ShowDialog()
                Loop

                'EN CASO DE NO TERMINAR LA CONFIGURACIÓN, BORRAR EL ARCHIVO DE TEXTO.'
            Else
                ConfiguracionDatosCompleta = True 'YA EXISTE UN ARCHIVO DE CONFIGURACIÓN.'
            End If
        Catch ex As Exception
            MsgBox("Problema: " & ex.Message) 'MENSAJE DE ERROR DEL SISTEMA.'
            File.Delete("C:\TeknoCom\Socket\ConfiguracionSocket.txt") 'BORRAR EL ARCHIVO DE CONFIGURACIÓN VACIO.'
            Application.ExitThread()
        End Try
    End Function
    Public Function CargarConfiguracion()
        Try
            Dim ConexionSQL As New SqlConnection()
            'ConexionSQL.ConnectionString = "Data Source=" & hostname & ";Initial Catalog=" & BaseDAtos & ";User Id=" & usuarioBD & ";Password=" & contra 'INFORMACIÓN DE LA CONEXIÓN.'
            Dim cmd As New SqlCommand()
            'CARGAR DATOS A VARAIBLES GLOBALES.'
        Catch ex As Exception

        End Try
    End Function
End Class
