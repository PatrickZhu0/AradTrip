using System;

namespace behaviac
{
	// Token: 0x020027FF RID: 10239
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node101 : Condition
	{
		// Token: 0x0601393D RID: 80189 RVA: 0x005D60A2 File Offset: 0x005D44A2
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node101()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601393E RID: 80190 RVA: 0x005D60D8 File Offset: 0x005D44D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D39B RID: 54171
		private int opl_p0;

		// Token: 0x0400D39C RID: 54172
		private int opl_p1;

		// Token: 0x0400D39D RID: 54173
		private int opl_p2;

		// Token: 0x0400D39E RID: 54174
		private int opl_p3;
	}
}
