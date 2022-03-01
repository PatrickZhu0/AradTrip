using System;

namespace behaviac
{
	// Token: 0x020034BA RID: 13498
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node20 : Condition
	{
		// Token: 0x060151BA RID: 86458 RVA: 0x0065C2A2 File Offset: 0x0065A6A2
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node20()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521715;
		}

		// Token: 0x060151BB RID: 86459 RVA: 0x0065C2C4 File Offset: 0x0065A6C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAC1 RID: 60097
		private BE_Target opl_p0;

		// Token: 0x0400EAC2 RID: 60098
		private BE_Equal opl_p1;

		// Token: 0x0400EAC3 RID: 60099
		private int opl_p2;
	}
}
