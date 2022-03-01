using System;

namespace behaviac
{
	// Token: 0x020027FB RID: 10235
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node91 : Condition
	{
		// Token: 0x06013935 RID: 80181 RVA: 0x005D5EEE File Offset: 0x005D42EE
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node91()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013936 RID: 80182 RVA: 0x005D5F24 File Offset: 0x005D4324
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D393 RID: 54163
		private int opl_p0;

		// Token: 0x0400D394 RID: 54164
		private int opl_p1;

		// Token: 0x0400D395 RID: 54165
		private int opl_p2;

		// Token: 0x0400D396 RID: 54166
		private int opl_p3;
	}
}
