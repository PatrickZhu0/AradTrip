using System;

namespace behaviac
{
	// Token: 0x02003F8D RID: 16269
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node5 : Condition
	{
		// Token: 0x06016684 RID: 91780 RVA: 0x006C7696 File Offset: 0x006C5A96
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node5()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06016685 RID: 91781 RVA: 0x006C76AC File Offset: 0x006C5AAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FED7 RID: 65239
		private float opl_p0;
	}
}
