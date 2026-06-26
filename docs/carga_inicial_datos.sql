SET NOCOUNT ON;
GO

/*
    Script de carga inicial para StrategIA 360
    Fuente funcional:
    - docs/Resumen_Sistema.docx
    - docs/Especificacion_Tecnica.docx

    Criterios:
    - Idempotente: usa IF NOT EXISTS para no duplicar catÃ¡logos ni datos base.
    - Cubre todas las tablas fÃ­sicas del modelo actual.
    - Inserta catÃ¡logos operativos y un set pequeÃ±o de datos transaccionales de ejemplo.
*/

DECLARE @Tienda VARCHAR(32) = 'ADN';
DECLARE @Ciudad VARCHAR(64) = 'PEDERNALES';
DECLARE @UsuarioSistema VARCHAR(32) = 'SEED';
DECLARE @Oficina INT = 1;
DECLARE @Estacion VARCHAR(32) = 'SCRIPT';
DECLARE @Hoy DATETIME = GETDATE();
DECLARE @HoyDate DATE = CAST(GETDATE() AS DATE);

/*==============================================================*/
/* 1. ROLES ORGANIZACIONALES                                    */
/*==============================================================*/
INSERT INTO dbo.RolOrganizacional
(
    Tienda, CodigoRol, NombreRol, NivelJerarquico, EsComando, Activo,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT v.Tienda, v.CodigoRol, v.NombreRol, v.NivelJerarquico, v.EsComando, 1,
       @Hoy, @UsuarioSistema, @Oficina, @Estacion
FROM
(
    VALUES
    (@Tienda, 'CONSUL',        'Jefe de CampaÃ±a',      1, 1),
    (@Tienda, 'GRAL_TIERRA',   'General de Tierra',    2, 1),
    (@Tienda, 'GRAL_ESTRAT',   'General Estratega',    2, 1),
    (@Tienda, 'CENTURION',     'CenturiÃ³n',            3, 0),
    (@Tienda, 'RELATOR',       'Relator',              4, 0),
    (@Tienda, 'SOLDADO',       'Soldado',              4, 0),
    (@Tienda, 'EXPLORADOR',    'Explorador',           4, 0)
) v(Tienda, CodigoRol, NombreRol, NivelJerarquico, EsComando)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.RolOrganizacional r
    WHERE r.Tienda = v.Tienda
      AND r.CodigoRol = v.CodigoRol
);
GO

/*==============================================================*/
/* 2. CENTURIAS                                                 */
/*==============================================================*/
INSERT INTO dbo.Centuria
(
    Tienda, Ciudad, CodigoCenturia, NombreCenturia, ParroquiaPrincipal,
    Descripcion, MetaContactosSemana, Activo,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT v.Tienda, v.Ciudad, v.CodigoCenturia, v.NombreCenturia, v.ParroquiaPrincipal,
       v.Descripcion, v.MetaContactosSemana, 1,
       GETDATE(), 'SEED', 1, 'SCRIPT'
FROM
(
    VALUES
    ('ADN', 'PEDERNALES', 'PEDERNALES',    'Centuria Pedernales',    'PEDERNALES',   'Casco urbano de Pedernales; 9 circuitos electorales; mayor densidad electoral.', 833),
    ('ADN', 'PEDERNALES', 'COJIMIES',      'Centuria CojimÃ­es',      'COJIMIES',     'Zona costera y comunidades remotas con acceso mixto vial y fluvial.',              833),
    ('ADN', 'PEDERNALES', '10_DE_AGOSTO',  'Centuria 10 de Agosto',  '10 DE AGOSTO', 'Zona agropecuaria; necesidades frecuentes de vialidad y riego.',                    833),
    ('ADN', 'PEDERNALES', 'ATAHUALPA',     'Centuria Atahualpa',     'ATAHUALPA',    'Zona de arraigo natural de la candidata y valor estratÃ©gico territorial.',          833)
) v(Tienda, Ciudad, CodigoCenturia, NombreCenturia, ParroquiaPrincipal, Descripcion, MetaContactosSemana)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Centuria c
    WHERE c.Tienda = v.Tienda
      AND c.Ciudad = v.Ciudad
      AND c.CodigoCenturia = v.CodigoCenturia
);
GO

/*==============================================================*/
/* 3. TERRITORIOS                                               */
/*==============================================================*/
INSERT INTO dbo.Territorio
(
    Tienda, Ciudad, CodigoTerritorio, CodigoCenturia, TipoTerritorio, NombreTerritorio,
    Parroquia, Barrio, EstadoCobertura, Activo,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT v.Tienda, v.Ciudad, v.CodigoTerritorio, v.CodigoCenturia, v.TipoTerritorio, v.NombreTerritorio,
       v.Parroquia, v.Barrio, v.EstadoCobertura, 1,
       GETDATE(), 'SEED', 1, 'SCRIPT'
FROM
(
    VALUES
    ('ADN', 'PEDERNALES', 'DOGOLA',                     'COJIMIES',     'SECTOR',   'Dogola',                                      'COJIMIES',     'DOGOLA',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'DOGILITA_ARRIBA',            'COJIMIES',     'SECTOR',   'Dogilita Arriba',                             'COJIMIES',     'DOGILITA ARRIBA',     'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'DOGILITA_ABAJO',             'COJIMIES',     'SECTOR',   'Dogilita Abajo',                              'COJIMIES',     'DOGILITA ABAJO',      'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'AGUACATAL',                  'COJIMIES',     'SECTOR',   'Aguacatal',                                   'COJIMIES',     'AGUACATAL',           'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'AGUA_FRIA',                  'COJIMIES',     'SECTOR',   'Agua Fria',                                   'COJIMIES',     'AGUA FRIA',           'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'COJIMIES',                   'COJIMIES',     'SECTOR',   'Cojimies',                                    'COJIMIES',     'COJIMIES',            'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CHARCA_LECHUGAL',            'COJIMIES',     'SECTOR',   'Charca de Lechugal',                          'COJIMIES',     'CHARCA DE LECHUGAL',  'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LECHUGAL',                   'COJIMIES',     'SECTOR',   'Lechugal',                                    'COJIMIES',     'LECHUGAL',            'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CEDRAL',                     'COJIMIES',     'SECTOR',   'Cedral',                                      'COJIMIES',     'CEDRAL',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CARRIZAL',                   'COJIMIES',     'SECTOR',   'Carrizal',                                    'COJIMIES',     'CARRIZAL',            'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'GUIONAL',                    'COJIMIES',     'SECTOR',   'Guional',                                     'COJIMIES',     'GUIONAL',             'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'ACHIOTAL',                   'COJIMIES',     'SECTOR',   'Achiotal',                                    'COJIMIES',     'ACHIOTAL',            'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'JUANANU',                    'COJIMIES',     'SECTOR',   'Juananu',                                     'COJIMIES',     'JUANANU',             'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'PALMAR',                     'COJIMIES',     'SECTOR',   'Palmar',                                      'COJIMIES',     'PALMAR',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LA_VIRGINIA',                'COJIMIES',     'SECTOR',   'La Virginia',                                 'COJIMIES',     'LA VIRGINIA',         'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'COCOMAR',                    'COJIMIES',     'SECTOR',   'Cocomar',                                     'COJIMIES',     'COCOMAR',             'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'EL_CHURO',                   'COJIMIES',     'SECTOR',   'El Churo',                                    'COJIMIES',     'EL CHURO',            'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CANAVERAL',                  'COJIMIES',     'SECTOR',   'Canaveral',                                   'COJIMIES',     'CANAVERAL',           'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LA_BONILLA',                 'COJIMIES',     'SECTOR',   'La Bonilla',                                  'COJIMIES',     'LA BONILLA',          'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'PALANCONA',                  'COJIMIES',     'SECTOR',   'Palancona',                                   'COJIMIES',     'PALANCONA',           'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CASA_BLANCA',                'COJIMIES',     'SECTOR',   'Casa Blanca',                                 'COJIMIES',     'CASA BLANCA',         'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'EL_MATE',                    'COJIMIES',     'SECTOR',   'El Mate',                                     'COJIMIES',     'EL MATE',             'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'ZURRONES',                   'COJIMIES',     'SECTOR',   'Zurrones',                                    'COJIMIES',     'ZURRONES',            'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'SURRONES',                   'COJIMIES',     'SECTOR',   'Surrones',                                   'COJIMIES',     'SURRONES',            'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'SURRONES_PLAYA',             'COJIMIES',     'SECTOR',   'Surrones Playa',                             'COJIMIES',     'SURRONES PLAYA',      'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'EL_TORO',                    'COJIMIES',     'SECTOR',   'El Toro',                                    'COJIMIES',     'EL TORO',             'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CADIAL_SURRONES',            'COJIMIES',     'SECTOR',   'Cadial de Surrones',                         'COJIMIES',     'CADIAL DE SURRONES',  'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'MARCOS',                     'COJIMIES',     'SECTOR',   'Marcos',                                     'COJIMIES',     'MARCOS',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'MARCO_ARRIBA',               'COJIMIES',     'SECTOR',   'Marco Arriba',                               'COJIMIES',     'MARCO ARRIBA',        'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CANAR',                      'COJIMIES',     'SECTOR',   'Canar',                                      'COJIMIES',     'CANAR',               'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CHONTAL',                    'COJIMIES',     'SECTOR',   'Chontal',                                    'COJIMIES',     'CHONTAL',             'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LA_MOCORA',                  'COJIMIES',     'SECTOR',   'La Mocora',                                  'COJIMIES',     'LA MOCORA',           'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'IGUANA',                     'COJIMIES',     'SECTOR',   'Iguana',                                     'COJIMIES',     'IGUANA',              'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'PALMAR',                     'PEDERNALES',   'SECTOR',   'Palmar',                                     'PEDERNALES',   'PALMAR',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LA_CABUYA',                  'PEDERNALES',   'SECTOR',   'La Cabuya',                                  'PEDERNALES',   'LA CABUYA',           'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'TABUGA',                     'PEDERNALES',   'SECTOR',   'Tabuga',                                     'PEDERNALES',   'TABUGA',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'FLORIDA',                    'PEDERNALES',   'SECTOR',   'Florida',                                    'PEDERNALES',   'FLORIDA',             'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'GENARO',                     'PEDERNALES',   'SECTOR',   'Genaro',                                     'PEDERNALES',   'GENARO',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'GARRAPATA',                  'PEDERNALES',   'SECTOR',   'Garrapata',                                  'PEDERNALES',   'GARRAPATA',           'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'TALAMO',                     'PEDERNALES',   'SECTOR',   'Talamo',                                     'PEDERNALES',   'TALAMO',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'COAQUE',                     'PEDERNALES',   'SECTOR',   'Coaque',                                     'PEDERNALES',   'COAQUE',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CHIQUIMBLE',                 'PEDERNALES',   'SECTOR',   'Chiquimble',                                 'PEDERNALES',   'CHIQUIMBLE',          'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'ARRASTRADERO',               'PEDERNALES',   'SECTOR',   'Arrastradero',                               'PEDERNALES',   'ARRASTRADERO',        'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'PEDERNALES',                 'PEDERNALES',   'SECTOR',   'Pedernales',                                 'PEDERNALES',   'PEDERNALES',          'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'PUERTO_TIZAL',               'PEDERNALES',   'SECTOR',   'Puerto Tizal',                               'PEDERNALES',   'PUERTO TIZAL',        'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'AGUAS_AMARGAS',              'PEDERNALES',   'SECTOR',   'Aguas Amargas',                              'PEDERNALES',   'AGUAS AMARGAS',       'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LA_FRONDA',                  'PEDERNALES',   'SECTOR',   'La Fronda',                                  'PEDERNALES',   'LA FRONDA',           'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LAGUNA_NALPE',               'PEDERNALES',   'SECTOR',   'Laguna de Nalpe',                            'PEDERNALES',   'LAGUNA DE NALPE',     'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'EL_ACHIOTE',                 'PEDERNALES',   'SECTOR',   'El Achiote',                                 'PEDERNALES',   'EL ACHIOTE',          'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'EL_RETIRO',                  'PEDERNALES',   'SECTOR',   'El Retiro',                                  'PEDERNALES',   'EL RETIRO',           'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'GUAYAQUILITO',               'PEDERNALES',   'SECTOR',   'Guayaquilito',                               'PEDERNALES',   'GUAYAQUILITO',        'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'ESTERO_HONDO',               'PEDERNALES',   'SECTOR',   'Estero Hondo',                               'PEDERNALES',   'ESTERO HONDO',        'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'VILELA',                     'PEDERNALES',   'SECTOR',   'Vilela',                                     'PEDERNALES',   'VILELA',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'ZAPATA',                     'PEDERNALES',   'SECTOR',   'Zapata',                                     'PEDERNALES',   'ZAPATA',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LA_PUNTILLA',                'PEDERNALES',   'SECTOR',   'La Puntilla',                                'PEDERNALES',   'LA PUNTILLA',         'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'BOCA_DE_PUEBLO',             'PEDERNALES',   'SECTOR',   'Boca de Pueblo',                              'PEDERNALES',   'BOCA DE PUEBLO',      'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LOS_LAS_TRES',               'PEDERNALES',   'SECTOR',   'Los Las Tres',                                'PEDERNALES',   'LOS LAS TRES',        'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'PLATANO',                    'PEDERNALES',   'SECTOR',   'Platano',                                     'PEDERNALES',   'PLATANO',             'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'ISLA_BLASA',                 'PEDERNALES',   'SECTOR',   'Isla Blasa',                                  'PEDERNALES',   'ISLA BLASA',          'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LAJERO',                     'PEDERNALES',   'SECTOR',   'Lajero',                                     'PEDERNALES',   'LAJERO',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'PRECIADO',                   'PEDERNALES',   'SECTOR',   'Preciado',                                   'PEDERNALES',   'PRECIADO',            'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'LAS_PALOMAS',                'PEDERNALES',   'SECTOR',   'Las Palomas',                                'PEDERNALES',   'LAS PALOMAS',         'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'TRES_CAMINO',                'PEDERNALES',   'SECTOR',   'Tres Camino',                                'PEDERNALES',   'TRES CAMINO',         'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'VENADO',                     'PEDERNALES',   'SECTOR',   'Venado',                                     'PEDERNALES',   'VENADO',              'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'LA_PIMIENTA',                'PEDERNALES',   'SECTOR',   'La Pimienta',                                'PEDERNALES',   'LA PIMIENTA',         'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'GUACHARACAL',                'PEDERNALES',   'SECTOR',   'Guacharacal',                                'PEDERNALES',   'GUACHARACAL',         'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CIEGO',                      'PEDERNALES',   'SECTOR',   'Ciego',                                      'PEDERNALES',   'CIEGO',               'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'LAS_BALSAS',                 'PEDERNALES',   'SECTOR',   'Las Balsas',                                 'PEDERNALES',   'LAS BALSAS',          'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'SERRANO',                    'PEDERNALES',   'SECTOR',   'Serrano',                                    'PEDERNALES',   'SERRANO',             'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CHEMERE',                    'PEDERNALES',   'SECTOR',   'Chemere',                                    'PEDERNALES',   'CHEMERE',             'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'PIEDRA_NALUCA',              'ATAHUALPA',    'SECTOR',   'Piedra Naluca',                              'ATAHUALPA',    'PIEDRA NALUCA',       'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CADIALES',                   'ATAHUALPA',    'SECTOR',   'Cadiales',                                   'ATAHUALPA',    'CADIALES',            'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'EL_SALADO',                  'ATAHUALPA',    'SECTOR',   'El Salado',                                  'ATAHUALPA',    'EL SALADO',           'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'VALENTIN',                   'ATAHUALPA',    'SECTOR',   'Valentin',                                   'ATAHUALPA',    'VALENTIN',            'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'PIEDRA_MALUCA',              'ATAHUALPA',    'SECTOR',   'Piedra Maluca',                              'ATAHUALPA',    'PIEDRA MALUCA',       'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'PATA_DE_PAJARO',             'ATAHUALPA',    'SECTOR',   'Pata de Pajaro',                             'ATAHUALPA',    'PATA DE PAJARO',      'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'PERALTA',                    'ATAHUALPA',    'SECTOR',   'Peralta',                                    'ATAHUALPA',    'PERALTA',             'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'LOS_PLATOS',                 'ATAHUALPA',    'SECTOR',   'Los Platos',                                 'ATAHUALPA',    'LOS PLATOS',          'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LA_MUERTE',                  'ATAHUALPA',    'SECTOR',   'La Muerte',                                  'ATAHUALPA',    'LA MUERTE',           'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'PALMAR',                     'ATAHUALPA',    'SECTOR',   'Palmar',                                     'ATAHUALPA',    'PALMAR',              'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'DON_PEPE',                   'ATAHUALPA',    'SECTOR',   'Don Pepe',                                   'ATAHUALPA',    'DON PEPE',            'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'CHIAL',                      'ATAHUALPA',    'SECTOR',   'Chial',                                      'ATAHUALPA',    'CHIAL',               'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'SANTA_ROSA',                 'ATAHUALPA',    'SECTOR',   'Santa Rosa',                                 'ATAHUALPA',    'SANTA ROSA',          'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'SAN_JOSE_DE_JAMA',           '10_DE_AGOSTO', 'SECTOR',   'San Jose de Jama',                           '10 DE AGOSTO', 'SAN JOSE DE JAMA',    'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'SAN_JOSE_ARRIBA',            '10_DE_AGOSTO', 'SECTOR',   'San Jose de Arriba',                         '10 DE AGOSTO', 'SAN JOSE DE ARRIBA',  'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'SAN_JOSE_MEDIO',             '10_DE_AGOSTO', 'SECTOR',   'San Jose de Medio',                          '10 DE AGOSTO', 'SAN JOSE DE MEDIO',   'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'SAN_JOSE_ABAJO',             '10_DE_AGOSTO', 'SECTOR',   'San Jose de Abajo',                          '10 DE AGOSTO', 'SAN JOSE DE ABAJO',   'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', '10_DE_AGOSTO',               '10_DE_AGOSTO', 'SECTOR',   '10 de Agosto',                               '10 DE AGOSTO', '10 DE AGOSTO',        'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'SAN_RAMON',                  '10_DE_AGOSTO', 'SECTOR',   'San Ramon',                                  '10 DE AGOSTO', 'SAN RAMON',           'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'GUINEAL',                    '10_DE_AGOSTO', 'SECTOR',   'Guineal',                                    '10 DE AGOSTO', 'GUINEAL',             'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'AGUA_FRIA',                  '10_DE_AGOSTO', 'SECTOR',   'Agua Fria',                                  '10 DE AGOSTO', 'AGUA FRIA',           'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LA_HUMEDAD',                 '10_DE_AGOSTO', 'SECTOR',   'La Humedad',                                 '10 DE AGOSTO', 'LA HUMEDAD',          'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'SANTA_ROSA',                 '10_DE_AGOSTO', 'SECTOR',   'Santa Rosa',                                 '10 DE AGOSTO', 'SANTA ROSA',          'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'ZAPALLO_ABAJO',              '10_DE_AGOSTO', 'SECTOR',   'Zapallo Abajo',                              '10 DE AGOSTO', 'ZAPALLO ABAJO',       'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'TAVIZA',                     '10_DE_AGOSTO', 'SECTOR',   'Taviza',                                     '10 DE AGOSTO', 'TAVIZA',              'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'EL_JORDAN',                  '10_DE_AGOSTO', 'SECTOR',   'El Jordan',                                  '10 DE AGOSTO', 'EL JORDAN',           'SIN_CONTACTO'),

    ('ADN', 'PEDERNALES', 'LA_BELLA_DE_TAVIZA',         '10_DE_AGOSTO', 'SECTOR',   'La Bella de Taviza',                         '10 DE AGOSTO', 'LA BELLA DE TAVIZA',  'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'BOCA_DE_TIGRE',              '10_DE_AGOSTO', 'SECTOR',   'Boca de Tigre',                              '10 DE AGOSTO', 'BOCA DE TIGRE',       'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'SANTA_TEREZA',               '10_DE_AGOSTO', 'SECTOR',   'Santa Tereza',                               '10 DE AGOSTO', 'SANTA TEREZA',        'SIN_CONTACTO'),
    ('ADN', 'PEDERNALES', 'LA_GLORIA',                  '10_DE_AGOSTO', 'SECTOR',   'La Gloria',                                  '10 DE AGOSTO', 'LA GLORIA',           'SIN_CONTACTO')
) v(Tienda, Ciudad, CodigoTerritorio, CodigoCenturia, TipoTerritorio, NombreTerritorio, Parroquia, Barrio, EstadoCobertura)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Territorio t
    WHERE t.Tienda = v.Tienda
      AND t.Ciudad = v.Ciudad
      AND t.CodigoCenturia = v.CodigoCenturia
      AND t.CodigoTerritorio = v.CodigoTerritorio
);
GO

/*==============================================================*/
/* 4. USUARIOS ORGANIZACIONALES                                 */
/*==============================================================*/
INSERT INTO dbo.UsuarioOrganizacional
(
    Tienda, CodigoUsuario, CodigoRol, CodigoCenturia, Nombres, Apellidos,
    Telefono, UsuarioLogin, Activo,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT v.Tienda, v.CodigoUsuario, v.CodigoRol, v.CodigoCenturia, v.Nombres, v.Apellidos,
       v.Telefono, v.UsuarioLogin, 1,
       GETDATE(), 'SEED', 1, 'SCRIPT'
FROM
(
    VALUES
    ('ADN', 'USR_CONSUL',  'CONSUL',      NULL,      'OMAR',      'TOAPANTA',  '0990000001', 'consul@strategia.local'),
    ('ADN', 'USR_GT001',   'GRAL_TIERRA', NULL,      'PATRICIO',  'MENDOZA',   '0990000002', 'gtierra@strategia.local'),
    ('ADN', 'USR_GE001',   'GRAL_ESTRAT', NULL,      'ANA',       'CEVALLOS',  '0990000003', 'gestratega@strategia.local'),
    ('ADN', 'USR_CEN_PED', 'CENTURION',   'PEDERNALES',   'MARIO',     'ALCIVAR',   '0990000011', 'centurion.ped@strategia.local'),
    ('ADN', 'USR_CEN_COJ', 'CENTURION',   'COJIMIES',     'LUCIA',     'MENDOZA',   '0990000012', 'centurion.coj@strategia.local'),
    ('ADN', 'USR_CEN_10A', 'CENTURION',   '10_DE_AGOSTO', 'JORGE',     'MOREIRA',   '0990000013', 'centurion.10a@strategia.local'),
    ('ADN', 'USR_CEN_ATA', 'CENTURION',   'ATAHUALPA',    'KARINA',    'INTRIAGO',  '0990000014', 'centurion.ata@strategia.local'),
    ('ADN', 'USR_REL_001', 'RELATOR',     'PEDERNALES',   'PAOLA',     'ZAMBRANO',  '0990000021', 'relator.001@strategia.local'),
    ('ADN', 'USR_REL_002', 'RELATOR',     'COJIMIES',     'JONATHAN',  'PALMA',     '0990000022', 'relator.002@strategia.local'),
    ('ADN', 'USR_REL_003', 'RELATOR',     '10_DE_AGOSTO', 'MELISSA',   'MORA',      '0990000023', 'relator.003@strategia.local'),
    ('ADN', 'USR_REL_004', 'RELATOR',     'ATAHUALPA',    'DAVID',     'CHAVEZ',    '0990000024', 'relator.004@strategia.local'),
    ('ADN', 'USR_SOL_001', 'SOLDADO',     'PEDERNALES',   'ELVIS',     'MIELES',    '0990000031', 'soldado.001@strategia.local'),
    ('ADN', 'USR_EXP_001', 'EXPLORADOR',  'PEDERNALES',   'SOFIA',     'VELASQUEZ', '0990000041', 'explorador.001@strategia.local'),
    ('ADN', 'USR_EXP_002', 'EXPLORADOR',  'COJIMIES',     'DIANA',     'SANTOS',    '0990000042', 'explorador.002@strategia.local'),
    ('ADN', 'USR_EXP_003', 'EXPLORADOR',  '10_DE_AGOSTO', 'ROBERTO',   'MENDOZA',   '0990000043', 'explorador.003@strategia.local'),
    ('ADN', 'USR_EXP_004', 'EXPLORADOR',  'ATAHUALPA',    'MARIANA',   'FARIAS',    '0990000044', 'explorador.004@strategia.local')
) v(Tienda, CodigoUsuario, CodigoRol, CodigoCenturia, Nombres, Apellidos, Telefono, UsuarioLogin)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.UsuarioOrganizacional u
    WHERE u.Tienda = v.Tienda
      AND u.CodigoUsuario = v.CodigoUsuario
);
GO

/*==============================================================*/
/* 5. MAESTRO DETALLE DE INTENCION DE VOTO                      */
/*==============================================================*/
INSERT INTO dbo.IntencionVotoGrupo
(
    Tienda, CodigoDignidad, FieldName, ObsFieldName, ObsLabel, Titulo, Orden, Activo,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT v.Tienda, v.CodigoDignidad, v.FieldName, v.ObsFieldName, v.ObsLabel, v.Titulo, v.Orden, 1,
       GETDATE(), 'SEED', 1, 'SCRIPT'
FROM
(
    VALUES
    ('ADN', 'ALCALDE',  'votoAlcalde',  'obsAlcalde',  'Observación para alcalde',  'Alcalde',  1),
    ('ADN', 'CONCEJAL', 'votoConcejal', 'obsConcejal', 'Observación para concejal', 'Concejal', 2),
    ('ADN', 'VOCALES',  'votoVocales',  'obsVocales',  'Observación para vocales',  'Vocales',  3)
) v(Tienda, CodigoDignidad, FieldName, ObsFieldName, ObsLabel, Titulo, Orden)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.IntencionVotoGrupo g
    WHERE g.Tienda = v.Tienda
      AND g.CodigoDignidad = v.CodigoDignidad
);
GO

INSERT INTO dbo.IntencionVotoOpcion
(
    Tienda, CodigoIntencionVotoOpcion, CodigoDignidad, NombreOpcion, Orden, Activo,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT v.Tienda, v.CodigoIntencionVotoOpcion, v.CodigoDignidad, v.NombreOpcion, v.Orden, 1,
       GETDATE(), 'SEED', 1, 'SCRIPT'
FROM
(
    VALUES
    ('ADN', 'PATRICIA_SALTOS', 'ALCALDE',  'Patricia Saltos', 1),
    ('ADN', 'DIEGO_CELORIO',   'ALCALDE',  'Diego Celorio',   2),
    ('ADN', 'SANTOS_CEDENO',   'ALCALDE',  'Santos Cedeño',   3),
    ('ADN', 'ROSY_PUERTAS',    'ALCALDE',  'Rosy Puertas',    4),
    ('ADN', 'DAVID_ZAMBRANO',  'ALCALDE',  'David Zambrano',  5),
    ('ADN', 'EDUARDO_CHICA',   'ALCALDE',  'Eduardo Chica',   6),
    ('ADN', 'ALC_INDECISO',        'ALCALDE',  'Indeciso',        7),
    ('ADN', 'ALC_BLANCO',          'ALCALDE',  'Voto blanco',     8),
    ('ADN', 'ALC_NULO',            'ALCALDE',  'Voto nulo',       9),
    ('ADN', 'ALC_NO_VOTA',         'ALCALDE',  'No vota',         10),
    ('ADN', 'ALC_NO_RESPONDE',     'ALCALDE',  'No responde',     11),

    ('ADN', 'CON_NUESTRO',     'CONCEJAL', 'Nuestra lista',     1),
    ('ADN', 'CON_COMP_A',      'CONCEJAL', 'Contrincante A',    2),
    ('ADN', 'CON_COMP_B',      'CONCEJAL', 'Contrincante B',    3),
    ('ADN', 'CON_INDECISO',    'CONCEJAL', 'Indeciso',          4),
    ('ADN', 'CON_BLANCO',      'CONCEJAL', 'Voto blanco',       5),
    ('ADN', 'CON_NULO',        'CONCEJAL', 'Voto nulo',         6),
    ('ADN', 'CON_NO_VOTA',     'CONCEJAL', 'No vota',           7),
    ('ADN', 'CON_NO_RESPONDE', 'CONCEJAL', 'No responde',       8),

    ('ADN', 'VOC_NUESTRO',     'VOCALES',  'Nuestra lista',     1),
    ('ADN', 'VOC_COMP_A',      'VOCALES',  'Contrincante A',    2),
    ('ADN', 'VOC_COMP_B',      'VOCALES',  'Contrincante B',    3),
    ('ADN', 'VOC_INDECISO',    'VOCALES',  'Indeciso',          4),
    ('ADN', 'VOC_BLANCO',      'VOCALES',  'Voto blanco',       5),
    ('ADN', 'VOC_NULO',        'VOCALES',  'Voto nulo',         6),
    ('ADN', 'VOC_NO_VOTA',     'VOCALES',  'No vota',           7),
    ('ADN', 'VOC_NO_RESPONDE', 'VOCALES',  'No responde',       8)
) v(Tienda, CodigoIntencionVotoOpcion, CodigoDignidad, NombreOpcion, Orden)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.IntencionVotoOpcion i
    WHERE i.Tienda = v.Tienda
      AND i.CodigoIntencionVotoOpcion = v.CodigoIntencionVotoOpcion
);
GO

/*==============================================================*/
/* 6. CIUDADANOS BASE                                           */
/*==============================================================*/
INSERT INTO dbo.Ciudadano
(
    Tienda, Ciudad, CodigoCenturia, CodigoTerritorio, Codigo, Nombres, Apellidos,
    NumeroCelular, Genero, MiembrosFamilia, MiembrosVotan, MiembrosDiscapacidad,
    Parroquia, Barrio, Direccion, PosX, PosY, Activo,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT v.Tienda, v.Ciudad, v.CodigoCenturia, v.CodigoTerritorio, v.Codigo, v.Nombres, v.Apellidos,
       v.NumeroCelular, v.Genero, v.MiembrosFamilia, v.MiembrosVotan, v.MiembrosDiscapacidad,
       v.Parroquia, v.Barrio, v.Direccion, v.PosX, v.PosY, 1,
       GETDATE(), 'SEED', 1, 'SCRIPT'
FROM
(
    VALUES
    ('ADN', 'PEDERNALES', 'PEDERNALES',   'PEDERNALES',   'CED001', 'JUAN CARLOS', 'PEREZ LOPEZ', '0991111111', 'masculino', 4, 3, 0, 'PEDERNALES',   'PEDERNALES',   'Calle 1 y Avenida 2',      CAST(-0.071234 AS DECIMAL(18,10)), CAST(-80.052345 AS DECIMAL(18,10))),
    ('ADN', 'PEDERNALES', 'COJIMIES',     'COJIMIES',     'CED002', 'MARIA JOSE',  'SUAREZ GILER','0992222222', 'femenino',  5, 4, 1, 'COJIMIES',     'COJIMIES',     'Malecon de Cojimies',      CAST( 0.068200 AS DECIMAL(18,10)), CAST(-80.045100 AS DECIMAL(18,10))),
    ('ADN', 'PEDERNALES', '10_DE_AGOSTO', '10_DE_AGOSTO', 'CED003', 'LUIS ALBERTO','MENDOZA RUIZ','0993333333', 'masculino', 6, 4, 0, '10 DE AGOSTO', '10 DE AGOSTO', 'Via principal junto al UPC', CAST(-0.088410 AS DECIMAL(18,10)), CAST(-79.989500 AS DECIMAL(18,10))),
    ('ADN', 'PEDERNALES', 'ATAHUALPA',    'PALMAR',       'CED004', 'ROSA ELENA',  'ZAMBRANO',    '0994444444', 'femenino',  3, 2, 0, 'ATAHUALPA',    'PALMAR',       'Frente al parque central', CAST(-0.105630 AS DECIMAL(18,10)), CAST(-79.958700 AS DECIMAL(18,10)))
) v(Tienda, Ciudad, CodigoCenturia, CodigoTerritorio, Codigo, Nombres, Apellidos, NumeroCelular, Genero, MiembrosFamilia, MiembrosVotan, MiembrosDiscapacidad, Parroquia, Barrio, Direccion, PosX, PosY)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Ciudadano c
    WHERE c.Tienda = v.Tienda
      AND c.Ciudad = v.Ciudad
      AND c.Codigo = v.Codigo
);
GO

/*==============================================================*/
/* 7. VISITAS BASE                                              */
/*==============================================================*/
DECLARE @IdCiudadano1 INT = (SELECT TOP 1 IdCiudadano FROM dbo.Ciudadano WHERE Tienda = 'ADN' AND Codigo = 'CED001');
DECLARE @IdCiudadano2 INT = (SELECT TOP 1 IdCiudadano FROM dbo.Ciudadano WHERE Tienda = 'ADN' AND Codigo = 'CED002');
DECLARE @IdCiudadano3 INT = (SELECT TOP 1 IdCiudadano FROM dbo.Ciudadano WHERE Tienda = 'ADN' AND Codigo = 'CED003');
DECLARE @IdCiudadano4 INT = (SELECT TOP 1 IdCiudadano FROM dbo.Ciudadano WHERE Tienda = 'ADN' AND Codigo = 'CED004');

INSERT INTO dbo.Visita
(
    IdCiudadano, Tienda, Ciudad, CodigoUsuario, CodigoCenturia, CodigoTerritorio,
    FechaVisita, ProblemaInterno, ProblemaFamiliar, TemaInteresReal, ReferidoNombres, ReferidoTelefono,
    NotaEncuestador, PosX, PosY, EstadoSync, Activo,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT v.IdCiudadano, v.Tienda, v.Ciudad, v.CodigoUsuario, v.CodigoCenturia, v.CodigoTerritorio,
       v.FechaVisita, v.ProblemaInterno, v.ProblemaFamiliar, v.TemaInteresReal, v.ReferidoNombres, v.ReferidoTelefono,
       v.NotaEncuestador, v.PosX, v.PosY, v.EstadoSync, 1,
       GETDATE(), 'SEED', 1, 'SCRIPT'
FROM
(
    VALUES
    (@IdCiudadano1, 'ADN', 'PEDERNALES', 'USR_REL_001', 'PEDERNALES',   'PEDERNALES',   DATEADD(DAY, -2, GETDATE()), 'Organizacion barrial debil.',   'Falta de alumbrado publico.', 'Seguridad ciudadana', 'PEDRO VERA', '0995555501', 'Ciudadano promovido con buen nivel de aceptacion.', CAST(-0.071234 AS DECIMAL(18,10)), CAST(-80.052345 AS DECIMAL(18,10)), 'SINCRONIZADO'),
    (@IdCiudadano2, 'ADN', 'PEDERNALES', 'USR_REL_002', 'COJIMIES',     'COJIMIES',     DATEADD(DAY, -2, GETDATE()), 'Baja coordinacion comunitaria.','Preocupacion por empleo local.', 'Empleo y turismo',    NULL,         NULL,         'Visita con interes medio y seguimiento pendiente.', CAST( 0.068200 AS DECIMAL(18,10)), CAST(-80.045100 AS DECIMAL(18,10)), 'SINCRONIZADO'),
    (@IdCiudadano3, 'ADN', 'PEDERNALES', 'USR_REL_003', '10_DE_AGOSTO', '10_DE_AGOSTO', DATEADD(DAY, -1, GETDATE()), 'Poca articulacion productiva.', 'Vias en mal estado.',           'Vialidad y riego',    NULL,         NULL,         'Necesita segunda visita para confirmar voto.',      CAST(-0.088410 AS DECIMAL(18,10)), CAST(-79.989500 AS DECIMAL(18,10)), 'SINCRONIZADO'),
    (@IdCiudadano4, 'ADN', 'PEDERNALES', 'USR_REL_004', 'ATAHUALPA',    'PALMAR',       DATEADD(DAY, -1, GETDATE()), 'Liderazgo local disperso.',     'Solicita apoyo productivo.',    'Apoyo productivo',    'MARTA LUZ',  '0995555504', 'Buen recibimiento; generar visita al referido.',    CAST(-0.105630 AS DECIMAL(18,10)), CAST(-79.958700 AS DECIMAL(18,10)), 'SINCRONIZADO')
) v(IdCiudadano, Tienda, Ciudad, CodigoUsuario, CodigoCenturia, CodigoTerritorio, FechaVisita, ProblemaInterno, ProblemaFamiliar, TemaInteresReal, ReferidoNombres, ReferidoTelefono, NotaEncuestador, PosX, PosY, EstadoSync)
WHERE v.IdCiudadano IS NOT NULL
  AND NOT EXISTS
(
    SELECT 1
    FROM dbo.Visita x
    WHERE x.IdCiudadano = v.IdCiudadano
      AND x.CodigoUsuario = v.CodigoUsuario
      AND CAST(x.FechaVisita AS DATE) = CAST(v.FechaVisita AS DATE)
);
GO

/*==============================================================*/
/* 8. INTENCIONES DE VOTO POR VISITA                            */
/*==============================================================*/
;WITH VisitasBase AS
(
    SELECT v.IdVisita, v.CodigoUsuario
    FROM dbo.Visita v
    WHERE v.CodigoUsuario IN ('USR_REL_001', 'USR_REL_002', 'USR_REL_003', 'USR_REL_004')
)
INSERT INTO dbo.VisitaIntencionVoto
(
    IdVisita, CodigoDignidad, CodigoIntencionVotoOpcion, Observacion,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT vb.IdVisita, s.CodigoDignidad, s.CodigoIntencionVotoOpcion, s.Observacion,
       GETDATE(), 'SEED', 1, 'SCRIPT'
FROM VisitasBase vb
INNER JOIN
(
    VALUES
    ('USR_REL_001', 'ALCALDE',  'PATRICIA_SALTOS', 'Apoyo claro a Patricia Saltos.'),
    ('USR_REL_001', 'CONCEJAL', 'CON_NUESTRO',     'Prefiere nuestra lista.'),
    ('USR_REL_001', 'VOCALES',  'VOC_NUESTRO',     'Alineado con la campaña.'),

    ('USR_REL_002', 'ALCALDE',  'ALC_INDECISO',    'Escucha propuesta pero no define.'),
    ('USR_REL_002', 'CONCEJAL', 'CON_INDECISO',    'Aun evaluando listas.'),
    ('USR_REL_002', 'VOCALES',  'VOC_INDECISO',    'Sin definición actual.'),

    ('USR_REL_003', 'ALCALDE',  'DIEGO_CELORIO',  'Menciona afinidad previa con Diego Celorio.'),
    ('USR_REL_003', 'CONCEJAL', 'CON_COMP_B',      'Apoya lista rival local.'),
    ('USR_REL_003', 'VOCALES',  'VOC_NO_RESPONDE', 'No desea responder.'),

    ('USR_REL_004', 'ALCALDE',  'PATRICIA_SALTOS', 'Muy buena aceptación.'),
    ('USR_REL_004', 'CONCEJAL', 'CON_NUESTRO',     'Alineado con nuestra lista.'),
    ('USR_REL_004', 'VOCALES',  'VOC_NUESTRO',     'Respaldo completo.')
) s(CodigoUsuario, CodigoDignidad, CodigoIntencionVotoOpcion, Observacion)
    ON s.CodigoUsuario = vb.CodigoUsuario
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.VisitaIntencionVoto iv
    WHERE iv.IdVisita = vb.IdVisita
      AND iv.CodigoDignidad = s.CodigoDignidad
);
GO

/*==============================================================*/
/* 8B. CARGA MASIVA SEMILLA                                     */
/*==============================================================*/
;WITH Numeros AS
(
    SELECT 1 AS n
    UNION ALL
    SELECT n + 1
    FROM Numeros
    WHERE n < 96
),
Semilla AS
(
    SELECT
        n,
        CASE ((n - 1) % 4)
            WHEN 0 THEN 'PEDERNALES'
            WHEN 1 THEN 'COJIMIES'
            WHEN 2 THEN '10_DE_AGOSTO'
            ELSE 'ATAHUALPA'
        END AS CodigoCenturia,
        CASE ((n - 1) % 4)
            WHEN 0 THEN 'PEDERNALES'
            WHEN 1 THEN 'COJIMIES'
            WHEN 2 THEN '10_DE_AGOSTO'
            ELSE 'PALMAR'
        END AS CodigoTerritorio,
        CASE ((n - 1) % 4)
            WHEN 0 THEN 'PEDERNALES'
            WHEN 1 THEN 'COJIMIES'
            WHEN 2 THEN '10 DE AGOSTO'
            ELSE 'ATAHUALPA'
        END AS Parroquia,
        CASE ((n - 1) % 4)
            WHEN 0 THEN 'PEDERNALES'
            WHEN 1 THEN 'COJIMIES'
            WHEN 2 THEN '10 DE AGOSTO'
            ELSE 'PALMAR'
        END AS Barrio,
        CASE ((n - 1) % 4)
            WHEN 0 THEN 'USR_REL_001'
            WHEN 1 THEN 'USR_REL_002'
            WHEN 2 THEN 'USR_REL_003'
            ELSE 'USR_REL_004'
        END AS CodigoUsuario,
        CASE ((n - 1) % 4)
            WHEN 0 THEN CAST(-0.071234 + (n * 0.00001) AS DECIMAL(18,10))
            WHEN 1 THEN CAST( 0.068200 + (n * 0.00001) AS DECIMAL(18,10))
            WHEN 2 THEN CAST(-0.088410 + (n * 0.00001) AS DECIMAL(18,10))
            ELSE CAST(-0.105630 + (n * 0.00001) AS DECIMAL(18,10))
        END AS PosX,
        CASE ((n - 1) % 4)
            WHEN 0 THEN CAST(-80.052345 - (n * 0.00001) AS DECIMAL(18,10))
            WHEN 1 THEN CAST(-80.045100 - (n * 0.00001) AS DECIMAL(18,10))
            WHEN 2 THEN CAST(-79.989500 - (n * 0.00001) AS DECIMAL(18,10))
            ELSE CAST(-79.958700 - (n * 0.00001) AS DECIMAL(18,10))
        END AS PosY
    FROM Numeros
)
INSERT INTO dbo.Ciudadano
(
    Tienda, Ciudad, CodigoCenturia, CodigoTerritorio, Codigo, Nombres, Apellidos,
    NumeroCelular, Genero, MiembrosFamilia, MiembrosVotan, MiembrosDiscapacidad,
    Parroquia, Barrio, Direccion, PosX, PosY, Activo,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT
    'ADN',
    'PEDERNALES',
    s.CodigoCenturia,
    s.CodigoTerritorio,
    'CED' + RIGHT('0000' + CAST(1000 + s.n AS VARCHAR(10)), 4),
    'CIUDADANO ' + CAST(s.n AS VARCHAR(10)),
    'SEMILLA ' + CAST(s.n AS VARCHAR(10)),
    '09' + RIGHT('00000000' + CAST(500000 + s.n AS VARCHAR(10)), 8),
    CASE WHEN s.n % 2 = 0 THEN 'femenino' ELSE 'masculino' END,
    3 + (s.n % 4),
    2 + (s.n % 3),
    s.n % 2,
    s.Parroquia,
    s.Barrio,
    'Direccion semilla ' + CAST(s.n AS VARCHAR(10)),
    s.PosX,
    s.PosY,
    1,
    GETDATE(),
    'SEED',
    1,
    'SCRIPT'
FROM Semilla s
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Ciudadano c
    WHERE c.Tienda = 'ADN'
      AND c.Codigo = 'CED' + RIGHT('0000' + CAST(1000 + s.n AS VARCHAR(10)), 4)
)
OPTION (MAXRECURSION 0);
GO

;WITH SemillaCiudadano AS
(
    SELECT
        c.IdCiudadano,
        c.Codigo,
        c.CodigoCenturia,
        c.CodigoTerritorio,
        c.Parroquia,
        c.Barrio,
        c.PosX,
        c.PosY,
        CASE c.CodigoCenturia
            WHEN 'PEDERNALES' THEN 'USR_REL_001'
            WHEN 'COJIMIES' THEN 'USR_REL_002'
            WHEN '10_DE_AGOSTO' THEN 'USR_REL_003'
            ELSE 'USR_REL_004'
        END AS CodigoUsuario,
        TRY_CAST(RIGHT(c.Codigo, 4) AS INT) AS NumSemilla
    FROM dbo.Ciudadano c
    WHERE c.Tienda = 'ADN'
      AND c.Codigo LIKE 'CED1%'
)
INSERT INTO dbo.Visita
(
    IdCiudadano, Tienda, Ciudad, CodigoUsuario, CodigoCenturia, CodigoTerritorio,
    FechaVisita, ProblemaInterno, ProblemaFamiliar, TemaInteresReal, ReferidoNombres, ReferidoTelefono,
    NotaEncuestador, PosX, PosY, EstadoSync, Activo,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT
    s.IdCiudadano,
    'ADN',
    'PEDERNALES',
    s.CodigoUsuario,
    s.CodigoCenturia,
    s.CodigoTerritorio,
    DATEADD(DAY, -(s.NumSemilla % 15), GETDATE()),
    CASE s.CodigoCenturia
        WHEN 'PEDERNALES' THEN 'Seguimiento interno de estructura territorial.'
        WHEN 'COJIMIES' THEN 'Seguimiento interno de coordinacion comunitaria.'
        WHEN '10_DE_AGOSTO' THEN 'Seguimiento interno de brigadas rurales.'
        ELSE 'Seguimiento interno de lideres parroquiales.'
    END,
    CASE s.CodigoCenturia
        WHEN 'PEDERNALES' THEN 'Consulta por seguridad y servicios basicos.'
        WHEN 'COJIMIES' THEN 'Consulta por empleo y conectividad.'
        WHEN '10_DE_AGOSTO' THEN 'Consulta por vias y riego.'
        ELSE 'Consulta por apoyo productivo y vias rurales.'
    END,
    CASE s.CodigoCenturia
        WHEN 'PEDERNALES' THEN 'Seguridad'
        WHEN 'COJIMIES' THEN 'Empleo'
        WHEN '10_DE_AGOSTO' THEN 'Vialidad'
        ELSE 'Produccion'
    END,
    NULL,
    NULL,
    'Visita semilla generada para pruebas masivas.',
    s.PosX,
    s.PosY,
    'SINCRONIZADO',
    1,
    GETDATE(),
    'SEED',
    1,
    'SCRIPT'
FROM SemillaCiudadano s
WHERE s.NumSemilla IS NOT NULL
  AND NOT EXISTS
(
    SELECT 1
    FROM dbo.Visita v
    WHERE v.IdCiudadano = s.IdCiudadano
      AND v.CodigoUsuario = s.CodigoUsuario
)
GO

;WITH VisitasSemilla AS
(
    SELECT
        v.IdVisita,
        v.CodigoCenturia,
        c.Codigo
    FROM dbo.Visita v
    INNER JOIN dbo.Ciudadano c
        ON c.IdCiudadano = v.IdCiudadano
    WHERE c.Tienda = 'ADN'
      AND c.Codigo LIKE 'CED1%'
)
INSERT INTO dbo.VisitaIntencionVoto
(
    IdVisita, CodigoDignidad, CodigoIntencionVotoOpcion, Observacion,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT
    v.IdVisita,
    'ALCALDE',
    CASE v.CodigoCenturia
        WHEN 'PEDERNALES' THEN 'PATRICIA_SALTOS'
        WHEN 'COJIMIES' THEN 'ALC_INDECISO'
        WHEN '10_DE_AGOSTO' THEN 'DIEGO_CELORIO'
        ELSE 'PATRICIA_SALTOS'
    END,
    'Intencion semilla generada para pruebas masivas.',
    GETDATE(),
    'SEED',
    1,
    'SCRIPT'
FROM VisitasSemilla v
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.VisitaIntencionVoto iv
    WHERE iv.IdVisita = v.IdVisita
      AND iv.CodigoDignidad = 'ALCALDE'
);
GO

/*==============================================================*/
/* 9. REPORTES ORGANIZACIONALES                                 */
/*==============================================================*/
INSERT INTO dbo.ReporteOrganizacional
(
    Tienda, Ciudad, CodigoReporte, TipoReporte, CodigoUsuario, CodigoRol, CodigoCenturia,
    FechaReporte, FechaEnvio, RelatoresActivos, SoldadosActivos, HorasCampo,
    PromovidosCompletos, PromovidosIncompletos, ContactosSinDatos, Vah, TendenciaVah,
    CoberturaPorcentaje, SectoresCompletados, SectoresPendientes, ZonaPrioritariaManana,
    TemperaturaSocial, ObjecionFrecuente, ActividadAdversario, Adversario,
    TipoActividadAdversario, SectorActividadAdversario, NivelAlerta,
    NecesitaMaterial, MaterialSolicitado, NecesitaPresupuesto, MontoPresupuesto,
    NecesitaLlamada, TemaLlamada, Observacion, Estado,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT v.*
FROM
(
    SELECT
        'ADN' AS Tienda, 'PEDERNALES' AS Ciudad, 'FEXP-PEDERNALES-' + CONVERT(VARCHAR(8), CAST(GETDATE() AS DATE), 112) AS CodigoReporte,
        'F-EXP' AS TipoReporte, 'USR_EXP_001' AS CodigoUsuario, 'EXPLORADOR' AS CodigoRol, 'PEDERNALES' AS CodigoCenturia,
        CAST(CAST(GETDATE() AS DATE) AS DATETIME) AS FechaReporte, DATEADD(MINUTE, 30, CAST(CAST(GETDATE() AS DATE) AS DATETIME)) AS FechaEnvio,
        4 AS RelatoresActivos, 1 AS SoldadosActivos, CAST(8.0 AS DECIMAL(12,2)) AS HorasCampo,
        12 AS PromovidosCompletos, 2 AS PromovidosIncompletos, 3 AS ContactosSinDatos, CAST(1.8750 AS DECIMAL(10,2)) AS Vah,
        'Subio' AS TendenciaVah, CAST(45.00 AS DECIMAL(5,2)) AS CoberturaPorcentaje,
        'CENTRO, MALECON' AS SectoresCompletados, 'LOS TAMARINDOS' AS SectoresPendientes, 'LOS TAMARINDOS' AS ZonaPrioritariaManana,
        NULL AS TemperaturaSocial, NULL AS ObjecionFrecuente, 0 AS ActividadAdversario, NULL AS Adversario,
        NULL AS TipoActividadAdversario, NULL AS SectorActividadAdversario, NULL AS NivelAlerta,
        0 AS NecesitaMaterial, NULL AS MaterialSolicitado, 0 AS NecesitaPresupuesto, CAST(0 AS DECIMAL(12,2)) AS MontoPresupuesto,
        0 AS NecesitaLlamada, NULL AS TemaLlamada, 'Reporte base del explorador para pruebas.' AS Observacion, 'ENVIADO' AS Estado,
        GETDATE() AS FechaCreacion, 'SEED' AS UsuarioCreacion, 1 AS OficinaCreacion, 'SCRIPT' AS EstacionCreacion

    UNION ALL

    SELECT
        'ADN', 'PEDERNALES', 'FCEN-PEDERNALES-' + CONVERT(VARCHAR(8), CAST(GETDATE() AS DATE), 112),
        'F-CEN', 'USR_CEN_PED', 'CENTURION', 'PEDERNALES',
        CAST(CAST(GETDATE() AS DATE) AS DATETIME), DATEADD(HOUR, 20, CAST(CAST(GETDATE() AS DATE) AS DATETIME)),
        4, 1, CAST(8.0 AS DECIMAL(12,2)),
        12, 2, 3, CAST(1.8750 AS DECIMAL(10,2)),
        'Subio', CAST(45.00 AS DECIMAL(5,2)),
        'CENTRO, MALECON', 'LOS TAMARINDOS', 'LOS TAMARINDOS',
        'Regular', 'No la conoce', 1, 'Santos CedeÃ±o',
        'Recorrido', 'MALECON', 'AMARILLO',
        1, 'Camisetas y volantes', 1, CAST(35.00 AS DECIMAL(12,2)),
        1, 'Definir apoyo logÃ­stico del fin de semana', 'Reporte base del centuriÃ³n para pruebas.', 'ENVIADO',
        GETDATE(), 'SEED', 1, 'SCRIPT'
) v
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.ReporteOrganizacional r
    WHERE r.Tienda = v.Tienda
      AND r.CodigoReporte = v.CodigoReporte
);
GO

/*==============================================================*/
/* 10. DASHBOARD CONTADOR                                       */
/*==============================================================*/
INSERT INTO dbo.DashboardContador
(
    Tienda, Ciudad, TipoCorte, FechaInicio, FechaFin, CodigoCenturia, CodigoTerritorio,
    Parroquia, Barrio, TipoContador, CodigoDignidad, CodigoIntencionVotoOpcion, Total,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT v.*
FROM
(
    SELECT
        'ADN' AS Tienda, 'PEDERNALES' AS Ciudad, 'DIARIO' AS TipoCorte,
        CAST(CAST(GETDATE() AS DATE) AS DATETIME) AS FechaInicio, CAST(CAST(GETDATE() AS DATE) AS DATETIME) AS FechaFin,
        'PEDERNALES' AS CodigoCenturia, 'PEDERNALES' AS CodigoTerritorio,
        'PEDERNALES' AS Parroquia, 'CENTRO' AS Barrio,
        'PROMOVIDOS' AS TipoContador, 'ALCALDE' AS CodigoDignidad, 'PATRICIA_SALTOS' AS CodigoIntencionVotoOpcion, 12 AS Total,
        GETDATE() AS FechaCreacion, 'SEED' AS UsuarioCreacion, 1 AS OficinaCreacion, 'SCRIPT' AS EstacionCreacion

    UNION ALL

    SELECT
        'ADN', 'PEDERNALES', 'SEMANAL',
        DATEADD(DAY, -6, CAST(CAST(GETDATE() AS DATE) AS DATETIME)), CAST(CAST(GETDATE() AS DATE) AS DATETIME),
        'PEDERNALES', 'TODOS',
        'PEDERNALES', 'TODOS',
        'CONTACTOS_EFECTIVOS', 'TODAS', 'TODAS', 57,
        GETDATE(), 'SEED', 1, 'SCRIPT'
) v
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.DashboardContador d
    WHERE d.Tienda = v.Tienda
      AND d.Ciudad = v.Ciudad
      AND d.TipoCorte = v.TipoCorte
      AND d.FechaInicio = v.FechaInicio
      AND d.FechaFin = v.FechaFin
      AND d.CodigoCenturia = v.CodigoCenturia
      AND d.CodigoTerritorio = v.CodigoTerritorio
      AND d.Parroquia = v.Parroquia
      AND d.Barrio = v.Barrio
      AND d.TipoContador = v.TipoContador
      AND d.CodigoDignidad = v.CodigoDignidad
      AND d.CodigoIntencionVotoOpcion = v.CodigoIntencionVotoOpcion
);
GO

/*==============================================================*/
/* 11. POLITICAS APRENDIDAS                                     */
/*==============================================================*/
INSERT INTO dbo.PoliticaAprendida
(
    Tienda, Ciudad, TipoEstado, ClaveEstado, TipoAccion, ValorAprendido,
    VecesProbado, RecompensaPromedio, UltimaActualizacion, Activo,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT v.Tienda, v.Ciudad, v.TipoEstado, v.ClaveEstado, v.TipoAccion, v.ValorAprendido,
       v.VecesProbado, v.RecompensaPromedio, GETDATE(), 1,
       GETDATE(), 'SEED', 1, 'SCRIPT'
FROM
(
    VALUES
    ('ADN', 'PEDERNALES', 'BARRIO',    'CENTRO|PROMOVIDO',       'REFORZAR_RELATORES', 0.800000, 5, 0.650000),
    ('ADN', 'PEDERNALES', 'COBERTURA', 'SIN_CONTACTO|7_DIAS',    'VISITA_PRIORITARIA', 0.920000, 3, 0.720000),
    ('ADN', 'PEDERNALES', 'OBJECION',  'NO_LA_CONOCE',           'MICRO_MENSAJE',      0.700000, 4, 0.550000)
) v(Tienda, Ciudad, TipoEstado, ClaveEstado, TipoAccion, ValorAprendido, VecesProbado, RecompensaPromedio)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.PoliticaAprendida p
    WHERE p.Tienda = v.Tienda
      AND p.Ciudad = v.Ciudad
      AND p.TipoEstado = v.TipoEstado
      AND p.ClaveEstado = v.ClaveEstado
      AND p.TipoAccion = v.TipoAccion
);
GO

/*==============================================================*/
/* 12. ACCIONES RECOMENDADAS                                    */
/*==============================================================*/
INSERT INTO dbo.AccionRecomendada
(
    Tienda, Ciudad, FechaGeneracion, TipoAccion, CodigoCenturia, CodigoTerritorio,
    CodigoDignidad, CodigoIntencionVotoOpcion, Titulo, Motivo, Score, Estado,
    FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
)
SELECT v.Tienda, v.Ciudad, GETDATE(), v.TipoAccion, v.CodigoCenturia, v.CodigoTerritorio,
       v.CodigoDignidad, v.CodigoIntencionVotoOpcion, v.Titulo, v.Motivo, v.Score, v.Estado,
       GETDATE(), 'SEED', 1, 'SCRIPT'
FROM
(
    VALUES
    ('ADN', 'PEDERNALES', 'REFORZAR_VISITA', 'PEDERNALES', 'PEDERNALES', 'ALCALDE', 'ALC_INDECISO', 'Refuerzo en Malecon', 'Zona con indecisos y cobertura parcial.', CAST(0.8700 AS DECIMAL(10,4)), 'PENDIENTE'),
    ('ADN', 'PEDERNALES', 'LLAMADA_SEGMENTADA', 'COJIMIES', 'COJIMIES', 'CONCEJAL', 'CON_COMP_A', 'Seguimiento Cojimies', 'Competencia detectada en preferencia de concejal.', CAST(0.7600 AS DECIMAL(10,4)), 'PENDIENTE')
) v(Tienda, Ciudad, TipoAccion, CodigoCenturia, CodigoTerritorio, CodigoDignidad, CodigoIntencionVotoOpcion, Titulo, Motivo, Score, Estado)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.AccionRecomendada a
    WHERE a.Tienda = v.Tienda
      AND a.Ciudad = v.Ciudad
      AND a.TipoAccion = v.TipoAccion
      AND a.CodigoCenturia = v.CodigoCenturia
      AND a.CodigoTerritorio = v.CodigoTerritorio
      AND a.Titulo = v.Titulo
);
GO

/*==============================================================*/
/* 13. RESULTADOS DE ACCION                                     */
/*==============================================================*/
DECLARE @IdAccionRefuerzo BIGINT =
(
    SELECT TOP 1 IdAccionRecomendada
    FROM dbo.AccionRecomendada
    WHERE Tienda = 'ADN'
      AND Ciudad = 'PEDERNALES'
      AND Titulo = 'Refuerzo en Malecon'
);

IF @IdAccionRefuerzo IS NOT NULL
AND NOT EXISTS
(
    SELECT 1
    FROM dbo.ResultadoAccion
    WHERE IdAccionRecomendada = @IdAccionRefuerzo
      AND TipoMetrica = 'PROMOVIDOS'
)
BEGIN
    INSERT INTO dbo.ResultadoAccion
    (
        IdAccionRecomendada, FechaResultado, TipoMetrica, TotalAntes, TotalDespues, Delta,
        Recompensa, Observacion,
        FechaCreacion, UsuarioCreacion, OficinaCreacion, EstacionCreacion
    )
    VALUES
    (
        @IdAccionRefuerzo, GETDATE(), 'PROMOVIDOS', 8, 11, 3,
        0.3750, 'La acciÃ³n elevÃ³ el nÃºmero de promovidos en el sector.',
        GETDATE(), 'SEED', 1, 'SCRIPT'
    );
END
GO

PRINT 'Carga inicial completada.';
GO


