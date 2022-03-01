using System;

namespace behaviac
{
	// Token: 0x02003FE6 RID: 16358
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node16 : Condition
	{
		// Token: 0x06016733 RID: 91955 RVA: 0x006CB13B File Offset: 0x006C953B
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node16()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06016734 RID: 91956 RVA: 0x006CB150 File Offset: 0x006C9550
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF85 RID: 65413
		private float opl_p0;
	}
}
