using System;

namespace behaviac
{
	// Token: 0x02003F7D RID: 16253
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node10 : Condition
	{
		// Token: 0x06016666 RID: 91750 RVA: 0x006C6AE6 File Offset: 0x006C4EE6
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node10()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06016667 RID: 91751 RVA: 0x006C6AFC File Offset: 0x006C4EFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEBB RID: 65211
		private float opl_p0;
	}
}
