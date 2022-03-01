using System;

namespace behaviac
{
	// Token: 0x020026D2 RID: 9938
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node89 : Condition
	{
		// Token: 0x060136E7 RID: 79591 RVA: 0x005C94D1 File Offset: 0x005C78D1
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node89()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060136E8 RID: 79592 RVA: 0x005C94E4 File Offset: 0x005C78E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D13F RID: 53567
		private float opl_p0;
	}
}
