using System;

namespace behaviac
{
	// Token: 0x020024EE RID: 9454
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node64 : Condition
	{
		// Token: 0x06013326 RID: 78630 RVA: 0x005B314A File Offset: 0x005B154A
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node64()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013327 RID: 78631 RVA: 0x005B3180 File Offset: 0x005B1580
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD45 RID: 52549
		private int opl_p0;

		// Token: 0x0400CD46 RID: 52550
		private int opl_p1;

		// Token: 0x0400CD47 RID: 52551
		private int opl_p2;

		// Token: 0x0400CD48 RID: 52552
		private int opl_p3;
	}
}
