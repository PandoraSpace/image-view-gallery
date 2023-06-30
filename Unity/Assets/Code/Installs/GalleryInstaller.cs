using CompositionRoot;
using Configs;
using Infrastructure;
using Services;
using Providers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installs
{
    public class GalleryInstaller : LifetimeScope
    {
        [SerializeField] private GalleryProvider _galleryProvider;
        [SerializeField] private LoadingImageConfig _loadingImageConfig;
        [SerializeField] private CoroutineRunner _coroutineRunner;
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterProviders(builder);
            RegisterServices(builder);
            RegisterConfigs(builder);
            RegisterInfrastructure(builder);

            builder.RegisterEntryPoint<GalleryEntryPoint>(Lifetime.Scoped);
        }

        private void RegisterInfrastructure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_coroutineRunner);
            builder.Register<ImageFactory>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();
        }

        private void RegisterConfigs(IContainerBuilder builder)
        {
            builder.RegisterInstance(_loadingImageConfig);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ImageLoaderService>(Lifetime.Scoped);
        }

        private void RegisterProviders(IContainerBuilder builder)
        {
            builder.RegisterInstance(_galleryProvider);
        }
    }
}