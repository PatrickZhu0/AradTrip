using System;

namespace behaviac
{
	// Token: 0x0200212B RID: 8491
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node3 : Condition
	{
		// Token: 0x06012BE8 RID: 76776 RVA: 0x005827A7 File Offset: 0x00580BA7
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node3()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012BE9 RID: 76777 RVA: 0x005827DC File Offset: 0x00580BDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5DA RID: 50650
		private int opl_p0;

		// Token: 0x0400C5DB RID: 50651
		private int opl_p1;

		// Token: 0x0400C5DC RID: 50652
		private int opl_p2;

		// Token: 0x0400C5DD RID: 50653
		private int opl_p3;
	}
}
