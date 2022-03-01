using System;

namespace behaviac
{
	// Token: 0x0200250A RID: 9482
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node67 : Condition
	{
		// Token: 0x0601335E RID: 78686 RVA: 0x005B3FA3 File Offset: 0x005B23A3
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node67()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601335F RID: 78687 RVA: 0x005B3FD8 File Offset: 0x005B23D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD7D RID: 52605
		private int opl_p0;

		// Token: 0x0400CD7E RID: 52606
		private int opl_p1;

		// Token: 0x0400CD7F RID: 52607
		private int opl_p2;

		// Token: 0x0400CD80 RID: 52608
		private int opl_p3;
	}
}
