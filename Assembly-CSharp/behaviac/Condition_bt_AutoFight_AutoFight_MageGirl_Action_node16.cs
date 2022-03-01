using System;

namespace behaviac
{
	// Token: 0x0200268C RID: 9868
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node16 : Condition
	{
		// Token: 0x0601365C RID: 79452 RVA: 0x005C695E File Offset: 0x005C4D5E
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node16()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601365D RID: 79453 RVA: 0x005C6994 File Offset: 0x005C4D94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0AF RID: 53423
		private int opl_p0;

		// Token: 0x0400D0B0 RID: 53424
		private int opl_p1;

		// Token: 0x0400D0B1 RID: 53425
		private int opl_p2;

		// Token: 0x0400D0B2 RID: 53426
		private int opl_p3;
	}
}
