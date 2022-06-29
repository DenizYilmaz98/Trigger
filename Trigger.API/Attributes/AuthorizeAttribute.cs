using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trigger.API.Attributes
{
    public class AuthorizeAttribute : Attribute, IAuthorizeData
    {
    }
    public interface IAuthorizeData
    {

    }
}