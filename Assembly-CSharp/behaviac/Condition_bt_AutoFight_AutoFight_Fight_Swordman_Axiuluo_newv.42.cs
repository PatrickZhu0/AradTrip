using System;

namespace behaviac
{
	// Token: 0x0200223A RID: 8762
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node10 : Condition
	{
		// Token: 0x06012DFD RID: 77309 RVA: 0x005901F7 File Offset: 0x0058E5F7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node10()
		{
			this.opl_p0 = 0.02f;
		}

		// Token: 0x06012DFE RID: 77310 RVA: 0x0059020C File Offset: 0x0058E60C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7FA RID: 51194
		private float opl_p0;
	}
}
