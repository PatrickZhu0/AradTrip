using System;

namespace behaviac
{
	// Token: 0x02001E19 RID: 7705
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node17 : Condition
	{
		// Token: 0x060125E3 RID: 75235 RVA: 0x0055DA39 File Offset: 0x0055BE39
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node17()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060125E4 RID: 75236 RVA: 0x0055DA4C File Offset: 0x0055BE4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFCE RID: 49102
		private float opl_p0;
	}
}
