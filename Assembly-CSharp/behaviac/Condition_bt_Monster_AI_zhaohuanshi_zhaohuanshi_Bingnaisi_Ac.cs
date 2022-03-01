using System;

namespace behaviac
{
	// Token: 0x02003F79 RID: 16249
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node6 : Condition
	{
		// Token: 0x0601665E RID: 91742 RVA: 0x006C6934 File Offset: 0x006C4D34
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node6()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601665F RID: 91743 RVA: 0x006C6948 File Offset: 0x006C4D48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEB3 RID: 65203
		private float opl_p0;
	}
}
