using System;

namespace behaviac
{
	// Token: 0x0200250D RID: 9485
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node71 : Condition
	{
		// Token: 0x06013364 RID: 78692 RVA: 0x005B4167 File Offset: 0x005B2567
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node71()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013365 RID: 78693 RVA: 0x005B419C File Offset: 0x005B259C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD84 RID: 52612
		private int opl_p0;

		// Token: 0x0400CD85 RID: 52613
		private int opl_p1;

		// Token: 0x0400CD86 RID: 52614
		private int opl_p2;

		// Token: 0x0400CD87 RID: 52615
		private int opl_p3;
	}
}
