using System;

namespace behaviac
{
	// Token: 0x02002872 RID: 10354
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node22 : Condition
	{
		// Token: 0x06013A21 RID: 80417 RVA: 0x005DC801 File Offset: 0x005DAC01
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node22()
		{
			this.opl_p0 = 1604;
		}

		// Token: 0x06013A22 RID: 80418 RVA: 0x005DC814 File Offset: 0x005DAC14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D47B RID: 54395
		private int opl_p0;
	}
}
