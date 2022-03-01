using System;

namespace behaviac
{
	// Token: 0x020026DB RID: 9947
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node50 : Condition
	{
		// Token: 0x060136F9 RID: 79609 RVA: 0x005C9871 File Offset: 0x005C7C71
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node50()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060136FA RID: 79610 RVA: 0x005C9884 File Offset: 0x005C7C84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D151 RID: 53585
		private float opl_p0;
	}
}
