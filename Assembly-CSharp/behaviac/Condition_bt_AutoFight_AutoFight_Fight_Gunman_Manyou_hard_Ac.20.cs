using System;

namespace behaviac
{
	// Token: 0x02002177 RID: 8567
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node48 : Condition
	{
		// Token: 0x06012C7F RID: 76927 RVA: 0x005856AB File Offset: 0x00583AAB
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node48()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012C80 RID: 76928 RVA: 0x005856E0 File Offset: 0x00583AE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C671 RID: 50801
		private int opl_p0;

		// Token: 0x0400C672 RID: 50802
		private int opl_p1;

		// Token: 0x0400C673 RID: 50803
		private int opl_p2;

		// Token: 0x0400C674 RID: 50804
		private int opl_p3;
	}
}
