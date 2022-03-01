using System;

namespace behaviac
{
	// Token: 0x02001E95 RID: 7829
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node65 : Condition
	{
		// Token: 0x060126D4 RID: 75476 RVA: 0x00563829 File Offset: 0x00561C29
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node65()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060126D5 RID: 75477 RVA: 0x0056383C File Offset: 0x00561C3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0C3 RID: 49347
		private float opl_p0;
	}
}
