Imports System.Text.RegularExpressions
Module VariableGlobales
    Public DireccionIP As String = "" 'DIRECCIÓN IP DEL SERVIDOR'
    Public Puerto As String = "" 'PUERTO UTILIZADO POR EL SOCKET'
    Public ConfiguraciónCompleta As Boolean = False 'PARA VERIFICAR QUE LA DIRECCIÓN IP Y EL PUERTO SE CONFIGURARON CORRECTAMENTE.'

    Public Instancia As String = "" 'INSTANCIA DE SQL.'
    Public BaseDAtos As String = "" 'NOMBRE DE LA BASE DE DATOS SQL. UTILIZADA PARA CARGAR DATOS PARA EL SOCKET.'
    Public User As String = "" 'USUARIO DE SQL.'
    Public Pass As String = "" 'CONTRASEÑA DE SQL.'

    Public ConfiguracionDatosCompleta As Boolean = False 'VERIFICADOR DE DATOS DE CONEXIÓN CON SQL. GUARDADOS EN UN ARCHIVO C:\Teknocom\Socket\.'

    Public aRutaFormato As String = "" 'UBICACIÓN DEL ARCHIVO DE FORMATO.'

    Public DirectorioConfiguracion As String = "C:\TeknoCom\Socket"
    Public DirectorioArchivoConfiguracion As String = "C:\TeknoCom\Socket\ConfiguracionSocket.txt"

    Public Key As String = "teknocom"
End Module
