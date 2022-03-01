using System;

namespace behaviac
{
	// Token: 0x020026B6 RID: 9910
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node78 : Condition
	{
		// Token: 0x060136AF RID: 79535 RVA: 0x005C88D1 File Offset: 0x005C6CD1
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node78()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x060136B0 RID: 79536 RVA: 0x005C88E4 File Offset: 0x005C6CE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D105 RID: 53509
		private float opl_p0;
	}
}
