using System;

namespace behaviac
{
	// Token: 0x0200406A RID: 16490
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node9 : Condition
	{
		// Token: 0x06016832 RID: 92210 RVA: 0x006D0C7F File Offset: 0x006CF07F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node9()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06016833 RID: 92211 RVA: 0x006D0C94 File Offset: 0x006CF094
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401007C RID: 65660
		private float opl_p0;
	}
}
