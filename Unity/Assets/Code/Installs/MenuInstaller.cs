using CompositionRoot;
using Providers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installs
{
    public class MenuInstaller : LifetimeScope
    {
        [SerializeField] private MenuProvider _menuProvider;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterProviders(builder);

            builder.RegisterEntryPoint<MenuEntryPoint>(Lifetime.Scoped);
        }

        private void RegisterProviders(IContainerBuilder builder)
        {
            builder.RegisterInstance(_menuProvider);
        }
    }
}