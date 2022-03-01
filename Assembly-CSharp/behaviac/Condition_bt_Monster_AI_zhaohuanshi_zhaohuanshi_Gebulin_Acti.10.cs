using System;

namespace behaviac
{
	// Token: 0x02003F99 RID: 16281
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node20 : Condition
	{
		// Token: 0x0601669C RID: 91804 RVA: 0x006C7BB2 File Offset: 0x006C5FB2
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node20()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601669D RID: 91805 RVA: 0x006C7BC8 File Offset: 0x006C5FC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEEF RID: 65263
		private float opl_p0;
	}
}
