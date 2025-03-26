using System;

namespace StaffManagementApi.Dtos;

public class UpdateStaffDto
{
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public required string NPWP { get; set; }
    public required string BankAccountNumber { get; set; }
    public required string BankBranch { get; set; }
    public required string AccountHolderName { get; set; }
    public required string EmergencyContact { get; set; }
    public required string EmergencyRelation { get; set; }
}
