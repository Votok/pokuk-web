using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using pokuk_common;

namespace web
{
    public class GalleryModel
    {
        private static GalleryModel _instance;

        public List<GalleryYear> Years { get; private set; }

        private GalleryModel(Gallery gallery)
        {
            Years = gallery.Years;
        }

        public static GalleryModel GetInstance()
        {
            if (_instance != null)
                return _instance;

            var manager = new GalleryManager();
            var azureGallery = manager.ReadGalleryFileFromAzure();

            _instance = new GalleryModel(azureGallery);
            return _instance;
        }

        public GalleryEvent GetGalleryEvent(string name)
        {
            foreach (var year in _instance.Years)
            {
                var found = year.GalleryEvents.FirstOrDefault(x => x.Name == name);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
}