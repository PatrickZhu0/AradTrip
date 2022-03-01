using System;

namespace behaviac
{
	// Token: 0x020027D1 RID: 10193
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node34 : Condition
	{
		// Token: 0x060138E1 RID: 80097 RVA: 0x005D4CF3 File Offset: 0x005D30F3
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node34()
		{
			this.opl_p0 = 3605;
		}

		// Token: 0x060138E2 RID: 80098 RVA: 0x005D4D08 File Offset: 0x005D3108
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D340 RID: 54080
		private int opl_p0;
	}
}
