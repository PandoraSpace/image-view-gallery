using CompositionRoot;
using Providers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installs
{
    public class ViewInstaller : LifetimeScope
    {
        [SerializeField] private ViewProvider _viewProvider;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterProviders(builder);

            builder.RegisterEntryPoint<ViewEntryPoint>();
        }

        private void RegisterProviders(IContainerBuilder builder)
        {
            builder.RegisterComponent(_viewProvider);
        }
    }
}