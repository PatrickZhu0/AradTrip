using System;

namespace behaviac
{
	// Token: 0x02002133 RID: 8499
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node13 : Condition
	{
		// Token: 0x06012BF8 RID: 76792 RVA: 0x00582ADF File Offset: 0x00580EDF
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node13()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012BF9 RID: 76793 RVA: 0x00582B14 File Offset: 0x00580F14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5EA RID: 50666
		private int opl_p0;

		// Token: 0x0400C5EB RID: 50667
		private int opl_p1;

		// Token: 0x0400C5EC RID: 50668
		private int opl_p2;

		// Token: 0x0400C5ED RID: 50669
		private int opl_p3;
	}
}
