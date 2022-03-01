using System;

namespace behaviac
{
	// Token: 0x02001DC0 RID: 7616
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node55 : Condition
	{
		// Token: 0x06012538 RID: 75064 RVA: 0x00559E15 File Offset: 0x00558215
		public Condition_bt_APC_APC_Mishushi_Action_node55()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012539 RID: 75065 RVA: 0x00559E28 File Offset: 0x00558228
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF2E RID: 48942
		private float opl_p0;
	}
}
