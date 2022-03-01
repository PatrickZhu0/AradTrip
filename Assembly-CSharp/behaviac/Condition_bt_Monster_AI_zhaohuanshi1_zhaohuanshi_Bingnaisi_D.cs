using System;

namespace behaviac
{
	// Token: 0x0200402F RID: 16431
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node4 : Condition
	{
		// Token: 0x060167BE RID: 92094 RVA: 0x006CE44C File Offset: 0x006CC84C
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node4()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x060167BF RID: 92095 RVA: 0x006CE460 File Offset: 0x006CC860
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401000A RID: 65546
		private float opl_p0;
	}
}
