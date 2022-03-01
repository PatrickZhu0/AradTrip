using System;

namespace behaviac
{
	// Token: 0x02004026 RID: 16422
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node10 : Condition
	{
		// Token: 0x060167AD RID: 92077 RVA: 0x006CDCC2 File Offset: 0x006CC0C2
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node10()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060167AE RID: 92078 RVA: 0x006CDCD8 File Offset: 0x006CC0D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFFA RID: 65530
		private float opl_p0;
	}
}
