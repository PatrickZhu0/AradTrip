using System;

namespace behaviac
{
	// Token: 0x020027B9 RID: 10169
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node9 : Condition
	{
		// Token: 0x060138B1 RID: 80049 RVA: 0x005D42BB File Offset: 0x005D26BB
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node9()
		{
			this.opl_p0 = 3616;
		}

		// Token: 0x060138B2 RID: 80050 RVA: 0x005D42D0 File Offset: 0x005D26D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D310 RID: 54032
		private int opl_p0;
	}
}
