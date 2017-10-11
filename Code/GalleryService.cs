using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using pokuk_common;

namespace web
{
    public class GalleryService
    {
        private static GalleryService _service;

        public List<GalleryYear> Years { get; private set; }

        private GalleryService(IGallery gallery)
        {
            Years = gallery.Years;
        }

        public static GalleryService Instance(GalleryOptions config)
        {
            if (_service != null)
                return _service;

            var provider = new GalleryProvider(config);
            var azureGallery = provider.ReadAzureGalleryJson();

            _service = new GalleryService(azureGallery);
            return _service;
        }

        public GalleryEvent GetEvent(string id)
        {
            int parsedYear;
            if (!int.TryParse(id.Substring(0, 4), out parsedYear))
                return null;

            string name = id.Substring(4);

            foreach (var year in _service.Years)
            {
                if (year.Year != parsedYear)
                    continue;

                var found = year.GalleryEvents.FirstOrDefault(x => x.Name == name);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
}