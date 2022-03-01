using System;

namespace behaviac
{
	// Token: 0x020034B6 RID: 13494
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node18 : Condition
	{
		// Token: 0x060151B2 RID: 86450 RVA: 0x0065C16F File Offset: 0x0065A56F
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node18()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521715;
		}

		// Token: 0x060151B3 RID: 86451 RVA: 0x0065C190 File Offset: 0x0065A590
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EABA RID: 60090
		private BE_Target opl_p0;

		// Token: 0x0400EABB RID: 60091
		private BE_Equal opl_p1;

		// Token: 0x0400EABC RID: 60092
		private int opl_p2;
	}
}
