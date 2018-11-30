using System.Collections.Generic;

namespace Pensatiu.Services.Interfaces
{
    public interface IPensatiuService<DtoForGet, DtoForCreate, DtoForUpdate>
        where DtoForGet : class
        where DtoForCreate : class
        where DtoForUpdate : class
    {
        DtoForGet Get(int id);

        IEnumerable<DtoForGet> GetAll();

        bool Exists(int id);

        DtoForGet Create(DtoForCreate dtoForCreate);

        bool Update(int id, DtoForUpdate dtoForUpdate);

        bool Delete(int id);
    }

    public interface IDto
    {
    }

    public interface IDtoForGet
    {
        int Id { get; set; }
    }

    public interface IDtoForCreate
    {
    }

    public interface IDtoForUpdate
    {
    }
}