using System;

namespace behaviac
{
	// Token: 0x0200402A RID: 16426
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node14 : Condition
	{
		// Token: 0x060167B5 RID: 92085 RVA: 0x006CDE76 File Offset: 0x006CC276
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node14()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060167B6 RID: 92086 RVA: 0x006CDE8C File Offset: 0x006CC28C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010002 RID: 65538
		private float opl_p0;
	}
}
