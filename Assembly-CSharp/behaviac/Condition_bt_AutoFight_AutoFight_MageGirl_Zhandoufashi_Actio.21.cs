using System;

namespace behaviac
{
	// Token: 0x0200271C RID: 10012
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node43 : Condition
	{
		// Token: 0x0601377A RID: 79738 RVA: 0x005CCB52 File Offset: 0x005CAF52
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node43()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 800;
			this.opl_p2 = 2200;
			this.opl_p3 = 2200;
		}

		// Token: 0x0601377B RID: 79739 RVA: 0x005CCB88 File Offset: 0x005CAF88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1D3 RID: 53715
		private int opl_p0;

		// Token: 0x0400D1D4 RID: 53716
		private int opl_p1;

		// Token: 0x0400D1D5 RID: 53717
		private int opl_p2;

		// Token: 0x0400D1D6 RID: 53718
		private int opl_p3;
	}
}
