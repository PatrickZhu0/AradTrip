using System;

namespace behaviac
{
	// Token: 0x02002B53 RID: 11091
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node42 : Condition
	{
		// Token: 0x06013FB4 RID: 81844 RVA: 0x005FF959 File Offset: 0x005FDD59
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node42()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06013FB5 RID: 81845 RVA: 0x005FF990 File Offset: 0x005FDD90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9D1 RID: 55761
		private int opl_p0;

		// Token: 0x0400D9D2 RID: 55762
		private int opl_p1;

		// Token: 0x0400D9D3 RID: 55763
		private int opl_p2;

		// Token: 0x0400D9D4 RID: 55764
		private int opl_p3;
	}
}
