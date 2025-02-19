namespace PersonelControlSystem.Dtos.PersonelDto
{
	public class CreatePersonelDto
	{
		public string PersonelName { get; set; }

		public string PersonelTitle { get; set; }

		public int PersonelRegisterNumber { get; set; }

		public DateTime PersonelShiftDate { get; set; }

        public int ShiftID { get; set; }

        public int LocationID { get; set; }
    }
}
