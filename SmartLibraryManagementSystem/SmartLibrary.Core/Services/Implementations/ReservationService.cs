using SmartLibrary.Core.DTOs.Reservations;
using SmartLibrary.Core.Entities;
using SmartLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepo;

        public ReservationService(IReservationRepository reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }

        public async Task<ReservationDto> ReserveBookAsync(CreateReservationDto dto)
        {
            var reservation = new Reservation
            {
                UserId = dto.UserId,
                BookId = dto.BookId,
                ReservedAt = DateTime.Now,
                IsActive = true
            };

            await _reservationRepo.AddAsync(reservation);

            return new ReservationDto
            {
                Id = reservation.Id,
                UserId = reservation.UserId,
                BookId = reservation.BookId,
                ReservedAt = reservation.ReservedAt,
                IsActive = reservation.IsActive
            };
        }

        public async Task<bool> CancelReservationAsync(int id)
        {
            var reservation = await _reservationRepo.GetByIdAsync(id);
            if (reservation == null)
                return false;

            reservation.IsActive = false;
            await _reservationRepo.UpdateAsync(reservation);
            return true;
        }
    }
}
