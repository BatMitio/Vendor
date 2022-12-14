using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Vendor.Services.Machines.Data.Persistence;

namespace Vendor.Services.Machines.Commands.CreateVendorCommand;

public class CreateVendingCommandValidator : AbstractValidator<CreateVendingCommand>
{
    public CreateVendingCommandValidator(MachineDbContext context)
    {
        RuleFor(v => v.Title)
            .MustAsync(async (title, _) =>
                await context.Vendings.Where(v => v.Title == title).FirstOrDefaultAsync() is null)
            .WithErrorCode("409")
            .WithMessage("Title is not available!");

        RuleFor(v => v.Title)
            .Must(title => title.Length >= 4)
            .WithErrorCode("409")
            .WithMessage("Title length must be at least 4 characters!");
    }
}