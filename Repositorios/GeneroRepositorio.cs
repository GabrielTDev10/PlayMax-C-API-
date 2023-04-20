using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayMax.Models;

namespace PlayMax.Repositorios
{
    public class GeneroRepositorio
    {
        private readonly ContextoBD _contexto;

        
     public GeneroRepositorio([FromServices] ContextoBD contexto){
    
        _contexto = contexto;
        }

     public Genero CriarGenero(Genero Genero){
        _contexto.Add(Genero);
        _contexto.SaveChanges();

        return Genero;
     }

     public List<Genero> ListarGeneros(){

         return _contexto.Generos.AsNoTracking().ToList();
     }

     public Genero  BuscarPeloNome(string nome ,bool Tracking = true){
         
         return Tracking?
         _contexto.Generos.FirstOrDefault(g => g.Nome == nome) :
         _contexto.Generos.AsNoTracking().FirstOrDefault(g => g.Nome == nome);   
     }

      public void RemoverGenero(Genero genero){
         _contexto.Remove(genero);
         _contexto.SaveChanges();
      }

      public void AtualizarGenero(){

         _contexto.SaveChanges();
      }

    }


    

}
