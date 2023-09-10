using ObiletJourney.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletJourney.Business.Interfaces
{
    public interface ISessionService
    {
        Task<BaseResponse> GetSessionAsync();
    }
}
