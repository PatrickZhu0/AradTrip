using System;

namespace behaviac
{
	// Token: 0x020024D5 RID: 9429
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node93 : Condition
	{
		// Token: 0x060132F4 RID: 78580 RVA: 0x005B247B File Offset: 0x005B087B
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node93()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060132F5 RID: 78581 RVA: 0x005B24B0 File Offset: 0x005B08B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD10 RID: 52496
		private int opl_p0;

		// Token: 0x0400CD11 RID: 52497
		private int opl_p1;

		// Token: 0x0400CD12 RID: 52498
		private int opl_p2;

		// Token: 0x0400CD13 RID: 52499
		private int opl_p3;
	}
}
