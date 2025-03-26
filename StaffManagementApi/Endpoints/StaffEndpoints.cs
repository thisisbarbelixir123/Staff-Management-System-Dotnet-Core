using Microsoft.AspNetCore.Mvc;
using StaffManagementApi.Dtos;
using StaffManagementApi.Services;

namespace StaffManagementApi.Endpoints;

[ApiController]
[Route("api/staff")]
public class StaffEndpoints : ControllerBase
{
    private readonly IStaffService _staffService;
    private readonly IFileService _fileService;

    public StaffEndpoints(IStaffService staffService, IFileService fileService)
    {
        _staffService = staffService;
        _fileService = fileService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchStaff([FromQuery] string keyword)
    {
        var result = await _staffService.SearchStaffAsync(keyword);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStaffById(int id)
    {
        var result = await _staffService.GetStaffByIdAsync(id);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddStaff([FromBody] CreateStaffDto staffDto)
    {
        var result = await _staffService.CreateStaffAsync(staffDto);
        return CreatedAtAction(nameof(GetStaffById), new { id = result.Id }, result);
    }

    [HttpPut("edit/{id}")]
    public async Task<IActionResult> EditStaff(int id, [FromBody] UpdateStaffDto staffDto)
    {
        var success = await _staffService.UpdateStaffAsync(id, staffDto);
        return success ? Ok() : NotFound();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteStaff(int id)
    {
        var success = await _staffService.DeleteStaffAsync(id);
        return success ? Ok() : NotFound();
    }

    [HttpPost("terminate/{id}")]
    public async Task<IActionResult> TerminateStaff(int id)
    {
        var success = await _staffService.TerminateStaffAsync(id);
        return success ? Ok() : NotFound();
    }

    [HttpPost("upload/excel")]
    public async Task<IActionResult> UploadExcel([FromForm] IFormFile file)
    {
        var result = await _fileService.UploadExcelAsync(file);
        return Ok(new { filePath = result });
    }

    [HttpPost("upload/photo/{id}")]
    public async Task<IActionResult> UploadPhoto(int id, [FromForm] IFormFile photo)
    {
        var result = await _fileService.UploadPhotoAsync(photo, id.ToString());
        return Ok(new { filePath = result });
    }
}
