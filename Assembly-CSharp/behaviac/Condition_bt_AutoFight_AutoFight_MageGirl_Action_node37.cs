using System;

namespace behaviac
{
	// Token: 0x020026A9 RID: 9897
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node37 : Condition
	{
		// Token: 0x06013696 RID: 79510 RVA: 0x005C75C5 File Offset: 0x005C59C5
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node37()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013697 RID: 79511 RVA: 0x005C75D8 File Offset: 0x005C59D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0EB RID: 53483
		private float opl_p0;
	}
}
