using series.Enum;
using System;

namespace series.Classes
{
    public class Serie: EntidadeBase
    {
        private string Titulo { get; set; }
        private Genero Genero { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido {get; set; }

        public Serie(int id, string titulo, Genero genero, string descricao, int ano)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Genero = genero;
            this.Descricao = descricao;
            this.Ano = ano; 
            this.Excluido = false;           
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;

            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
        
    }
}