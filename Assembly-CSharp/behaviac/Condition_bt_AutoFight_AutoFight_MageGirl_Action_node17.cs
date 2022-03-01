using System;

namespace behaviac
{
	// Token: 0x0200268D RID: 9869
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node17 : Condition
	{
		// Token: 0x0601365E RID: 79454 RVA: 0x005C69D9 File Offset: 0x005C4DD9
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node17()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601365F RID: 79455 RVA: 0x005C69EC File Offset: 0x005C4DEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0B3 RID: 53427
		private float opl_p0;
	}
}
