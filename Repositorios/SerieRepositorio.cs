using System;
using System.Collections.Generic;
using series.Classes;
using series.Interfaces;

namespace series.Repositorios
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie serie)
        {
            var lista = RetornaPorId(id);
            if (lista != null)
            {
                listaSerie[id] = serie;
            }                        
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie serie)
        {
            listaSerie.Add(serie);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            try
            {
                 return listaSerie[id];
            }
            catch (Exception)
            {                
                return null;
            }           
            
        }
    }
}