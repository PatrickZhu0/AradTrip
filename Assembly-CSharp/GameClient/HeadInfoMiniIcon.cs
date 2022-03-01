using System;

namespace GameClient
{
	// Token: 0x020010A2 RID: 4258
	public class HeadInfoMiniIcon
	{
		// Token: 0x0600A080 RID: 41088 RVA: 0x00205147 File Offset: 0x00203547
		public void Reset()
		{
			this.sortOrder = int.MaxValue;
			this.buffID = 0;
			this.used = false;
			if (this.comBuffIconUnit != null)
			{
				this.comBuffIconUnit.gameObject.SetActive(true);
			}
		}

		// Token: 0x04005927 RID: 22823
		public int sortOrder;

		// Token: 0x04005928 RID: 22824
		public int buffID;

		// Token: 0x04005929 RID: 22825
		public bool used;

		// Token: 0x0400592A RID: 22826
		public ComBuffIcon comBuffIconUnit;
	}
}
