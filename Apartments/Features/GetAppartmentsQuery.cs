using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Apartments.DAL;
using Apartments.Models;
using Apartments.Models.Apartment;
using Apartments.Models.Apartment.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Apartments.Features.Query
{
    public class GetAppartmentsQuery : IRequest<GetApartmentsViewModel>
    {
        public GetAppartmentsQuery(GetAppartmentsRequest request, int top, int skip)
        {
            Request = request;
            Top = top;
            Skip = skip;
        }

        public GetAppartmentsRequest Request { get; }
        public int Top { get; set; }
        public int Skip { get; set; }
    }

    public class GetAppartmentsQueryHandler : IRequestHandler<GetAppartmentsQuery, GetApartmentsViewModel>
    {
        private readonly ILogger<GetAppartmentsQueryHandler> _logger;
        private readonly IRepository<Apartment> _apartmentRepository;

        public GetAppartmentsQueryHandler(ILogger<GetAppartmentsQueryHandler> logger, IRepository<Apartment> apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
            _logger = logger;
        }

        public async Task<GetApartmentsViewModel> Handle(GetAppartmentsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting apartments");


            var app = await _apartmentRepository.Query.ToListAsync();

            var apartmentsQuery = _apartmentRepository.Query.Include(x => x.Owner).AsNoTracking()
                                     .Where(a =>
                                          (string.IsNullOrEmpty(request.Request.Address) || a.Address.Contains(request.Request.Address)) &&
                                          (request.Request.RoomsNumber == null || a.RoomsNumber == request.Request.RoomsNumber));

            if (request.Request.Owner != null)
            {
                apartmentsQuery = FilterByOwner(apartmentsQuery, request.Request.Owner);
            }

            var apartments = await apartmentsQuery.ToListAsync();

            return new GetApartmentsViewModel()
            {
                Apartments = apartments.Skip(request.Skip).Take(request.Top).ToList(),
                TotalRecords = apartments.Count()
            };
        }

        private IQueryable<Apartment> FilterByOwner(IQueryable<Apartment> apartments, OwnerViewModel owner)
        {
            return apartments.Where(a => a.Owner == null || (
                                        (string.IsNullOrEmpty(owner.FirstName) || a.Owner.FirstName.Contains(owner.FirstName)) &&
                                        (string.IsNullOrEmpty(owner.LastName) || a.Owner.LastName.Contains(owner.LastName)) &&
                                        (string.IsNullOrEmpty(owner.PlacceOfWork) || a.Owner.PlacceOfWork.Contains(owner.PlacceOfWork))
                                        ));
        }
    }
}