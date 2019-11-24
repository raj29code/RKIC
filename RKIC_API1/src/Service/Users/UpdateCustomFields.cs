
using System;
using System.Collections.Generic;
using RKICUser = Service.Model.User;

namespace Service.Users
{
   public class UpdateCustomFieldsCommand : UpdateBase<RKICUser>
    {
        public static UpdateCustomFieldsCommand WithFilter(IQuery<RKICUser> filter)
        {
            var obj = new UpdateCustomFieldsCommand();
            obj.FilterInt = filter;
            return obj;
        }
        public UpdateCustomFieldsCommand UpdateMany()
        {
            IsManyUpdate = true;
            return this;
        }
      
        public UpdateCustomFieldsCommand SetExistingColumns(RKICUser fMPCustomFields)
        {
            if(fMPCustomFields.Email!=null) Updates.Add(UpdateBuilder.Set(s => s.Email, fMPCustomFields.Email));
          Updates.Add(UpdateBuilder.Set(s => s.UserName, fMPCustomFields.UserName));
             Updates.Add(UpdateBuilder.Set(s => s.PasswordHash, fMPCustomFields.PasswordHash));
             Updates.Add(UpdateBuilder.Set(s => s.RefreshTokens, fMPCustomFields.RefreshTokens));
            return this;
        }
    }
}
