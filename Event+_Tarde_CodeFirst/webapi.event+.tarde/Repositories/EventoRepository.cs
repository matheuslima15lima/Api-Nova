﻿using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _eventContext.Evento.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.Descricao = evento.Descricao;
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                }

                _eventContext.Update(eventoBuscado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventContext.Evento.Select(t => new Evento
                {
                    IdEvento = t.IdEvento,
                    NomeEvento = t.NomeEvento


                }).FirstOrDefault(t => t.IdEvento == id)!;


                return eventoBuscado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Add(evento);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        public void Deletar(Guid id)
        {
            Evento eventoBuscado = _eventContext.Evento.Find(id)!;

            _eventContext.Remove(eventoBuscado);

            _eventContext.SaveChanges();
        }

        public List<Evento> Listar()
        {
            return _eventContext.Evento.ToList();
        }
    }
}
