using System;

namespace behaviac
{
	// Token: 0x020024D9 RID: 9433
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node21 : Condition
	{
		// Token: 0x060132FC RID: 78588 RVA: 0x005B262F File Offset: 0x005B0A2F
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node21()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060132FD RID: 78589 RVA: 0x005B2664 File Offset: 0x005B0A64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD18 RID: 52504
		private int opl_p0;

		// Token: 0x0400CD19 RID: 52505
		private int opl_p1;

		// Token: 0x0400CD1A RID: 52506
		private int opl_p2;

		// Token: 0x0400CD1B RID: 52507
		private int opl_p3;
	}
}
