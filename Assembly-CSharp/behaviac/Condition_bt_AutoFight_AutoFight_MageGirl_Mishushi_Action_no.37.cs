using System;

namespace behaviac
{
	// Token: 0x020026E0 RID: 9952
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node7 : Condition
	{
		// Token: 0x06013703 RID: 79619 RVA: 0x005C9A6B File Offset: 0x005C7E6B
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node7()
		{
			this.opl_p0 = 2007;
		}

		// Token: 0x06013704 RID: 79620 RVA: 0x005C9A80 File Offset: 0x005C7E80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D15A RID: 53594
		private int opl_p0;
	}
}
