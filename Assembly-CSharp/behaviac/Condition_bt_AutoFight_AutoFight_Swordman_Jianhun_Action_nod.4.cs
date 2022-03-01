using System;

namespace behaviac
{
	// Token: 0x02002908 RID: 10504
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node99 : Condition
	{
		// Token: 0x06013B46 RID: 80710 RVA: 0x005E3A3F File Offset: 0x005E1E3F
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node99()
		{
			this.opl_p0 = 1912;
		}

		// Token: 0x06013B47 RID: 80711 RVA: 0x005E3A54 File Offset: 0x005E1E54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5AA RID: 54698
		private int opl_p0;
	}
}
