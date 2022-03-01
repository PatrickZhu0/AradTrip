using System;

namespace behaviac
{
	// Token: 0x02002441 RID: 9281
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node19 : Condition
	{
		// Token: 0x060131D7 RID: 78295 RVA: 0x005ABBCC File Offset: 0x005A9FCC
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node19()
		{
			this.opl_p0 = 0.55f;
		}

		// Token: 0x060131D8 RID: 78296 RVA: 0x005ABBE0 File Offset: 0x005A9FE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC01 RID: 52225
		private float opl_p0;
	}
}
