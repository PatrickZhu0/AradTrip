using System;

namespace behaviac
{
	// Token: 0x0200219F RID: 8607
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node48 : Condition
	{
		// Token: 0x06012CCE RID: 77006 RVA: 0x005874C7 File Offset: 0x005858C7
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node48()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012CCF RID: 77007 RVA: 0x005874FC File Offset: 0x005858FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6C0 RID: 50880
		private int opl_p0;

		// Token: 0x0400C6C1 RID: 50881
		private int opl_p1;

		// Token: 0x0400C6C2 RID: 50882
		private int opl_p2;

		// Token: 0x0400C6C3 RID: 50883
		private int opl_p3;
	}
}
