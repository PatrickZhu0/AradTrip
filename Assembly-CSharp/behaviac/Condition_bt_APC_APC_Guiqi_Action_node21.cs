using System;

namespace behaviac
{
	// Token: 0x02001D3A RID: 7482
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node21 : Condition
	{
		// Token: 0x06012436 RID: 74806 RVA: 0x00553A0D File Offset: 0x00551E0D
		public Condition_bt_APC_APC_Guiqi_Action_node21()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012437 RID: 74807 RVA: 0x00553A44 File Offset: 0x00551E44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE28 RID: 48680
		private int opl_p0;

		// Token: 0x0400BE29 RID: 48681
		private int opl_p1;

		// Token: 0x0400BE2A RID: 48682
		private int opl_p2;

		// Token: 0x0400BE2B RID: 48683
		private int opl_p3;
	}
}
