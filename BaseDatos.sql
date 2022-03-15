CREATE TABLE Clientes (
  idCliente INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  nombre VARCHAR(50) NOT NULL,
  genero VARCHAR(50) NOT NULL,
  edad INTEGER UNSIGNED NOT NULL,
  identificacion VARCHAR(13) NOT NULL,
  direccion VARCHAR(100) NOT NULL,
  telefono VARCHAR(12) NOT NULL,
  contrasenia VARCHAR(10) NOT NULL,
  estado BOOL NOT NULL,
  PRIMARY KEY(idCliente)
);

CREATE TABLE Cuentas (
  idCuenta INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  idCliente INTEGER UNSIGNED NOT NULL,
  numeroCuenta VARCHAR(10) NOT NULL,
  tipo VARCHAR(20) NOT NULL,
  saldoInicial DECIMAL(10,4)) NOT NULL,
  estado BOOL NOT NULL,
  PRIMARY KEY(idCuenta),
  INDEX Cuentas_FKIndex1(idCliente)
);

CREATE TABLE Movimientos (
  idMovimiento INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  idCuenta INTEGER UNSIGNED NOT NULL,
  fecha DATETIME NOT NULL,
  tipo VARCHAR(20) NOT NULL,
  valor DECIMAL(10,4) NOT NULL,
  saldo DECIMAL(10,4) NOT NULL,
  PRIMARY KEY(idMovimiento),
  INDEX Movimientos_FKIndex1(idCuenta)
);

