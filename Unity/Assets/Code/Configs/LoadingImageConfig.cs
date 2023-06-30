using Providers;
using UnityEngine;
using UnityEngine.UI;

namespace Configs
{
    [CreateAssetMenu]
    public class LoadingImageConfig : ScriptableObject
    {
        [SerializeField] private ImageProvider _imagePrefab;
        [SerializeField, Range(1, 8)] private int _imagesPerPage = 8;
        [SerializeField] private string _path;

        public ImageProvider ImagePrefab => _imagePrefab;

        public int ImagesPerPage => _imagesPerPage;

        public string Path => _path;
    }
}