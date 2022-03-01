using System;

namespace behaviac
{
	// Token: 0x02003409 RID: 13321
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node45 : Condition
	{
		// Token: 0x06015063 RID: 86115 RVA: 0x0065591D File Offset: 0x00653D1D
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node45()
		{
			this.opl_p0 = 900000;
			this.opl_p1 = 900000;
			this.opl_p2 = 900000;
			this.opl_p3 = 900000;
		}

		// Token: 0x06015064 RID: 86116 RVA: 0x00655954 File Offset: 0x00653D54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E93C RID: 59708
		private int opl_p0;

		// Token: 0x0400E93D RID: 59709
		private int opl_p1;

		// Token: 0x0400E93E RID: 59710
		private int opl_p2;

		// Token: 0x0400E93F RID: 59711
		private int opl_p3;
	}
}
