CREATE DATABASE paginapacientes;

USE PAGINAPACIENTES;


CREATE TABLE PACIENTE (
    idPaciente INT AUTO_INCREMENT PRIMARY KEY,
    nombrePaciente VARCHAR(100),
    rutPaciente VARCHAR(20),
    fechaIngreso DATETIME,
    edadPaciente INT,
    telefonoPaciente VARCHAR(20),
    emailPaciente VARCHAR(100),
    direccionPaciente VARCHAR(200),
    motivoConsulta VARCHAR(255)
);

SELECT * FROM PACIENTE;

INSERT INTO PACIENTE VALUES
(1, 'Juan Pérez González',     '12345678-9', '2026-01-10 09:30:00', 34, '+56912345678', 'juan.perez@gmail.com',    'Av. Providencia 123, Santiago',   'Dolor de cabeza frecuente'),
(2, 'María López Soto',        '9876543-2',  '2026-02-15 11:00:00', 28, '+56987654321', 'maria.lopez@hotmail.com', 'Calle Larga 456, Valparaíso',     'Control general'),
(3, 'Carlos Ramírez Fuentes',  '15234567-K', '2026-03-05 08:45:00', 52, '+56911223344', 'carlos.rf@gmail.com',     'Los Aromos 789, Concepción',      'Presión arterial alta'),
(4, 'Ana Martínez Vidal',      '18456789-3', '2026-04-20 14:15:00', 41, '+56955667788', 'ana.martinez@gmail.com',  'Pasaje El Roble 12, Temuco',      'Diabetes tipo 2'),
(5, 'Pedro Castillo Mora',     '11987654-7', '2026-05-01 10:00:00', 19, '+56999887766', 'pedro.castillo@yahoo.com','Villa Las Palmas 34, Antofagasta', 'Dolor de rodilla');
