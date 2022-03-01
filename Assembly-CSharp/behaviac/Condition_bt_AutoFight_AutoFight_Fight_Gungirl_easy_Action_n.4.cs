using System;

namespace behaviac
{
	// Token: 0x02001F7B RID: 8059
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node7 : Condition
	{
		// Token: 0x06012896 RID: 75926 RVA: 0x0056DB96 File Offset: 0x0056BF96
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node7()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06012897 RID: 75927 RVA: 0x0056DBAC File Offset: 0x0056BFAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C288 RID: 49800
		private float opl_p0;
	}
}
