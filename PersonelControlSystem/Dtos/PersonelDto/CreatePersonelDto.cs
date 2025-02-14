namespace PersonelControlSystem.Dtos.PersonelDto
{
	public class CreatePersonelDto
	{
		public string PersonelName { get; set; }

		public string PersonelTitle { get; set; }

		public int PersonelRegisterNumber { get; set; }

		public DateTime PersonelShiftDate { get; set; }
	}
}
