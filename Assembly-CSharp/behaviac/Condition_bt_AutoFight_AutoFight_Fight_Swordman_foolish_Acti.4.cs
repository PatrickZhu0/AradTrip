using System;

namespace behaviac
{
	// Token: 0x02002281 RID: 8833
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node10 : Condition
	{
		// Token: 0x06012E84 RID: 77444 RVA: 0x00593BF3 File Offset: 0x00591FF3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node10()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06012E85 RID: 77445 RVA: 0x00593C08 File Offset: 0x00592008
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C891 RID: 51345
		private int opl_p0;
	}
}
