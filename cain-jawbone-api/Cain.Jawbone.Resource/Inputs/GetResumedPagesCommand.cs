using cain_jawbone_resources.Results;
using MediatR;

namespace cain_jawbone_resources.Inputs
{
    public class GetResumedPagesCommand : IRequest<GetResumedPagesResult>
    {
        public GetResumedPagesCommand()
        {
        }
    }
}
