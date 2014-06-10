using System;
using ProstateBioBank.ObjectExtensions;

namespace ProstateBioBank.EntityFramework
{
    public abstract class EntityFrameworkRepository
    {
        private readonly Func<ProstateBioBankContext> _getContext;

        protected EntityFrameworkRepository(Func<ProstateBioBankContext> getContext)
        {
            _getContext = this.GetOrThrowArgumentNullException(getContext, "getContext");
        }

        protected ProstateBioBankContext Context
        {
            get { return _getContext(); }
        }
    }
}
