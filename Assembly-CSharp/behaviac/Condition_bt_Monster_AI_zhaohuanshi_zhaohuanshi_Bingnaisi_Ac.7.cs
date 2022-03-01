using System;

namespace behaviac
{
	// Token: 0x02003F81 RID: 16257
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node14 : Condition
	{
		// Token: 0x0601666E RID: 91758 RVA: 0x006C6C9A File Offset: 0x006C509A
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node14()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601666F RID: 91759 RVA: 0x006C6CB0 File Offset: 0x006C50B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEC3 RID: 65219
		private float opl_p0;
	}
}
