using System;

namespace StaffManagementApi.Dtos;

public class StaffSummaryDto
{
        public required string FullName { get; set; }
        public required string NIM { get; set; }
        public required string BinusianId { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
}
