using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace FSMChildVersion.Common.RequestResponseModel.Settings
{
    public class AddSettingsRequest : IRequest<AddSettingsResponse>
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public static AddSettingsRequest CreateSettingRequest(string key, string value)
        {
            return new AddSettingsRequest(key, value);
        }
        public AddSettingsRequest()
        {

        }
        public AddSettingsRequest(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
