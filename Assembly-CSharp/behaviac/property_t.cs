using System;

namespace behaviac
{
	// Token: 0x02004844 RID: 18500
	public struct property_t
	{
		// Token: 0x0601A966 RID: 108902 RVA: 0x00838480 File Offset: 0x00836880
		public property_t(string n, string v)
		{
			this.name = n;
			this.value = v;
		}

		// Token: 0x0401296D RID: 76141
		public string name;

		// Token: 0x0401296E RID: 76142
		public string value;
	}
}
