using System;

namespace behaviac
{
	// Token: 0x02001E1D RID: 7709
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node22 : Condition
	{
		// Token: 0x060125EB RID: 75243 RVA: 0x0055DBED File Offset: 0x0055BFED
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node22()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060125EC RID: 75244 RVA: 0x0055DC00 File Offset: 0x0055C000
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFD6 RID: 49110
		private float opl_p0;
	}
}
