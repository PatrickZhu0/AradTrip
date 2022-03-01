using System;

namespace behaviac
{
	// Token: 0x020024A2 RID: 9378
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node7 : Condition
	{
		// Token: 0x0601328F RID: 78479 RVA: 0x005AFDA9 File Offset: 0x005AE1A9
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node7()
		{
			this.opl_p0 = 2504;
		}

		// Token: 0x06013290 RID: 78480 RVA: 0x005AFDBC File Offset: 0x005AE1BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCA7 RID: 52391
		private int opl_p0;
	}
}
