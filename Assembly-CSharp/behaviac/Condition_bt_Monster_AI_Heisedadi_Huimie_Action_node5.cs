using System;

namespace behaviac
{
	// Token: 0x02003412 RID: 13330
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node5 : Condition
	{
		// Token: 0x06015075 RID: 86133 RVA: 0x00655CAD File Offset: 0x006540AD
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node5()
		{
			this.opl_p0 = 900000;
			this.opl_p1 = 900000;
			this.opl_p2 = 900000;
			this.opl_p3 = 900000;
		}

		// Token: 0x06015076 RID: 86134 RVA: 0x00655CE4 File Offset: 0x006540E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E94B RID: 59723
		private int opl_p0;

		// Token: 0x0400E94C RID: 59724
		private int opl_p1;

		// Token: 0x0400E94D RID: 59725
		private int opl_p2;

		// Token: 0x0400E94E RID: 59726
		private int opl_p3;
	}
}
