using System;

namespace behaviac
{
	// Token: 0x0200298C RID: 10636
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node113 : Condition
	{
		// Token: 0x06013C4C RID: 80972 RVA: 0x005E9D9E File Offset: 0x005E819E
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node113()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x06013C4D RID: 80973 RVA: 0x005E9DD4 File Offset: 0x005E81D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6B5 RID: 54965
		private int opl_p0;

		// Token: 0x0400D6B6 RID: 54966
		private int opl_p1;

		// Token: 0x0400D6B7 RID: 54967
		private int opl_p2;

		// Token: 0x0400D6B8 RID: 54968
		private int opl_p3;
	}
}
