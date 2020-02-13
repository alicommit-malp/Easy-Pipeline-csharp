using System;
using System.Threading.Tasks;

namespace EasyPipeLine.deprecated
{
    [Obsolete("Link class has been deprecated, please drive from WorkStation class instead")]
    public abstract class Link
    {
        private Link _nextLink;
        private Link _prevLink;
        protected bool IsRoot;

        [Obsolete("Next Method has been deprecated, please use WorkStation's Next method instead")]
        public Link Next(Link link)
        {
            _nextLink = link;
            _nextLink._prevLink = this;
            return _nextLink;
        }

        [Obsolete("Run Method has been deprecated, please use WorkStation's Run method instead")]
        public async Task Run(ILinkData data)
        {
            if (IsRoot)
                await InvokeAsync(data);
            else
            {
                _prevLink?.Run(data);
            }
        }

        [Obsolete("InvokeAsync Method has been deprecated, please use WorkStation's InvokeAsync method instead")]
        protected virtual async Task InvokeAsync(ILinkData data)
        {
            if (_nextLink != null) await _nextLink?.InvokeAsync(data);
        }
    }
}