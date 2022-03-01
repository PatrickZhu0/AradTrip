using System;

namespace behaviac
{
	// Token: 0x020026EB RID: 9963
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node17 : Condition
	{
		// Token: 0x06013719 RID: 79641 RVA: 0x005C9F41 File Offset: 0x005C8341
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node17()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601371A RID: 79642 RVA: 0x005C9F54 File Offset: 0x005C8354
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D171 RID: 53617
		private float opl_p0;
	}
}
