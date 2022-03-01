using System;

namespace behaviac
{
	// Token: 0x02002245 RID: 8773
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node9 : Condition
	{
		// Token: 0x06012E12 RID: 77330 RVA: 0x0059098D File Offset: 0x0058ED8D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node9()
		{
			this.opl_p0 = 1710;
		}

		// Token: 0x06012E13 RID: 77331 RVA: 0x005909A0 File Offset: 0x0058EDA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C811 RID: 51217
		private int opl_p0;
	}
}
