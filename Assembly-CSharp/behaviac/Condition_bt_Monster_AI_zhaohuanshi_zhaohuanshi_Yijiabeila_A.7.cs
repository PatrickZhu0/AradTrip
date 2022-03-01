using System;

namespace behaviac
{
	// Token: 0x02004006 RID: 16390
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node7 : Condition
	{
		// Token: 0x06016770 RID: 92016 RVA: 0x006CC752 File Offset: 0x006CAB52
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node7()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06016771 RID: 92017 RVA: 0x006CC768 File Offset: 0x006CAB68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFBF RID: 65471
		private float opl_p0;
	}
}
