using System;

namespace behaviac
{
	// Token: 0x02002991 RID: 10641
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node118 : Condition
	{
		// Token: 0x06013C56 RID: 80982 RVA: 0x005E9F9B File Offset: 0x005E839B
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node118()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013C57 RID: 80983 RVA: 0x005E9FD0 File Offset: 0x005E83D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6BE RID: 54974
		private int opl_p0;

		// Token: 0x0400D6BF RID: 54975
		private int opl_p1;

		// Token: 0x0400D6C0 RID: 54976
		private int opl_p2;

		// Token: 0x0400D6C1 RID: 54977
		private int opl_p3;
	}
}
