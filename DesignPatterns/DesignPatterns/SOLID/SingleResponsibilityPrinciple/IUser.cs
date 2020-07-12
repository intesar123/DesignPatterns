using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.SingleResponsibilityPrinciple
{
    interface IUser
    {
        bool login(string userName, string password);
        bool register(string userName, string password, string email);
        // if we look at closely the user object should be able to perform only above two function and blow functions should not be part of it
        //bool logError(string error);
        //bool sendMail(string emailContent);

    }
    interface ILogError
    {
        bool logError(string error);
    }
    interface ISendMail
    {
        bool sendMail(string emailContent);
    }
}
