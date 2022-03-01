using System;

namespace behaviac
{
	// Token: 0x020020B7 RID: 8375
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node28 : Condition
	{
		// Token: 0x06012B05 RID: 76549 RVA: 0x0057C8A7 File Offset: 0x0057ACA7
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node28()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B06 RID: 76550 RVA: 0x0057C8DC File Offset: 0x0057ACDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4F7 RID: 50423
		private int opl_p0;

		// Token: 0x0400C4F8 RID: 50424
		private int opl_p1;

		// Token: 0x0400C4F9 RID: 50425
		private int opl_p2;

		// Token: 0x0400C4FA RID: 50426
		private int opl_p3;
	}
}
