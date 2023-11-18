using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class proyecto
{
    static void Main()
    {
        using (var dbContext = new DbContext())
        {
          
            var nuevoEstudiante = new Notas
            {
                Estudiante = "Nombre del Estudiante",
                Parciales = 8.5m, 
                Laboratorios = 9.0m,
            };

            nuevoEstudiante.NotaFinal = CalcularNotaFinalAcumulada(nuevoEstudiante.Parciales, nuevoEstudiante.Laboratorios);

            dbContext.Notas.Add(nuevoEstudiante);
            dbContext.SaveChanges();

           
            MostrarRegistros(dbContext);
        }
    }

    static void MostrarRegistros( DbContext)
    {
        
        var registros = DbContext.Notas.ToList();

        Console.WriteLine("Registros en la tabla Notas:");
        foreach (var registro in registros)
        {
            Console.WriteLine($"ID: {registro.Id}, Estudiante: {registro.Estudiante}, Parciales: {registro.Parciales}, Laboratorios: {registro.Laboratorios}, Nota Final: {registro.NotaFinal}");
        }
    }

    static decimal CalcularNotaFinalAcumulada(decimal notaParciales, decimal notaLaboratorios)
    {
       
        return (notaParciales + notaLaboratorios) / 2;
    }
}

