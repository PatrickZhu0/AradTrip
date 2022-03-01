using System;

namespace behaviac
{
	// Token: 0x0200406D RID: 16493
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node13 : Condition
	{
		// Token: 0x06016838 RID: 92216 RVA: 0x006D0D6B File Offset: 0x006CF16B
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node13()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06016839 RID: 92217 RVA: 0x006D0D80 File Offset: 0x006CF180
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010082 RID: 65666
		private float opl_p0;
	}
}
