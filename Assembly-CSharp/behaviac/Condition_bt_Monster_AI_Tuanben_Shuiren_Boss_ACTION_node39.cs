using System;

namespace behaviac
{
	// Token: 0x02003B67 RID: 15207
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node39 : Condition
	{
		// Token: 0x06015E83 RID: 89731 RVA: 0x0069DEF3 File Offset: 0x0069C2F3
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node39()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015E84 RID: 89732 RVA: 0x0069DF28 File Offset: 0x0069C328
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F748 RID: 63304
		private int opl_p0;

		// Token: 0x0400F749 RID: 63305
		private int opl_p1;

		// Token: 0x0400F74A RID: 63306
		private int opl_p2;

		// Token: 0x0400F74B RID: 63307
		private int opl_p3;
	}
}
