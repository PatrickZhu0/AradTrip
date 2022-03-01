using System;

namespace behaviac
{
	// Token: 0x02002684 RID: 9860
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node6 : Condition
	{
		// Token: 0x0601364C RID: 79436 RVA: 0x005C65F6 File Offset: 0x005C49F6
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601364D RID: 79437 RVA: 0x005C662C File Offset: 0x005C4A2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D09F RID: 53407
		private int opl_p0;

		// Token: 0x0400D0A0 RID: 53408
		private int opl_p1;

		// Token: 0x0400D0A1 RID: 53409
		private int opl_p2;

		// Token: 0x0400D0A2 RID: 53410
		private int opl_p3;
	}
}
