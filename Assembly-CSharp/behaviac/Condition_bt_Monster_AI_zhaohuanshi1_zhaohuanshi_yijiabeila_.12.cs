using System;

namespace behaviac
{
	// Token: 0x020040B7 RID: 16567
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node5 : Condition
	{
		// Token: 0x060168C6 RID: 92358 RVA: 0x006D40EA File Offset: 0x006D24EA
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node5()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x060168C7 RID: 92359 RVA: 0x006D4100 File Offset: 0x006D2500
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401010D RID: 65805
		private float opl_p0;
	}
}
