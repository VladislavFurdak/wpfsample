using ReferenceData.BAL.BusModels;
using ReferenceData.DAL.Model;
using System.Collections.Generic;

namespace ReferenceData.BAL
{
    public interface IBusUser : IAddEntity<User>, IUpdateEntity<User>, IGetEntity<User,int>, IGetList<User>
    {
        Dictionary<int, UserBusModel> UserList();
        UserBusModel AddBusModel(UserBusModel model);
        UserBusModel UpdateBusModel(UserBusModel model);
    }
}
