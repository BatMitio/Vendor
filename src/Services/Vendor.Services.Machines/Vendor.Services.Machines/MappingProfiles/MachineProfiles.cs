using AutoMapper;
using Vendor.Services.Machines.Commands.CreateVendorCommand;
using Vendor.Services.Machines.Commands.LoadSpiralCommand;
using Vendor.Services.Machines.Commands.VendingDropCommand;
using Vendor.Services.Machines.Data.Entities;
using Vendor.Services.Machines.DTO;
using Vendor.Services.Machines.Queries;
using Vendor.Services.Machines.Views;

namespace Vendor.Services.Machines.MappingProfiles;

public class MachineProfiles : Profile
{
    public MachineProfiles()
    {
        CreateMap<CreateVendingCommand, Vending>();

        CreateMap<Vending, VendingView>()
            .ForMember(destinationMember =>
                    destinationMember.Products,
                memberOptions =>
                    memberOptions.MapFrom(
                        src => src.Spirals
                            .Where(s => s.ProductId != null)
                            .Select(s => new ProductView(){ProductId = s.ProductId, Quantity = s.Loads})
                            .ToList()
                    )
            );

        CreateMap<CreateVendingDto, CreateVendingCommand>();
        CreateMap<VendingDropDto, VendingDropCommand>();
        CreateMap<LoadSpiralDto, LoadSpiralCommand>();
        CreateMap<Spiral, SpiralView>();
        CreateMap<QuerySpiralDto, QuerySpiral>();
    }
}