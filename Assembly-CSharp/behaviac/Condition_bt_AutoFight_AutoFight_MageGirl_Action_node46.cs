using System;

namespace behaviac
{
	// Token: 0x0200269D RID: 9885
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node46 : Condition
	{
		// Token: 0x0601367E RID: 79486 RVA: 0x005C70A9 File Offset: 0x005C54A9
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node46()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x0601367F RID: 79487 RVA: 0x005C70BC File Offset: 0x005C54BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0D3 RID: 53459
		private float opl_p0;
	}
}
