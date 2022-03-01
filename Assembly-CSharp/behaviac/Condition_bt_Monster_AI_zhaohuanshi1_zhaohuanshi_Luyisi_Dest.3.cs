using System;

namespace behaviac
{
	// Token: 0x02004089 RID: 16521
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node8 : Condition
	{
		// Token: 0x0601686E RID: 92270 RVA: 0x006D213F File Offset: 0x006D053F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node8()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601686F RID: 92271 RVA: 0x006D2154 File Offset: 0x006D0554
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100B8 RID: 65720
		private float opl_p0;
	}
}
