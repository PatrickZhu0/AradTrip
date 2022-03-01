using System;

namespace GameClient
{
	// Token: 0x02000F7B RID: 3963
	public class TestDropDownData : ComControlData
	{
		// Token: 0x06009948 RID: 39240 RVA: 0x001D7F71 File Offset: 0x001D6371
		public TestDropDownData()
		{
		}

		// Token: 0x06009949 RID: 39241 RVA: 0x001D7F79 File Offset: 0x001D6379
		public TestDropDownData(int index, int id, string name, bool isSelected) : base(index, id, name, isSelected)
		{
		}

		// Token: 0x04004EEC RID: 20204
		public string DropDownName;
	}
}
