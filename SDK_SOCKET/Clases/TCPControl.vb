Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Public Class TCPControl
    'Eventos Personales'
    Public Event Trimbrar(sender As TCPControl, Dato As String)

    'Configuración de servidor'
    Public ServerIP As IPAddress = IPAddress.Parse(DireccionIP) 'Dirección IP del servidor'
    Public ServerPort As Integer = Puerto 'Puerto del servidor'
    Public Server As TcpListener

    Private ComThread As Thread
    Public IsListening As Boolean = True

    'Clientes'
    Private Client As TcpClient
    Private ClientData As StreamReader

    Public Sub New()
        Server = New TcpListener(ServerIP, ServerPort)
        Server.Start()

        ComThread = New Thread(New ThreadStart(AddressOf Listening))
        ComThread.Start() 'Inicializa el hilo'
    End Sub

    Private Sub Listening()
        'CREATE LISTENER LOOP'
        'SE MANTIENE ESCUCHANDO LAS CONEXIONES NUEVAS Y LOS MENSAJES'
        Do Until IsListening = False
            GC.Collect()
            'ACCEPTED INCOMING CONECTIONS'
            If Server.Pending = True Then
                Client = Server.AcceptTcpClient
                ClientData = New StreamReader(Client.GetStream)
            End If
            'RAISE EVENT FOR INCOMING MESSAGES'
            Try
                RaiseEvent Trimbrar(Me, ClientData.ReadLine) ' CAPTURA DE EVENTO.'
            Catch ex As Exception

            End Try
            Thread.Sleep(100) ' SE UTILIZA PARA REDUCIR EL USO DEL CPU.'
            GC.GetTotalMemory(True) 'LIMPIEZA DE BASURA.'
        Loop
    End Sub
End Class
