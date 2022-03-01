using System;

namespace behaviac
{
	// Token: 0x02004017 RID: 16407
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node16 : Condition
	{
		// Token: 0x06016791 RID: 92049 RVA: 0x006CD1D3 File Offset: 0x006CB5D3
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node16()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06016792 RID: 92050 RVA: 0x006CD1E8 File Offset: 0x006CB5E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFE0 RID: 65504
		private float opl_p0;
	}
}
