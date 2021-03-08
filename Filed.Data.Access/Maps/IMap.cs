using Microsoft.EntityFrameworkCore;

namespace Filed.Data.Access.Maps
{
    public interface IMap
    {
        void Visit(ModelBuilder builder);
    }
}
