using System;

namespace behaviac
{
	// Token: 0x0200401E RID: 16414
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Zhaohuan_tongyong_node6 : Condition
	{
		// Token: 0x0601679E RID: 92062 RVA: 0x006CD80B File Offset: 0x006CBC0B
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Zhaohuan_tongyong_node6()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601679F RID: 92063 RVA: 0x006CD820 File Offset: 0x006CBC20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFEC RID: 65516
		private float opl_p0;
	}
}
