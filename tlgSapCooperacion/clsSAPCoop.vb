Imports System.Net
Imports System.Security.Cryptography.X509Certificates, System.Net.Security
<ComClass(ClsSAPCoop.ClassId, ClsSAPCoop.InterfaceId, ClsSAPCoop.EventsId)>
Public Class ClsSAPCoop
    Dim mCuit As String
    Private mUsuario As String
    Private mPassword As String
    Private mUrlRead As String, mUrlChange As String, mUrlCreate As String, mExisteProveedor As Boolean, mRolProveedor As String
    Private mCodigo_Externo As String, mCodigo_SAP As String
    Private mApellido As String, mNombre As String, mRazonSocial As String
    Private mTipoDoc As String, mDireccion As String, mLocalidad As String, mProvincia As String, mZipCode As String, mPais As String, mTelefonos As String, mEmails As String
    Private mCtaBco As String, mCtaCta As String, mCtaCbu As String, mCtaTip As String
    Private mErrorWS As String, mErrorActualizaDatosProveedor As String, mErrorAltaProveedor As String
    Private mCodigo_SapDirecciones As String, mTelefonosEnContacto, mEmailsEnContacto
    Private mActualizaDatosBancarios As Boolean
    Private mClase_Impuesto As String

#Region "GUID de COM"
    ' Estos GUID proporcionan la identidad de COM para esta clase 
    ' y las interfaces de COM. Si las cambia, los clientes 
    ' existentes no podrán obtener acceso a la clase.
    Public Const ClassId As String = "a6046775-0008-4fc2-aff6-0225e585e59d"
    Public Const InterfaceId As String = "1e88ea66-9e47-41f4-b94f-1576cd8fda01"
    Public Const EventsId As String = "7c46e948-44ec-4403-a327-215029e33bb7"
#End Region

    ' Una clase COM que se puede crear debe tener Public Sub New() 
    ' sin parámetros, si no la clase no se 
    ' registrará en el registro COM y no se podrá crear a 
    ' través de CreateObject.

    Public Property Usuario() As String
        Get
            Return mUsuario
        End Get
        Set(ByVal value As String)
            mUsuario = value
        End Set
    End Property

    Public Property passWord() As String
        Get
            Return mPassword
        End Get
        Set(ByVal value As String)
            mPassword = value
        End Set
    End Property

    Public Property URLRead() As String
        Get
            Return mUrlRead
        End Get
        Set(ByVal value As String)
            mUrlRead = value
        End Set
    End Property
    Public Property URLChange() As String
        Get
            Return mUrlChange
        End Get
        Set(ByVal value As String)
            mUrlChange = value
        End Set
    End Property
    Public Property URLCreate() As String
        Get
            Return mUrlCreate
        End Get
        Set(ByVal value As String)
            mUrlCreate = value
        End Set
    End Property

    Public Property CUIT As String
        Get
            Return mCuit
        End Get
        Set(value As String)
            mCuit = value
        End Set
    End Property
    Public Property RolProveedor() As String
        Get
            Return mRolProveedor
        End Get
        Set(ByVal value As String)
            mRolProveedor = value
        End Set
    End Property
    Public Property Codigo_SAP() As String
        Get
            Return mCodigo_SAP
        End Get
        Set(ByVal value As String)
            mCodigo_SAP = value
        End Set
    End Property

    Public Property Codigo_Externo() As String
        Get
            Return mCodigo_Externo
        End Get
        Set(ByVal value As String)
            mCodigo_Externo = value
        End Set
    End Property


    Public Property Nombre() As String
        Get
            Return mNombre
        End Get
        Set(ByVal value As String)
            mNombre = value
        End Set
    End Property
    Public Property Apellido() As String
        Get
            Return mApellido
        End Get
        Set(ByVal value As String)
            mApellido = value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return mRazonSocial
        End Get
        Set(ByVal value As String)
            mRazonSocial = value
        End Set
    End Property
    Public Property TipoDoc() As String
        Get
            Return mTipoDoc
        End Get
        Set(ByVal value As String)
            mTipoDoc = value
        End Set
    End Property
    Public Property Direccion() As String
        Get
            Return mDireccion
        End Get
        Set(ByVal value As String)
            mDireccion = value
        End Set
    End Property
    Public Property Localidad() As String
        Get
            Return mLocalidad
        End Get
        Set(ByVal value As String)
            mLocalidad = value
        End Set
    End Property

    Public Property CodigoPostal() As String
        Get
            Return mZipCode
        End Get
        Set(ByVal value As String)
            mZipCode = value
        End Set
    End Property
    Public Property Provincia() As String
        Get
            Return mProvincia
        End Get
        Set(ByVal value As String)
            mProvincia = value
        End Set
    End Property

    Public Property Pais() As String
        Get
            Return mPais
        End Get
        Set(ByVal value As String)
            mPais = value
        End Set
    End Property
    Public Property Telefonos() As String
        Get
            Return mTelefonos
        End Get
        Set(value As String)
            mTelefonos = value
        End Set
    End Property

    Public Property eMails() As String
        Get
            Return meMails
        End Get
        Set(value As String)
            meMails = value
        End Set
    End Property
    Public Property ctaBco() As String
        Get
            Return mCtaBco
        End Get
        Set(value As String)
            mCtaBco = value
        End Set
    End Property
    Public Property ctaCbu() As String
        Get
            Return mCtaCbu
        End Get
        Set(value As String)
            mCtaCbu = value
        End Set
    End Property
    Public Property ctaCta() As String
        Get
            Return mCtaCta
        End Get
        Set(value As String)
            mCtaCta = value
        End Set
    End Property
    Public Property ctaTip() As String
        Get
            Return mCtaTip
        End Get
        Set(value As String)
            mCtaTip = value
        End Set
    End Property
    Public Property Clase_Impuesto As String
        Get
            Return mClase_Impuesto
        End Get
        Set(value As String)
            mClase_Impuesto = value
        End Set
    End Property

    Public Property ExisteProveedor() As Boolean
        Get
            Return mExisteProveedor
        End Get
        Set(ByVal value As Boolean)
            mExisteProveedor = value
        End Set
    End Property

    Public Property ErrorWs() As String
        Get
            Return mErrorWS
        End Get
        Set(ByVal value As String)
            mErrorWS = value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub ManejaDatosProveedor()
        'Variables del Read
        Dim mi_SAP_READ As Sap_Read.ZWS_BP_READ, misCredenciales As NetworkCredential
        Dim miCriterio As Sap_Read.ZFM_BP_SERVICES_READ, mi_IS_BP_READ As Sap_Read.ZST_BP_READ_IN_WS, mi_Out_WS() As Sap_Read.ZST_BP_READ_OUT_WS
        Dim mis_Roles_Proveedor As Sap_Read.ZST_BP_BU_PARTNERROLE()

        Dim miRespuesta As Sap_Read.ZFM_BP_SERVICES_READResponse

        Try
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                Function(senderX, certificate, chain, sslPolicyErrors)
                    Return True
                End Function

            mi_SAP_READ = New Sap_Read.ZWS_BP_READ
            misCredenciales = New NetworkCredential
            misCredenciales.UserName = mUsuario
            misCredenciales.Password = mPassword
            If mUrlRead <> "" Then
                mi_SAP_READ.Url = mUrlRead
            End If

            mi_SAP_READ.Credentials = misCredenciales

            mi_IS_BP_READ = New Sap_Read.ZST_BP_READ_IN_WS
            mi_IS_BP_READ.CUIT = mCuit

            miCriterio = New Sap_Read.ZFM_BP_SERVICES_READ

            miCriterio.IS_BP_READ = mi_IS_BP_READ

            miRespuesta = mi_SAP_READ.ZFM_BP_SERVICES_READ(miCriterio)
            If miRespuesta IsNot Nothing Then
                mExisteProveedor = Not miRespuesta.ES_ERROR.IS_ERROR = "X"

                If mExisteProveedor Then
                    mi_Out_WS = miRespuesta.ET_BP_READ
                    If mi_Out_WS IsNot Nothing Then
                        mActualizaDatosBancarios = True
                        mis_Roles_Proveedor = mi_Out_WS(0).ROLES
                        mCodigo_SAP = mi_Out_WS(0).BASICOS.CODIGO_SAP
                        mCodigo_Externo = mi_Out_WS(0).BASICOS.CODIGO_EXTERNO
                        mCodigo_SapDirecciones = mi_Out_WS(0).DIRECCIONES(0).CODIGO_SAP
                        mTelefonosEnContacto = mi_Out_WS(0).DIRECCIONES(0).CONTACTO.TELEFONOS
                        mEmailsEnContacto = mi_Out_WS(0).DIRECCIONES(0).CONTACTO.EMAILS
                        If mi_Out_WS(0).BANCARIOS.Length > 0 Then
                            For Each misBancarios In mi_Out_WS(0).BANCARIOS
                                If misBancarios.CBU = ctaCbu And misBancarios.TIPO = ctaTip Then
                                    mActualizaDatosBancarios = False
                                    Exit For
                                End If
                            Next
                        End If

                        ActualizaDatosProveedor(Not BuscaRolEnColeccion(mis_Roles_Proveedor, mRolProveedor))
                        mErrorWS = mErrorActualizaDatosProveedor
                    End If
                Else
                    AltaDatosProveedor()
                    mErrorWS = mErrorAltaProveedor
                End If

            End If
        Catch ex As Exception
            mErrorWS = ex.Message
        End Try

        mi_SAP_READ = Nothing
        mi_Out_WS = Nothing
        miCriterio = Nothing
        misCredenciales = Nothing
        miRespuesta = Nothing
        mi_IS_BP_READ = Nothing

    End Sub
    Sub ActualizaDatosProveedor(AltaRol As Boolean)
        Dim mCriterios As Sap_Change.ZFM_BP_SERVICES_CHANGE 'datos para actualizar

        Dim mItemsIdentificacion As Sap_Change.ZST_BP_CHANGE_IN_WS_IDENT, mIdent() As Sap_Change.ZST_BP_CHANGE_IN_WS_IDENT
        Dim misCredenciales As NetworkCredential


        Dim mItemDireccion As Sap_Change.ZST_BP_CHANGE_IN_WS_DIRECCION, mItemDireccion_X As Sap_Change.ZST_BP_CHANGE_IN_WS_DIRECCIONX
        Dim mDirecciones As Sap_Change.ZST_BP_CHANGE_IN_WS_DIR, mArrayDirecciones() As Sap_Change.ZST_BP_CHANGE_IN_WS_DIR
        Dim mItemContacto As Sap_Change.ZST_BP_CHANGE_IN_WS_CONTACTO

        Dim mItemTelefono As Sap_Change.ZST_BP_CHANGE_IN_WS_TELEFONO, mArrayTelefonos() As Sap_Change.ZST_BP_CHANGE_IN_WS_TELEFONO, spliteroTelefonos
        Dim mItemEmail As Sap_Change.ZST_BP_CHANGE_IN_WS_EMAIL, mArrayEmails() As Sap_Change.ZST_BP_CHANGE_IN_WS_EMAIL, spliteroEmails
        Dim mItemBancario As Sap_Change.ZST_BP_CHANGE_IN_WS_BANCO, mArrayBancarios() As Sap_Change.ZST_BP_CHANGE_IN_WS_BANCO
        Dim countTel As Integer


        Dim mi_SAP_Change As Sap_Change.ZWS_BP_CHANGE, mi_Is_BP_CHANGE As Sap_Change.ZST_BP_CHANGE_IN_WS
        Dim miPersona As Sap_Change.ZST_BP_CREATE_IN_WS_PERSONA, miPersona_X As Sap_Change.ZST_BP_CHANGE_IN_WS_PERSONA_X, miEmpresa As Sap_Change.ZST_BP_CHANGE_IN_WS_EMPRESA

        Dim mItemsRol As Sap_Change.ZST_BP_BU_PARTNERROLE, mArrayRoles() As Sap_Change.ZST_BP_BU_PARTNERROLE
        Dim miRespuesta As Sap_Change.ZFM_BP_SERVICES_CHANGEResponse
        'AQUI DOY DE ALTA EL ITEM IDENTIFICACION SI ES PERSONA LE MANDO TIPO Y NUMERO DE CUIT SI ES EMPRESA LE MANDO SOLO EL NUMERO DE CUIT    
        '-------------------------------------------------------------------------------------------------
        mErrorActualizaDatosProveedor = ""

        mItemsRol = New Sap_Change.ZST_BP_BU_PARTNERROLE
        mItemsRol.ROL = mRolProveedor
        mItemsRol.VALIDO_DESDE = Year(Date.Today) & Format(Month(Date.Today), "00") & Format(Day(Date.Today), "00")
        mItemsRol.VALIDO_HASTA = "20501231"

        'Basicos-------------------------------------------------------
        mItemsIdentificacion = New Sap_Change.ZST_BP_CHANGE_IN_WS_IDENT
        If Left(mCuit, 2) = "20" Or Left(mCuit, 2) = "23" Or Left(mCuit, 2) = "24" Or Left(mCuit, 2) = "27" Then
            mItemsIdentificacion.TIPO_DOC = mTipoDoc
            mItemsIdentificacion.NUMERO_DOC = Mid(mCuit, 3, 8)

        Else
            mItemsIdentificacion.TIPO_DOC = ""
            mItemsIdentificacion.NUMERO_DOC = mCuit
        End If
        mItemsIdentificacion.VALIDO_DESDE = ""
        mItemsIdentificacion.VALIDO_HASTA = ""
        mItemsIdentificacion.FECHA_ENTRADA = ""
        '--------------------------------------------------------------------------------------------------------------------
        'Alta de datos de Direccion
        mItemDireccion = New Sap_Change.ZST_BP_CHANGE_IN_WS_DIRECCION
        mItemDireccion.CODIGO_SAP = mCodigo_SapDirecciones
        mItemDireccion.CALLE = mDireccion
        mItemDireccion.CODIGO_POSTAL = mZipCode
        mItemDireccion.PROVINCIA = mProvincia
        mItemDireccion.CODIGO_POBLACION = mLocalidad
        mItemDireccion.PAIS = mPais

        mItemDireccion_X = New Sap_Change.ZST_BP_CHANGE_IN_WS_DIRECCIONX
        mItemDireccion_X.CALLE = "X"
        mItemDireccion_X.CODIGO_POSTAL = "X"
        mItemDireccion_X.PROVINCIA = "X"
        mItemDireccion_X.CODIGO_POBLACION = "X"
        mItemDireccion_X.PAIS = "X"
        mItemDireccion_X.CONTACTO = "X"
        'Telefonos-----------------------------------------------------------

        ReDim mArrayTelefonos(0)
        spliteroTelefonos = Split(mTelefonos, ";")
        countTel = 0
        For Each tel In spliteroTelefonos
            mItemTelefono = New Sap_Change.ZST_BP_CHANGE_IN_WS_TELEFONO
            If mTelefonosEnContacto.length > 0 Then
                If countTel <= mTelefonosEnContacto.length - 1 Then
                    mItemTelefono.ID_NUMERO = mTelefonosEnContacto(countTel).ID_NUMERO
                End If
            End If
            mItemTelefono.ES_PRINCIPAL = "X"
            mItemTelefono.NUMERO = tel
            ReDim Preserve mArrayTelefonos(countTel)
            mArrayTelefonos(countTel) = mItemTelefono
            mItemTelefono = Nothing
            countTel = countTel + 1
        Next
        'Roles---------------------------------------------------------------
        ReDim mArrayRoles(0)
        If AltaRol Then
            mArrayRoles(0) = mItemsRol
        End If

        'eMails---------------------------------------------------------------
        ReDim mArrayEmails(0)
        spliteroEmails = Split(mEmails, ";")
        countTel = 0
        For Each tel In spliteroEmails
            mItemEmail = New Sap_Change.ZST_BP_CHANGE_IN_WS_EMAIL
            If mEmailsEnContacto.length > 0 Then
                If countTel <= mEmailsEnContacto.length - 1 Then
                    mItemEmail.ID_EMAIL = mEmailsEnContacto(countTel).ID_EMAIL
                End If
            End If

            mItemEmail.ES_PRINCIPAL = "X"
            mItemEmail.COMENTARIO = "PROVEEDORES"
            mItemEmail.EMAIL = tel
            ReDim Preserve mArrayEmails(countTel)
            mArrayEmails(countTel) = mItemEmail
            mItemEmail = Nothing
            countTel = countTel + 1
        Next
        mItemContacto = New Sap_Change.ZST_BP_CHANGE_IN_WS_CONTACTO
        mItemContacto.TELEFONOS = mArrayTelefonos
        mItemContacto.EMAIL = mArrayEmails
        '----------------------------------------------------------------------------------------------------------------------
        'Datos Banco--------------------------
        If mCtaCbu <> "" And mActualizaDatosBancarios Then
            mItemBancario = New Sap_Change.ZST_BP_CHANGE_IN_WS_BANCO
            mItemBancario.CBU = mCtaCbu
            mItemBancario.CODIGO = Mid(mCtaCbu, 1, 7)   'mCtaBco 
            mItemBancario.CUENTA = Mid(mCtaCbu, 9, 13) 'mCtaCta
            mItemBancario.TIPO = mCtaTip
            mItemBancario.PAIS = mPais
        End If
        '-----------------------------------------------
        Try
            'System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            mCriterios = New Sap_Change.ZFM_BP_SERVICES_CHANGE
            mi_SAP_Change = New Sap_Change.ZWS_BP_CHANGE
            misCredenciales = New NetworkCredential
            misCredenciales.UserName = mUsuario
            misCredenciales.Password = mPassword
            If mUrlChange <> "" Then
                mi_SAP_Change.Url = mUrlChange
            End If
            mi_SAP_Change.Credentials = misCredenciales


            mi_Is_BP_CHANGE = New Sap_Change.ZST_BP_CHANGE_IN_WS
            mi_Is_BP_CHANGE.CODIGO_SAP = mCodigo_SAP

            If AltaRol Then
                mi_Is_BP_CHANGE.ROLES = mArrayRoles
            End If

            'mi_Is_BP_CHANGE.CODIGO_EXTERNO = mCodigo_Externo
            If Left(mCuit, 2) = "20" Or Left(mCuit, 2) = "23" Or Left(mCuit, 2) = "24" Or Left(mCuit, 2) = "27" Then
                miPersona = New Sap_Change.ZST_BP_CREATE_IN_WS_PERSONA
                miPersona.NOMBRES = mNombre
                miPersona.APELLIDOS = mApellido

                mi_Is_BP_CHANGE.PERSONA = miPersona
                miPersona_X = New Sap_Change.ZST_BP_CHANGE_IN_WS_PERSONA_X
                miPersona_X.NOMBRES = "X"
                miPersona_X.APELLIDOS = "X"
                mi_Is_BP_CHANGE.PERSONA_X = miPersona_X
            Else
                miEmpresa = New Sap_Change.ZST_BP_CHANGE_IN_WS_EMPRESA
                miEmpresa.RAZON_SOCIAL = mRazonSocial
                mi_Is_BP_CHANGE.EMPRESA = miEmpresa
            End If
            ReDim mIdent(0)
            mIdent(0) = mItemsIdentificacion
            mi_Is_BP_CHANGE.IDENTIFICACION = mIdent

            'tratamiento de Direcciones --------------
            mDirecciones = New Sap_Change.ZST_BP_CHANGE_IN_WS_DIR
            mDirecciones.DIRECCION = mItemDireccion
            mDirecciones.DIRECCION.CONTACTO = mItemContacto
            mDirecciones.DIRECCION_X = mItemDireccion_X

            ReDim mArrayDirecciones(0)
            mArrayDirecciones(0) = mDirecciones
            mi_Is_BP_CHANGE.DIRECCIONES = mArrayDirecciones
            '----------------------------------------------------------
            'Datos Bancos-----------------------------------------------
            If mCtaCbu <> "" And mActualizaDatosBancarios Then
                ReDim mArrayBancarios(0)
                mArrayBancarios(0) = mItemBancario
                mi_Is_BP_CHANGE.BANCARIOS = mArrayBancarios
            End If
            '-----------------------------------------------------------

            mCriterios.IS_BP_CHANGE = mi_Is_BP_CHANGE
            miRespuesta = mi_SAP_Change.ZFM_BP_SERVICES_CHANGE(mCriterios)
            If miRespuesta.ES_ERROR.IS_ERROR = "X" Then
                mErrorActualizaDatosProveedor = miRespuesta.ES_ERROR.MESSAGES(0).MESSAGE
            End If

        Catch ex As Exception
            mErrorActualizaDatosProveedor = ex.Message
        End Try
        mi_SAP_Change = Nothing
        mi_Is_BP_CHANGE = Nothing
        misCredenciales = Nothing
    End Sub
    Sub AltaDatosProveedor()
        Dim mCriterios As Sap_Create.ZFM_BP_SERVICES_CREATE   'datos para Agregar
        Dim mi_SAP_Create As Sap_Create.ZWS_BP_CREATE, mi_Is_BP_CREATE As Sap_Create.ZST_BP_CREATE_IN_WS
        Dim miRespuesta As Sap_Create.ZFM_BP_SERVICES_CREATEResponse
        mErrorAltaProveedor = ""
        Try
            mi_Is_BP_CREATE = New Sap_Create.ZST_BP_CREATE_IN_WS

            'Basicos --------------------------------------
            Dim mItemBasicos As Sap_Create.ZST_BP_CREATE_IN_WS_BASICOS
            mItemBasicos = New Sap_Create.ZST_BP_CREATE_IN_WS_BASICOS
            mItemBasicos.TIPO = IIf(Left(mCuit, 2) = "20" Or Left(mCuit, 2) = "23" Or Left(mCuit, 2) = "24" Or Left(mCuit, 2) = "27", 1, 2)
            mItemBasicos.BUSQUEDA1 = mNombre & " " & mApellido
            mItemBasicos.BUSQUEDA2 = mCuit

            mi_Is_BP_CREATE.BASICOS = mItemBasicos
            'Roles--------------------------------------
            Dim mItemsRol As Sap_Create.ZST_BP_BU_PARTNERROLE, mArrayRoles() As Sap_Create.ZST_BP_BU_PARTNERROLE
            mItemsRol = New Sap_Create.ZST_BP_BU_PARTNERROLE
            mItemsRol.ROL = mRolProveedor
            mItemsRol.VALIDO_DESDE = Year(Date.Today) & Format(Month(Date.Today), "00") & Format(Day(Date.Today), "00")
            mItemsRol.VALIDO_HASTA = "20501231"
            ReDim mArrayRoles(0)
            mArrayRoles(0) = mItemsRol
            mi_Is_BP_CREATE.ROLES = mArrayRoles
            '-------------------------------------------------------------------------------------------------------------
            Dim mItemPersonas As Sap_Create.ZST_BP_CREATE_IN_WS_PERSONA
            Dim mItemsEmpresa As Sap_Create.ZST_BP_CREATE_IN_WS_EMPRESA
            If Left(mCuit, 2) = "20" Or Left(mCuit, 2) = "23" Or Left(mCuit, 2) = "24" Or Left(mCuit, 2) = "27" Then
                'Personas-------------------------------------------------------
                mItemPersonas = New Sap_Create.ZST_BP_CREATE_IN_WS_PERSONA
                mItemPersonas.NOMBRES = mNombre
                mItemPersonas.APELLIDOS = mApellido
                Select Case Left(mCuit, 2)
                    Case "20"
                        mItemPersonas.SEXO = 2
                    Case "27"
                        mItemPersonas.SEXO = 1
                    Case "23"
                        If Right(mCuit, 1) = "9" Then
                            mItemPersonas.SEXO = 2
                        Else
                            mItemPersonas.SEXO = 1
                        End If
                    Case "24"
                        mItemPersonas.SEXO = 1
                End Select
                mItemPersonas.NACIONALIDAD = mPais
                mi_Is_BP_CREATE.PERSONA = mItemPersonas
            Else
                'Empresa---------------------------------------------------------
                mItemsEmpresa = New Sap_Create.ZST_BP_CREATE_IN_WS_EMPRESA
                mItemsEmpresa.RAZON_SOCIAL = mRazonSocial
                mi_Is_BP_CREATE.EMPRESA = mItemsEmpresa
            End If

            'Identificacion----------------------------------------------------------
            Dim mItemsIdentificacion As Sap_Create.ZST_BP_CREATE_IN_WS_IDENT, arrayIdentificacion() As Sap_Create.ZST_BP_CREATE_IN_WS_IDENT
            mItemsIdentificacion = New Sap_Create.ZST_BP_CREATE_IN_WS_IDENT
            If Left(mCuit, 2) = "20" Or Left(mCuit, 2) = "23" Or Left(mCuit, 2) = "24" Or Left(mCuit, 2) = "27" Then
                mItemsIdentificacion.TIPO_DOC = mTipoDoc
                mItemsIdentificacion.NUMERO_DOC = Mid(mCuit, 3, 8)
            Else
                mItemsIdentificacion.TIPO_DOC = ""
                mItemsIdentificacion.NUMERO_DOC = mCuit
            End If
            ReDim arrayIdentificacion(0)
            arrayIdentificacion(0) = mItemsIdentificacion
            mi_Is_BP_CREATE.IDENTIFICACION = arrayIdentificacion

#Region "Direcciones"
            'Direcciones----------------------------------------------------------------------
            Dim mItemDireccion As Sap_Create.ZST_BP_CREATE_IN_WS_DIRECCION, mArrayDirecciones() As Sap_Create.ZST_BP_CREATE_IN_WS_DIRECCION
            mItemDireccion = New Sap_Create.ZST_BP_CREATE_IN_WS_DIRECCION
            mItemDireccion.CALLE = mDireccion
            mItemDireccion.NUMERO = "S/N"
            mItemDireccion.CODIGO_POSTAL = mZipCode
            mItemDireccion.PROVINCIA = mProvincia
            mItemDireccion.CODIGO_POBLACION = mLocalidad
            mItemDireccion.PAIS = mPais
            'Telefonos en Direcciones ---------------------------------------------------------------------
            Dim mItemTelefono As Sap_Create.ZST_BP_TELEFONO, mArrayTelefonos() As Sap_Create.ZST_BP_TELEFONO
            Dim countTel As Integer, spliteroTelefonos
            ReDim mArrayTelefonos(0)
            spliteroTelefonos = Split(mTelefonos, ";")
            countTel = 0
            For Each tel In spliteroTelefonos
                mItemTelefono = New Sap_Create.ZST_BP_TELEFONO
                If mTelefonosEnContacto.length > 0 Then
                    If countTel <= mTelefonosEnContacto.length - 1 Then
                        mItemTelefono.ID_NUMERO = mTelefonosEnContacto(countTel).ID_NUMERO
                    End If
                End If
                mItemTelefono.ES_PRINCIPAL = "X"
                mItemTelefono.NUMERO = tel
                ReDim Preserve mArrayTelefonos(countTel)
                mArrayTelefonos(countTel) = mItemTelefono
                mItemTelefono = Nothing
                countTel = countTel + 1
            Next
            'Emails en Direcciones-------------------------------------------------------------------------------------------
            Dim mItemEmail As Sap_Create.ZST_BP_EMAIL, mArrayEmails() As Sap_Create.ZST_BP_EMAIL, spliteroEmails
            ReDim mArrayEmails(0)
            spliteroEmails = Split(mEmails, ";")
            countTel = 0
            For Each tel In spliteroEmails
                mItemEmail = New Sap_Create.ZST_BP_EMAIL
                If mEmailsEnContacto.length > 0 Then
                    If countTel <= mEmailsEnContacto.length - 1 Then
                        mItemEmail.ID_EMAIL = mEmailsEnContacto(countTel).ID_EMAIL
                    End If
                End If

                mItemEmail.ES_PRINCIPAL = "X"
                mItemEmail.COMENTARIO = "PROVEEDORES"
                mItemEmail.EMAIL = tel
                ReDim Preserve mArrayEmails(countTel)
                mArrayEmails(countTel) = mItemEmail
                mItemEmail = Nothing
                countTel = countTel + 1
            Next
            'AGREGO Telefonos y EMAILS a CONTACTOS--------------------------------------------------------------------
            Dim mItemContacto As Sap_Create.ZST_BP_CREATE_IN_WS_CONTACTO
            mItemContacto = New Sap_Create.ZST_BP_CREATE_IN_WS_CONTACTO
            mItemContacto.TELEFONOS = mArrayTelefonos
            mItemContacto.EMAILS = mArrayEmails
            'Agrego Contactos as Direccion----------------------------------------------------------------------------
            mItemDireccion.CONTACTO = mItemContacto
            'Agregos CLASES a DIRECCION-------------------------------------------------------------------------------
            Dim mItemClases As Sap_Create.ZST_BP_CREATE_IN_WS_CLASES, mArrayClases() As Sap_Create.ZST_BP_CREATE_IN_WS_CLASES
            mItemClases = New Sap_Create.ZST_BP_CREATE_IN_WS_CLASES
            mItemClases.CLASE = "ZCOMERCIAL"
            ReDim mArrayClases(0)
            mArrayClases(0) = mItemClases
            mItemDireccion.CLASES = mArrayClases

            ReDim mArrayDirecciones(0)
            mArrayDirecciones(0) = mItemDireccion
            mi_Is_BP_CREATE.DIRECCIONES = mArrayDirecciones

            '------Fin Direcciones---------------------------------------------------------------------------------------------
#End Region
            '--BANCARIOS-------------------------------------------------------------------------------------------------------
            If mCtaCbu <> "" Then
                Dim mItemBancario As Sap_Create.ZST_BP_CREATE_IN_WS_BANCO, mArrayBancos() As Sap_Create.ZST_BP_CREATE_IN_WS_BANCO
                mItemBancario = New Sap_Create.ZST_BP_CREATE_IN_WS_BANCO
                mItemBancario.CBU = mCtaCbu
                mItemBancario.PAIS = mPais
                mItemBancario.CODIGO = Mid(mCtaCbu, 1, 7)
                mItemBancario.CUENTA = Mid(mCtaCbu, 9, 13)
                mItemBancario.TIPO = mCtaTip
                ReDim mArrayBancos(0)
                mArrayBancos(0) = mItemBancario
                mi_Is_BP_CREATE.BANCARIOS = mArrayBancos
            End If
            'IMPUESTOS----------------------------------------------------------------------------------------------------------------
            Dim mItemImpuestos As Sap_Create.ZST_BP_CREATE_IN_WS_IMPUESTOS, mArrayImpuestos() As Sap_Create.ZST_BP_CREATE_IN_WS_IMPUESTOS
            mItemImpuestos = New Sap_Create.ZST_BP_CREATE_IN_WS_IMPUESTOS
            If Left(mCuit, 2) = "20" Or Left(mCuit, 2) = "23" Or Left(mCuit, 2) = "24" Or Left(mCuit, 2) = "27" Then
                mItemImpuestos.TIPO_IMP = "AR1B"
            Else
                mItemImpuestos.TIPO_IMP = "AR1A"
            End If
            mItemImpuestos.NUMERO_IMP = mCuit
            ReDim mArrayImpuestos(0)
            mArrayImpuestos(0) = mItemImpuestos
            mi_Is_BP_CREATE.IMPUESTOS = mArrayImpuestos
            '-------------------------------------------------------------------------------------------------------------------------
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                Function(senderX, certificate, chain, sslPolicyErrors)
                    Return True
                End Function
            mi_SAP_Create = New Sap_Create.ZWS_BP_CREATE
            mCriterios = New Sap_Create.ZFM_BP_SERVICES_CREATE
            mCriterios.IS_BP_CREATE = mi_Is_BP_CREATE
            miRespuesta = mi_SAP_Create.ZFM_BP_SERVICES_CREATE(mCriterios)
            If miRespuesta.ES_ERROR.IS_ERROR = "X" Then
                mErrorAltaProveedor = miRespuesta.ES_ERROR.MESSAGES(0).MESSAGE
            End If

            mItemEmail = Nothing
            mArrayEmails = Nothing
            mItemTelefono = Nothing
            mArrayTelefonos = Nothing
            mItemClases = Nothing
            mItemBasicos = Nothing
            mItemsRol = Nothing
            mItemPersonas = Nothing
            mItemsEmpresa = Nothing

        Catch ex As Exception
            mErrorAltaProveedor = ex.Message
        End Try


        mCriterios = Nothing
        mi_SAP_Create = Nothing
        mi_Is_BP_CREATE = Nothing
    End Sub
    Private Function BuscaRolEnColeccion(coleccion As Sap_Read.ZST_BP_BU_PARTNERROLE(), dato As String) As Boolean
        Dim existeRol As Boolean
        For Each pepe In coleccion
            If pepe.ROL = dato Then
                existeRol = True
                Exit For
            End If
        Next
        BuscaRolEnColeccion = existeRol
    End Function
End Class


