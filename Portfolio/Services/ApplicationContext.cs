using Microsoft.EntityFrameworkCore;

namespace Portfolio
{
    public class ApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
