using CV_Web.Data;
using CV_Web.DTOS;
using CV_Web.Interfaces;
using Dapper;

namespace CV_Web.Repositories
{
	public class ProfileRepository : IProfileRepository
	{
		private readonly Context _context;

		public ProfileRepository(Context context)
		{
			_context = context;
		}

		public async Task<ProfileDto> GetAsync()
		{
			string query = "Select * from Profile";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<ProfileDto>(query);
				return values;
			}
		}
	}
}
