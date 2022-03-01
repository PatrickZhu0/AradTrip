using System;

namespace behaviac
{
	// Token: 0x02002636 RID: 9782
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node33 : Condition
	{
		// Token: 0x060135B2 RID: 79282 RVA: 0x005C1CD7 File Offset: 0x005C00D7
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node33()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060135B3 RID: 79283 RVA: 0x005C1D0C File Offset: 0x005C010C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFFF RID: 53247
		private int opl_p0;

		// Token: 0x0400D000 RID: 53248
		private int opl_p1;

		// Token: 0x0400D001 RID: 53249
		private int opl_p2;

		// Token: 0x0400D002 RID: 53250
		private int opl_p3;
	}
}
