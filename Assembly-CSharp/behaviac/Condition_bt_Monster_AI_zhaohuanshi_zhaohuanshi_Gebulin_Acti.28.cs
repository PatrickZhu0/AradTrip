using System;

namespace behaviac
{
	// Token: 0x02003FB1 RID: 16305
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node50 : Condition
	{
		// Token: 0x060166CC RID: 91852 RVA: 0x006C85EA File Offset: 0x006C69EA
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node50()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060166CD RID: 91853 RVA: 0x006C8600 File Offset: 0x006C6A00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF1F RID: 65311
		private float opl_p0;
	}
}
