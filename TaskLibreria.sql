USE TaskLibreria;

CREATE TABLE Utente (
	utenteID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL
);

CREATE TABLE Libro(
	libroID INT PRIMARY KEY IDENTITY (1,1),
	titolo VARCHAR(250) NOT NULL,
	annoDiPubblicazione DATE NOT NULL,
	IsDisponibile BIT DEFAULT 0 NOT NULL

);

CREATE TABLE Prestito(
	prestitoID INT PRIMARY KEY IDENTITY (1,1),
	dataDiPrestito DATE NOT NULL,
	dataDiRitorno DATE,
	libroRIF INT NOT NULL,
	utenteRIF INT NOT NULL,
	FOREIGN KEY (libroRIF) REFERENCES Libro (libroID) ON DELETE CASCADE,
	FOREIGN KEY (utenteRIF) REFERENCES Utente (utenteID) ON DELETE CASCADE
);

SELECT * FROM Libro 
SELECT * FROM Libro
JOIN 