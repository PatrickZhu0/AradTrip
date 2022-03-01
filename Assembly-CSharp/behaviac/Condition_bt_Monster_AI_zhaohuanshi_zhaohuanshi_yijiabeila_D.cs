using System;

namespace behaviac
{
	// Token: 0x0200400E RID: 16398
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node5 : Condition
	{
		// Token: 0x0601677F RID: 92031 RVA: 0x006CCF0E File Offset: 0x006CB30E
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node5()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06016780 RID: 92032 RVA: 0x006CCF24 File Offset: 0x006CB324
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFCE RID: 65486
		private float opl_p0;
	}
}
