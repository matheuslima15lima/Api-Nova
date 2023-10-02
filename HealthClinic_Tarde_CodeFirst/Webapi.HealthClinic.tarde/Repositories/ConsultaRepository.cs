using Webapi.HealthClinic.tarde.Context;
using Webapi.HealthClinic.tarde.Domains;
using Webapi.HealthClinic.tarde.Interfaces;

namespace Webapi.HealthClinic.tarde.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext _healthcontext;

        public ConsultaRepository() 
        {
            _healthcontext= new HealthClinicContext();
        }

        public void Atualizar(Guid id, Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                _healthcontext.Add(consulta);
                _healthcontext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Consulta consultaBuscada = _healthcontext.Consulta.Find(id)!;
                _healthcontext.Remove(consultaBuscada);
                _healthcontext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
          

           
        }

        public List<Consulta> ListarConsultaDosUsuarios(Guid id)
        {
            try
            {

              return  _healthcontext.Consulta.Where(x => x.Medico.IdUsuario == id || x.Paciente.IdUsuario == id).ToList();

                /*return _healthcontext.Consulta.Where(x => x.Medico.IdUsuario == id || x.Paciente.IdUsuario == id).ToList();*/




            }
            catch (Exception)
            {

                throw;
            }
        }

      
    }
}
