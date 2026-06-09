using AutoMapper;
using DFast.Common.Types;
using DFast.Seguridad.Api.DTOs;
using DFast.Seguridad.Api.Helper;
using DFast.Seguridad.Api.Models;
using DFast.Seguridad.Api.Persistences;
using DFast.Seguridad.Api.Repositories;


namespace DFast.Seguridad.Api.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly IRegistroRepository _registroRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ContextDatabase _contextDatabase;
        public RegistroService(
            IRegistroRepository registroRepository,
            IUserRepository userRepository,
             IMapper mapper,
           ContextDatabase contextDatabase            )
        {
            _registroRepository = registroRepository;
            _userRepository = userRepository;
            _contextDatabase = contextDatabase;
            _mapper = mapper;

        }

        public async Task<bool> GuardarAsync(UsuarioDto command, bool flag )
        {

       
            var user = await _registroRepository.GetAsync(command.IdUsuario);
            if (user == null) // si no existe registro lo crea
            {
                Registro reg = new Registro
                {
                    IdUsuario = command.IdUsuario,
                    Sistema = command.Sistema,
                    Imei = command.Imei,
                    So = command.So,
                    Token = command.Token,
                    FechaCreacion = DateTime.Now
                };
                await _registroRepository.AddAsync(reg);
            }
            else
            {
                //user.Imei = command.Imei;
                user.So = command.So;
                user.Token = command.Token;
                user.FechaModificacion = DateTime.Now;
                _registroRepository.Update(user);
            }

            //commit en la base de datos
            if (flag)
                _contextDatabase.SaveChanges();

            return true;
        }
        public async Task<Registro> Guardar(UsuarioDto command)
        {
            var user = await _registroRepository.GetAsync(command.IdUsuario);
            if (user == null) // si no existe registro lo crea
            {
                Registro reg = new Registro
                {
                    IdUsuario = command.IdUsuario,
                    Sistema = command.Sistema,
                    Imei = command.Imei,
                    So = command.So,
                    Token = command.Token,
                    FechaCreacion = DateTime.Now
                };
            }
            else
            {
                //user.Imei = command.Imei;
                user.So = command.So;
                user.Token = command.Token;
                user.FechaModificacion = DateTime.Now;
            }
            return user;
        }
        public async Task<UsuarioDto> RegistroValidarImei(string sistema, string imei)
        {
            var reg = await _registroRepository.ObtenerxImeiAsync(sistema,imei);
            if (reg != null) // si no existe registro lo crea
            {
                var usr = await _userRepository.GetAsync(reg.IdUsuario);
                usr.Password = "";
                if (usr.Activo == false)
                    throw new DFastException(Codes.UsuarioInactivo, "Usuario Inactivo!!");
                return _mapper.Map<UsuarioDto>(usr);
                
            }
            // si es que no existe registro
            throw new DFastException(Codes.UserNotFound, "Registro no Existe!!");
        }

        public async Task<UsuarioDto> Consultar(string sistema, int idUsuario)
        {
            var reg = await _registroRepository.ObtenerxIdUsuarioAsync(sistema, idUsuario);
            if (reg != null) // si no existe registro lo crea
            {
                var usr = await _userRepository.GetAsync(reg.IdUsuario);
                usr.Password = "";
                if (usr.Activo == false)
                    throw new DFastException(Codes.UsuarioInactivo, "Usuario Inactivo!!");
                return _mapper.Map<UsuarioDto>(usr);

            }
            // si es que no existe registro
            throw new DFastException(Codes.UserNotFound, "Registro no Existe!!");
        }
    }
}