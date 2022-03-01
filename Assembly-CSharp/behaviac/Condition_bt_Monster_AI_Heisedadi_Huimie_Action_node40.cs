using System;

namespace behaviac
{
	// Token: 0x0200340E RID: 13326
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node40 : Condition
	{
		// Token: 0x0601506D RID: 86125 RVA: 0x00655B09 File Offset: 0x00653F09
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node40()
		{
			this.opl_p0 = 900000;
			this.opl_p1 = 900000;
			this.opl_p2 = 900000;
			this.opl_p3 = 900000;
		}

		// Token: 0x0601506E RID: 86126 RVA: 0x00655B40 File Offset: 0x00653F40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E944 RID: 59716
		private int opl_p0;

		// Token: 0x0400E945 RID: 59717
		private int opl_p1;

		// Token: 0x0400E946 RID: 59718
		private int opl_p2;

		// Token: 0x0400E947 RID: 59719
		private int opl_p3;
	}
}
