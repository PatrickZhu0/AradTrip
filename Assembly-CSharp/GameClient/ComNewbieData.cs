using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x0200105B RID: 4187
	public class ComNewbieData
	{
		// Token: 0x06009D2D RID: 40237 RVA: 0x001EEB07 File Offset: 0x001ECF07
		public ComNewbieData(NewbieGuideComType ct, List<NewbieModifyData> ModifyTypeList, params object[] args)
		{
			this.comType = ct;
			this.ModifyDataTypeList = ModifyTypeList;
			this.args = args;
		}

		// Token: 0x17001953 RID: 6483
		// (get) Token: 0x06009D2E RID: 40238 RVA: 0x001EEB2F File Offset: 0x001ECF2F
		public NewbieGuideComType ComType
		{
			get
			{
				return this.comType;
			}
		}

		// Token: 0x17001954 RID: 6484
		// (get) Token: 0x06009D2F RID: 40239 RVA: 0x001EEB37 File Offset: 0x001ECF37
		public Type ComNewbieGuideType
		{
			get
			{
				return this.comNewbieGuideType;
			}
		}

		// Token: 0x06009D30 RID: 40240 RVA: 0x001EEB40 File Offset: 0x001ECF40
		public static ComNewbieData New<T>(List<NewbieModifyData> ModifyTypeList, params object[] args) where T : ComNewbieGuideBase
		{
			return new ComNewbieData(NewbieGuideComType.USER_DEFINE, ModifyTypeList, args)
			{
				comNewbieGuideType = typeof(T)
			};
		}

		// Token: 0x06009D31 RID: 40241 RVA: 0x001EEB67 File Offset: 0x001ECF67
		public static ComNewbieData New(NewbieGuideComType ct, List<NewbieModifyData> ModifyTypeList, params object[] args)
		{
			return new ComNewbieData(ct, ModifyTypeList, args);
		}

		// Token: 0x04005612 RID: 22034
		private NewbieGuideComType comType;

		// Token: 0x04005613 RID: 22035
		private Type comNewbieGuideType;

		// Token: 0x04005614 RID: 22036
		public object[] args;

		// Token: 0x04005615 RID: 22037
		public List<NewbieModifyData> ModifyDataTypeList = new List<NewbieModifyData>();
	}
}
