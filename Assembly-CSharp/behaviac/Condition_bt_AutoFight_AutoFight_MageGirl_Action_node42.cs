using System;

namespace behaviac
{
	// Token: 0x020026AC RID: 9900
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node42 : Condition
	{
		// Token: 0x0601369C RID: 79516 RVA: 0x005C76FE File Offset: 0x005C5AFE
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node42()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601369D RID: 79517 RVA: 0x005C7714 File Offset: 0x005C5B14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0EF RID: 53487
		private float opl_p0;
	}
}
