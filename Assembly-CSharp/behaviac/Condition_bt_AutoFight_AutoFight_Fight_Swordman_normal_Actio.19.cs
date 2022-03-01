using System;

namespace behaviac
{
	// Token: 0x02002453 RID: 9299
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node57 : Condition
	{
		// Token: 0x060131FA RID: 78330 RVA: 0x005AC333 File Offset: 0x005AA733
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node57()
		{
			this.opl_p0 = 1511;
		}

		// Token: 0x060131FB RID: 78331 RVA: 0x005AC348 File Offset: 0x005AA748
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC21 RID: 52257
		private int opl_p0;
	}
}
