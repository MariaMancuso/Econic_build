using Econic.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Econic.Mobile.Services
{
    public interface IMediaService
    {
        event EventHandler<MediaEventArgs> OnMediaAssetLoaded;
        bool IsLoading { get; }
        Task<IList<MediaAssest>> RetrieveMediaAssetsAsync(CancellationToken? token = null);
        Task<string> StoreProfileImage(string path);
        Task<string> GetImageWithCamera();
    }
}
