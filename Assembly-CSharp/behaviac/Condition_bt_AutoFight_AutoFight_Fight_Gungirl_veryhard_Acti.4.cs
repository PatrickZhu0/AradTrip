using System;

namespace behaviac
{
	// Token: 0x020020A7 RID: 8359
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node8 : Condition
	{
		// Token: 0x06012AE5 RID: 76517 RVA: 0x0057C0D7 File Offset: 0x0057A4D7
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012AE6 RID: 76518 RVA: 0x0057C10C File Offset: 0x0057A50C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4D7 RID: 50391
		private int opl_p0;

		// Token: 0x0400C4D8 RID: 50392
		private int opl_p1;

		// Token: 0x0400C4D9 RID: 50393
		private int opl_p2;

		// Token: 0x0400C4DA RID: 50394
		private int opl_p3;
	}
}
