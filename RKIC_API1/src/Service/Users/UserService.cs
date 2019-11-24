
using Service.Model;
using Service.Users.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMPCustomFields = Service.Model.User;

namespace Service.Users
{
    public class UserService : IUserService
    {

        private readonly ICommandHandler<ICreateCommand<FMPCustomFields>> _createCustomFields;
        private readonly IQueryHandler<IQuery<FMPCustomFields>, bool> _customFieldsExists;
        private readonly IQueryHandler<IQuery<FMPCustomFields>, IReadOnlyList<FMPCustomFields>> _customfields;
        private readonly ICommandHandler<IUpdateCommand<FMPCustomFields>> _updatecustomfields;

        public UserService(ICommandHandler<ICreateCommand<FMPCustomFields>> createCustomFields,
            IQueryHandler<IQuery<FMPCustomFields>, bool> customFieldsExists,
             IQueryHandler<IQuery<FMPCustomFields>, IReadOnlyList<FMPCustomFields>> customfields,
              ICommandHandler<IUpdateCommand<FMPCustomFields>> updatecustomfields)
        {
            _createCustomFields = createCustomFields;
            _customFieldsExists = customFieldsExists;
            _customfields = customfields;
            _updatecustomfields = updatecustomfields;
        }

        public async Task<bool> createUser(FMPCustomFields saveCustomColumnRequestData)
        {
            var Isexist = await _customFieldsExists.Handle(
                 CustomFieldsFilter.UserName(saveCustomColumnRequestData.UserName)
                    );
            if(Isexist)
            {
                return false;
            }
            else
            {
                var customFieldsData = FMPCustomFields.From(
         saveCustomColumnRequestData);
                await _createCustomFields.Handle(
                   CreateCommand<FMPCustomFields>.From(customFieldsData));
            }
            return true;
        }

        public async Task<User> GetUserByIdAndPassword(string UserId,string password)
        {
            var data = await _customfields.Handle(
                 CustomFieldsFilter.UserName(UserId).AndByPassword(password)
                    );

            if(data.Count()>0)
            {
                return data.ToList()[0];
            }

            return null;
        }
        public async Task<User> GetUserById(string UserId)
        {
            var data = await _customfields.Handle(
                 CustomFieldsFilter.UserName(UserId)
                    );

            if (data.Count() > 0)
            {
                return data.ToList()[0];
            }

            return null;
        }

        public async Task<bool> UpdateUser(FMPCustomFields User)
        {
          var result =  await _updatecustomfields.Handle(
                    UpdateCustomFieldsCommand
                        .WithFilter(CustomFieldsFilter
                            .UserName(User.UserName)
)
                        .SetExistingColumns(User)
                );

            return result;
        }
    }
}
