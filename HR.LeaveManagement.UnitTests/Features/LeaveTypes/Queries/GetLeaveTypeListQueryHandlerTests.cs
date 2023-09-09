using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypesDetails;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.UnitTests.Features.LeaveTypes.Queries
{
    public class GetLeaveTypeListQueryHandlerTests
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetLeaveTypesQueryHandler>> _mockLogger;
        public GetLeaveTypeListQueryHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypesMockLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(c => c.AddProfile<LeaveTypeProfile>());
            _mapper = mapperConfig.CreateMapper();
            _mockLogger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypesQueryHandler(_mapper, _mockRepo.Object, _mockLogger.Object);
            var result = handler.Handle(new GetLeaveTypesQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<LeaveTypeDto>>();
            
        }
    }
}
