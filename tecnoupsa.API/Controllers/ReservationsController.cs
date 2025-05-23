using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TecnoupsaBackend.Data;
using TecnoupsaBackend.Models;

namespace TecnoupsaBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ReservationsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReservationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateReservation([FromBody] Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        _context.SaveChanges();
        return CreatedAtAction(nameof(CreateReservation), new { id = reservation.Id }, reservation);
    }
}