using System;

namespace behaviac
{
	// Token: 0x02002153 RID: 8531
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node3 : Condition
	{
		// Token: 0x06012C37 RID: 76855 RVA: 0x005845C3 File Offset: 0x005829C3
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node3()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012C38 RID: 76856 RVA: 0x005845F8 File Offset: 0x005829F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C629 RID: 50729
		private int opl_p0;

		// Token: 0x0400C62A RID: 50730
		private int opl_p1;

		// Token: 0x0400C62B RID: 50731
		private int opl_p2;

		// Token: 0x0400C62C RID: 50732
		private int opl_p3;
	}
}
