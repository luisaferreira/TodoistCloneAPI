using System.Data;

namespace TodoistCloneAPI.Shared.Interfaces.Repositories
{
    public interface IDataBase
    {
        int ExecutaQuery(string sql);
        DataSet ExecutaSelect(string sql);
    }
}
