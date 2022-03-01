using System;

namespace behaviac
{
	// Token: 0x0200244E RID: 9294
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node63 : Condition
	{
		// Token: 0x060131F0 RID: 78320 RVA: 0x005AC13A File Offset: 0x005AA53A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node63()
		{
			this.opl_p0 = 0.59f;
		}

		// Token: 0x060131F1 RID: 78321 RVA: 0x005AC150 File Offset: 0x005AA550
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC18 RID: 52248
		private float opl_p0;
	}
}
