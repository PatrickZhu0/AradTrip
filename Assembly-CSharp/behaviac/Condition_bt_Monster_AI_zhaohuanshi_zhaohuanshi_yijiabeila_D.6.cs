using System;

namespace behaviac
{
	// Token: 0x02004015 RID: 16405
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node13 : Condition
	{
		// Token: 0x0601678D RID: 92045 RVA: 0x006CD12F File Offset: 0x006CB52F
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node13()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 7000;
			this.opl_p2 = 7000;
			this.opl_p3 = 7000;
		}

		// Token: 0x0601678E RID: 92046 RVA: 0x006CD164 File Offset: 0x006CB564
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFDB RID: 65499
		private int opl_p0;

		// Token: 0x0400FFDC RID: 65500
		private int opl_p1;

		// Token: 0x0400FFDD RID: 65501
		private int opl_p2;

		// Token: 0x0400FFDE RID: 65502
		private int opl_p3;
	}
}
