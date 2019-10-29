USE [Transacciones]
GO
/****** Object:  Table [dbo].[PTC_CobrosRealizadosOffline]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_CobrosRealizadosOffline](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[NoTransaccion] [nvarchar](50) NULL,
	[Fecha] [datetime] NULL,
	[CodigoCobrador] [nvarchar](4) NULL,
	[Contrato] [nvarchar](8) NULL,
	[Status] [int] NULL,
	[Capital] [numeric](19, 2) NULL,
	[Interes] [numeric](19, 2) NULL,
	[Comision] [numeric](19, 2) NULL,
	[Otros] [numeric](19, 2) NULL,
	[IntAdicional] [numeric](19, 2) NULL,
	[Auxiliar] [numeric](19, 2) NULL,
	[Mora] [numeric](19, 2) NULL,
	[Moneda] [nvarchar](2) NULL,
	[DescripcionMoneda] [nvarchar](50) NULL,
	[ConceptoDelPago] [nvarchar](1000) NULL,
	[NombreDispositivoMovil] [nvarchar](50) NULL,
	[NombreCompañia] [nvarchar](250) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_CuotasDePrestamo]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_CuotasDePrestamo](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[Contrato] [nvarchar](10) NOT NULL,
	[CuotaNumPtm] [nvarchar](50) NOT NULL,
	[FechaVencCuota] [datetime] NOT NULL,
	[ValorCuotaCap] [money] NULL,
	[ValorCuotaInt] [money] NULL,
	[ValorCuotaCom] [money] NULL,
	[ValorCuotaComVta] [money] NULL,
	[ValorCuotaTrasp] [money] NULL,
	[ValorCuotaReg] [money] NULL,
	[ValorCuotaSeg] [money] NULL,
	[ValorCuotaExo] [money] NULL,
	[ValorCuotaLegal] [money] NULL,
	[ValorCuotaOtros] [money] NULL,
 CONSTRAINT [PK_PTC_CuotasDePrestamo] PRIMARY KEY CLUSTERED 
(
	[Contrato] ASC,
	[CuotaNumPtm] ASC,
	[FechaVencCuota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_CuotasDePrestamoRen]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_CuotasDePrestamoRen](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[NumDocCont] [nvarchar](10) NOT NULL,
	[Contrato] [nvarchar](10) NOT NULL,
	[CuotaNumPtm] [nvarchar](50) NOT NULL,
	[FechaVencCuota] [datetime] NOT NULL,
	[ValorCuotaCap] [money] NULL,
	[ValorCuotaInt] [money] NULL,
	[ValorCuotaCom] [money] NULL,
	[ValorCuotaComVta] [money] NULL,
	[ValorCuotaTrasp] [money] NULL,
	[ValorCuotaReg] [money] NULL,
	[ValorCuotaSeg] [money] NULL,
	[ValorCuotaExo] [money] NULL,
	[ValorCuotaLegal] [money] NULL,
	[ValorCuotaOtros] [money] NULL,
	[FechaNegociacion] [datetime] NOT NULL,
 CONSTRAINT [PK_PTC_CuotasDePrestamoRen] PRIMARY KEY CLUSTERED 
(
	[NumDocCont] ASC,
	[Contrato] ASC,
	[CuotaNumPtm] ASC,
	[FechaVencCuota] ASC,
	[FechaNegociacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_FechaRecordatorioDePago]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_FechaRecordatorioDePago](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[Fecha] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
	[Clave] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_PTC_FechaRecordatorioDePago] PRIMARY KEY CLUSTERED 
(
	[Fecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_MaestraOficialesCobrosPr]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_MaestraOficialesCobrosPr](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[CodigoOficial] [nvarchar](4) NOT NULL,
	[Nombre] [nvarchar](80) NULL,
	[Control] [nvarchar](4) NULL,
	[Cedula] [nvarchar](15) NULL,
	[Direccion] [nvarchar](120) NULL,
	[Telefono] [nvarchar](25) NULL,
	[Fax] [nvarchar](25) NULL,
	[Celular] [nvarchar](25) NULL,
	[Beeper] [nvarchar](25) NULL,
	[Mail] [nvarchar](80) NULL,
	[TasaComision] [numeric](10, 2) NULL,
 CONSTRAINT [PK_PTC_MaestraOficialesCobrosPr] PRIMARY KEY CLUSTERED 
(
	[CodigoOficial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_MaestroAplicaciones]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_MaestroAplicaciones](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[CodigoApls] [nvarchar](3) NOT NULL,
	[DescripcionApls] [nvarchar](50) NULL,
	[OrdenApls] [int] NULL,
	[Grupo] [nvarchar](3) NULL,
	[idIcon] [int] NULL,
 CONSTRAINT [PK_PTC_MaestroAplicaciones] PRIMARY KEY CLUSTERED 
(
	[CodigoApls] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_MaestroCias]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_MaestroCias](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[CodigoCia] [nvarchar](3) NOT NULL,
	[NombreCia] [nvarchar](80) NULL,
	[DireccionCia] [ntext] NULL,
	[CiudadCia] [nvarchar](40) NULL,
	[SectorCia] [nvarchar](40) NULL,
	[PaisCia] [nvarchar](40) NULL,
	[RncCia] [nvarchar](12) NULL,
	[TelefonosCia] [nvarchar](30) NULL,
	[FaxCia] [nvarchar](16) NULL,
	[EmailCia] [nvarchar](60) NULL,
	[WebCia] [nvarchar](60) NULL,
	[LocalNo] [nvarchar](20) NULL,
	[Consolidacion] [tinyint] NULL,
 CONSTRAINT [PK_PTC_MaestroCias] PRIMARY KEY CLUSTERED 
(
	[CodigoCia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_MaestroClasificacionPgms]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_MaestroClasificacionPgms](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[CodigoTipoPgm] [nvarchar](1) NOT NULL,
	[DescripcionTipoPgm] [nvarchar](40) NULL,
 CONSTRAINT [PK_PTC_MaestroClasificacionPgms] PRIMARY KEY CLUSTERED 
(
	[CodigoTipoPgm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_MaestroClientes]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PTC_MaestroClientes](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[CodClteApls] [nvarchar](15) NOT NULL,
	[NomClteApls] [nvarchar](150) NULL,
	[ApeClteApls] [nvarchar](100) NULL,
	[DireccionClteApls] [nvarchar](150) NULL,
	[SectorClteApls] [nvarchar](40) NULL,
	[TipoClteApls] [nvarchar](3) NULL,
	[nacionalidadClteApls] [nvarchar](50) NULL,
	[FecAperClteApls] [smalldatetime] NULL,
	[TipoID] [nvarchar](1) NULL,
	[CedRncClteApls] [nvarchar](20) NULL,
	[FechaNac1Apls] [smalldatetime] NULL,
	[EstadoCivilClteApls] [nvarchar](1) NULL,
	[CiudadClteApls] [nvarchar](50) NULL,
	[PaisClteApls] [nvarchar](40) NULL,
	[ProvinciaClteApls] [nvarchar](4) NULL,
	[Ocupacion] [nvarchar](50) NULL,
	[Sexo] [nvarchar](1) NULL,
	[RegistroMercantil] [nvarchar](20) NULL,
	[TelefonosClteApls] [nvarchar](30) NULL,
	[TelefonoOficinaClteApls] [nvarchar](30) NULL,
	[FaxClteApls] [nvarchar](20) NULL,
	[CelularClteApls] [nvarchar](20) NULL,
	[BeeperClteApls] [varbinary](180) NULL,
	[E_mailClteApls] [nvarchar](60) NULL,
	[E_mail2ClteApls] [nvarchar](60) NULL,
	[WebSiteClteApls] [nvarchar](60) NULL,
	[Estatus] [tinyint] NULL,
	[Comentario] [nvarchar](200) NULL,
	[Comision] [numeric](18, 2) NULL,
	[NombreConyuge] [nvarchar](50) NULL,
	[ApellidoConyuge] [nvarchar](40) NULL,
	[CedulaConyuge] [nvarchar](20) NULL,
	[TelefonoConyuge] [nvarchar](20) NULL,
	[CelularConyuge] [nvarchar](20) NULL,
	[BeeperConyuge] [nvarchar](20) NULL,
	[DireccionConyuge] [nvarchar](50) NULL,
	[Aniversario] [smalldatetime] NULL,
	[empresaL] [nvarchar](50) NULL,
	[CedulaL] [nvarchar](20) NULL,
	[direccionL] [nvarchar](50) NULL,
	[NacionalidadL] [nvarchar](30) NULL,
	[SectorL] [nvarchar](50) NULL,
	[CiudadL] [nvarchar](50) NULL,
	[TelefonoL] [nvarchar](20) NULL,
	[FaxL] [nvarchar](20) NULL,
	[mailL] [nvarchar](60) NULL,
	[cargoL] [nvarchar](50) NULL,
	[jefeL] [nvarchar](50) NULL,
	[SueldoL] [money] NULL,
	[fechaIngreso] [smalldatetime] NULL,
	[PrestacionesAcum] [money] NULL,
	[SinRegalia] [tinyint] NULL,
	[Prestaciones76] [money] NULL,
	[Prestaciones40] [money] NULL,
	[Activo1] [nvarchar](250) NULL,
	[ValorActivo1] [money] NULL,
	[Activo2] [nvarchar](250) NULL,
	[ValorActivo2] [money] NULL,
	[Activo3] [nvarchar](250) NULL,
	[ValorActivo3] [money] NULL,
	[Activo4] [nvarchar](250) NULL,
	[ValorActivo4] [money] NULL,
	[CuentaBanco1] [nvarchar](50) NULL,
	[Banco1] [nvarchar](50) NULL,
	[CuentaBanco2] [nvarchar](50) NULL,
	[Banco2] [nvarchar](50) NULL,
	[CuentaBanco3] [nvarchar](50) NULL,
	[Banco3] [nvarchar](50) NULL,
	[DescripcionFirma] [nvarchar](250) NULL,
	[ActividadS] [nvarchar](50) NULL,
	[TipoEmpresaS] [nvarchar](2) NULL,
	[cuentaS] [nvarchar](50) NULL,
	[tipoDeudorS] [nvarchar](3) NULL,
	[autorizadoC] [nvarchar](50) NULL,
	[cedulaAutoC] [nvarchar](50) NULL,
	[observacionesC] [nvarchar](350) NULL,
	[limite] [money] NULL,
	[codigoVendApls] [nvarchar](3) NULL,
	[codigoZonaApls] [nvarchar](3) NULL,
	[Contacto] [nvarchar](40) NULL,
	[ClasificacionCliente] [nvarchar](4) NULL,
	[ClienteGeneral] [tinyint] NULL,
	[ClienteFactoring] [tinyint] NULL,
	[ContactoEmpresa] [tinyint] NULL,
	[Deudor] [tinyint] NULL,
	[ProveedorCliente] [tinyint] NULL,
	[RepresentanteLegal] [tinyint] NULL,
	[TasaInteres] [numeric](18, 6) NULL,
	[TasaMora] [numeric](18, 6) NULL,
	[TasaReserva] [numeric](18, 6) NULL,
	[TasaInteresD] [numeric](18, 6) NULL,
	[TasaMoraD] [numeric](18, 6) NULL,
	[TasaReservaD] [numeric](18, 6) NULL,
	[DiasReservaPesos] [numeric](18, 0) NULL,
	[DiasReservaDolares] [numeric](18, 0) NULL,
	[TasaInteresConf] [numeric](18, 6) NULL,
	[TasaMoraConf] [numeric](18, 6) NULL,
	[TasaReservaConf] [numeric](18, 6) NULL,
	[TasaInteresDConf] [numeric](18, 6) NULL,
	[TasaMoraDConf] [numeric](18, 6) NULL,
	[TasaReservaDConf] [numeric](18, 6) NULL,
	[DiasReservaPesosConf] [numeric](18, 0) NULL,
	[DiasReservaDolaresConf] [numeric](18, 0) NULL,
	[DiasMinInt] [numeric](18, 0) NULL,
	[DiasCalcIntCxc] [numeric](18, 0) NULL,
	[NoCuentaP] [nvarchar](50) NULL,
	[BancoBeneficiarioP] [nvarchar](50) NULL,
	[DireccionBancoP] [nvarchar](250) NULL,
	[TipoCuentaP] [nvarchar](50) NULL,
	[SwiftBancoP] [nvarchar](50) NULL,
	[BeneficiarioD] [nvarchar](100) NULL,
	[DireccionBeneficiarioD] [nvarchar](250) NULL,
	[BancoBenefPrimerD] [nvarchar](50) NULL,
	[DireccionBancoPrimerD] [nvarchar](250) NULL,
	[NoCuentaPrimerD] [nvarchar](50) NULL,
	[SwiftPrimerD] [nvarchar](50) NULL,
	[ABAPrimerD] [nvarchar](50) NULL,
	[BancoIntermediarioD] [nvarchar](50) NOT NULL,
	[DireccionBancoIntermD] [nvarchar](120) NULL,
	[NoCuentaIntermD] [nvarchar](50) NULL,
	[SwiftIntermD] [nvarchar](50) NULL,
	[NCfEmitidoA] [nvarchar](1) NULL,
	[DevolucionInteres] [nvarchar](1) NULL,
	[FactoringOConfirming] [nvarchar](1) NULL,
	[TasaIntDespVencFactPesos] [numeric](18, 6) NULL,
	[LegalizacionFactPesos] [tinyint] NULL,
	[NotificacionesFactPesos] [tinyint] NULL,
	[ImpuestoAlDebFactPesos] [tinyint] NULL,
	[TasaImpuestoAlDebitoFactPesos] [numeric](18, 6) NULL,
	[CobroDeComisionFactPesos] [tinyint] NULL,
	[TasaComisionFactPesos] [numeric](18, 6) NULL,
	[ValorComisionFactPesos] [numeric](18, 2) NULL,
	[ItbisFactPesos] [tinyint] NULL,
	[LimiteDeCreditoFactPesos] [numeric](18, 2) NULL,
	[TasaIntDespVencFactDolares] [numeric](18, 6) NULL,
	[LegalizacionFactDolares] [tinyint] NULL,
	[NotificacionesFactDolares] [tinyint] NULL,
	[ImpuestoAlDebFactDolares] [tinyint] NULL,
	[TasaImpuestoAlDebitoFactDolares] [numeric](18, 6) NULL,
	[CobroDeComisionFactDolares] [tinyint] NULL,
	[TasaComisionFactDolares] [numeric](18, 6) NULL,
	[ValorComisionFactDolares] [numeric](18, 2) NULL,
	[ItbisFactDolares] [tinyint] NULL,
	[LimiteDeCreditoFactDolares] [numeric](18, 2) NULL,
	[TasaIntDespVencConfPesos] [numeric](18, 6) NULL,
	[MismaTasaQueSuplidorConfPesos] [nchar](10) NULL,
	[LegalizacionConfPesos] [tinyint] NULL,
	[NotificacionesConfPesos] [tinyint] NULL,
	[ImpuestoAlDebConfPesos] [tinyint] NULL,
	[TasaImpuestoAlDebitoConfPesos] [numeric](18, 6) NULL,
	[CobroDeComisionConfPesos] [tinyint] NULL,
	[TasaComisionConfPesos] [numeric](18, 6) NULL,
	[ValorComisionConfPesos] [numeric](18, 2) NULL,
	[ItbisConfPesos] [tinyint] NULL,
	[DiasAdicionalesConfPesos] [numeric](18, 0) NULL,
	[LimiteDeCreditoConfPesos] [numeric](18, 2) NULL,
	[TasaIntDespVencConfDolares] [numeric](18, 6) NULL,
	[MismaTasaQueSuplidorConfDolares] [tinyint] NULL,
	[LegalizacionConfDolares] [tinyint] NULL,
	[NotificacionesConfDolares] [tinyint] NULL,
	[ImpuestoAlDebConfDolares] [tinyint] NULL,
	[TasaImpuestoAlDebitoConfDolares] [numeric](18, 6) NULL,
	[CobroDeComisionConfDolares] [tinyint] NULL,
	[TasaComisionConfDolares] [numeric](18, 6) NULL,
	[ValorComisionConfDolares] [numeric](18, 2) NULL,
	[ItbisConfDolares] [tinyint] NULL,
	[DiasAdicionalesConfDolares] [numeric](18, 0) NULL,
	[LimiteDeCreditoConfDolares] [numeric](18, 2) NULL,
	[SectorComercio] [nvarchar](3) NULL,
	[SubSectorComercio] [nvarchar](3) NULL,
	[Eliminado] [bit] NOT NULL,
	[FechaEliminado] [datetime] NULL,
 CONSTRAINT [PK_PTC_MaestroClientes] PRIMARY KEY CLUSTERED 
(
	[Cia] ASC,
	[CodClteApls] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PTC_MaestroPgms]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_MaestroPgms](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[NombreFrm] [nvarchar](100) NOT NULL,
	[CodigoApls] [nvarchar](3) NOT NULL,
	[CodigoTipoPgm] [nvarchar](2) NULL,
	[OrdenDelFrmEnApls] [smallint] NOT NULL,
	[DescripcionFrm] [nvarchar](60) NULL,
	[DescripcionCompletaFrm] [nvarchar](120) NULL,
	[Grupo] [int] NULL,
 CONSTRAINT [PK_PTC_MaestroPgms] PRIMARY KEY CLUSTERED 
(
	[NombreFrm] ASC,
	[CodigoApls] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_MaestroPrestamos]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_MaestroPrestamos](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[Contrato] [nvarchar](8) NOT NULL,
	[CodigoCliente] [nvarchar](8) NOT NULL,
	[FechaPtm] [datetime] NOT NULL,
	[MontoPtm] [money] NULL,
	[CuotasPtm] [smallint] NULL,
	[CuotasTraspPtm] [smallint] NULL,
	[InteresPtm] [money] NULL,
	[OtrosPtm] [money] NULL,
	[FrecuenciaCuotaPtm] [tinyint] NULL,
	[TasaIntPtm] [float] NULL,
	[TasaMoraPtm] [float] NULL,
	[Cobrador] [nvarchar](4) NULL,
	[Vencimiento] [tinyint] NULL,
	[PagarePtm] [nvarchar](8) NULL,
	[InicialPtm] [money] NULL,
	[CuentaCont] [nvarchar](14) NOT NULL,
	[StatusPtm] [nvarchar](1) NULL,
	[InteresAntPtm] [money] NULL,
	[ComisionPtm] [money] NULL,
	[ComisionAntPtm] [money] NULL,
	[ComisionVentas] [money] NULL,
	[TraspasoPtm] [money] NULL,
	[RegistroPtm] [money] NULL,
	[SeguroPtm] [money] NULL,
	[ExoneracionPtm] [money] NULL,
	[LegalPtm] [money] NULL,
	[CuentaCiiu] [nvarchar](14) NULL,
	[TasaComPtm] [float] NULL,
	[TasaComisionVentas] [float] NULL,
	[Oficial] [nvarchar](4) NOT NULL,
	[Corredor] [nvarchar](6) NULL,
	[Producto] [nvarchar](4) NULL,
	[Clasificacion] [nvarchar](4) NULL,
	[Moneda] [nvarchar](2) NULL,
	[TipoGarantiaPtm] [nvarchar](3) NULL,
	[PeriodoGracias] [smallint] NULL,
	[PagosEspeciales] [tinyint] NULL,
	[AbsolutoInsoluto] [tinyint] NULL,
	[CobrosSobreSaldos] [tinyint] NULL,
	[TipoTabla] [tinyint] NULL,
	[NumeroCheque] [nvarchar](8) NULL,
	[CodigoFiador] [nvarchar](14) NULL,
	[NCF] [nvarchar](19) NULL,
	[NotaPtm] [nvarchar](100) NULL,
 CONSTRAINT [PK_PTC_MaestroPrestamos] PRIMARY KEY CLUSTERED 
(
	[Contrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_MaestroUsuarios]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_MaestroUsuarios](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[IdentificacionUsr] [nvarchar](20) NOT NULL,
	[ClaveDeAccesoUsr] [nvarchar](20) NOT NULL,
	[NombreUsr] [nvarchar](50) NULL,
	[CodigoCia] [nvarchar](3) NOT NULL,
	[TodoTipoAccesoCia] [tinyint] NULL,
	[EscribirUsr] [tinyint] NULL,
	[LeerUsr] [tinyint] NULL,
	[ActualizarUsr] [tinyint] NULL,
	[EliminarUsr] [tinyint] NULL,
	[Consolidado] [int] NULL,
 CONSTRAINT [PK_PTC_MaestroUsuarios] PRIMARY KEY CLUSTERED 
(
	[IdentificacionUsr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_MovimientosRelacionCobradores]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_MovimientosRelacionCobradores](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[CodigoCobrador] [nvarchar](6) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Contrato] [nvarchar](10) NOT NULL,
	[CodigoCliente] [nvarchar](15) NOT NULL,
	[NombreApls] [nvarchar](255) NULL,
	[CedulaRnc] [nvarchar](50) NULL,
	[FechaUltimoPago] [datetime] NULL,
	[ValorUltimoPago] [money] NULL,
	[Pagadas] [nvarchar](3) NULL,
	[Pendientes] [nvarchar](3) NULL,
	[ValorCuotaCap] [money] NULL,
	[ValorCuotaInt] [money] NULL,
	[ValorCuotaCom] [money] NULL,
	[ValorCuotaOtros] [money] NULL,
	[ValorPagoCap] [money] NULL,
	[ValorPagoInt] [money] NULL,
	[ValorPagoCom] [money] NULL,
	[ValorPagoOtros] [money] NULL,
	[BceIntAdicional] [money] NULL,
	[BceMora] [money] NULL,
	[BceAuxiliar] [money] NULL,
	[PagosEspeciales] [int] NULL,
	[DetalleCuotasEspeciales] [ntext] NULL,
	[FechaCuotas] [ntext] NULL,
	[CodigoMoneda] [nvarchar](2) NULL,
	[NombreMoneda] [nvarchar](20) NULL,
	[NombreCompañia] [nvarchar](250) NULL,
	[DireccionCliente] [nvarchar](300) NULL,
 CONSTRAINT [PK_PTC_MovimientosRelacionCobradores] PRIMARY KEY CLUSTERED 
(
	[CodigoCobrador] ASC,
	[Fecha] ASC,
	[Contrato] ASC,
	[CodigoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_PagosDePrestamo]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_PagosDePrestamo](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[Contrato] [nvarchar](8) NOT NULL,
	[FechaDocCont] [datetime] NOT NULL,
	[TipoDocCont] [nvarchar](2) NOT NULL,
	[NumDocCont] [nvarchar](8) NOT NULL,
	[MovDocCont] [tinyint] NOT NULL,
	[CodigoCobrador] [nvarchar](4) NULL,
	[ValorPagoCapital] [money] NULL,
	[ValorPagoInteres] [money] NULL,
	[ValorPagoComision] [money] NULL,
	[valorPagoComisionVenta] [money] NULL,
	[ValorpagoMora] [money] NULL,
	[ValorPagoTraspaso] [money] NULL,
	[ValorPagoRegistro] [money] NULL,
	[ValorPagoSeguro] [money] NULL,
	[ValorPagoExoneracion] [money] NULL,
	[ValorPagoLegal] [money] NULL,
	[ValorPagoOtros] [money] NULL,
	[NCF] [nvarchar](19) NULL,
	[NoTransaccion] [nvarchar](10) NULL,
 CONSTRAINT [PK_PTC_PagosDePrestamo] PRIMARY KEY CLUSTERED 
(
	[Contrato] ASC,
	[FechaDocCont] ASC,
	[TipoDocCont] ASC,
	[NumDocCont] ASC,
	[MovDocCont] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_Parametros]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_Parametros](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[ID] [int] NOT NULL,
	[SecuenciaRc] [nvarchar](8) NOT NULL,
	[CampoControl] [nvarchar](10) NOT NULL,
	[Fecha_ult_Mayor] [datetime] NULL,
	[PrefijoCtaActivos] [nvarchar](14) NULL,
	[PrefijoCtaCostos] [nvarchar](14) NULL,
	[PreFijoCtaIngresos] [nvarchar](14) NULL,
	[PrefijoCtaGastos] [nvarchar](14) NULL,
	[CuentaResultado] [nvarchar](14) NULL,
	[LONGITUD] [tinyint] NULL,
	[SEPARADOR] [nvarchar](1) NULL,
	[PREFIJO_LARGAD] [nvarchar](4) NULL,
	[Itbis] [int] NULL,
	[MascaraCuentas] [nvarchar](50) NULL,
	[Marque] [int] NULL,
	[SobreGiro] [int] NULL,
	[TipoCheque] [int] NULL,
	[TipoRecibo] [int] NULL,
	[FechaUltCInv] [datetime] NULL,
	[FechaUltCActivos] [datetime] NULL,
	[FechaUltimaPosicion] [datetime] NULL,
	[FechaUltAuxiliar] [datetime] NULL,
	[super] [int] NULL,
	[certi] [int] NULL,
	[ruta] [nvarchar](50) NULL,
	[CxC] [nvarchar](50) NULL,
	[CxP] [nvarchar](50) NULL,
	[Prestamo] [nvarchar](50) NULL,
	[cuentacaja] [nvarchar](50) NULL,
	[DescuentoCxC] [nvarchar](50) NULL,
	[DescuentoCxP] [nvarchar](50) NULL,
	[ActualizaCondeCxC] [nvarchar](50) NULL,
	[ActualizaCondeCxP] [nvarchar](50) NULL,
	[FechaCierreCxC] [datetime] NULL,
	[conItbis] [int] NULL,
	[ActualizaInvaCxP] [nvarchar](50) NULL,
	[IdInv] [nvarchar](20) NULL,
	[DIFERENCIA] [money] NULL,
	[Regulada] [int] NULL,
	[PrecioDeVentaITBISNoSi] [int] NULL,
	[CostoConITBISNoSi] [int] NULL,
	[EmiteRcCont] [nvarchar](3) NULL,
	[CodificaRcCont] [nvarchar](3) NULL,
	[EmiteFt] [nvarchar](3) NULL,
	[ModificaFT] [nvarchar](3) NULL,
	[ApruebaCredito] [nvarchar](3) NULL,
	[ApruebaCreditoconAtraso] [nvarchar](3) NULL,
	[ApruebaMora] [nvarchar](5) NULL,
	[PorcientoMora] [nvarchar](5) NULL,
	[EmiteRcCXC] [nvarchar](3) NULL,
	[EmiteSolicitudChk] [nvarchar](3) NULL,
	[CodificaSolicitudChk] [nvarchar](3) NULL,
	[RevisarSolicitudChk] [nvarchar](3) NULL,
	[ApruebasolicitudChk] [nvarchar](3) NULL,
	[CantidadCia] [int] NULL,
	[PorIncrementoActivo] [float] NULL,
	[CuantaDeVoluciones] [nvarchar](14) NULL,
	[CuentaDeDVSinCargoEnCXC] [nvarchar](14) NULL,
	[CuentaFuncionarioEmp] [nvarchar](14) NULL,
	[RealizarDescuento] [nvarchar](3) NULL,
	[BajaPrecio] [nvarchar](3) NULL,
	[PrecioXdeBajoCosto] [nvarchar](3) NULL,
	[CuentaCartera] [nvarchar](14) NULL,
	[CInteres] [nvarchar](14) NULL,
	[cComision] [nvarchar](14) NULL,
	[cComisionVenta] [nvarchar](14) NULL,
	[cMora] [nvarchar](14) NULL,
	[cCaja] [nvarchar](14) NULL,
	[cAdjudicado] [nvarchar](14) NULL,
	[NoCobrable] [nvarchar](14) NULL,
	[CuentaAuxiliarPr] [nvarchar](14) NULL,
	[cOtros] [nvarchar](14) NULL,
	[cAdministrativo] [nvarchar](14) NULL,
	[cLegal] [nvarchar](14) NULL,
	[cSeguro] [nvarchar](14) NULL,
	[cExoneracion] [nvarchar](14) NULL,
	[cTraspaso] [nvarchar](14) NULL,
	[cRegistro] [nvarchar](14) NULL,
	[cInteresCXC] [nvarchar](14) NULL,
	[cComisionesCXC] [nvarchar](14) NULL,
	[cInteresAnt] [nvarchar](14) NULL,
	[cComisionesAnt] [nvarchar](14) NULL,
	[GridComisiones] [bit] NOT NULL,
	[GridComisionVenta] [bit] NOT NULL,
	[GridRegistro] [bit] NOT NULL,
	[GridSeguro] [bit] NOT NULL,
	[GridExoneracion] [bit] NOT NULL,
	[GridLegal] [bit] NOT NULL,
	[GridOtros] [bit] NOT NULL,
	[GridTraspaso] [bit] NOT NULL,
	[GridCalculo] [bit] NOT NULL,
	[ApruebaNotaCredito] [nvarchar](3) NULL,
	[RealizaCambioTasaCer] [nvarchar](3) NULL,
	[RealizaRetiroInt] [nvarchar](3) NULL,
	[FechaCierreCer] [datetime] NULL,
	[FechaCalculoCer] [datetime] NULL,
	[CuentaInteresCertificado] [nvarchar](15) NULL,
	[CuentaCapitalsCertificado1] [nvarchar](15) NULL,
	[CuentaCapitalsCertificado2] [nvarchar](15) NULL,
	[DigitaSolicitudPr] [nvarchar](3) NULL,
	[RevisaSolicitudPr] [nvarchar](3) NULL,
	[ApruebaSolicitudPr] [nvarchar](3) NULL,
	[ApruebaDesembolsoPr] [nvarchar](3) NULL,
	[ApruebaDesembolsoPrPrestamo] [nvarchar](6) NULL,
	[DepuradoPorPr] [nvarchar](6) NULL,
	[VerificadoDomPr] [nvarchar](6) NULL,
	[AnalizadoPr] [nvarchar](6) NULL,
	[ApruebaCalculoInteresDevengado] [nvarchar](6) NULL,
	[gGestionFinanciera] [bit] NULL,
	[AnularPrestamo] [nvarchar](6) NULL,
	[AutorizaNcyPagoSoloCapital] [nvarchar](6) NULL,
 CONSTRAINT [PK_PTC_Parametros] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_ProgramasPorUsuarios]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_ProgramasPorUsuarios](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[IdentificacionUsr] [nvarchar](12) NOT NULL,
	[CodigoApls] [nvarchar](3) NOT NULL,
	[NombreFrm] [nvarchar](100) NOT NULL,
	[TodoTipoAccesUsrpgms] [tinyint] NULL,
	[EscribirUsrpgms] [tinyint] NULL,
	[LeerUsrpgms] [tinyint] NULL,
	[ModificarUsrpgms] [tinyint] NULL,
	[EliminarUsrpgms] [tinyint] NULL,
 CONSTRAINT [PK_PTC_ProgramasPorUsuarios] PRIMARY KEY CLUSTERED 
(
	[IdentificacionUsr] ASC,
	[CodigoApls] ASC,
	[NombreFrm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_rptCalculoMoraPrestamo]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_rptCalculoMoraPrestamo](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[Cuota] [nvarchar](7) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Valor] [money] NOT NULL,
	[Dias] [nvarchar](6) NOT NULL,
	[Calculo] [money] NOT NULL,
	[TasaAnual] [nvarchar](5) NOT NULL,
	[PC] [nvarchar](20) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_rptCuotasVencidasYNoSaldadas]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_rptCuotasVencidasYNoSaldadas](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[CodigoCliente] [nvarchar](17) NOT NULL,
	[Contrato] [nvarchar](10) NOT NULL,
	[Cuotas] [nvarchar](10) NOT NULL,
	[Capital] [money] NOT NULL,
	[Interes] [money] NOT NULL,
	[Comision] [money] NOT NULL,
	[ComisionVenta] [money] NOT NULL,
	[Traspaso] [money] NOT NULL,
	[Registro] [money] NOT NULL,
	[Seguro] [money] NOT NULL,
	[Exoneracion] [money] NOT NULL,
	[Legal] [money] NOT NULL,
	[Otros] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[FechaCuotas] [datetime] NOT NULL,
	[PC] [nvarchar](20) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_rptListaMovimientosPrestamo]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_rptListaMovimientosPrestamo](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[Contrato] [nvarchar](10) NOT NULL,
	[CodigoCliente] [nvarchar](10) NOT NULL,
	[Cliente] [nvarchar](200) NOT NULL,
	[Mov] [nvarchar](2) NOT NULL,
	[Dia] [int] NOT NULL,
	[Documento] [nvarchar](15) NOT NULL,
	[Capital] [money] NOT NULL,
	[Interes] [money] NOT NULL,
	[Mora] [money] NOT NULL,
	[Otros] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[PC] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_rptMovimientosPrestamo]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_rptMovimientosPrestamo](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[Fecha] [datetime] NOT NULL,
	[Documento] [nvarchar](11) NOT NULL,
	[Movimiento] [nvarchar](7) NOT NULL,
	[Capital] [money] NOT NULL,
	[Interes] [money] NOT NULL,
	[Otros] [money] NOT NULL,
	[Mora] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[PC] [nvarchar](20) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_rptTasaRendimiento]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_rptTasaRendimiento](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[Cuota] [nvarchar](3) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[ValorCuota] [money] NOT NULL,
	[Interes] [money] NOT NULL,
	[Comision] [money] NOT NULL,
	[Otros] [money] NOT NULL,
	[Amortizar] [money] NOT NULL,
	[Saldo] [money] NOT NULL,
	[PC] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_SecuenciaPrestamos]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_SecuenciaPrestamos](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[SecuenciaPr] [nvarchar](8) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_TipoDocumento]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_TipoDocumento](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[IDTipoDoc] [nvarchar](2) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
	[NCF] [nvarchar](11) NULL,
	[Secuencia] [nvarchar](8) NULL,
	[PreSecuencia] [nvarchar](8) NULL,
	[siCargo] [tinyint] NULL,
	[Almacen] [nvarchar](4) NULL,
 CONSTRAINT [PK_PTC_TipoDocumento] PRIMARY KEY CLUSTERED 
(
	[IDTipoDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PTC_tmpReporteInteresComision]    Script Date: 20/03/2019 4:19:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTC_tmpReporteInteresComision](
	[Cia] [nvarchar](3) NOT NULL,
	[fechaHoraReg] [datetime] NULL,
	[Usuario] [nvarchar](40) NULL,
	[Prestmos] [nvarchar](10) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Balance] [money] NOT NULL,
	[Interes] [money] NOT NULL,
	[Comision] [money] NOT NULL,
	[Otros] [money] NOT NULL,
	[CuotaVenc] [int] NOT NULL,
	[DiasVenc] [int] NOT NULL,
	[Mora] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[PC] [nvarchar](100) NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PTC_MaestroClientes] ADD  CONSTRAINT [DF_PTC_MaestroClientes_ProveedorCliente]  DEFAULT ((1)) FOR [ClienteGeneral]
GO
