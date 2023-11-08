
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using artvibe_oracle.Data;
using artvibe_oracle.Data.Configurations;
using artvibe_oracle.Infraestructura;
using artvibe_oracle.Infraestructura.Entidades;
using artvibe_oracle.Models.userModel;

namespace artvibe_oracle.Services
{
    public class UserSe : IUsuario
    {
        private readonly SignInManager<UserData> _signInManager;
        private readonly UserManager<UserData> _userManager;
        private readonly IResponseService _responseService;
        private readonly IConfiguration _configuration;
        private UserData _user;
        public readonly IMapper _mapper;
        public UserSe(IMapper mapper, IConfiguration configuration, IResponseService responseService, UserManager<UserData> userMana, SignInManager<UserData> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userMana;
            _responseService = responseService;
            _configuration = configuration;
            _mapper = mapper;
            _signInManager = signInManager;
        }
        public Task<IResponseService> Borrar(Guid id)
        {
            throw new NotImplementedException();
        }


        public async Task<IResponseService> Crear(RegisterUser register)
        {
            try
            {
                var _userData = _mapper.Map<UserData>(register);

                var result = await _userManager.CreateAsync(_userData, register.Password);
                Debug.WriteLine("CreateAsync executed");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(_userData, "Admin");
                    _responseService.EstablecerRespuesta(true, _userData);
                }
                else
                {
                    _responseService.Estado = false;

                }

                return _responseService;
            }
            catch (Exception ex)
            {
                //_responseService.Errores.Add(_exceptionHandler.GetMessage(ex));
                _responseService.Estado = false;
                return _responseService;
            }
        }

        public Task<IResponseService> Listar(dynamic param)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseService> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IResponseService> Modificar(Guid id, UserData entidad)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseService> Obtener(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponseDto> Login(LoginDtoBase loginDtoBase)
        {
            //_logger.LogInformation($"Looking for user with email {loginDtoBase.Email}");

            var money = await _signInManager.PasswordSignInAsync(loginDtoBase.Email, loginDtoBase.Password, false, lockoutOnFailure: true);
            _user = await _userManager.FindByEmailAsync(loginDtoBase.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(_user, loginDtoBase.Password);
            if (isValidUser == false || _user == null)
            {
                //     _logger.LogWarning($"User with email {loginDtoBase.Email} was not found");
                return null;
            }
            var token = await GenerateToken();
            // _logger.LogInformation($"Token generated for user with email {loginDtoBase.Email} | token {token}");
            return new AuthResponseDto
            {
                Token = token,
                UserId = _user.Id,
                //  RefreshToken = null
            };

        }

        private async Task<string> GenerateToken()
        {
            //Se firma el token 
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            //Encriptación de token 
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            //Roles que tiene el usuario consulta
            var roles = await _userManager.GetRolesAsync(_user);
            //
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user);

            var claims = new List<Claim>
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, _user.Email),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, _user.Email),
                new Claim("uid", _user.Id),
            }
            .Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task<IResponseService> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
