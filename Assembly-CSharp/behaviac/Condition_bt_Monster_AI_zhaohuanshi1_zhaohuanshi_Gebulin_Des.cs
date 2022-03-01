using System;

namespace behaviac
{
	// Token: 0x02004067 RID: 16487
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node5 : Condition
	{
		// Token: 0x0601682C RID: 92204 RVA: 0x006D0B92 File Offset: 0x006CEF92
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node5()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601682D RID: 92205 RVA: 0x006D0BA8 File Offset: 0x006CEFA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010076 RID: 65654
		private float opl_p0;
	}
}
