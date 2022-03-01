using System;

namespace behaviac
{
	// Token: 0x0200223D RID: 8765
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node1 : Condition
	{
		// Token: 0x06012E03 RID: 77315 RVA: 0x00590332 File Offset: 0x0058E732
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node1()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06012E04 RID: 77316 RVA: 0x00590348 File Offset: 0x0058E748
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7FE RID: 51198
		private float opl_p0;
	}
}
