using System;

namespace behaviac
{
	// Token: 0x0200229A RID: 8858
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node10 : Condition
	{
		// Token: 0x06012EB2 RID: 77490 RVA: 0x00594E57 File Offset: 0x00593257
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node10()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06012EB3 RID: 77491 RVA: 0x00594E6C File Offset: 0x0059326C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8BE RID: 51390
		private int opl_p0;
	}
}
