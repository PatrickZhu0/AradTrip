using System;

namespace behaviac
{
	// Token: 0x020026CF RID: 9935
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node85 : Condition
	{
		// Token: 0x060136E1 RID: 79585 RVA: 0x005C9363 File Offset: 0x005C7763
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node85()
		{
			this.opl_p0 = 2208;
		}

		// Token: 0x060136E2 RID: 79586 RVA: 0x005C9378 File Offset: 0x005C7778
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D138 RID: 53560
		private int opl_p0;
	}
}
