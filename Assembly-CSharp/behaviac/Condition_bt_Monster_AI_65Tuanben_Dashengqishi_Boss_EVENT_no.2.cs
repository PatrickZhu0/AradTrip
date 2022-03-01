using System;

namespace behaviac
{
	// Token: 0x02002DB8 RID: 11704
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node27 : Condition
	{
		// Token: 0x0601444F RID: 83023 RVA: 0x0061756B File Offset: 0x0061596B
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node27()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06014450 RID: 83024 RVA: 0x006175A0 File Offset: 0x006159A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE16 RID: 56854
		private int opl_p0;

		// Token: 0x0400DE17 RID: 56855
		private int opl_p1;

		// Token: 0x0400DE18 RID: 56856
		private int opl_p2;

		// Token: 0x0400DE19 RID: 56857
		private int opl_p3;
	}
}
