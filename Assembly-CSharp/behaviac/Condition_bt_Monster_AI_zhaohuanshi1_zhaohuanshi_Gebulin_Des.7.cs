using System;

namespace behaviac
{
	// Token: 0x02004070 RID: 16496
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node17 : Condition
	{
		// Token: 0x0601683E RID: 92222 RVA: 0x006D0E57 File Offset: 0x006CF257
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node17()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601683F RID: 92223 RVA: 0x006D0E6C File Offset: 0x006CF26C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010088 RID: 65672
		private float opl_p0;
	}
}
