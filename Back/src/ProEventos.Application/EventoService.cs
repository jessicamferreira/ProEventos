using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace ProEventos.Application
{
    public class EventoService : IEventosService
    {
        private readonly IGeralPersist _geralpersist;
        private readonly IEventoPersist _eventopersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventopersist = eventoPersist;
            _geralpersist = geralPersist;
        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralpersist.Add<Evento>(model);
                if (await _geralpersist.SaveChangesAsync())
                {
                    return await _eventopersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventopersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _geralpersist.Update(model);
                if(await _geralpersist.SaveChangesAsync())
                {
                    return await _eventopersist.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventopersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento para DELETE não encontrado");


                _geralpersist.Delete<Evento>(evento);
                return await _geralpersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            try
            {
                var eventos = await _eventopersist.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            try
            {
                var eventos = await _eventopersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes)
        {
            try
            {
                var eventos = await _eventopersist.GetEventoByIdAsync(EventoId, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}