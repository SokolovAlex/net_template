using App.BLL;
using App.DAL;

namespace App.Web
{
    public class IoCConfig
    {
        public static void Initialize()
        {
            IoC.Initialize(
                new BLL_IoCModule(),
                new DAL_IoCModule()
            );
        }
    }
}