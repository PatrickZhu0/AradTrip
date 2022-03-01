using System;

namespace GameClient
{
	// Token: 0x0200105C RID: 4188
	public class NewbieConditionData
	{
		// Token: 0x06009D32 RID: 40242 RVA: 0x001EEB74 File Offset: 0x001ECF74
		public NewbieConditionData(eNewbieGuideCondition c, int[] args = null, string[] LimitFrameArgs = null)
		{
			this.condition = c;
			if (args == null)
			{
				this.LimitArgsList = new int[0];
			}
			else
			{
				this.LimitArgsList = args;
			}
			if (LimitFrameArgs == null)
			{
				this.LimitFramesList = new string[0];
			}
			else
			{
				this.LimitFramesList = LimitFrameArgs;
			}
		}

		// Token: 0x06009D33 RID: 40243 RVA: 0x001EEBCC File Offset: 0x001ECFCC
		public static NewbieConditionData NewUserCondition(NewbieConditionData.userConditionFunc func)
		{
			return new NewbieConditionData(eNewbieGuideCondition.UserDefine, null, null)
			{
				mComditionFunc = func
			};
		}

		// Token: 0x04005616 RID: 22038
		public eNewbieGuideCondition condition;

		// Token: 0x04005617 RID: 22039
		public int[] LimitArgsList;

		// Token: 0x04005618 RID: 22040
		public string[] LimitFramesList;

		// Token: 0x04005619 RID: 22041
		public NewbieConditionData.userConditionFunc mComditionFunc;

		// Token: 0x0200105D RID: 4189
		// (Invoke) Token: 0x06009D35 RID: 40245
		public delegate bool userConditionFunc();
	}
}
