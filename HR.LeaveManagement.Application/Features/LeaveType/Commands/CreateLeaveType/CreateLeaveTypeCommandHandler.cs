using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate Incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validateResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validateResult.IsValid)
                throw new BadRequestException("Invalid LeaveType", validateResult);
            //convert to domain Entity object
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);
            //add to db
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
            //return Id
            return leaveTypeToCreate.Id;
        }
    }
}
