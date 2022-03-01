using System;

namespace behaviac
{
	// Token: 0x02003FA9 RID: 16297
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node40 : Condition
	{
		// Token: 0x060166BC RID: 91836 RVA: 0x006C8282 File Offset: 0x006C6682
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node40()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060166BD RID: 91837 RVA: 0x006C8298 File Offset: 0x006C6698
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF0F RID: 65295
		private float opl_p0;
	}
}
