using System;

namespace behaviac
{
	// Token: 0x02002218 RID: 8728
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node47 : Condition
	{
		// Token: 0x06012DBA RID: 77242 RVA: 0x0058DAC6 File Offset: 0x0058BEC6
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node47()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012DBB RID: 77243 RVA: 0x0058DAFC File Offset: 0x0058BEFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7AF RID: 51119
		private int opl_p0;

		// Token: 0x0400C7B0 RID: 51120
		private int opl_p1;

		// Token: 0x0400C7B1 RID: 51121
		private int opl_p2;

		// Token: 0x0400C7B2 RID: 51122
		private int opl_p3;
	}
}
