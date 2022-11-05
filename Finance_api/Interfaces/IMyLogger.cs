using Serilog.Core;

namespace Finance_api.Interfaces
{
    internal interface IMyLogger
    {
         Logger WriteLogInFile();
    }
}
