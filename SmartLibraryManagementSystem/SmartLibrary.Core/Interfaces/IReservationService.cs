using SmartLibrary.Core.DTOs.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationDto> ReserveBookAsync(CreateReservationDto dto);
        Task<bool> CancelReservationAsync(int id);
    }
}
