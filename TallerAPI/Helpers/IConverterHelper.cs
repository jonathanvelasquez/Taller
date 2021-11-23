using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerAPI.Data.Entities;
using TallerAPI.Models;

namespace TallerAPI.Helpers
{
    public interface IConverterHelper
    {
        Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew);

        UserViewModel ToUserViewModel(User user);
    }
}
