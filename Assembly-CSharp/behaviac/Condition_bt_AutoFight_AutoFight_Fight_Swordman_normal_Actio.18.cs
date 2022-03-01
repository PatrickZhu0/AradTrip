using System;

namespace behaviac
{
	// Token: 0x02002452 RID: 9298
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node54 : Condition
	{
		// Token: 0x060131F8 RID: 78328 RVA: 0x005AC2EA File Offset: 0x005AA6EA
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node54()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060131F9 RID: 78329 RVA: 0x005AC300 File Offset: 0x005AA700
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC20 RID: 52256
		private float opl_p0;
	}
}
