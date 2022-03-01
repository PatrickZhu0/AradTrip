using System;

namespace behaviac
{
	// Token: 0x02001E22 RID: 7714
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node12 : Condition
	{
		// Token: 0x060125F5 RID: 75253 RVA: 0x0055DE15 File Offset: 0x0055C215
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node12()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060125F6 RID: 75254 RVA: 0x0055DE28 File Offset: 0x0055C228
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFE2 RID: 49122
		private float opl_p0;
	}
}
