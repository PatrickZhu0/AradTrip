using System;

namespace behaviac
{
	// Token: 0x020026C6 RID: 9926
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node37 : Condition
	{
		// Token: 0x060136CF RID: 79567 RVA: 0x005C8FB5 File Offset: 0x005C73B5
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node37()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060136D0 RID: 79568 RVA: 0x005C8FC8 File Offset: 0x005C73C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D127 RID: 53543
		private float opl_p0;
	}
}
