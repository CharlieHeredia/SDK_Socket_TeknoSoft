<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEstadoConexion = New System.Windows.Forms.Label()
        Me.btnIniciarServidor = New System.Windows.Forms.Button()
        Me.btnConfiguracion = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Estado:"
        '
        'txtEstadoConexion
        '
        Me.txtEstadoConexion.AutoSize = True
        Me.txtEstadoConexion.Location = New System.Drawing.Point(74, 21)
        Me.txtEstadoConexion.Name = "txtEstadoConexion"
        Me.txtEstadoConexion.Size = New System.Drawing.Size(90, 13)
        Me.txtEstadoConexion.TabIndex = 1
        Me.txtEstadoConexion.Text = "Servidor detenido"
        '
        'btnIniciarServidor
        '
        Me.btnIniciarServidor.Location = New System.Drawing.Point(127, 60)
        Me.btnIniciarServidor.Name = "btnIniciarServidor"
        Me.btnIniciarServidor.Size = New System.Drawing.Size(101, 23)
        Me.btnIniciarServidor.TabIndex = 2
        Me.btnIniciarServidor.Text = "Iniciar Servidor"
        Me.btnIniciarServidor.UseVisualStyleBackColor = True
        '
        'btnConfiguracion
        '
        Me.btnConfiguracion.Location = New System.Drawing.Point(16, 60)
        Me.btnConfiguracion.Name = "btnConfiguracion"
        Me.btnConfiguracion.Size = New System.Drawing.Size(84, 23)
        Me.btnConfiguracion.TabIndex = 3
        Me.btnConfiguracion.Text = "Configuración"
        Me.btnConfiguracion.UseVisualStyleBackColor = True
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(251, 95)
        Me.Controls.Add(Me.btnConfiguracion)
        Me.Controls.Add(Me.btnIniciarServidor)
        Me.Controls.Add(Me.txtEstadoConexion)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SDK SOCKET"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEstadoConexion As System.Windows.Forms.Label
    Friend WithEvents btnIniciarServidor As System.Windows.Forms.Button
    Friend WithEvents btnConfiguracion As System.Windows.Forms.Button

End Class
