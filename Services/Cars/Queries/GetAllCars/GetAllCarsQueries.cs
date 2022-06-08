using MediatR;


namespace Services.Cars.Queries.GetAllCars
{
    public class GetAllCarsQueries : IRequest<IEnumerable<Car1>> { }

    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQueries, IEnumerable<Car1>>
    {
        public async Task<IEnumerable<Car1>> Handle(GetAllCarsQueries request, CancellationToken cancellationToken)
        {
            return new[] { new Car1 { nameof = "Ford"},
            new Car1 { nameof = "Ford1" },
            new Car1 { nameof = "Ford2" },
            new Car1 { nameof = "Ford3" }};            
        }
    }

    public class Car1
    {
        public string nameof { get; set; }

    }

}
