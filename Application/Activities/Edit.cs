using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistance;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity? Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            public DataContext _context { get; }
            private readonly IMapper mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                this.mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity!.Id);

                this.mapper.Map(request.Activity, activity);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}