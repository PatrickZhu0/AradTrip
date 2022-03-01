using System;

namespace behaviac
{
	// Token: 0x020026C3 RID: 9923
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node61 : Condition
	{
		// Token: 0x060136C9 RID: 79561 RVA: 0x005C8E47 File Offset: 0x005C7247
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node61()
		{
			this.opl_p0 = 2205;
		}

		// Token: 0x060136CA RID: 79562 RVA: 0x005C8E5C File Offset: 0x005C725C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D120 RID: 53536
		private int opl_p0;
	}
}
