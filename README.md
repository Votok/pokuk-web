# pokuk-web

Asp.net core mvc web for pokuk photo gallery
_This assumes existing photos and gallery json schema in blob container - all can be done by pokuk-upload_

Add **appsettings.json** file with the following keys:

- **GalleryJsonName**: gallery schema json file that is created localy and saved to azure blob
- **AzureContainerName**: name of the blob container where the photos are
- **AzureContainerUrl**: azure blob container base url
- **AzureStorageConnectionString**: azure storage connection string

**Example:**

```sh
{
  "GalleryJsonName": "_gallery.json",
  "AzureContainerName": "somecontainer",
  "AzureContainerUrl": "https://somestorage.blob.core.windows.net/somecontainer/",
  "AzureStorageConnectionString": "DefaultEndpointsProtocol=https;AccountName=***storage;AccountKey=***;EndpointSuffix=***"
}
```

dotnet restore
dotnet run

profit

## Deployment (Azure App Service Local Git)

You can deploy manually to Azure App Service using Local Git (Kudu). This repo was previously deployed that way.

Prerequisites:

- Local Git is enabled in Azure Portal > Your App Service > Deployment Center > Local Git
- Application-scope Local Git username and password are configured in Deployment Center (specific to this app)
- App Service is configured for .NET 8 runtime

Add the Azure Kudu remote (use your Application-scope Local Git username if you want to embed it; otherwise omit and you will be prompted):

```zsh
# From the repository root
git remote add azure https://pokuk.scm.azurewebsites.net:443/pokuk.git
# or with Application-scope username embedded (you will still be prompted for the password)
# git remote add azure https://<APP_SCOPE_USERNAME>@pokuk.scm.azurewebsites.net:443/pokuk.git
```

Deploy by pushing the master branch directly to production:

```zsh
git push azure master
```

Notes:

- The server-side build runs in Kudu. Monitor progress in Azure Portal > Deployment Center > Logs.
- If the push is rejected due to a different default branch, set the deployment branch in Deployment Center to "master".
- If you previously used GitHub Actions, they have been removed to avoid confusion with Local Git deploys.
- When prompted for credentials, use the Application-scope Local Git username and password from Deployment Center (do not use the global Deployment User or Azure AD credentials).
