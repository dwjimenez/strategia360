using AutoMapper;
using DFast.Seguridad.Api.Models;
using DFast.Seguridad.Api.Helper;
using DFast.Seguridad.Api.Repositories;
using DFast.Seguridad.Api.DTOs;
using DFast.Common.Types;
using DFast.Common.Utils;

using DFast.Seguridad.Api.Persistences;
using DFast.Common.Token.Src;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DFast.Seguridad.Api.Proxy;
using Docufy.Seguridad.Api.DTOs;
using DFast.Common.Metric.Registry;
using DFast.Seguridad.Api.DTOs;




namespace DFast.Seguridad.Api.Services
{
    public class IdentityService :  IIdentityService
    {
        private readonly ContextDatabase _contextDatabase;
        private readonly IUserRepository _userRepository;
        private readonly IRolRepository _rolRepository;
        private readonly ILogSeguridadRepository _logSeguridadRepository;
        private readonly IMapper _mapper;
        private readonly JwtOptions _jwtOption;
        private readonly IConfiguration _configuration;
        private readonly INotificacionService _notificacionService;
        private readonly IRegistroService _registroService;
        private readonly IRegistroRepository _registroRepository;
        private readonly IOtpRepository _otpRepository;
        private readonly IUserSistemaRepository _userSistemaRepository;
        private readonly IMenuRepository _menuRepository;

        //private readonly IMetricsRegistry _metricsRegistry;
        private readonly ILogger<IdentityService> _logger;
        private readonly ISendNotificationService _sendNotificationService;
        private readonly IConfiguracionService _configuracionService;

        public IdentityService(
            IUserRepository userRepository,
            ContextDatabase contextDatabase,
            IMapper mapper,
            IRolRepository rolRepository,
            ILogSeguridadRepository logSeguridadRepository,
            IOptionsSnapshot<JwtOptions> jwtOption,
            IConfiguration configuration,
            INotificacionService notificacionService,
            IRegistroService registroService,
            IRegistroRepository registroRepository,
            IOtpRepository otpRepository,
            IUserSistemaRepository userSistemaRepository,
            IMenuRepository menuRepository,
            //IMetricsRegistry metricsRegistry,
            ILogger<IdentityService> logger,
            ISendNotificationService sendNotificationService,
            IConfiguracionService configuracionService
            )
        {
            _userRepository = userRepository;
            _contextDatabase = contextDatabase;
            _mapper = mapper;
            _rolRepository = rolRepository;
            _logSeguridadRepository = logSeguridadRepository;
            _jwtOption = jwtOption.Value;
            _configuration = configuration;
            _notificacionService = notificacionService;
            _registroService = registroService;
            _registroRepository = registroRepository;
            _otpRepository = otpRepository;
            _userSistemaRepository = userSistemaRepository;
            _menuRepository = menuRepository;
            //_metricsRegistry = metricsRegistry;
            _logger = logger;
            _sendNotificationService = sendNotificationService;
            _configuracionService = configuracionService;
        }

        public List<Usuario> ObtenerTodos(string institucion)
        {
            var list = _userRepository.ObtenerTodosAsync(institucion);
            return list;
        }
        public async Task<UsuarioDto> SignUpFullAsync(UsuarioDto command)
        {
       

            var flagNew = true;
            var user = await _userRepository.GetAsync(command.Key, command.Sistema);
            if (user == null) // si no existe registro lo crea
            {
                flagNew = false;
                user = new()
                {
                    Id = Guid.NewGuid(),
                    Key = command.Key,
                    Sistema = command.Sistema,
                    Institucion = command.Institucion,

                    Email = command.Email,
                    Nombres = command.Nombres,
                    Apellidos = command.Apellidos,
                    Rol = command.Rol,
                    Telefono1 = command.Telefono1,
                    Telefono2 = command.Telefono2,
                    TipoIdentificacion = command.TipoIdentificacion,
                    Identificacion = command.Identificacion,
                };
            }
            else
            {
                user.Email = command.Email;
                user.Nombres = command.Nombres;
                user.Apellidos = command.Apellidos;
                user.Rol = command.Rol;
                user.Telefono1 = command.Telefono1;
                user.Telefono2 = command.Telefono2;
                user.Identificacion = command.Identificacion;
            }

            string password = Utils.GenerateRandomNo().ToString();
            user.Password = PasswordHasher.HashPassword(password);
            user.Activo = false;

            //guardar el registro del token
            if (command.Token != null)
            {
                //command.IdUsuario = user.IdUsuario;
                user.Registros = (ICollection<Registro>)await _registroService.Guardar(command);
            }


            if (flagNew)
                _userRepository.Update(user);
            else
                await _userRepository.AddAsync(user);

          
            //commit en la base de datos
            _contextDatabase.SaveChanges();

            _notificacionService.SendMail(user, password); //llama asincrono

            //enviar el passwrod para q valide en la interfaz
            user.Password = password.ToString();

            return _mapper.Map<UsuarioDto>(user);
        }

        public async Task<UsuarioDto> SignUpSimpleAsync(UsuarioDto command)
        {
            var flagNew = true;
            var user = await _userRepository.GetAsync(command.Key, command.Sistema);
            if (user == null) // si no existe registro lo crea
            {
                flagNew = false;
                user = new()
                {
                    Id = Guid.NewGuid(),
                    Key = command.Key,
                    Sistema = command.Sistema,
                    Rol = command.Rol,
                    Telefono1 = command.Telefono1,
                    Nombres = command.Nombres,
                    Email = command.Email
                };

            }
            else
            {
                user.Rol = command.Rol;
                user.Telefono1 = command.Telefono1;
                user.Nombres = command.Nombres;
                user.Email = command.Email;
            }

            string password = Utils.GenerateRandomNo().ToString();
            user.Password = PasswordHasher.HashPassword(password);
            user.Activo = false;

            if (flagNew)
                _userRepository.Update(user);
            else
                await _userRepository.AddAsync(user);

            //guardar el registro del token
            if (command.Token != null)
            {
                command.IdUsuario = user.IdUsuario;
                await _registroService.GuardarAsync(command, false);
            }

            //commit en la base de datos
            _contextDatabase.SaveChanges();

            _notificacionService.SendMail(user, password); //llama asincrono

            //enviar el passwrod para q valide en la interfaz
            user.Password = password.ToString();
            return _mapper.Map<UsuarioDto>(user);

        }

        public async Task<UsuarioDto> ActivarAsync(UsuarioDto command)
        {
            var user = await _userRepository.GetAsync(command.Key, command.Sistema);
            user.Activo = true;
            _userRepository.Update(user);
            _contextDatabase.SaveChanges();
            return _mapper.Map<UsuarioDto>(user);
        }

        public async Task<UsuarioDto> RegistrarIngresoAsync(UsuarioDto command)
        {
            //guarda el registro del token
            var user = await _userRepository.GetAsync(command.Key, command.Sistema);
            //asigno id del usuario
            command.IdUsuario = user.IdUsuario;
            await _registroService.GuardarAsync(command, false);
            _contextDatabase.SaveChanges();
            RegistrarLogAsync(new LogSeguridadCreated("Login", (int)user.Oficina, "", user.IdUsuario, user.Key, (int)user.Intentos, 0, "OK"));
            user.Password = "";
            return _mapper.Map<UsuarioDto>(user);
        }

        public async Task<object> SignInAsync(string key, string password, string sistema, string estacion,bool validarActivos)
        {
            if (key == "" || password == "")
            {
                RegistrarLogAsync(new LogSeguridadCreated("Error", 0, "", 0, key, 0, 0, "Usuario o Password incorrecto."));
                throw new DFastException(Codes.CredencialesInvalidas,"Usuario o Password incorrecto.");
            }
            var user = await _userRepository.GetAsync(key, sistema);
            if (user == null)// usuario no existe
            {
                RegistrarLogAsync(new LogSeguridadCreated("Error", 0, "", 0, key, 0, 0, "Usuario no existe."));
                throw new DFastException(Codes.UserNotFound, "Usuario no Existe.");
            }
            if (user.Activo == false && validarActivos)
            {
                    RegistrarLogAsync(new LogSeguridadCreated("Error", (int)user.Oficina, "", user.IdUsuario, user.Key, (int)user.Intentos, 0, "Usuario Inactivo"));
                    throw new DFastException(Codes.RegistroInactivo, "Usuario Inactivo!!");
            }
            if (user.Estado == "BLOQUEADO")
            {
                RegistrarLogAsync(new LogSeguridadCreated("Error", (int)user.Oficina, "", user.IdUsuario, user.Key, (int)user.Intentos, 0, "Usuario Bloqueado"));
                throw new DFastException(Codes.UsuarioBloqueado, "Usuario Bloqueado!!");
            }

            //SEC010
            if (user.FechaCaducidadPass < DateTime.Now)
            {
                RegistrarLogAsync(new LogSeguridadCreated("Error", (int)user.Oficina, "", user.IdUsuario, user.Key, (int)user.Intentos, 0, "Contraseña Expirada"));
                throw new DFastException(Codes.ExpiredPassword, "Contraseña Expirada!!");
            }

            if (!PasswordHasher.VerifyPassword(password,user.Password))
            {
                user.Intentos = (short?)(user.Intentos + 1);
                if (user.Intentos >= 3)
                    user.Estado = "BLOQUEADO";
                
                _userRepository.Update(user);
                //commit en la base de datos
                _contextDatabase.SaveChanges();

                if (user.Intentos >= 3)
                {
                    RegistrarLogAsync(new LogSeguridadCreated("Error", 0, "", 0, key, 0, 0, "Usuario Boqueado por intentos fallidos!"));
                    throw new DFastException(Codes.UsuarioBloqueado, "Usuario Bloqueado");
                }
                else
                {
                    RegistrarLogAsync(new LogSeguridadCreated("Error", 0, "", 0, key, 0, 0, "Usuario o Password incorrecto"));
                    throw new DFastException(Codes.CredencialesInvalidas, "Usuario o Password incorrecto.");
                }
            }

            

            user.Intentos = 0;
            user.Estado = "CONECTADO";
            user.Estacion = estacion;
            user.Activo = true;

            _userRepository.Update(user);
            _contextDatabase.SaveChanges();

             RegistrarLogAsync(new LogSeguridadCreated("Login", (int)user.Oficina, "", user.IdUsuario, user.Key, (int)user.Intentos, 0, "OK"));

            ///
            var claims = new Claim[]
            {
                new Claim("Id", user.IdUsuario.ToString()),
                new Claim("Key", user.IdUsuario.ToString()),
                new Claim("Email", user.Email.ToString()),
                new Claim("Sistema", user.Sistema.ToString()),
                new Claim("Rol", user.Rol.ToString()),
                new Claim("TipoIdentificacion", user.TipoIdentificacion.ToString()),
                new Claim("Identificacion", user.Identificacion == null ? "":user.Identificacion.ToString()),
                new Claim("Nombres", user.Nombres.ToString()),
                new Claim("Apellidos", user.Apellidos == null ? "":user.Apellidos.ToString()),
                new Claim("Telefono1", user.Telefono1 == null ? "" : user.Telefono1),
                new Claim("Telefono2", user.Telefono2 == null ? "" : user.Telefono2),
                new Claim("Oficina", user.Oficina == null ? "" : user.Oficina.ToString()),
                new Claim("Estacion", estacion == null ? "" : estacion ),
                };
            var jwt = new JwtSecurityToken(
                issuer: _configuration.GetSection("jwt:issuer").ToString(),
                audience: _configuration.GetSection("jwt:audience").ToString(),
                claims: claims,
                expires: DateTime.Now.AddMinutes(300)
            );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            var usuarioDto = _mapper.Map<UsuarioDto>(user);
            usuarioDto.Token = accessToken;
            /////
            List<MenuSistemaDto> listMenuSistemas = new();
            List<MenuDto> listMenu = new List<MenuDto>();
            if (user.UsuarioRols.FirstOrDefault() != null)
            {
                foreach (UsuarioRol usuariorol in user.UsuarioRols)
                {
                    if ((bool)usuariorol.Estado)
                    {
                        var rol = await _rolRepository.ObtenerXIdAsync(usuariorol.IdRol.Value);
                       
                        foreach (RolOpcion opcion in rol.RolOpcions)
                        {
                            if ((bool)opcion.Activo)
                            {
                                MenuDto menu = _mapper.Map<MenuDto>(await _menuRepository.ObtenerXIDAsync(opcion.IdMenu));
                                if ((bool)menu.Activo)
                                {

                                    if (!listMenu.Any(ms => ms.IdMenu == menu.IdMenu))
                                        listMenu.Add(menu);

                                    if (menu.IdMenuOrigen == null && !listMenuSistemas.Any(ms => ms.idMenuOrigin == menu.IdMenu))
                                        {
                                            MenuSistemaDto menuSistema = new MenuSistemaDto()
                                            {
                                                icon = menu.Icono,
                                                id = menu.IdMenu.ToString(),
                                                subtitle = menu.SubTitulo,
                                                label = menu.Titulo,
                                                type = menu.Tipo,
                                                orden = menu.Orden,
                                                idMenuOrigin = menu.IdMenu,
                                            };
                                            listMenuSistemas.Add(menuSistema);
                                        }
                                }
                                    
                            }
                        }
                    }
                }
                listMenuSistemas.ForEach(item => {
                    var childrenMenuSistema = _mapper.Map<List<MenuSistemaChildren>>(listMenu.Where(item2 => item2.IdMenuOrigen == item.idMenuOrigin).ToList());
                    item.children = childrenMenuSistema;

                    item.children.ForEach(item1 => {
                        var childrenMenuSistema = _mapper.Map<List<MenuSistemaChildren>>(listMenu.Where(item3 => item3.IdMenuOrigen.ToString() == item1.id));
                        item1.children = childrenMenuSistema;
                    });
                });
            }

            
            //saco la oficina
            
            var officeResponse = await _configuracionService.ObtenerXId(user.Oficina!.Value);
            if (officeResponse?.data != null)
            {
                usuarioDto.CcdigoOficina = officeResponse.data.Codigo;
                usuarioDto.OficinaRegistro = officeResponse.data;
            }
            var result = new
            {
                //accessToken,
                usuario = _mapper.Map<UsuarioDtoIng>(usuarioDto),
                menu= listMenuSistemas
            };
            return result;
        }

        public async Task<UsuarioDto> ActualizarAsync(UsuarioDto command)
        {
            var user = await _userRepository.GetAsync(command.Key, command.Sistema);
            user.Email = command.Email; 
            user.Telefono1 = command.Telefono1;
            user.Nombres = command.Nombres;
            
            _userRepository.Update(user);
   
            //commit en la base de datos
            _contextDatabase.SaveChanges();
            return _mapper.Map<UsuarioDto>(user);

        }
        public async void RegistrarLogAsync(LogSeguridadCreated command)
        {
            LogSeguridad log = new LogSeguridad();
            log.Evento = command.Evento;
            log.RegistroFecha = DateTime.Now;
            log.IdOficina = command.IdOficina;
            log.Maquina = command.Maquina;
            log.IdUsuario = command.IdUsuario;
            log.CodigoUsuario = command.CodigoUsuario;
            log.Intentos = command.Intentos;
            log.IdPerfil = command.IdPerfil;
            log.Observacion = command.Observacion;
            log.FechaCreacion = DateTime.Now;
            await _logSeguridadRepository.AddAsync(log);
            _contextDatabase.SaveChanges();
        }

        public async Task<bool> ForgetPasswordAsync(string key, string sistema)
        {
            var user = await _userRepository.GetAsync(key, sistema);
            if (user == null)
                throw new DFastException(Codes.UserNotFound, $"Usuario : '{key}' no existe.");

            string password = Utils.GenerateRandomNo().ToString();
            user.Password = PasswordHasher.HashPassword(password);

            user.FechaCaducidadPass = DateTime.Now.AddDays(-1);
            user.Intentos = 0;
            user.Estado = "DESCONECTADO";
            _userRepository.Update(user);

            await _contextDatabase.SaveChangesAsync();

            // LOG DE USUARIO
             RegistrarLogAsync(new LogSeguridadCreated("OLVIDOPASSWORD", 0, "", user.IdUsuario, user.Key, (int)user.Intentos, 0, "OK"));

            //ENVIO DE PASSWORD
            _notificacionService.SendMail(user, password); 

            return true;

        }

        public async Task<bool> ChangePasswordAsync(string key, string currentPassword, string newPassword, string sistema)
        {
            var user = await _userRepository.GetAsync(key, sistema);

            if (user == null)
                 throw new DFastException(Codes.UserNotFound, $"Usuario : '{key}' no existe.");

            if (newPassword == currentPassword)
                throw new DFastException(Codes.CredencialesInvalidas, "Ingrese clave diferente a la anterior");

            if (!PasswordHasher.VerifyPassword(currentPassword, user.Password))
                throw new DFastException(Codes.CredencialesInvalidas, "Password Incorrecto.");

            user.Password = PasswordHasher.HashPassword(newPassword);

            user.FechaCaducidadPass = DateTime.Now.AddDays(365);
            user.Intentos = 0;
            user.Estado = "DESCONECTADO";

            _userRepository.Update(user);
            await _contextDatabase.SaveChangesAsync();

         
           RegistrarLogAsync(new LogSeguridadCreated("CAMBIOPASSWORD", 0, "", user.IdUsuario, user.Key, (int)user.Intentos, 0, "OK"));

            return true;
        }

        public async Task<bool> UpdatePasswordAsync(string key, string currentPassword, string newPassword, string sistema)
        {
            var user = await _userRepository.GetAsync(key, sistema);

            if (user == null)
                throw new DFastException(Codes.UserNotFound, $"Usuario : '{key}' no existe.");

            user.Password = PasswordHasher.HashPassword(newPassword);

            user.FechaCaducidadPass = DateTime.Now.AddDays(365);
            user.Intentos = 0;
            user.Estado = "DESCONECTADO";

            _userRepository.Update(user);
            await _contextDatabase.SaveChangesAsync();


            RegistrarLogAsync(new LogSeguridadCreated("ACTPASSWORD", 0, "", user.IdUsuario, user.Key, (int)user.Intentos, 0, "OK"));

            return true;
        }

        private string ClaimsAsync(Usuario user)
        {
            var claims = new Claim[]
            {
                new Claim("iduser", user.IdUsuario.ToString()),
                new Claim("user", user.Key.ToString()),
                new Claim("email", user.Email.ToString()),
                new Claim("sistema", user.Sistema.ToString()),
                new Claim("identificacion", user.Identificacion == null ? "":user.Identificacion.ToString()),
                new Claim("nombres", user.Nombres.ToString()),
                new Claim("apellidos", user.Apellidos == null ? "":user.Apellidos.ToString()),
                };
            var jwt = new JwtSecurityToken(
               issuer: _configuration.GetSection("jwt:issuer").ToString(),
               audience: _configuration.GetSection("jwt:audience").ToString(),
               claims: claims,
               expires: DateTime.Now.AddMinutes(300)
           );
            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }

        public async Task<string> TokenAsync(string key, string sistema)
        {
            var user = await _userRepository.GetAsync(key, sistema);
            if (user == null)
            {
                throw new DFastException(Codes.UserNotFound,
                    $"Usuario : '{key}' no existe.");
            }
            var jwt= ClaimsAsync(user); 
            return jwt;
        }

        public async Task<string> CrearOtpAsync(UsuarioDto command)
        {
            var user = await _userRepository.GetAsync(command.Key, command.Sistema);

            if (user == null)
                throw new DFastException(Codes.UserNotFound, $"Usuario : '{command.Key}' no existe.");

            int password = GenerateRandomNo();
            //user.Password = PasswordHasher.HashPassword(password.ToString());

            Otp reg = new()
            {
                Dato = command.Key,
                Clave = PasswordHasher.HashPassword(password.ToString()),
                Estado = "",
                FechaVigencia = DateTime.Now.AddMinutes(5)
            };

           await _otpRepository.AddAsync(reg);
           await _contextDatabase.SaveChangesAsync();
           return password.ToString();

        }
        public async Task<bool> ValidarOtpAsync(UsuarioDto command)
        {
            var reg = await _otpRepository.GetAsync(command.Key, "");
            if (reg == null)
                throw new DFastException(Codes.ExpiredPassword, $"Clave inválida.");
            if (reg.FechaVigencia < DateTime.Now) // no tiene una calve vigente
                throw new DFastException(Codes.ExpiredPassword, $"Clave expirada.");

             string password = PasswordHasher.HashPassword(command.Imei);

            if (!PasswordHasher.VerifyPassword(command.Imei, reg.Clave))
                throw new DFastException(Codes.CredencialesInvalidas, $"Clave inválida.");

            reg.Estado = "VALIDADO";
            _otpRepository.Update(reg);
            await _contextDatabase.SaveChangesAsync();
            return true;
        }

        private static int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public async Task<bool> EnviarPushAsync(MessagePush source)
        {
            var reg = await _registroRepository.ObtenerxIdUsuarioAsync(source.Sistema, source.IdUsuario);
            source.DeviceToken = reg.Token;

            var reg1 = await _userRepository.GetAsync(reg.IdUsuario);
          
            _logger.LogInformation("paso1");

            MessagePushDto mensagePush =  new MessagePushDto
            {
                Institution = reg1.Institucion,        // mapeo explícito
                Identification = reg1.Identificacion,

                Titulo = source.Titulo,
                Texto = source.Texto,
                Img = source.Img,
                DeviceToken = source.DeviceToken,
                Dato1 = source.Dato1,
                Dato2 = source.Dato2,
                Dato3 = source.Dato3,
                Dato4 = source.Dato4
            };

            await _sendNotificationService.SendPush(mensagePush); //ojo
            
            _logger.LogInformation("paso2");
            //_metricsRegistry.IncrementFindQuery(); // Incrementa el métrico
            _logger.LogInformation("paso3");
            return true;
        }


        public async Task<bool> EnviarListaPushAsync(List<MessagePush> sources)
        {
            if (sources == null || sources.Count == 0)
                return false;

            foreach (var source in sources)
            {
                // 1) token del dispositivo
                var reg = await _registroRepository.ObtenerxIdUsuarioAsync(source.Sistema, source.IdUsuario);
                if (reg == null || string.IsNullOrWhiteSpace(reg.Token))
                {
                    _logger.LogWarning("Sin token. Sistema={Sistema}, IdUsuario={IdUsuario}", source.Sistema, source.IdUsuario);
                    continue;
                }

                // 2) datos del usuario (institución / identificación)
                var user = await _userRepository.GetAsync(reg.IdUsuario);
                if (user == null)
                {
                    _logger.LogWarning("Usuario no encontrado. IdUsuario={IdUsuario}", reg.IdUsuario);
                    continue;
                }

                var mensajePush = new MessagePushDto
                {
                    Institution = user.Institucion,
                    Identification = user.Identificacion,

                    Titulo = source.Titulo,
                    Texto = source.Texto,
                    Img = source.Img,
                    DeviceToken = reg.Token,

                    Dato1 = source.Dato1,
                    Dato2 = source.Dato2,
                    Dato3 = source.Dato3,
                    Dato4 = source.Dato4
                };

                _logger.LogInformation("Enviando push a {IdUsuario}", source.IdUsuario);
                await _sendNotificationService.SendPush(mensajePush);
            }

            return true;
        }

        public async Task<List<UsuarioSistemaDto>> ObtenerUsuariosComercioAsync(int idComercio)
        {
            List<UsuarioSistema> regs = await _userSistemaRepository.ObtenerTodosxRelacionAsync(idComercio);
            return _mapper.Map<List<UsuarioSistemaDto>>(regs);
        }

        public async Task<UsuarioDtoIng> GetUser(string key,string sistema)
        {
            var user = await _userRepository.GetAsync(key, sistema);

            if (user == null)
                throw new DFastException(Codes.UserNotFound, $"Usuario : '{key}' no existe.");

            UsuarioDto regUser = _mapper.Map<UsuarioDto>(user);
            return _mapper.Map<UsuarioDtoIng>(regUser);


            
        }

        public async Task<List<UsuarioDtoIng>> GetUsersByNombreApellidos(string nombres, string apellidos, string sistema)
        {
            var users = await _userRepository.GetByNombreApellidosAsync(nombres, apellidos, sistema);
            var regUsers = _mapper.Map<List<UsuarioDto>>(users);
            return _mapper.Map<List<UsuarioDtoIng>>(regUsers);
        }
    }
}
