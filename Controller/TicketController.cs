using backend_management_system_api.Data;
using backend_management_system_api.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_management_system_api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {

        private readonly DbConfig ticketContext;

        public TicketController(DbConfig ticket_context)
        {
            ticketContext = ticket_context;
        }


        // get all Tickets from Database;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAllTickets()
        {
            return await ticketContext.Tickets.ToListAsync();
        }


        // get one ticket;
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ticket>> GetOneTicketByID(int id)
        {

            var ticket = await ticketContext.Tickets.FindAsync(id);
            if(ticket == null){
                return NotFound("Cannot find this ticket...");
            }else{
                return Ok(ticket);
            }
        }

        // to create one Ticket to a Database;
        [HttpPost]
        public async Task<ActionResult<Ticket>> CraeteOneTicket(Ticket ticket)
        {

            if(!ModelState.IsValid){
                return BadRequest();
            }
            
            ticketContext.Tickets.Add(ticket);
            var res = await ticketContext.SaveChangesAsync();

            if(res > 0){
                return CreatedAtAction(nameof(GetAllTickets), new { id = ticket.Id }, ticket);
            }
            return BadRequest();
            
        }

        // to see if the ticket data exists in the DB;
        private bool TicketExists(long id){
            return (ticketContext.Tickets?.Any(ticket => ticket.Id == id)).GetValueOrDefault();
        }

        // PUT: api/tickets/{id} to edit one Ticket in the Database;
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id){
                return BadRequest("Cannot find the ticket...");
            }

            ticketContext.Entry(ticket).State = EntityState.Modified;
            try
            {
                var res = await ticketContext.SaveChangesAsync();
                if(res > 0){
                    return Ok(ticket);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                
               if(!TicketExists(id)){
                  return NotFound("Ticket not found...");
               }
               else{
                throw;
               }
            }
            return BadRequest("Cannot update the ticket...");
        }

        

        // delete one ticket if found;
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {

            var ticket = await ticketContext.Tickets.FindAsync(id);
            if (ticket == null || ticketContext.Tickets == null){
               return NotFound("Cannot find this ticket...");
            }
            // Log.Information("ticket ", ticket);

            ticketContext.Tickets.Remove(ticket);
            var res = await ticketContext.SaveChangesAsync();
            if(res > 0){
                return Ok();
            }
            return BadRequest();
        }
        
    }
}