using Microsoft.EntityFrameworkCore;
using StaffManagementApi.Data;
using StaffManagementApi.Dtos;
using StaffManagementApi.Entities;

namespace StaffManagementApi.Services
{
    public class StaffService : IStaffService
    {
        private readonly AppDbContext _context;

        public StaffService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StaffDetailsDto>> GetAllStaffDetailsAsync()
        {
            return await _context.Staffs
                .Select(staff => new StaffDetailsDto
                {
                    Id = staff.Id,
                    FullName = staff.FullName,
                    NIM = staff.NIM,
                    BinusianId = staff.BinusianId,
                    Gender = staff.Gender,
                    Email = staff.Email,
                    PhoneNumber = staff.PhoneNumber,
                    ActiveSemester = staff.ActiveSemester,
                    BinusianStatus = staff.BinusianStatus,
                    NIK = staff.NIK,
                    DateOfBirth = staff.DateOfBirth,
                    Address = staff.Address,
                    NPWP = staff.NPWP,
                    BankAccountNumber = staff.BankAccountNumber,
                    BankBranch = staff.BankBranch,
                    AccountHolderName = staff.AccountHolderName,
                    ParentGuardianName = staff.ParentGuardianName,
                    ParentGuardianPhone = staff.ParentGuardianPhone,
                    EmergencyContact = staff.EmergencyContact,
                    EmergencyRelation = staff.EmergencyRelation,
                    IsActive = staff.IsActive,
                    StartDate = staff.StartDate,
                    EndDate = staff.EndDate
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<StaffSummaryDto>> GetStaffAsync()
        {
            return await _context.Staffs
                .Select(s => new StaffSummaryDto
                {
                    FullName = s.FullName,
                    NIM = s.NIM,
                    BinusianId = s.BinusianId,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    IsActive = s.IsActive
                })
                .ToListAsync();
        }

        public async Task<StaffDetailsDto> GetStaffByIdAsync(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null) return null!;

            return new StaffDetailsDto
            {
                Id = staff.Id,
                FullName = staff.FullName,
                NIM = staff.NIM,
                BinusianId = staff.BinusianId,
                Gender = staff.Gender,
                Email = staff.Email,
                PhoneNumber = staff.PhoneNumber,
                ActiveSemester = staff.ActiveSemester,
                BinusianStatus = staff.BinusianStatus,
                NIK = staff.NIK,
                DateOfBirth = staff.DateOfBirth,
                Address = staff.Address,
                NPWP = staff.NPWP,
                BankAccountNumber = staff.BankAccountNumber,
                BankBranch = staff.BankBranch,
                AccountHolderName = staff.AccountHolderName,
                ParentGuardianName = staff.ParentGuardianName,
                ParentGuardianPhone = staff.ParentGuardianPhone,
                EmergencyContact = staff.EmergencyContact,
                EmergencyRelation = staff.EmergencyRelation,
                IsActive = staff.IsActive,
                StartDate = staff.StartDate,
                EndDate = staff.EndDate
            };
        }

        public async Task<StaffDetailsDto> CreateStaffAsync(CreateStaffDto staffDto)
        {
            var existingStaff = await _context.Staffs
                .FirstOrDefaultAsync(s => s.NIM == staffDto.NIM || s.BinusianId == staffDto.BinusianId);
            if (existingStaff != null)
            {
                throw new InvalidOperationException("Staff with this NIM or BinusianId already exists.");
            }

            var staff = new Staff
            {
                FullName = staffDto.FullName,
                NIM = staffDto.NIM,
                BinusianId = staffDto.BinusianId,
                Gender = staffDto.Gender,
                Email = staffDto.Email,
                PhoneNumber = staffDto.PhoneNumber,
                ActiveSemester = staffDto.ActiveSemester,
                BinusianStatus = staffDto.BinusianStatus,
                NIK = staffDto.NIK,
                DateOfBirth = staffDto.DateOfBirth,
                Address = staffDto.Address,
                NPWP = staffDto.NPWP,
                BankAccountNumber = staffDto.BankAccountNumber,
                BankBranch = staffDto.BankBranch,
                AccountHolderName = staffDto.AccountHolderName,
                ParentGuardianName = staffDto.ParentGuardianName,
                ParentGuardianPhone = staffDto.ParentGuardianPhone,
                EmergencyContact = staffDto.EmergencyContact,
                EmergencyRelation = staffDto.EmergencyRelation,
                IsActive = true,
                StartDate = DateOnly.FromDateTime(DateTime.UtcNow),
                EndDate = null
            };

            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();

            return await GetStaffByIdAsync(staff.Id);
        }

        public async Task<bool> UpdateStaffAsync(int id, UpdateStaffDto staffDto)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null) return false;

            staff.FullName = staffDto.FullName;
            staff.Email = staffDto.Email;
            staff.PhoneNumber = staffDto.PhoneNumber;
            staff.Address = staffDto.Address;
            staff.NPWP = staffDto.NPWP;
            staff.BankAccountNumber = staffDto.BankAccountNumber;
            staff.BankBranch = staffDto.BankBranch;
            staff.AccountHolderName = staffDto.AccountHolderName;
            staff.EmergencyContact = staffDto.EmergencyContact;
            staff.EmergencyRelation = staffDto.EmergencyRelation;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null) return false;

            _context.Staffs.Remove(staff); // Hapus data dari database
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TerminateStaffAsync(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null) return false;

            staff.IsActive = false;
            staff.EndDate = DateOnly.FromDateTime(DateTime.UtcNow);
            await _context.SaveChangesAsync();
            return true;    
        }

        public async Task<IEnumerable<StaffSummaryDto>> SearchStaffAsync(string keyword)
        {
            return await _context.Staffs
                .Where(s => s.FullName.Contains(keyword) || s.Email.Contains(keyword))
                .Select(s => new StaffSummaryDto
                {
                    FullName = s.FullName,
                    NIM = s.NIM,
                    BinusianId = s.BinusianId,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    IsActive = s.IsActive
                })
                .ToListAsync();
        }
    }
}
