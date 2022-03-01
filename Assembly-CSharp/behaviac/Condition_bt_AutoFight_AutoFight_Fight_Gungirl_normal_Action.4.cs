using System;

namespace behaviac
{
	// Token: 0x0200208F RID: 8335
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node8 : Condition
	{
		// Token: 0x06012AB6 RID: 76470 RVA: 0x0057AE17 File Offset: 0x00579217
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012AB7 RID: 76471 RVA: 0x0057AE4C File Offset: 0x0057924C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4A8 RID: 50344
		private int opl_p0;

		// Token: 0x0400C4A9 RID: 50345
		private int opl_p1;

		// Token: 0x0400C4AA RID: 50346
		private int opl_p2;

		// Token: 0x0400C4AB RID: 50347
		private int opl_p3;
	}
}
