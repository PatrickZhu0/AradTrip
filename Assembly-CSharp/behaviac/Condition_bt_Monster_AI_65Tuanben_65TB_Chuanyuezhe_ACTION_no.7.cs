using System;

namespace behaviac
{
	// Token: 0x02002B43 RID: 11075
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node38 : Condition
	{
		// Token: 0x06013F94 RID: 81812 RVA: 0x005FF02E File Offset: 0x005FD42E
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node38()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 5000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013F95 RID: 81813 RVA: 0x005FF064 File Offset: 0x005FD464
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9B8 RID: 55736
		private int opl_p0;

		// Token: 0x0400D9B9 RID: 55737
		private int opl_p1;

		// Token: 0x0400D9BA RID: 55738
		private int opl_p2;

		// Token: 0x0400D9BB RID: 55739
		private int opl_p3;
	}
}
