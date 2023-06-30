using Core;
using Infrastructure;
using Services;
using Providers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installs
{
    public class ProjectInstaller : LifetimeScope
    {
        [SerializeField] private CurtainProvider _curtain;
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterProviders(builder);
            RegisterServices(builder);
            RegisterInfrastructure(builder);
        }

        private void RegisterInfrastructure(IContainerBuilder builder)
        {
            builder.Register<ImageClickHandler>(Lifetime.Singleton);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<SceneLoader>().AsSelf();
            builder.Register<DisplayOrientationService>(Lifetime.Singleton);
        }

        private void RegisterProviders(IContainerBuilder builder)
        {
            builder.Register(container => Instantiate(_curtain), Lifetime.Singleton);
            builder.RegisterEntryPoint<InputService>();
        }
    }
}
