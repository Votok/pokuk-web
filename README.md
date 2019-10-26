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
