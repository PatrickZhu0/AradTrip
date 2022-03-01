using System;

namespace behaviac
{
	// Token: 0x0200203E RID: 8254
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node7 : Condition
	{
		// Token: 0x06012A16 RID: 76310 RVA: 0x0057708A File Offset: 0x0057548A
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node7()
		{
			this.opl_p0 = 0.47f;
		}

		// Token: 0x06012A17 RID: 76311 RVA: 0x005770A0 File Offset: 0x005754A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C409 RID: 50185
		private float opl_p0;
	}
}
