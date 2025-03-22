using DeleteContact.Application.Contacts.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace DeleteContact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _dispatcher;

        public ContactsController(IMediator dispatcher)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(DeleteContactCommandResponse), Status202Accepted)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<DeleteContactCommandResponse>> DeleteContact([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = await _dispatcher.Send(new DeleteContactCommand(id), cancellationToken);
            return Accepted(response);
        }
    }
}
