using System;

namespace behaviac
{
	// Token: 0x02003620 RID: 13856
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node2 : Condition
	{
		// Token: 0x06015464 RID: 87140 RVA: 0x0066A046 File Offset: 0x00668446
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06015465 RID: 87141 RVA: 0x0066A07C File Offset: 0x0066847C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE1D RID: 60957
		private int opl_p0;

		// Token: 0x0400EE1E RID: 60958
		private int opl_p1;

		// Token: 0x0400EE1F RID: 60959
		private int opl_p2;

		// Token: 0x0400EE20 RID: 60960
		private int opl_p3;
	}
}
