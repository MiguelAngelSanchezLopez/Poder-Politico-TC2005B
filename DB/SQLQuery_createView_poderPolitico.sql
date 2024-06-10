CREATE OR ALTER VIEW VistaSumaVotos AS
SELECT CP.NombreCandidato, CP.ApellidoCandidato, COUNT(*) AS TotalVotos
FROM EleccionCandidatos EC
JOIN CandidatosPresidenciales CP ON EC.idCandidato = CP.idCandidato
GROUP BY CP.NombreCandidato, CP.ApellidoCandidato;



/*SELECT * FROM VistaSumaVotos
ORDER BY TotalVotos DESC;*/