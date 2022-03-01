using System;

namespace behaviac
{
	// Token: 0x020029BE RID: 10686
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node43 : Condition
	{
		// Token: 0x06013CB0 RID: 81072 RVA: 0x005EB36B File Offset: 0x005E976B
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node43()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013CB1 RID: 81073 RVA: 0x005EB3A0 File Offset: 0x005E97A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D71C RID: 55068
		private int opl_p0;

		// Token: 0x0400D71D RID: 55069
		private int opl_p1;

		// Token: 0x0400D71E RID: 55070
		private int opl_p2;

		// Token: 0x0400D71F RID: 55071
		private int opl_p3;
	}
}
