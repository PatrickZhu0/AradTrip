using System;

namespace behaviac
{
	// Token: 0x02004014 RID: 16404
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node12 : Condition
	{
		// Token: 0x0601678B RID: 92043 RVA: 0x006CD0E7 File Offset: 0x006CB4E7
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node12()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601678C RID: 92044 RVA: 0x006CD0FC File Offset: 0x006CB4FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFDA RID: 65498
		private float opl_p0;
	}
}
