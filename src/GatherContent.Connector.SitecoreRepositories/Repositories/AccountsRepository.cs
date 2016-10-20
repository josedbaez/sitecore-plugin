﻿using GatherContent.Connector.Entities;
using GatherContent.Connector.IRepositories.Interfaces;

namespace GatherContent.Connector.SitecoreRepositories.Repositories
{
    public class AccountsRepository : BaseSitecoreRepository, IAccountsRepository
    {
        public AccountsRepository() : base() { }

        public GCAccountSettings GetAccountSettings()
        {
            var accountSettingItem = ContextDatabase.GetItem(Constants.AccountItemId, ContextLanguage);
            if (accountSettingItem != null)
            {
                return new GCAccountSettings
                {
                    ApiUrl = "https://api.gathercontent.com/", //hardcoded value requested by client 
                    Username = accountSettingItem["Account Owner Email Address"],
                    ApiKey = accountSettingItem["API Key"],
                    TemplateFolderId = accountSettingItem["Templates Root Folder"],
                    DateFormat = accountSettingItem["Date Format"],
                    GatherContentUrl = accountSettingItem["Platform Url"],
                    DropTreeHomeNode = accountSettingItem["DropTree Home Node"],
                    AccountItemId = accountSettingItem.ID.ToString()
                };

            }

            return null;
        }
    }
}
