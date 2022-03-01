using System;

namespace behaviac
{
	// Token: 0x02003FE3 RID: 16355
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node12 : Condition
	{
		// Token: 0x0601672D RID: 91949 RVA: 0x006CB04F File Offset: 0x006C944F
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node12()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601672E RID: 91950 RVA: 0x006CB064 File Offset: 0x006C9464
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF7F RID: 65407
		private float opl_p0;
	}
}
