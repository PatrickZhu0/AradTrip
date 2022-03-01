using System;

namespace behaviac
{
	// Token: 0x020030E4 RID: 12516
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node6 : Condition
	{
		// Token: 0x06014A7B RID: 84603 RVA: 0x006384B3 File Offset: 0x006368B3
		public Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node6()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06014A7C RID: 84604 RVA: 0x006384E8 File Offset: 0x006368E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3E9 RID: 58345
		private int opl_p0;

		// Token: 0x0400E3EA RID: 58346
		private int opl_p1;

		// Token: 0x0400E3EB RID: 58347
		private int opl_p2;

		// Token: 0x0400E3EC RID: 58348
		private int opl_p3;
	}
}
