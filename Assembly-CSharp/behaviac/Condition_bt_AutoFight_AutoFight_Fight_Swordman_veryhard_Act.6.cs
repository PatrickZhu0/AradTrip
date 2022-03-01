using System;

namespace behaviac
{
	// Token: 0x0200245E RID: 9310
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node19 : Condition
	{
		// Token: 0x0601320D RID: 78349 RVA: 0x005AD124 File Offset: 0x005AB524
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node19()
		{
			this.opl_p0 = 0.78f;
		}

		// Token: 0x0601320E RID: 78350 RVA: 0x005AD138 File Offset: 0x005AB538
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC33 RID: 52275
		private float opl_p0;
	}
}
