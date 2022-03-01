using System;

namespace behaviac
{
	// Token: 0x02004011 RID: 16401
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node8 : Condition
	{
		// Token: 0x06016785 RID: 92037 RVA: 0x006CCFFB File Offset: 0x006CB3FB
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node8()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06016786 RID: 92038 RVA: 0x006CD010 File Offset: 0x006CB410
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFD4 RID: 65492
		private float opl_p0;
	}
}
