using AndysManClub.Data.Repositories;
using AndysManClub.Domain.AggregateRoot;
using AndysManClub.Domain.Repositories;
using AndysManClub.Shared.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AndysManClub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IAmcEventRepository _amcEventRepository;
        private readonly IMapper _mapper;

        public EventController(IAmcEventRepository amcEventRepository, IMapper mapper)
        {
            _amcEventRepository = amcEventRepository ?? throw new ArgumentNullException(nameof(amcEventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public IActionResult Get()
        {
            var activeEvents = _amcEventRepository.Get();
            if (!activeEvents.Any())
            {
                return BadRequest(activeEvents);
            }
            // This needs to be mapped to a dto instead of returning the raw object
            return Ok(activeEvents);
        }

        // Intend this method to get back more information about a particular event assuming
        // the other endpoint we bring back a list of superficial inofrmation about an event
        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var activeEvent = _amcEventRepository.Get(id);
            if (activeEvent is null)
            {
                return BadRequest(activeEvent);
            }
            // This needs to be mapped to a dto instead of returning the raw object
            return Ok(activeEvent);
        }

        // should we be more explicit and have "/create" as the route?
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateAmcEventDto amcEvent)
        {
            // assume we do some auto mapping from a dto to a AmcEvent
            // and will most likely contain other information as well
            try
            {
                ArgumentNullException.ThrowIfNull(amcEvent);

                _amcEventRepository.Create(_mapper.Map<CreateAmcEventDto, AmcEvent>(amcEvent));
                await _amcEventRepository.Save();
            } catch (Exception ex)
            {
                // What do we return here?
                return BadRequest();
            }

            // What do we return? Just an okay?
            return Ok();
        }

        // What should the method signature be? Do we send a full person dto or should it be a guid
        // Then we do a look up to see if they exist?
        [HttpPut("/{id:Guid}/volunteer")]
        public IActionResult Put(Guid id, Person person)
        {
            // assume we do some auto mapping from a dto to a AmcEvent
            // and will most likely contain other information as well
            try
            {
                var amcEvent = _amcEventRepository.Get(id);
                amcEvent.RegisterPerson(person);
                _amcEventRepository.Save();
            }
            catch (Exception ex)
            {
                // What do we return here?
                return BadRequest();
            }

            // What do we return? Just an okay?
            return Ok();
        }

    }
}
