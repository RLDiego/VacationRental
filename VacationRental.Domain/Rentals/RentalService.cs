using System;
using VacationRental.Domain.DTO.Common;
using VacationRental.Domain.DTO.Rental;

namespace VacationRental.Domain.Rentals
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public RentalViewModel GetById(int rentalId)
        {
            if (!this._rentalRepository.Exists(rentalId))
                throw new ApplicationException("Rental not found");

            return this._rentalRepository.GetById(rentalId);
        }

        public ResourceIdViewModel Add(RentalBindingModel model)
        {
            if (model.Units < 1)
                throw new ApplicationException("Rental units must be positive");
            if (model.PreparationTimeInDays < 0)
                throw new ApplicationException("The preparation time in days cannot be less than zero");

            var nextId = new ResourceIdViewModel { Id = this._rentalRepository.GetNextId() };
            var newRental = new RentalViewModel()
            {
                Id = nextId.Id,
                Units = model.Units,
                PreparationTimeInDays = model.PreparationTimeInDays
            };

            this._rentalRepository.Add(newRental);

            return nextId;
        }
    }
}
