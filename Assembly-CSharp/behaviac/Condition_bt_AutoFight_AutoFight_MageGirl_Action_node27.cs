using System;

namespace behaviac
{
	// Token: 0x020026A1 RID: 9889
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node27 : Condition
	{
		// Token: 0x06013686 RID: 79494 RVA: 0x005C725D File Offset: 0x005C565D
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node27()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013687 RID: 79495 RVA: 0x005C7270 File Offset: 0x005C5670
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0DB RID: 53467
		private float opl_p0;
	}
}
