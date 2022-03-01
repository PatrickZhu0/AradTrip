using System;

namespace behaviac
{
	// Token: 0x02002EDF RID: 11999
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node77 : Condition
	{
		// Token: 0x06014698 RID: 83608 RVA: 0x00622F8B File Offset: 0x0062138B
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node77()
		{
			this.opl_p0 = 13000;
			this.opl_p1 = 7000;
			this.opl_p2 = 7000;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014699 RID: 83609 RVA: 0x00622FC0 File Offset: 0x006213C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E00D RID: 57357
		private int opl_p0;

		// Token: 0x0400E00E RID: 57358
		private int opl_p1;

		// Token: 0x0400E00F RID: 57359
		private int opl_p2;

		// Token: 0x0400E010 RID: 57360
		private int opl_p3;
	}
}
