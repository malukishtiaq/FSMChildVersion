using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace FSMChildVersion.Core.Model.Settings
{
    public class GetSettingsRequest : IRequest<GetSettingsResponse>
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public static GetSettingsRequest CreateSettingRequest(string key, string value)
        {
            return new GetSettingsRequest(key, value);
        }
        public GetSettingsRequest()
        {

        }
        public GetSettingsRequest(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
