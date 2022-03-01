using System;

namespace behaviac
{
	// Token: 0x0200226C RID: 8812
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node13 : Condition
	{
		// Token: 0x06012E5D RID: 77405 RVA: 0x00592C14 File Offset: 0x00591014
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node13()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x06012E5E RID: 77406 RVA: 0x00592C28 File Offset: 0x00591028
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C86B RID: 51307
		private float opl_p0;
	}
}
