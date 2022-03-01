using System;

namespace behaviac
{
	// Token: 0x020029DF RID: 10719
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node1 : Condition
	{
		// Token: 0x06013CF1 RID: 81137 RVA: 0x005EDE7B File Offset: 0x005EC27B
		public Condition_bt_BOSS_BOSS20_4_Action_node1()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013CF2 RID: 81138 RVA: 0x005EDE90 File Offset: 0x005EC290
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D765 RID: 55141
		private float opl_p0;
	}
}
