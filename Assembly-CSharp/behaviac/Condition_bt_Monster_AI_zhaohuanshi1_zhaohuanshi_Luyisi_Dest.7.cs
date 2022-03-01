using System;

namespace behaviac
{
	// Token: 0x0200408F RID: 16527
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node16 : Condition
	{
		// Token: 0x0601687A RID: 92282 RVA: 0x006D2317 File Offset: 0x006D0717
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node16()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601687B RID: 92283 RVA: 0x006D232C File Offset: 0x006D072C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100C4 RID: 65732
		private float opl_p0;
	}
}
