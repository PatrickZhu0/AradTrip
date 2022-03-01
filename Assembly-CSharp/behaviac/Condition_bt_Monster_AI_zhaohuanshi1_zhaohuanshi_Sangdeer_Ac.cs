using System;

namespace behaviac
{
	// Token: 0x02004093 RID: 16531
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node4 : Condition
	{
		// Token: 0x06016881 RID: 92289 RVA: 0x006D2862 File Offset: 0x006D0C62
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node4()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06016882 RID: 92290 RVA: 0x006D2878 File Offset: 0x006D0C78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100CA RID: 65738
		private float opl_p0;
	}
}
