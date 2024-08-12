using Autenticacao.Jwt.CrossCutting.Configurations.v1.Models;

namespace Autenticacao.Jwt.CrossCutting.Configurations.v1
{
    public class AppsettingsConfigurations
    {
        public JwtConfiguration JwtConfiguration { get; set; }
        public RedisConfiguration RedisConfiguration { get; set; }
        public string Database { get; set; }
    }
}