
Public Class FrmPrueba

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim miClase As tlgSapCooperacion.ClsSAPCoop
        miClase = New tlgSapCooperacion.ClsSAPCoop With {
            .URLRead = "https://aws-s4q.cooperacionseguros.com.ar:8001/sap/bc/srt/rfc/sap/zws_bp_read/300/zws_bp_read/zws_bp_read",
            .URLChange = "https://aws-s4q.cooperacionseguros.com.ar:8001/sap/bc/srt/rfc/sap/zws_bp_change/300/zws_bp_change/zws_bp_change",
            .URLCreate = "https://aws-s4q.cooperacionseguros.com.ar:8001/sap/bc/srt/rfc/sap/zws_bp_create/300/zws_bp_create/zws_bp_create",
            .CUIT = "30712383484",
            .Usuario = "WS_SEL2SAP",
            .passWord = "C00perac!",
            .RolProveedor = "FLVN00",
            .Nombre = "",
            .Apellido = "",
            .RazonSocial = "AMHSOFT S.R.L.",
            .Direccion = "Pasaje AMSTERDAM 1185",
            .TipoDoc = "",
            .CodigoPostal = "2000",
            .Provincia = "12",
            .Localidad = "19007",
            .Pais = "AR",
            .Telefonos = "03414656119",
            .eMails = "info@trylogyc.com.ar;mivancich@trylogyc.com.ar",
            .ctaBco = "",
            .ctaTip = "1",
            .ctaCta = "",
            .ctaCbu = "1910083455008300337950"}

        miClase.ManejaDatosProveedor()
        If miClase.ExisteProveedor Then
            MsgBox("Existe")
        Else
            MsgBox("No Existe")
        End If

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub FrmPrueba_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtRol_TextChanged(sender As Object, e As EventArgs) Handles txtRol.TextChanged

    End Sub
End Class
