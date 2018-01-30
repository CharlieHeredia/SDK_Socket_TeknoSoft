Option Strict Off
Option Explicit On
'** MODIFICACION .NET
Imports System.Runtime.InteropServices
Imports System.Text
Module SDK_ADMW
    '--------------------------------------------------------------------------------------
    ' Modulo:             SDK_ADMW
    ' Descripción:        En este módulo se declaran las constantes, métodos,  y estructuras de datos del SDK de AdminPAQ.
    ' Fecha de creación:  01.sept.06
    ' Departamento:       Alianzas ISV's
    ' Autor:              AS
    ' Actualización:      15.sept.06
    ' Contacto:           desarrollo.isv@compac.com.mx
    '--------------------------------------------------------------------------------------
    '___________________DECLARACIÓN DE CONSTANTES DE LONGITUD____________________
    '
    ' Se adiciona 1 (+ 1) a la longitud original contemplando
    ' el caracter nulo necesario al final de la cadena.
    Public Const kLongCodigo As Short = 30 + 1
    Public Const kLongNombre As Short = 60 + 1
    Public Const kLongNombreProducto As Short = 255 + 1
    Public Const kLongFecha As Short = 23 + 1
    Public Const kLongAbreviatura As Short = 3 + 1
    Public Const kLongCodValorClasif As Short = 3 + 1
    Public Const kLongTextoExtra As Short = 50 + 1
    Public Const kLongNumSerie As Short = 11 + 1
    Public Const kLongReferencia As Short = 20 + 1
    Public Const kLongSeries As Short = 30 + 1
    Public Const kLongDescripcion As Short = 60 + 1
    Public Const kLongNumeroExtInt As Short = 30 + 1
    Public Const kLongCodigoPostal As Short = 6 + 1
    Public Const kLongTelefono As Short = 15 + 1
    Public Const kLongEmailWeb As Short = 50 + 1
    Public Const kLongRFC As Short = 20 + 1
    Public Const kLongCURP As Short = 20 + 1
    Public Const kLongDesCorta As Short = 20 + 1
    Public Const kLongDenComercial As Short = 50 + 1
    Public Const kLongRepLegal As Short = 50 + 1
    '** MODIFICACION .NET
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)> _
    Public Structure tDocumento
        Dim aFolio As Double
        Dim aMoneda As Int32
        Dim aTipoCambio As Double
        Dim aImporte As Double
        Dim aDescuentoDoc1 As Double
        Dim aDescuentoDoc2 As Double
        Dim aSistemaOrigen As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Dim aCodConcepto As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=kLongNumSerie)> Dim aSerie As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=kLongFecha)> Dim aFecha As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Dim aCodigoCteProv As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Dim aCodigoAgente As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=kLongReferencia)> Dim aReferencia As Byte()
        Dim aAfecta As Int32
        Dim aGasto1 As Double
        Dim aGasto2 As Double
        Dim aGasto3 As Double
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)> _
    Public Structure tLlaveDocto
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Dim aCodConcepto As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=kLongNumSerie)> Dim aSerie As Byte()
        Dim aFolio As Double
    End Structure
    ' Registro para Movimientos
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)> _
    Public Structure tMovimiento
        Dim aConsecutivo As Int32 ' Valor inicial debe ser 100 con incrementos de 100 en 100, por si es necesario insertar movtos intermedios
        Dim aUnidades As Double ' En caso de producto con series, lotes y/o pedimentos y carcateristicas este valor es cero
        Dim aPrecio As Double ' Usado para docuementos de venta
        Dim aCosto As Double ' Usado para docuemtnos de compra y/o inventarios
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Dim aCodProdSer As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Dim aCodAlmacen As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=kLongReferencia)> Dim aReferencia As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Dim aCodClasificacion As Byte()
    End Structure
    ' Registro para movimientos con series, lotes y pedimentos
    Public Structure tSeriesCapas
        Dim aUnidades As Double ' Si es un producto con series este valor es cero
        Dim aTipoCambio As Double
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongSeries), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongSeries)> Public aSeries() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public aPedimento() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public aAgencia() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongFecha), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongFecha)> Public aFechaPedimento() As Char ' Formato mm/dd/aaaa
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public aNumeroLote() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongFecha), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongFecha)> Public aFechaFabricacion() As Char ' Formato mm/dd/aaaa
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongFecha), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongFecha)> Public aFechaCaducidad() As Char ' Formato mm/dd/aaaa
    End Structure
    ' Registro para Caracteristicas
    Public Structure tCaracteristicas
        Dim aUnidades As Double
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public aValorCaracteristica1() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public aValorCaracteristica2() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public aValorCaracteristica3() As Char
    End Structure
    ' Registro para CaracteristicasUnidades
    Public Structure tCaracteristicasUnidades
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongAbreviatura), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongAbreviatura)> Public aUnidad() As Char
        Dim aUnidades As Double
        Dim aUnidadesNC As Double
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public aValorCaracteristica1() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public aValorCaracteristica2() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public aValorCaracteristica3() As Char
    End Structure
    ' Registro para Tipo de Producto
    Public Structure tTipoProducto
        Dim aSeriesCapas As tSeriesCapas
        Dim aCaracteristicas As tCaracteristicas
    End Structure
    ' Registro para Llave de Apertura de Caja
    Public Structure tLlaveAper
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodigo), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Public aCodCaja() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongFecha), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongFecha)> Public aFechaApe() As Char
    End Structure
    ' Registro para Producto
    Public Structure tProducto
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodigo), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Public cCodigoProducto() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongNombre), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongNombre)> Public cNombreProducto() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongNombreProducto), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongNombreProducto)> Public cDescripcionProducto() As Char
        Dim cTipoProducto As Integer ' 1 = Producto, 2 = Paquete, 3 = Servicio
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongFecha), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongFecha)> Public cFechaAltaProducto() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongFecha), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongFecha)> Public cFechaBaja() As Char
        Dim cStatusProducto As Integer ' 0 - Baja Lógica, 1 - Alta
        Dim cControlExistencia As Integer
        Dim cMetodoCosteo As Integer ' 1 = Costo Promedio en Base a Entradas, 2 = Costo Promedio en Base a Entradas Almacen, 3 = Último costo, 4 = UEPS, 5 = PEPS, 6 = Costo específico, 7 = Costo Estandar
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodigo), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Public cCodigoUnidadBase() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodigo), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Public cCodigoUnidadNoConvertible() As Char
        Dim cPrecio1 As Double
        Dim cPrecio2 As Double
        Dim cPrecio3 As Double
        Dim cPrecio4 As Double
        Dim cPrecio5 As Double
        Dim cPrecio6 As Double
        Dim cPrecio7 As Double
        Dim cPrecio8 As Double
        Dim cPrecio9 As Double
        Dim cPrecio10 As Double
        Dim cImpuesto1 As Double
        Dim cImpuesto2 As Double
        Dim cImpuesto3 As Double
        Dim cRetencion1 As Double
        Dim cRetencion2 As Double
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongAbreviatura), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongAbreviatura)> Public cNombreCaracteristica1() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongAbreviatura), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongAbreviatura)> Public cNombreCaracteristica2() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongAbreviatura), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongAbreviatura)> Public cNombreCaracteristica3() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacion1() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacion2() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacion3() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacion4() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacion5() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacion6() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongTextoExtra), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongTextoExtra)> Public cTextoExtra1() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongTextoExtra), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongTextoExtra)> Public cTextoExtra2() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongTextoExtra), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongTextoExtra)> Public cTextoExtra3() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongFecha), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongFecha)> Public cFechaExtra() As Char
        Dim cImporteExtra1 As Double
        Dim cImporteExtra2 As Double
        Dim cImporteExtra3 As Double
        Dim cImporteExtra4 As Double
    End Structure
    ' Registro para Cliente/Proveedor
    Public Structure tClienteProveedor
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodigo), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Public cCodigoCliente() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongNombre), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongNombre)> Public cRazonSocial() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongFecha), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongFecha)> Public cFechaAlta() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongRFC), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongRFC)> Public cRFC() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCURP), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCURP)> Public cCURP() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDenComercial), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDenComercial)> Public cDenComercial() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongRepLegal), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongRepLegal)> Public cRepLegal() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongNombre), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongNombre)> Public cNombreMoneda() As Char
        Dim cListaPreciosCliente As Integer
        Dim cDescuentoMovto As Double
        Dim cBanVentaCredito As Integer ' 0 = No se permite venta a crédito, 1 = Se permite venta a crédito
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacionCliente1() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacionCliente2() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacionCliente3() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacionCliente4() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacionCliente5() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacionCliente6() As Char
        Dim cTipoCliente As Integer ' 1 - Cliente, 2 - Cliente/Proveedor, 3 - Proveedor
        Dim cEstatus As Integer ' 0. Inactivo, 1. Activo
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongFecha), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongFecha)> Public cFechaBaja() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongFecha), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongFecha)> Public cFechaUltimaRevision() As Char
        Dim cLimiteCreditoCliente As Double
        Dim cDiasCreditoCliente As Integer
        Dim cBanExcederCredito As Integer ' 0 = No se permite exceder crédito, 1 = Se permite exceder el crédito
        Dim cDescuentoProntoPago As Double
        Dim cDiasProntoPago As Integer
        Dim cInteresMoratorio As Double
        Dim cDiaPago As Integer
        Dim cDiasRevision As Integer
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDesCorta), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDesCorta)> Public cMensajeria() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public cCuentaMensajeria() As Char
        Dim cDiasEmbarqueCliente As Integer
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodigo), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Public cCodigoAlmacen() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodigo), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Public cCodigoAgenteVenta() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodigo), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Public cCodigoAgenteCobro() As Char
        Dim cRestriccionAgente As Integer
        Dim cImpuesto1 As Double
        Dim cImpuesto2 As Double
        Dim cImpuesto3 As Double
        Dim cRetencionCliente1 As Double
        Dim cRetencionCliente2 As Double
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacionProveedor1() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacionProveedor2() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacionProveedor3() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacionProveedor4() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacionProveedor5() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacionProveedor6() As Char
        Dim cLimiteCreditoProveedor As Double
        Dim cDiasCreditoProveedor As Integer
        Dim cTiempoEntrega As Integer
        Dim cDiasEmbarqueProveedor As Integer
        Dim cImpuestoProveedor1 As Double
        Dim cImpuestoProveedor2 As Double
        Dim cImpuestoProveedor3 As Double
        Dim cRetencionProveedor1 As Double
        Dim cRetencionProveedor2 As Double
        Dim cBanInteresMoratorio As Integer ' 0 = No se le calculan intereses moratorios al cliente, 1 = Si se le calculan intereses moratorios al cliente.
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongTextoExtra), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongTextoExtra)> Public cTextoExtra1() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongTextoExtra), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongTextoExtra)> Public cTextoExtra2() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongTextoExtra), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongTextoExtra)> Public cTextoExtra3() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongFecha), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongFecha)> Public cFechaExtra() As Char
        Dim cImporteExtra1 As Double
        Dim cImporteExtra2 As Double
        Dim cImporteExtra3 As Double
        Dim cImporteExtra4 As Double
    End Structure
    ' Registro para Valores de clasificación
    Public Structure tValorClasificacion
        Dim cClasificacionDe As Integer
        Dim cNumClasificacion As Integer
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodValorClasif), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodValorClasif)> Public cCodigoValorClasificacion() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public cValorClasificacion() As Char
    End Structure
    ' Registro para Unidades de peso y medida
    Public Structure tUnidad
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongNombre), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongNombre)> Public cNombreUnidad() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongAbreviatura), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongAbreviatura)> Public cAbreviatura() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongAbreviatura), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongAbreviatura)> Public cDespliegue() As Char
    End Structure
    ' Registro para Direcciones
    Public Structure tDireccion
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodigo), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodigo)> Public cCodCteProv() As Char
        Dim cTipoCatalogo As Integer ' 1=Clientes y 2=Proveedores
        Dim cTipoDireccion As Integer ' 1=Domicilio Fiscal, 2=Domicilio Envio
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public cNombreCalle() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongNumeroExtInt), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongNumeroExtInt)> Public cNumeroExterior() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongNumeroExtInt), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongNumeroExtInt)> Public cNumeroInterior() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public cColonia() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongCodigoPostal), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongCodigoPostal)> Public cCodigoPostal() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongTelefono), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongTelefono)> Public cTelefono1() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongTelefono), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongTelefono)> Public cTelefono2() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongTelefono), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongTelefono)> Public cTelefono3() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongTelefono), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongTelefono)> Public cTelefono4() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongEmailWeb), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongEmailWeb)> Public cEmail() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongEmailWeb), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongEmailWeb)> Public cDireccionWeb() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public cCiudad() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public cEstado() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public cPais() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(kLongDescripcion), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=kLongDescripcion)> Public cTextoExtra() As Char
    End Structure
    '__________________DECLARACIÓN DE LAS FUNCIONES DEL SDK______________________
    ' ***** Funciones Generales del SDK *****
    ' Inicialización/Terminación
    Public Declare Ansi Function fInicializaSDK Lib "MGW_SDK.DLL" () As Integer
    Public Declare Ansi Sub fTerminaSDK Lib "MGW_SDK.DLL" ()
    ' Manejo de errores
    Public Declare Ansi Sub fError Lib "MGW_SDK.DLL" (ByVal aNumError As Integer, ByVal aError As String, ByVal aLen As Integer)
    ' ***** Funciones de Empresas *****
    ' Navegación
    Declare Ansi Function fPosPrimerEmpresa Lib "MGW_SDK.DLL" (ByRef aIdEmpresa As Integer, ByVal aNombreEmpresa As String, ByVal aDirectorioEmpresa As String) As Integer
    Declare Ansi Function fPosSiguienteEmpresa Lib "MGW_SDK.DLL" (ByRef aIdEmpresa As Integer, ByVal aNombreEmpresa As String, ByVal aDirectorioEmpresa As String) As Integer
    ' Apertura/Cierre
    Declare Ansi Function fAbreEmpresa Lib "MGW_SDK.DLL" (ByVal aError As String) As Integer
    Public Declare Ansi Sub fCierraEmpresa Lib "MGW_SDK.DLL" ()
    ' ***** Funciones de Documentos *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Ansi Function fInsertarDocumento Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fEditarDocumento Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fGuardaDocumento Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fCancelarModificacionDocumento Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fBorraDocumento Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fCancelaDocumento Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fBorraDocumento_CW Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fCancelaDocumento_CW Lib "MGW_SDK.DLL" () As Integer
    'Todos los documentos creados con el SDK deben afectarse a fin de que se actualicen los acumulados del sistema
    Declare Ansi Function fAfectaDocto_Param Lib "MGW_SDK.DLL" (ByVal aCodConcepto As String, ByVal aSerie As String, ByVal aFolio As Double, ByVal aAfecta As Boolean) As Integer
    Declare Ansi Function fSaldarDocumento_Param Lib "MGW_SDK.DLL" (ByVal aCodConcepto_Pagar As String, ByVal aSerie_Pagar As String, ByVal aFolio_Pagar As Double, ByVal aCodConcepto_Pago As String, ByVal aSerie_Pago As String, ByVal aFolio_Pago As Double, ByVal aImporte As Double, ByVal aIdMoneda As Integer, ByVal aFecha As String) As Integer
    Declare Ansi Function fBorrarAsociacion_Param Lib "MGW_SDK.DLL" (ByVal aCodConcepto_Pagar As String, ByVal aSerie_Pagar As String, ByVal aFolio_Pagar As Double, ByVal aCodConcepto_Pago As String, ByVal aSerie_Pago As String, ByVal aFolio_Pago As Double) As Integer
    Declare Ansi Function fSetDatoDocumento Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String) As Integer
    Declare Ansi Function fLeeDatoDocumento Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String) As Integer
    Declare Ansi Function fLeeDatoDocumento Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String, ByVal aLen As Integer) As Integer
    Declare Ansi Function fSiguienteFolio Lib "MGW_SDK.DLL" (ByVal aCodigoConcepto As String, ByVal aSerie As String, ByRef aFolio As Double) As Integer
    Declare Ansi Function fSetFiltroDocumento Lib "MGW_SDK.DLL" (ByVal aFechaInicio As String, ByVal aFechaFin As String, ByVal aCodigoConcepto As String, ByVal aCodigoCteProv As String) As Integer
    Declare Ansi Function fCancelaFiltroDocumento Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fDocumentoImpreso Lib "MGW_SDK.DLL" (ByVal aImpreso As Boolean) As Integer
    ' Bajo Nivel - Busqueda/Navegación
    Declare Ansi Function fBuscarDocumento Lib "MGW_SDK.DLL" (ByVal aCodConcepto As String, ByVal aSerie As String, ByVal aFolio As String) As Integer
    Declare Ansi Function fBuscarIdDocumento Lib "MGW_SDK.DLL" (ByVal aIdDocumento As Integer) As Integer
    Declare Ansi Function fPosPrimerDocumento Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fPosUltimoDocumento Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fPosSiguienteDocumento Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fPosAnteriorDocumento Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fPosBOF Lib "MGW_SDK.DLL" () As Integer
    Declare Ansi Function fPosEOF Lib "MGW_SDK.DLL" () As Integer
    ' Alto Nivel - Lectura/Escritura
    'UPGRADE_WARNING: Structure tDocumento may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Ansi Function fAltaDocumento Lib "MGW_SDK.DLL" (ByRef aIdDocumento As Integer, ByRef aDocto As tDocumento) As Integer
    'UPGRADE_WARNING: Structure tDocumento may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Ansi Function fAltaDocumentoCargoAbono Lib "MGW_SDK.DLL" (ByRef aDocto As tDocumento) As Integer
    'Todos los documentos creados con el SDK deben afectarse a fin de que se actualicen los acumulados del sistema
    'UPGRADE_WARNING: Structure tLlaveDocto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Ansi Function fAfectaDocto Lib "MGW_SDK.DLL" (ByRef astDocAPagar As tLlaveDocto, ByVal aAfecta As Boolean) As Integer
    'UPGRADE_WARNING: Structure tLlaveDocto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    'UPGRADE_WARNING: Structure tLlaveDocto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fSaldarDocumento Lib "MGW_SDK.DLL" (ByRef astDocAPagar As tLlaveDocto, ByRef astDocPago As tLlaveDocto, ByVal aImporte As Double, ByVal aIdMoneda As Integer, ByVal aFecha As String) As Integer
    'UPGRADE_WARNING: Structure tLlaveDocto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    'UPGRADE_WARNING: Structure tLlaveDocto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fSaldarDocumentoCheqPAQ Lib "MGW_SDK.DLL" (ByVal astDocAPagar As tLlaveDocto, ByVal astDocPago As tLlaveDocto, ByVal aImporte As Double, ByVal aIdMoneda As Integer, ByVal aFecha As String, ByVal aTipoCambioCheqPAQ As Double) As Integer
    'UPGRADE_WARNING: Structure tLlaveDocto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    'UPGRADE_WARNING: Structure tLlaveDocto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fBorrarAsociacion Lib "MGW_SDK.DLL" (ByVal astDocAPagar As tLlaveDocto, ByVal astDocPago As tLlaveDocto) As Integer
    'UPGRADE_WARNING: Structure tLlaveDocto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fRegresaIVACargo Lib "MGW_SDK.DLL" (ByVal aLlaveDocto As tLlaveDocto, ByRef aNetoTasa15 As Double, ByRef aNetoTasa10 As Double, ByRef aNetoTasaCero As Double, ByRef aNetoTasaExcenta As Double, ByRef aNetoOtrasTasas As Double, ByRef aIVATasa15 As Double, ByRef aIVATasa10 As Double, ByRef aIVAOtrasTasas As Double) As Integer
    'UPGRADE_WARNING: Structure tLlaveDocto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fRegresaIVAPago Lib "MGW_SDK.DLL" (ByVal aLlaveDocto As tLlaveDocto, ByRef aNetoTasa15 As Double, ByRef aNetoTasa10 As Double, ByRef aNetoTasaCero As Double, ByRef aNetoTasaExcenta As Double, ByRef aNetoOtrasTasas As Double, ByRef aIVATasa15 As Double, ByRef aIVATasa10 As Double, ByRef aIVAOtrasTasas As Double) As Integer
    ' Alto Nivel - Busqueda/Navegación
    'UPGRADE_WARNING: Structure tLlaveDocto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fBuscaDocumento Lib "MGW_SDK.DLL" (ByRef aLlaveDocto As tLlaveDocto) As Integer
    ' ***** Funciones de Movimientos  *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fInsertarMovimiento Lib "MGW_SDK.DLL" () As Integer
    Declare Function fEditarMovimiento Lib "MGW_SDK.DLL" () As Integer
    Declare Function fGuardaMovimiento Lib "MGW_SDK.DLL" () As Integer
    Declare Function fCancelaCambiosMovimiento Lib "MGW_SDK.DLL" () As Integer
    Declare Function fAltaMovimientoCaracteristicas_Param Lib "MGW_SDK.DLL" (ByVal aIdMovimiento As String, ByVal aIdMovtoCaracteristicas As String, ByVal aUnidades As String, ByVal aValorCaracteristica1 As String, ByVal aValorCaracteristica2 As String, ByVal aValorCaracteristica3 As String) As Integer
    Declare Function fAltaMovimientoSeriesCapas_Param Lib "MGW_SDK.DLL" (ByVal aIdMovimiento As String, ByVal aIdMovtoCaracteristicas As String, ByVal aUnidad As String, ByVal aUnidades As String, ByVal aUnidadesNC As String, ByVal aValorCaracteristica1 As String, ByVal aValorCaracteristica2 As String, ByVal aValorCaracteristica3 As String) As Integer
    Declare Function fAltaMovtoCaracteristicasUnidades_Param Lib "MGW_SDK.DLL" (ByVal aIdMovimiento As String, ByVal aUnidades As String, ByVal aTipoCambio As String, ByVal aSeries As String, ByVal aPedimento As String, ByVal aAgencia As String, ByVal aFechaPedimento As String, ByVal aNumeroLote As String, ByVal aFechaFabricacion As String, ByVal aFechaCaducidad As String) As Integer
    Declare Function fCalculaMovtoSerieCapa Lib "MGW_SDK.DLL" (ByVal aIdMovimiento As Integer) As Integer
    Declare Function fObtieneUnidadesPendientes Lib "MGW_SDK.DLL" (ByVal aConceptoDocto As String, ByVal aCodigoProducto As String, ByVal aCodigoAlmacen As String, ByRef aUnidades As String) As Integer
    Declare Function fObtieneUnidadesPendientesCarac Lib "MGW_SDK.DLL" (ByVal aConceptoDocto As String, ByVal aCodigoProducto As String, ByVal aCodigoAlmacen As String, ByVal aValorCaracteristica1 As String, ByVal aValorCaracteristica2 As String, ByVal aValorCaracteristica3 As String, ByRef aUnidades As String) As Integer
    Declare Function fModificaCostoEntrada Lib "MGW_SDK.DLL" (ByVal aIdMovimiento As String, ByVal aCostoEntrada As String) As Integer
    Declare Function fSetDatoMovimiento Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String) As Integer
    Declare Function fLeeDatoMovimiento Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String, ByVal aLen As Integer) As Integer
    Declare Function fSetFiltroMovimiento Lib "MGW_SDK.DLL" (ByVal aIdDocumento As Integer) As Integer
    Declare Function fCancelaFiltroMovimiento Lib "MGW_SDK.DLL" () As Integer
    ' Bajo Nivel - Busqueda/Navegación
    Declare Function fBuscarIdMovimiento Lib "MGW_SDK.DLL" (ByVal aIdMovimiento As Integer) As Integer
    Declare Function fPosPrimerMovimiento Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosUltimoMovimiento Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosSiguienteMovimiento Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosAnteriorMovimiento Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosMovimientoBOF Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosMovimientoEOF Lib "MGW_SDK.DLL" () As Integer
    ' Alto Nivel - Lectura/Escritura
    'UPGRADE_WARNING: Structure tMovimiento may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fAltaMovimiento Lib "MGW_SDK.DLL" (ByVal aIdDocumento As Integer, ByRef aIdMovimiento As Integer, ByRef aMovimiento As tMovimiento) As Integer
    'UPGRADE_WARNING: Structure tProducto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fAltaMovimientoEx Lib "MGW_SDK.DLL" (ByVal aIdMovimiento As Integer, ByRef aTipoProducto As tProducto) As Integer
    'UPGRADE_WARNING: Structure tCaracteristicas may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fAltaMovimientoCaracteristicas Lib "MGW_SDK.DLL" (ByVal aIdMovimiento As Integer, ByRef aIdMovtoCaracteristicas As Integer, ByRef aCaracteristicas As tCaracteristicas) As Integer
    'UPGRADE_WARNING: Structure tCaracteristicasUnidades may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fAltaMovtoCaracteristicasUnidades Lib "MGW_SDK.DLL" (ByVal aIdMovimiento As Integer, ByRef aIdMovtoCaracteristicas As Integer, ByRef aCaracteristicasUnidades As tCaracteristicasUnidades) As Integer
    'UPGRADE_WARNING: Structure tSeriesCapas may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fAltaMovimientoSeriesCapas Lib "MGW_SDK.DLL" (ByVal aIdMovimiento As Integer, ByRef aSeriesCapas As tSeriesCapas) As Integer
    ' ***** Funciones de Clientes / Proveedores *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fInsertaCteProv Lib "MGW_SDK.DLL" () As Integer
    Declare Function fEditaCteProv Lib "MGW_SDK.DLL" () As Integer
    Declare Function fGuardaCteProv Lib "MGW_SDK.DLL" () As Integer
    Declare Function fBorraCteProv Lib "MGW_SDK.DLL" () As Integer
    Declare Function fCancelarModificacionCteProv Lib "MGW_SDK.DLL" () As Integer
    Declare Function fEliminarCteProv Lib "MGW_SDK.DLL" (ByVal aCodCteProv As String) As Integer
    Declare Function fSetDatoCteProv Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String) As Integer
    Declare Function fLeeDatoCteProv Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String, ByVal aLen As Integer) As Integer
    ' Bajo Nivel - Busqueda/Navegación
    Declare Function fBuscaCteProv Lib "MGW_SDK.DLL" (ByVal aCodCteProv As String) As Integer
    Declare Function fBuscaIdCteProv Lib "MGW_SDK.DLL" (ByVal aIdCteProv As Integer) As Integer
    Declare Function fPosPrimerCteProv Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosUltimoCteProv Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosSiguienteCteProv Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosAnteriorCteProv Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosBOFCteProv Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosEOFCteProv Lib "MGW_SDK.DLL" () As Integer
    ' Alto Nivel - Lectura/Escritura
    'UPGRADE_WARNING: Structure tClienteProveedor may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fAltaCteProv Lib "MGW_SDK.DLL" (ByRef aIdCteProv As Integer, ByRef aCteProv As tClienteProveedor) As Integer
    'UPGRADE_WARNING: Structure tClienteProveedor may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fActualizaCteProv Lib "MGW_SDK.DLL" (ByVal aCodCteProv As String, ByRef aCteProv As tClienteProveedor) As Integer
    'UPGRADE_WARNING: Structure tClienteProveedor may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fLlenaRegistroCteProv Lib "MGW_SDK.DLL" (ByRef aCteProv As tClienteProveedor, ByVal aEsAlta As Integer) As Integer
    ' ***** Funciones de Productos  *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fInsertaProducto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fEditaProducto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fGuardaProducto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fBorraProducto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fCancelarModificacionProducto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fEliminarProducto Lib "MGW_SDK.DLL" (ByVal aCodCteProv As String) As Integer
    Declare Function fSetDatoProducto Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String) As Integer
    Declare Function fLeeDatoProducto Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String, ByVal aLen As Integer) As Integer
    Declare Function fRecuperaTipoProducto Lib "MGW_SDK.DLL" (ByRef aUnidades As Boolean, ByRef aSerie As Boolean, ByRef aLote As Boolean, ByRef aPedimento As Boolean, ByRef aCaracteristicas As Boolean) As Integer
    'Función de recosteo de productos
    Declare Function fRecosteoProducto Lib "MGW_SDK.DLL" (ByVal aCodigoProducto As String, ByVal aEjercicio As Integer, ByVal aPeriodo As Integer, ByVal aCodigoClasificacion1 As String, ByVal aCodigoClasificacion2 As String, ByVal aCodigoClasificacion3 As String, ByVal aCodigoClasificacion4 As String, ByVal aCodigoClasificacion5 As String, ByVal aCodigoClasificacion6 As String, ByVal aNombreBitacora As String, ByVal aSobreEscribirBitacora As Integer, ByVal aEsCalculoArimetico As Integer) As Integer
    Declare Function fRegresaPrecioVenta Lib "MGW_SDK.DLL" (ByVal aCodigoConcepto As String, ByVal aCodigoCliente As String, ByVal aCodigoProducto As String, ByRef aPrecioVenta As String) As Integer
    ' Bajo Nivel - Busqueda/Navegación
    Declare Function fBuscaProducto Lib "MGW_SDK.DLL" (ByVal aCodProducto As String) As Integer
    Declare Function fBuscaIdProducto Lib "MGW_SDK.DLL" (ByVal aIdProducto As Integer) As Integer
    Declare Function fPosPrimerProducto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosUltimoProducto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosSiguienteProducto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosAnteriorProducto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosBOFProducto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosEOFProducto Lib "MGW_SDK.DLL" () As Integer
    ' Alto Nivel - Lectura/Escritura
    'UPGRADE_WARNING: Structure tProducto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fAltaProducto Lib "MGW_SDK.DLL" (ByRef aIdProducto As Integer, ByRef aProducto As tProducto) As Integer
    'UPGRADE_WARNING: Structure tProducto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fActualizaProducto Lib "MGW_SDK.DLL" (ByVal aCodigoProducto As String, ByRef aProducto As tProducto) As Integer
    'UPGRADE_WARNING: Structure tProducto may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fLlenaRegistroProducto Lib "MGW_SDK.DLL" (ByRef aProducto As tProducto, ByVal aEsAlta As Integer) As Integer
    ' ***** Funciones de Direcciones  *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fInsertaDireccion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fEditaDireccion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fGuardaDireccion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fCancelarModificacionDireccion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fSetDatoDireccion Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String) As Integer
    Declare Function fLeeDatoDireccion Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String, ByVal aLen As Integer) As Integer
    ' Bajo Nivel - Busqueda/Navegación
    Declare Function fBuscaDireccionEmpresa Lib "MGW_SDK.DLL" () As Integer
    Declare Function fBuscaDireccionCteProv Lib "MGW_SDK.DLL" (ByVal aCodCteProv As String, ByRef aTipoDireccion As String) As Integer
    Declare Function fBuscaDireccionDocumento Lib "MGW_SDK.DLL" (ByVal aIdDocumento As Integer, ByRef aTipoDireccion As String) As Integer
    Declare Function fPosPrimerDireccion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosUltimaDireccion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosSiguienteDireccion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosAnteriorDireccion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosBOFDireccion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosEOFDireccion Lib "MGW_SDK.DLL" () As Integer
    ' Alto Nivel - Lectura/Escritura
    'UPGRADE_WARNING: Structure tDireccion may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fAltaDireccion Lib "MGW_SDK.DLL" (ByRef aIdDireccion As Integer, ByRef astDireccion As tDireccion) As Integer
    'UPGRADE_WARNING: Structure tDireccion may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fActualizaDireccion Lib "MGW_SDK.DLL" (ByRef astDireccion As tDireccion) As Integer
    'UPGRADE_WARNING: Structure tDireccion may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fLlenaRegistroDireccion Lib "MGW_SDK.DLL" (ByRef astDireccion As tDireccion, ByVal aEsAlta As Integer) As Integer
    ' ***** Funciones de Existencias  *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fRegresaExistencia Lib "MGW_SDK.DLL" (ByVal aCodigoProducto As String, ByVal aCodigoAlmacen As String, ByVal aAnio As String, ByVal aMes As String, ByVal aDia As String, ByRef aExistencia As Double) As Integer
    Declare Function fRegresaExistenciaCaracteristicas Lib "MGW_SDK.DLL" (ByVal aCodigoProducto As String, ByVal aCodigoAlmacen As String, ByVal aAnio As String, ByVal aMes As String, ByVal aDia As String, ByVal aValorCaracteristica1 As String, ByVal aValorCaracteristica2 As String, ByVal aValorCaracteristica3 As String, ByRef aExistencia As Double) As Integer
    ' ***** Funciones de Costo Histórico  *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fRegresaCostoPromedio Lib "MGW_SDK.DLL" (ByVal aCodigoProducto As String, ByVal aCodigoAlmacen As String, ByVal aAnio As String, ByVal aMes As String, ByVal aDia As String, ByRef aCostoPromedio As String) As Integer
    Declare Function fRegresaUltimoCosto Lib "MGW_SDK.DLL" (ByVal aCodigoProducto As String, ByVal aCodigoAlmacen As String, ByVal aAnio As String, ByVal aMes As String, ByVal aDia As String, ByRef aUltimoCosto As String) As Integer
    Declare Function fRegresaCostoEstandar Lib "MGW_SDK.DLL" (ByVal aCodigoProducto As String, ByRef aCostoEstandar As String) As Integer
    Declare Function fRegresaCostoCapa Lib "MGW_SDK.DLL" (ByVal aCodigoProducto As String, ByVal aCodigoAlmacen As String, ByVal aUnidades As Double, ByRef aImporteCosto As String) As Integer
    ' ***** Funciones de Concepto Documento *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fLeeDatoConceptoDocto Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String, ByVal aLen As Integer) As Integer
    Declare Function fRegresPorcentajeImpuesto Lib "MGW_SDK.DLL" (ByVal aIdConceptoDocumento As Integer, ByVal aIdClienteProveedor As Integer, ByVal aIdProducto As Integer, ByRef aPorcentajeImpuesto As Double) As Integer
    ' Bajo Nivel - Busqueda/Navegación
    Declare Function fBuscaConceptoDocto Lib "MGW_SDK.DLL" (ByVal aCodConcepto As String) As Integer
    Declare Function fBuscaIdConceptoDocto Lib "MGW_SDK.DLL" (ByVal aIdConcepto As Integer) As Integer
    Declare Function fPosPrimerConceptoDocto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosUltimaConceptoDocto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosSiguienteConceptoDocto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosAnteriorConceptoDocto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosBOFConceptoDocto Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosEOFConceptoDocto Lib "MGW_SDK.DLL" () As Integer
    ' ***** Funciones de Parámetros *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fLeeDatoParametros Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String, ByVal aLen As Integer) As Integer
    ' ***** Funciones del Catálogo de Clasificaciones  *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fEditaClasificacion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fGuardaClasificacion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fCancelarModificacionClasificacion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fSetDatoClasificacion Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String) As Integer
    Declare Function fLeeDatoClasificacion Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String, ByVal aLen As Integer) As Integer
    Declare Function fActualizaClasificacion Lib "MGW_SDK.DLL" (ByVal aClasificacionDe As Integer, ByVal aNumClasificacion As Integer, ByVal aNombreClasificacion As String) As Integer
    ' Bajo Nivel - Busqueda/Navegación
    Declare Function fBuscaClasificacion Lib "MGW_SDK.DLL" (ByVal aClasificacionDe As Integer, ByVal aNumClasificacion As Integer) As Integer
    Declare Function fBuscaIdClasificacion Lib "MGW_SDK.DLL" (ByVal aIdClasificacion As Integer) As Integer
    Declare Function fPosPrimerClasificacion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosUltimoClasificacion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosSiguienteClasificacion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosAnteriorClasificacion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosBOFClasificacion Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosEOFClasificacion Lib "MGW_SDK.DLL" () As Integer
    ' ***** Funciones del Catálogo de Valores de Clasificaciones *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fInsertaValorClasif Lib "MGW_SDK.DLL" () As Integer
    Declare Function fEditaValorClasif Lib "MGW_SDK.DLL" () As Integer
    Declare Function fGuardaValorClasif Lib "MGW_SDK.DLL" () As Integer
    Declare Function fBorraValorClasif Lib "MGW_SDK.DLL" () As Integer
    Declare Function fCancelarModificacionValorClasif Lib "MGW_SDK.DLL" () As Integer
    Declare Function fEliminarValorClasif Lib "MGW_SDK.DLL" (ByVal aClasificacionDe As Integer, ByVal aNumClasificacion As Integer, ByVal aCodValorClasif As String) As Integer
    Declare Function fSetDatoValorClasif Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String) As Integer
    Declare Function fLeeDatoValorClasif Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String, ByVal aLen As Integer) As Integer
    ' Bajo Nivel - Busqueda/Navegación
    Declare Function fBuscaValorClasif Lib "MGW_SDK.DLL" (ByVal aClasificacionDe As Integer, ByVal aNumClasificacion As Integer, ByVal aCodValorClasif As String) As Integer
    Declare Function fBuscaIdValorClasif Lib "MGW_SDK.DLL" (ByVal aIdValorClasif As Integer) As Integer
    Declare Function fPosPrimerValorClasif Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosUltimoValorClasif Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosSiguienteValorClasif Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosAnteriorValorClasif Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosBOFValorClasif Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosEOFValorClasif Lib "MGW_SDK.DLL" () As Integer
    ' Alto Nivel - Lectura/Escritura
    'UPGRADE_WARNING: Structure tValorClasificacion may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fAltaValorClasif Lib "MGW_SDK.DLL" (ByRef aIdValorClasif As Integer, ByRef astValorClasif As tValorClasificacion) As Integer
    'UPGRADE_WARNING: Structure tValorClasificacion may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fActualizaValorClasif Lib "MGW_SDK.DLL" (ByVal aCodigoValorClasif As String, ByRef astValorClasif As tValorClasificacion) As Integer
    'UPGRADE_WARNING: Structure tValorClasificacion may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fLlenaRegistroValorClasif Lib "MGW_SDK.DLL" (ByRef astValorClasif As tValorClasificacion) As Integer
    ' ***** Funciones del Catálogo de Unidades de Medida y Peso  *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fInsertaUnidad Lib "MGW_SDK.DLL" () As Integer
    Declare Function fEditaUnidad Lib "MGW_SDK.DLL" () As Integer
    Declare Function fGuardaUnidad Lib "MGW_SDK.DLL" () As Integer
    Declare Function fBorraUnidad Lib "MGW_SDK.DLL" () As Integer
    Declare Function fCancelarModificacionUnidad Lib "MGW_SDK.DLL" () As Integer
    Declare Function fEliminarUnidad Lib "MGW_SDK.DLL" (ByVal aNombreUnidad As String) As Integer
    Declare Function fSetDatoUnidad Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String) As Integer
    Declare Function fLeeDatoUnidad Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String, ByVal aLen As Integer) As Integer
    ' Bajo Nivel - Busqueda/Navegación
    Declare Function fBuscaUnidad Lib "MGW_SDK.DLL" (ByVal aNombreUnidad As String) As Integer
    Declare Function fBuscaIdUnidad Lib "MGW_SDK.DLL" (ByVal aIdUnidad As Integer) As Integer
    Declare Function fPosPrimerUnidad Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosUltimoUnidad Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosSiguienteUnidad Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosAnteriorUnidad Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosBOFUnidad Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosEOFUnidad Lib "MGW_SDK.DLL" () As Integer
    ' Alto Nivel - Lectura/Escritura
    'UPGRADE_WARNING: Structure tUnidad may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fAltaUnidad Lib "MGW_SDK.DLL" (ByRef aIdUnidad As Integer, ByRef astUnidad As tUnidad) As Integer
    'UPGRADE_WARNING: Structure tUnidad may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fActualizaUnidad Lib "MGW_SDK.DLL" (ByVal aNombreUnidad As String, ByRef astUnidad As tUnidad) As Integer
    'UPGRADE_WARNING: Structure tUnidad may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Function fLlenaRegistroUnidad Lib "MGW_SDK.DLL" (ByRef astUnidad As tUnidad) As Integer
    ' ***** Funciones del Catálogo de Agentes *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fInsertaAgente Lib "MGW_SDK.DLL" () As Integer
    'Declare Function fEditaAgente Lib "MGW_SDK.DLL" () As Long
    Declare Function fEditaAgente Lib "MGW_SDK.DLL" () As Integer
    Declare Function fGuardaAgente Lib "MGW_SDK.DLL" () As Integer
    Declare Function fCancelarModificacionAgente Lib "MGW_SDK.DLL" () As Integer
    Declare Function fLeeDatoAgente Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String, ByVal aLen As Integer) As Integer
    Declare Function fSetDatoAgente Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String) As Integer
    ' Bajo Nivel - Busqueda/Navegación
    Declare Function fBuscaIdAgente Lib "MGW_SDK.DLL" (ByVal aIdAgente As Integer) As Integer
    Declare Function fBuscaAgente Lib "MGW_SDK.DLL" (ByVal aCodigoAgente As String) As Integer
    Declare Function fPosPrimerAgente Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosUltimoAgente Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosSiguienteAgente Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosAnteriorAgente Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosBOFAgente Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosEOFAgente Lib "MGW_SDK.DLL" () As Integer
    ' ***** Funciones del Catálogo de Almacenes *****
    ' Bajo Nivel - Lectura/Escritura
    Declare Function fInsertaAlmacen Lib "MGW_SDK.DLL" () As Integer
    Declare Function fEditaAlmacen Lib "MGW_SDK.DLL" () As Integer
    Declare Function fGuardaAlmacen Lib "MGW_SDK.DLL" () As Integer
    Declare Function fCancelarModificacionAlmacen Lib "MGW_SDK.DLL" () As Integer
    Declare Function fLeeDatoAlmacen Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String, ByVal aLen As Integer) As Integer
    Declare Function fSetDatoAlmacen Lib "MGW_SDK.DLL" (ByVal aCampo As String, ByVal aValor As String) As Integer
    ' Bajo Nivel - Busqueda/Navegación
    Declare Function fBuscaIdAlmacen Lib "MGW_SDK.DLL" (ByVal aIdAlmacen As Integer) As Integer
    Declare Function fBuscaAlmacen Lib "MGW_SDK.DLL" (ByVal aCodigoAlmacen As String) As Integer
    Declare Function fPosPrimerAlmacen Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosUltimoAlmacen Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosSiguienteAlmacen Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosAnteriorAlmacen Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosBOFAlmacen Lib "MGW_SDK.DLL" () As Integer
    Declare Function fPosEOFAlmacen Lib "MGW_SDK.DLL" () As Integer
    Declare Function fSetNombrePAQ Lib "MGW_SDK.dll" (ByVal Programa As String) As Integer
    Public Declare Function fInicializaLicenseInfo Lib "MGW_SDK.DLL" (ByVal lSistema As Byte) As Integer
    Declare Function fEmitirDocumento Lib "MGW_SDK.DLL" (ByVal aCodigoConcepto As String, ByVal aNumSerie As String, ByVal aFolio As Double, ByVal aPassword As String, ByVal aArchivo As String) As Long
    Public Declare Function fEntregEnDiscoXML Lib "MGW_SDK.DLL" (<MarshalAs(UnmanagedType.LPStr)> ByVal aCodigoConcepto As String, <MarshalAs(UnmanagedType.LPStr)> ByVal aSerie As String, ByVal aFolio As Double, ByVal aFormato As Integer, <MarshalAs(UnmanagedType.LPStr)> ByVal aFormatoAmig As String) As Integer
    Declare Function fTimbraXML Lib "MGW_SDK.DLL" (<MarshalAs(UnmanagedType.LPStr)> ByVal aRutaXML As String, <MarshalAs(UnmanagedType.LPStr)> ByVal aCodConcepto As String, <MarshalAs(UnmanagedType.LPStr)> ByVal aUUID As String, <MarshalAs(UnmanagedType.LPStr)> ByVal aRutaDDA As String, <MarshalAs(UnmanagedType.LPStr)> ByVal aRutaResultado As String, <MarshalAs(UnmanagedType.LPStr)> ByVal aPass As String, <MarshalAs(UnmanagedType.LPStr)> ByVal aRutaFormato As String) As Integer
    Public Declare Function SetCurrentDirectory Lib "KERNEL32" Alias "SetCurrentDirectoryA" (ByVal pPtrDirActual As String) As Integer

End Module
