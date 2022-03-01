using System;

namespace behaviac
{
	// Token: 0x02001EA4 RID: 7844
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node12 : Condition
	{
		// Token: 0x060126F1 RID: 75505 RVA: 0x00564401 File Offset: 0x00562801
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node12()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060126F2 RID: 75506 RVA: 0x00564414 File Offset: 0x00562814
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0DF RID: 49375
		private float opl_p0;
	}
}
