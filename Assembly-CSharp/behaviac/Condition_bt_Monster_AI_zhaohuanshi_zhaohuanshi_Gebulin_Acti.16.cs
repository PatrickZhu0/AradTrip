using System;

namespace behaviac
{
	// Token: 0x02003FA1 RID: 16289
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node30 : Condition
	{
		// Token: 0x060166AC RID: 91820 RVA: 0x006C7F1A File Offset: 0x006C631A
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node30()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060166AD RID: 91821 RVA: 0x006C7F30 File Offset: 0x006C6330
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEFF RID: 65279
		private float opl_p0;
	}
}
