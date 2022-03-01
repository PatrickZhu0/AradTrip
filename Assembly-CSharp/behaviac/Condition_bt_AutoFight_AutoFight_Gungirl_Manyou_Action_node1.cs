using System;

namespace behaviac
{
	// Token: 0x020024FE RID: 9470
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node10 : Condition
	{
		// Token: 0x06013346 RID: 78662 RVA: 0x005B38CB File Offset: 0x005B1CCB
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node10()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013347 RID: 78663 RVA: 0x005B3900 File Offset: 0x005B1D00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD65 RID: 52581
		private int opl_p0;

		// Token: 0x0400CD66 RID: 52582
		private int opl_p1;

		// Token: 0x0400CD67 RID: 52583
		private int opl_p2;

		// Token: 0x0400CD68 RID: 52584
		private int opl_p3;
	}
}
