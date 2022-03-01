using System;

namespace behaviac
{
	// Token: 0x02001D31 RID: 7473
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node1 : Condition
	{
		// Token: 0x06012424 RID: 74788 RVA: 0x005532E1 File Offset: 0x005516E1
		public Condition_bt_APC_APC_Guiqi_Action_node1()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012425 RID: 74789 RVA: 0x00553318 File Offset: 0x00551718
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE14 RID: 48660
		private int opl_p0;

		// Token: 0x0400BE15 RID: 48661
		private int opl_p1;

		// Token: 0x0400BE16 RID: 48662
		private int opl_p2;

		// Token: 0x0400BE17 RID: 48663
		private int opl_p3;
	}
}
