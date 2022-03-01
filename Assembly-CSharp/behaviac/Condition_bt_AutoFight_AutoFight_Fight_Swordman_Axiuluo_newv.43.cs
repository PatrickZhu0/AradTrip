using System;

namespace behaviac
{
	// Token: 0x0200223B RID: 8763
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node6 : Condition
	{
		// Token: 0x06012DFF RID: 77311 RVA: 0x0059023F File Offset: 0x0058E63F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node6()
		{
			this.opl_p0 = 1515;
		}

		// Token: 0x06012E00 RID: 77312 RVA: 0x00590254 File Offset: 0x0058E654
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7FB RID: 51195
		private int opl_p0;
	}
}
