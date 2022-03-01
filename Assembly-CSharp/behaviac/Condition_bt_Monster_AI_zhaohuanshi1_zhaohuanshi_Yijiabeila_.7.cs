using System;

namespace behaviac
{
	// Token: 0x020040AF RID: 16559
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node7 : Condition
	{
		// Token: 0x060168B7 RID: 92343 RVA: 0x006D392E File Offset: 0x006D1D2E
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node7()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060168B8 RID: 92344 RVA: 0x006D3944 File Offset: 0x006D1D44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100FE RID: 65790
		private float opl_p0;
	}
}
