using System;

namespace behaviac
{
	// Token: 0x02002930 RID: 10544
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node6 : Condition
	{
		// Token: 0x06013B96 RID: 80790 RVA: 0x005E4DD3 File Offset: 0x005E31D3
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node6()
		{
			this.opl_p0 = 1506;
		}

		// Token: 0x06013B97 RID: 80791 RVA: 0x005E4DE8 File Offset: 0x005E31E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5FC RID: 54780
		private int opl_p0;
	}
}
