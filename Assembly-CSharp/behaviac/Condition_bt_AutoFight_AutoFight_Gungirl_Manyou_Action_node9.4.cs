using System;

namespace behaviac
{
	// Token: 0x020024D1 RID: 9425
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node95 : Condition
	{
		// Token: 0x060132EC RID: 78572 RVA: 0x005B22C7 File Offset: 0x005B06C7
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node95()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060132ED RID: 78573 RVA: 0x005B22FC File Offset: 0x005B06FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD08 RID: 52488
		private int opl_p0;

		// Token: 0x0400CD09 RID: 52489
		private int opl_p1;

		// Token: 0x0400CD0A RID: 52490
		private int opl_p2;

		// Token: 0x0400CD0B RID: 52491
		private int opl_p3;
	}
}
