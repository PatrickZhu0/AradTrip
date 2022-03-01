using System;

namespace GameClient
{
	// Token: 0x02000F37 RID: 3895
	public class TestLevelData : ComControlData
	{
		// Token: 0x060097BD RID: 38845 RVA: 0x001D11BD File Offset: 0x001CF5BD
		public TestLevelData()
		{
		}

		// Token: 0x060097BE RID: 38846 RVA: 0x001D11C5 File Offset: 0x001CF5C5
		public TestLevelData(int index, int id, string name, bool isSelected) : base(index, id, name, isSelected)
		{
		}

		// Token: 0x04004E48 RID: 20040
		public string LevelName;
	}
}
