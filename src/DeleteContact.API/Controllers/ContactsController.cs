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

        [HttpDelete]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<CreateContactCommandResponse>> DeleteContact(
            [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _dispatcher.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
