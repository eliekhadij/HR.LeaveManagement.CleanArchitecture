using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    //Created as a record since it does not change (immutable)
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;
}
