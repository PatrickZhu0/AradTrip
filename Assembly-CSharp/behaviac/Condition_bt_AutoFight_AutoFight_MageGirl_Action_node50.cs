using System;

namespace behaviac
{
	// Token: 0x02002690 RID: 9872
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node50 : Condition
	{
		// Token: 0x06013664 RID: 79460 RVA: 0x005C6B12 File Offset: 0x005C4F12
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node50()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013665 RID: 79461 RVA: 0x005C6B48 File Offset: 0x005C4F48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0B7 RID: 53431
		private int opl_p0;

		// Token: 0x0400D0B8 RID: 53432
		private int opl_p1;

		// Token: 0x0400D0B9 RID: 53433
		private int opl_p2;

		// Token: 0x0400D0BA RID: 53434
		private int opl_p3;
	}
}
