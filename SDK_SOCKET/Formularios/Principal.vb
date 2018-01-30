Imports System.IO
Imports Microsoft.VisualBasic.Compatibility
Imports System.Threading
Public Class Principal
    Private Server As TCPControl
    Dim ConfiguracionForm As ConfiguracionServidorForm = New ConfiguracionServidorForm
    Dim Configuracion As New ConfiguracionSistema()
    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If IsNothing(Server) = False Then 'VALIDACIÓN PARA DETENER EL SERVIDOR, EN CASO DE ENTRAR, EL SERVIDOR SE ENCONTRABA ENCENDIDO.'
            Server.IsListening = False 'FINALIZACIÓN DEL SERVIDOR.'
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Carga del archivo dll'
            Configuracion.CargarDatosConfiguracion() 'CARGA lOS DATOS DE CONEXION DE SQL.'
            CargarSDK() 'FUNCIÓN PARA CARGAR EL SDK.'
            VerificarConfiguración() 'FUNCIÓN PARA VERIFICAR QUE SE CONFIGURÓ LA DIRECCIÓN IP Y PUERTO DEL SOCKET SERVIDOR.'
        Catch ex As Exception
            MsgBox("Error: " & ex.Message) 'MENSAJE DE ERROR.'
        End Try
    End Sub
    Private Sub CargarSDK() 'FUNCIÓN PARA CARGAR EL SDK MGW_SDK.dll '
        Dim resul As Integer
        Directory.SetCurrentDirectory("C:\Program Files (x86)\Compacw\AdminPAQ\")
        resul = fInicializaSDK() 'FUNCIÓN UTILIZADA PARA VERIFICAR EL USO DEL SDK.'
        'MsgBox("Resultado: " & resul)
        fTerminaSDK()
    End Sub
    Private Sub VerificarConfiguración() 'FUNCIÓN PARA VERIFICAR SI SE CONFIGURÓ LA DIRECCIÓN IP Y PUERTO DEL SOCKET SERVIDOR.'
        If ConfiguraciónCompleta = False Then 'VALIDACIÓN PARA DESHABILITAR EL BOTON DE INICIO DE SERVIDOR.'
            btnIniciarServidor.Enabled = False 'DESHABILITACIÓN DEL BOTON INICIAR SERVIDOR.'
        Else
            btnIniciarServidor.Enabled = True 'HABILIDATCIÓN DEL BOTON INICIAR SERVIDOR.'
        End If
    End Sub

    Private Sub btnConfiguracion_Click(sender As Object, e As EventArgs) Handles btnConfiguracion.Click
        'CONFIGURACIÓN DEL SERVIDOR'
        ConfiguracionForm.ShowDialog()
        VerificarConfiguración()
    End Sub
    'EXTERNAL THREAD CANNOT COMMUNICATE DIRECTLY WITH FORMS, SO WE NEED A DELEGATE SUB.'
    'UN HILO EXTERNO NO PUEDE COMUNICARSE DIRECTAMENTE CON UN FORM, DE MANERA QUE SE CREA UNA SUB FUNCIÓN DELEGATE.'
    Private Sub btnIniciarServidor_Click(sender As Object, e As EventArgs) Handles btnIniciarServidor.Click
        If IsNothing(Server) = True Then 'VALIDACIÓN DE SERVIDOR INACTIVO.'
            Server = New TCPControl 'SE GENERA UNA NUEVA INSTANCIA LA VARIABLE TIPO TCPControl.'
            txtEstadoConexion.Text = "Servidor Iniciado." & vbCrLf 'CAMBIO DE TEXTO PARA NOTIFICAR QUE EL SERVIDOR SE INICIÓ.'
            AddHandler Server.Trimbrar, AddressOf OnLineReceived 'SE CAPTURA EL EVENTO Timbrar'
        Else
            'HAY UN SERVIDOR CORRIENDO.'
            If MsgBox("Hay un servidor corriendo, se detendra el servidor. ¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Server.IsListening = False
                Server.Server.Stop()
                Server = New TCPControl 'SE GENERA UNA NUEVA INSTANCIA LA VARIABLE TIPO TCPControl.'
                txtEstadoConexion.Text = "Servidor Iniciado." & vbCrLf 'CAMBIO DE TEXTO PARA NOTIFICAR QUE EL SERVIDOR SE INICIÓ.'
                AddHandler Server.Trimbrar, AddressOf OnLineReceived 'SE CAPTURA EL EVENTO Timbrar'
            End If

        End If



    End Sub
    Private Sub OnLineReceived(sender As TCPControl, Data As String) 'SUB FUNCIÓN PARA TIMBRAR'
        If Data <> "" Then
            MsgBox("Timbrando : " & Data)
            'CargarSDK()
            Timbrado()
        End If
    End Sub

    Private Function Timbrado()
        Try
            '24/01/2018 NOTA: ESTA FUNCIÓN PROCESARA UN ARCHIVO XML GENERADO POR EL WEB SERVICE.'
            GC.Collect() ' COMIENZA A RECOLECTAR LA BASURA GENERADA, PARA LIMPIARLA DESPUES DE TERMINAR EL PROCESO.'
            Directory.SetCurrentDirectory("C:\Program Files (x86)\Compacw\AdminPAQ\") ' SE ESTABLECE LA LOCALIZACIÓN DEL SDK.'
            fInicializaSDK() 'SE INICIALIZA EL SDK.'
            fAbreEmpresa("\\Server\Empresas\Wurth Mexico")
            Dim aRutaXML As String = "\\server\serverdev\Compartido\Equipo\Jorge\CORRECTO 3.3.xml"
            Dim aCodConcepto As String = "110"
            Dim aUUID As String = ""
            Dim aRutaDDA As String = ""
            Dim aPass As String = "12345678a"
            Dim aRutaFormato As String = "C:\TeknoCom\FE_CFDI_Wurth.htm"
            Dim estado As Integer = fInicializaLicenseInfo(0) ' VALIDACIÓN DE LA LICENCIA DE ADMINPAQ.'
            Dim aMensaje As New Compatibility.VB6.FixedLengthString(350) ' MENSAJE UTILIZADO PARA OBTENER EL ERROR DEL SISTEMA.'
            aMensaje.Value = New String(Chr(0), 349)
            If estado <> 0 Then
                fError(estado, aMensaje.Value, 350) ' OBTIENE EL ERROR.'
                MsgBox("Error Licencia: " & aMensaje.Value) ' MENSAJE DE ERROR.'
            Else
                estado = fTimbraXML(aRutaXML, aCodConcepto, aUUID, aRutaDDA, Application.StartupPath & "\Archivos\", aPass, aRutaFormato)
                If estado <> 0 Then
                    fError(estado, aMensaje.Value, 350)
                    MsgBox("Error Timbrando: " & aMensaje.Value)
                End If
            End If
            fCierraEmpresa()
            fTerminaSDK()
        Catch ex As Exception
            fCierraEmpresa() ' CIERRA LA RUTA DE LA EMRPESA'
            fTerminaSDK() ' TERMINA LA CONEXIÓN CON SDK'
            MsgBox("Error: " & ex.Message)
        End Try
        
        GC.GetTotalMemory(True) 'LIMPIEZA DE BASURA'

        MsgBox("Saliendo")
    End Function
End Class
