using System;

namespace behaviac
{
	// Token: 0x02001E8D RID: 7821
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node1 : Condition
	{
		// Token: 0x060126C4 RID: 75460 RVA: 0x005634C0 File Offset: 0x005618C0
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node1()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x060126C5 RID: 75461 RVA: 0x005634D4 File Offset: 0x005618D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0B3 RID: 49331
		private float opl_p0;
	}
}
