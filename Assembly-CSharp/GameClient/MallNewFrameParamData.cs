using System;

namespace GameClient
{
	// Token: 0x0200179A RID: 6042
	public class MallNewFrameParamData
	{
		// Token: 0x0600EE65 RID: 61029 RVA: 0x003FFE7F File Offset: 0x003FE27F
		public MallNewFrameParamData()
		{
			this.MallNewType = MallNewType.PropertyMall;
			this.Index = 0;
			this.SecondIndex = 0;
			this.ThirdIndex = 0;
		}

		// Token: 0x040091CD RID: 37325
		public MallNewType MallNewType;

		// Token: 0x040091CE RID: 37326
		public int Index;

		// Token: 0x040091CF RID: 37327
		public int SecondIndex;

		// Token: 0x040091D0 RID: 37328
		public int ThirdIndex;
	}
}
