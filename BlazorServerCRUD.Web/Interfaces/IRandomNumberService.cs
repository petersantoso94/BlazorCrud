using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerCRUD.Web.Interfaces
{
    public interface IRandomNumberService
    {
        List<string> GetRandomNumber();
    }
}