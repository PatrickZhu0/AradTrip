using System;

namespace GameClient
{
	// Token: 0x02001302 RID: 4866
	public class TAPQuestionnaireInformation
	{
		// Token: 0x0600BCDB RID: 48347 RVA: 0x002C2050 File Offset: 0x002C0450
		public TAPQuestionnaireInformation(byte activeTimeType, byte masterType, byte regionId, string declaration)
		{
			this.activeTimeType = activeTimeType;
			this.masterType = masterType;
			this.regionId = regionId;
			this.declaration = declaration;
		}

		// Token: 0x04006A31 RID: 27185
		public byte activeTimeType;

		// Token: 0x04006A32 RID: 27186
		public byte masterType;

		// Token: 0x04006A33 RID: 27187
		public byte regionId;

		// Token: 0x04006A34 RID: 27188
		public string declaration;
	}
}
