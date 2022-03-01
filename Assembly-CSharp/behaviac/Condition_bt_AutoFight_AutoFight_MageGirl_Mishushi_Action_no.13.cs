using System;

namespace behaviac
{
	// Token: 0x020026BF RID: 9919
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node56 : Condition
	{
		// Token: 0x060136C1 RID: 79553 RVA: 0x005C8C93 File Offset: 0x005C7093
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node56()
		{
			this.opl_p0 = 2203;
		}

		// Token: 0x060136C2 RID: 79554 RVA: 0x005C8CA8 File Offset: 0x005C70A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D118 RID: 53528
		private int opl_p0;
	}
}
