using System;

namespace behaviac
{
	// Token: 0x020026CA RID: 9930
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node65 : Condition
	{
		// Token: 0x060136D7 RID: 79575 RVA: 0x005C9169 File Offset: 0x005C7569
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node65()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060136D8 RID: 79576 RVA: 0x005C917C File Offset: 0x005C757C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D12F RID: 53551
		private float opl_p0;
	}
}
