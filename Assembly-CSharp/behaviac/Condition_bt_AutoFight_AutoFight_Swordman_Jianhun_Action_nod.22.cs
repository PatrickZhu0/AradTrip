using System;

namespace behaviac
{
	// Token: 0x02002920 RID: 10528
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node64 : Condition
	{
		// Token: 0x06013B76 RID: 80758 RVA: 0x005E464B File Offset: 0x005E2A4B
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node64()
		{
			this.opl_p0 = 1909;
		}

		// Token: 0x06013B77 RID: 80759 RVA: 0x005E4660 File Offset: 0x005E2A60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5DC RID: 54748
		private int opl_p0;
	}
}
