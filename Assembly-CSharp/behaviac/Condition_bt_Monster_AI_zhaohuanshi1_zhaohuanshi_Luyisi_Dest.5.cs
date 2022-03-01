using System;

namespace behaviac
{
	// Token: 0x0200408C RID: 16524
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node12 : Condition
	{
		// Token: 0x06016874 RID: 92276 RVA: 0x006D222B File Offset: 0x006D062B
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node12()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06016875 RID: 92277 RVA: 0x006D2240 File Offset: 0x006D0640
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100BE RID: 65726
		private float opl_p0;
	}
}
