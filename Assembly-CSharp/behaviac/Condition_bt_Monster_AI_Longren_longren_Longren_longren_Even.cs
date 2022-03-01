using System;

namespace behaviac
{
	// Token: 0x020035A0 RID: 13728
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node4 : Condition
	{
		// Token: 0x0601536F RID: 86895 RVA: 0x00664F89 File Offset: 0x00663389
		public Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node4()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06015370 RID: 86896 RVA: 0x00664F9C File Offset: 0x0066339C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED38 RID: 60728
		private float opl_p0;
	}
}
