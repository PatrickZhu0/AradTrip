using System;

namespace behaviac
{
	// Token: 0x02003EDD RID: 16093
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node26 : Condition
	{
		// Token: 0x06016536 RID: 91446 RVA: 0x006C0D21 File Offset: 0x006BF121
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node26()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06016537 RID: 91447 RVA: 0x006C0D34 File Offset: 0x006BF134
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD6B RID: 64875
		private float opl_p0;
	}
}
