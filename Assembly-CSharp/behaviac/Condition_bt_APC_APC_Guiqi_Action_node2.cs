using System;

namespace behaviac
{
	// Token: 0x02001D2C RID: 7468
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node2 : Condition
	{
		// Token: 0x0601241A RID: 74778 RVA: 0x00552DE6 File Offset: 0x005511E6
		public Condition_bt_APC_APC_Guiqi_Action_node2()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601241B RID: 74779 RVA: 0x00552E1C File Offset: 0x0055121C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE09 RID: 48649
		private int opl_p0;

		// Token: 0x0400BE0A RID: 48650
		private int opl_p1;

		// Token: 0x0400BE0B RID: 48651
		private int opl_p2;

		// Token: 0x0400BE0C RID: 48652
		private int opl_p3;
	}
}
