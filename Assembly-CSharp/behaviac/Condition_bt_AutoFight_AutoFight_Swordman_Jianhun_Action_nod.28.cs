using System;

namespace behaviac
{
	// Token: 0x02002928 RID: 10536
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node57 : Condition
	{
		// Token: 0x06013B86 RID: 80774 RVA: 0x005E4A0F File Offset: 0x005E2E0F
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node57()
		{
			this.opl_p0 = 1511;
		}

		// Token: 0x06013B87 RID: 80775 RVA: 0x005E4A24 File Offset: 0x005E2E24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5EC RID: 54764
		private int opl_p0;
	}
}
