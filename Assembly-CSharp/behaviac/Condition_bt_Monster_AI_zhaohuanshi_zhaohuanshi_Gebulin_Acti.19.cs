using System;

namespace behaviac
{
	// Token: 0x02003FA5 RID: 16293
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node35 : Condition
	{
		// Token: 0x060166B4 RID: 91828 RVA: 0x006C80CE File Offset: 0x006C64CE
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node35()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060166B5 RID: 91829 RVA: 0x006C80E4 File Offset: 0x006C64E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF07 RID: 65287
		private float opl_p0;
	}
}
