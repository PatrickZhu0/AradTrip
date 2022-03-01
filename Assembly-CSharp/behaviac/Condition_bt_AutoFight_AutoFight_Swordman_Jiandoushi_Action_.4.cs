using System;

namespace behaviac
{
	// Token: 0x020028E7 RID: 10471
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node64 : Condition
	{
		// Token: 0x06013B05 RID: 80645 RVA: 0x005E20DF File Offset: 0x005E04DF
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node64()
		{
			this.opl_p0 = 4015;
		}

		// Token: 0x06013B06 RID: 80646 RVA: 0x005E20F4 File Offset: 0x005E04F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D568 RID: 54632
		private int opl_p0;
	}
}
