using CV_Web.DTOS;

namespace CV_Web.Interfaces
{
    public interface IProfileRepository
    {
        Task<ProfileDto> GetAsync();
    }
}
