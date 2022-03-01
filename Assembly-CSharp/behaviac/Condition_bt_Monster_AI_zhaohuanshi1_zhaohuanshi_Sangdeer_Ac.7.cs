using System;

namespace behaviac
{
	// Token: 0x0200409B RID: 16539
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node14 : Condition
	{
		// Token: 0x06016891 RID: 92305 RVA: 0x006D2BCA File Offset: 0x006D0FCA
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node14()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06016892 RID: 92306 RVA: 0x006D2BE0 File Offset: 0x006D0FE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100DA RID: 65754
		private float opl_p0;
	}
}
