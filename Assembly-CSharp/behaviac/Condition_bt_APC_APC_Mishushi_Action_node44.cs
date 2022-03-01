using System;

namespace behaviac
{
	// Token: 0x02001DCC RID: 7628
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node44 : Condition
	{
		// Token: 0x06012550 RID: 75088 RVA: 0x0055A331 File Offset: 0x00558731
		public Condition_bt_APC_APC_Mishushi_Action_node44()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012551 RID: 75089 RVA: 0x0055A344 File Offset: 0x00558744
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF46 RID: 48966
		private float opl_p0;
	}
}
