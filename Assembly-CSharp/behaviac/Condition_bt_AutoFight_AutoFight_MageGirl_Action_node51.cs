using System;

namespace behaviac
{
	// Token: 0x02002691 RID: 9873
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node51 : Condition
	{
		// Token: 0x06013666 RID: 79462 RVA: 0x005C6B8D File Offset: 0x005C4F8D
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node51()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013667 RID: 79463 RVA: 0x005C6BA0 File Offset: 0x005C4FA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0BB RID: 53435
		private float opl_p0;
	}
}
