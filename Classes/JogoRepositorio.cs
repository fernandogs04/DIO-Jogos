using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO.Jogos.Interfaces;

namespace DIO.Jogos
{
    public class JogoRepositorio : IRepositorio<Jogo>
    {
        private List<Jogo> listaJogo = new List<Jogo>();
        public void Atualiza(int id, Jogo jogo)
        {
            listaJogo[id] = jogo;
        }

        public void Conclui(int id)
        {
            listaJogo[id].Concluir();
        }

        public void Insere(Jogo jogo)
        {
            listaJogo.Add(jogo);
        }

        public List<Jogo> Lista()
        {
            return listaJogo;
        }

        public int ProximoId()
        {
            return listaJogo.Count;
        }

        public Jogo RetornaPorId(int id)
        {
            return listaJogo[id];
        }
    }
}