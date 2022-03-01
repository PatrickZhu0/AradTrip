using System;

namespace behaviac
{
	// Token: 0x02002915 RID: 10517
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node22 : Condition
	{
		// Token: 0x06013B60 RID: 80736 RVA: 0x005E3FB3 File Offset: 0x005E23B3
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node22()
		{
			this.opl_p0 = 1907;
		}

		// Token: 0x06013B61 RID: 80737 RVA: 0x005E3FC8 File Offset: 0x005E23C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5C5 RID: 54725
		private int opl_p0;
	}
}
