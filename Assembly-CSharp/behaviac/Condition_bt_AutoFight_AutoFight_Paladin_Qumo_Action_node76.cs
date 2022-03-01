using System;

namespace behaviac
{
	// Token: 0x020027EB RID: 10219
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node76 : Condition
	{
		// Token: 0x06013915 RID: 80149 RVA: 0x005D581E File Offset: 0x005D3C1E
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node76()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06013916 RID: 80150 RVA: 0x005D5854 File Offset: 0x005D3C54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D373 RID: 54131
		private int opl_p0;

		// Token: 0x0400D374 RID: 54132
		private int opl_p1;

		// Token: 0x0400D375 RID: 54133
		private int opl_p2;

		// Token: 0x0400D376 RID: 54134
		private int opl_p3;
	}
}
