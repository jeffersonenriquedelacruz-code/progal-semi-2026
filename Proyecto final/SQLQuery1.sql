CREATE DATABASE empleo_local;
GO
USE empleo_local;
GO

CREATE TABLE ciudades (
    id_ciudad INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(80) NOT NULL,
    provincia NVARCHAR(80) NOT NULL
);

CREATE TABLE categorias (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE empresas (
    id_empresa INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    ruc NVARCHAR(30) NOT NULL UNIQUE,
    telefono NVARCHAR(20),
    correo NVARCHAR(100) NOT NULL UNIQUE,
    direccion NVARCHAR(150),
    id_ciudad INT NOT NULL,
    FOREIGN KEY (id_ciudad) REFERENCES ciudades(id_ciudad)
);

CREATE TABLE candidatos (
    id_candidato INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(80) NOT NULL,
    apellido NVARCHAR(80) NOT NULL,
    cedula NVARCHAR(20) NOT NULL UNIQUE,
    telefono NVARCHAR(20),
    correo NVARCHAR(100) NOT NULL UNIQUE,
    profesion NVARCHAR(100),
    fecha_registro DATE NOT NULL DEFAULT GETDATE(),
    id_ciudad INT NOT NULL,
    FOREIGN KEY (id_ciudad) REFERENCES ciudades(id_ciudad)
);

CREATE TABLE ofertas (
    id_oferta INT IDENTITY(1,1) PRIMARY KEY,
    titulo NVARCHAR(120) NOT NULL,
    descripcion NVARCHAR(MAX),
    salario DECIMAL(10,2),
    jornada NVARCHAR(20) NOT NULL
        CHECK (jornada IN ('Tiempo completo','Medio tiempo','Por horas')),
    fecha_publicacion DATE NOT NULL DEFAULT GETDATE(),
    estado NVARCHAR(10) NOT NULL DEFAULT 'Abierta'
        CHECK (estado IN ('Abierta','Cerrada')),
    id_empresa INT NOT NULL,
    id_categoria INT NOT NULL,
    id_ciudad INT NOT NULL,
    FOREIGN KEY (id_empresa) REFERENCES empresas(id_empresa),
    FOREIGN KEY (id_categoria) REFERENCES categorias(id_categoria),
    FOREIGN KEY (id_ciudad) REFERENCES ciudades(id_ciudad)
);

CREATE TABLE postulaciones (
    id_postulacion INT IDENTITY(1,1) PRIMARY KEY,
    id_oferta INT NOT NULL,
    id_candidato INT NOT NULL,
    fecha_postulacion DATE NOT NULL DEFAULT GETDATE(),
    estado NVARCHAR(15) NOT NULL DEFAULT 'Pendiente'
        CHECK (estado IN ('Pendiente','En revisión','Aceptada','Rechazada')),
    UNIQUE (id_oferta, id_candidato),
    FOREIGN KEY (id_oferta) REFERENCES ofertas(id_oferta),
    FOREIGN KEY (id_candidato) REFERENCES candidatos(id_candidato)
);
GO