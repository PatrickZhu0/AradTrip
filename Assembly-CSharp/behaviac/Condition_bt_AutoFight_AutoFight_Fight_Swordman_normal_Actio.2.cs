using System;

namespace behaviac
{
	// Token: 0x0200243B RID: 9275
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node11 : Condition
	{
		// Token: 0x060131CC RID: 78284 RVA: 0x005AB8A0 File Offset: 0x005A9CA0
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node11()
		{
			this.opl_p0 = 0.58f;
		}

		// Token: 0x060131CD RID: 78285 RVA: 0x005AB8B4 File Offset: 0x005A9CB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBF6 RID: 52214
		private float opl_p0;
	}
}
