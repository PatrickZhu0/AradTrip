using System;

namespace behaviac
{
	// Token: 0x02002911 RID: 10513
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node35 : Condition
	{
		// Token: 0x06013B58 RID: 80728 RVA: 0x005E3DFF File Offset: 0x005E21FF
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node35()
		{
			this.opl_p0 = 1521;
		}

		// Token: 0x06013B59 RID: 80729 RVA: 0x005E3E14 File Offset: 0x005E2214
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5BD RID: 54717
		private int opl_p0;
	}
}
