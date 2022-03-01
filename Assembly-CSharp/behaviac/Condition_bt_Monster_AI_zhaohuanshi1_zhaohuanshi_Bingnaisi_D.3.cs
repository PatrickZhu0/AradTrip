using System;

namespace behaviac
{
	// Token: 0x02004032 RID: 16434
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node7 : Condition
	{
		// Token: 0x060167C4 RID: 92100 RVA: 0x006CE537 File Offset: 0x006CC937
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node7()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x060167C5 RID: 92101 RVA: 0x006CE54C File Offset: 0x006CC94C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010010 RID: 65552
		private float opl_p0;
	}
}
