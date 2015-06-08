using ReferenceData.BAL.BusModels;
using ReferenceData.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.BAL
{
    public interface IBusUser : IAddEntity<User>, IUpdateEntity<User>, IGetEntity<User,int>, IGetList<User>
    {
        Dictionary<int, UserBusModel> GetSimpleUserList();
        UserBusModel AddBusModel(UserBusModel model);
        UserBusModel UpdateBusModel(UserBusModel model);
    }
}
