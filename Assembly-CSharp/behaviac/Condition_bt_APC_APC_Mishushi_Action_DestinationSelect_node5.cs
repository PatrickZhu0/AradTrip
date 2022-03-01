using System;

namespace behaviac
{
	// Token: 0x02001DD4 RID: 7636
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_DestinationSelect_node5 : Condition
	{
		// Token: 0x0601255F RID: 75103 RVA: 0x0055AB91 File Offset: 0x00558F91
		public Condition_bt_APC_APC_Mishushi_Action_DestinationSelect_node5()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012560 RID: 75104 RVA: 0x0055ABA4 File Offset: 0x00558FA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF53 RID: 48979
		private float opl_p0;
	}
}
