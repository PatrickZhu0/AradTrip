using System;

namespace behaviac
{
	// Token: 0x02001D3B RID: 7483
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node22 : Condition
	{
		// Token: 0x06012438 RID: 74808 RVA: 0x00553A89 File Offset: 0x00551E89
		public Condition_bt_APC_APC_Guiqi_Action_node22()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012439 RID: 74809 RVA: 0x00553A9C File Offset: 0x00551E9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE2C RID: 48684
		private float opl_p0;
	}
}
