﻿using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface ITipoEventoRepository
    {
        public void Cadastrar(TipoEvento tipoEvento);

    }
}
