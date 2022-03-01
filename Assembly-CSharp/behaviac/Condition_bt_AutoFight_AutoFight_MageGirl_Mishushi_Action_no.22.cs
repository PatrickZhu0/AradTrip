using System;

namespace behaviac
{
	// Token: 0x020026CB RID: 9931
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node66 : Condition
	{
		// Token: 0x060136D9 RID: 79577 RVA: 0x005C91AF File Offset: 0x005C75AF
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node66()
		{
			this.opl_p0 = 2207;
		}

		// Token: 0x060136DA RID: 79578 RVA: 0x005C91C4 File Offset: 0x005C75C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D130 RID: 53552
		private int opl_p0;
	}
}
