using System;

namespace behaviac
{
	// Token: 0x02003F91 RID: 16273
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node10 : Condition
	{
		// Token: 0x0601668C RID: 91788 RVA: 0x006C784A File Offset: 0x006C5C4A
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node10()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601668D RID: 91789 RVA: 0x006C7860 File Offset: 0x006C5C60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEDF RID: 65247
		private float opl_p0;
	}
}
