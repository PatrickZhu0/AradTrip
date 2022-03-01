using System;

namespace behaviac
{
	// Token: 0x02002A8B RID: 10891
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_hua_node19 : Condition
	{
		// Token: 0x06013E3A RID: 81466 RVA: 0x005F6CC5 File Offset: 0x005F50C5
		public Condition_bt_Guanka_apc_Mofashi_hua_node19()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013E3B RID: 81467 RVA: 0x005F6CD8 File Offset: 0x005F50D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8B0 RID: 55472
		private float opl_p0;
	}
}
