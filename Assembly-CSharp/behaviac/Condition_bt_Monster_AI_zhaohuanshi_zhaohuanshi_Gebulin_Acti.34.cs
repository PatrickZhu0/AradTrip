using System;

namespace behaviac
{
	// Token: 0x02003FB9 RID: 16313
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node60 : Condition
	{
		// Token: 0x060166DC RID: 91868 RVA: 0x006C8952 File Offset: 0x006C6D52
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node60()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060166DD RID: 91869 RVA: 0x006C8968 File Offset: 0x006C6D68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF2F RID: 65327
		private float opl_p0;
	}
}
