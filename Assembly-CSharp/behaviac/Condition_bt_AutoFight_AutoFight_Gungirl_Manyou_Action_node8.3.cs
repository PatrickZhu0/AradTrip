using System;

namespace behaviac
{
	// Token: 0x020024F2 RID: 9458
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node80 : Condition
	{
		// Token: 0x0601332E RID: 78638 RVA: 0x005B32FF File Offset: 0x005B16FF
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node80()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x0601332F RID: 78639 RVA: 0x005B3334 File Offset: 0x005B1734
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD4D RID: 52557
		private int opl_p0;

		// Token: 0x0400CD4E RID: 52558
		private int opl_p1;

		// Token: 0x0400CD4F RID: 52559
		private int opl_p2;

		// Token: 0x0400CD50 RID: 52560
		private int opl_p3;
	}
}
