using System;

namespace behaviac
{
	// Token: 0x02002096 RID: 8342
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node17 : Condition
	{
		// Token: 0x06012AC4 RID: 76484 RVA: 0x0057B1B6 File Offset: 0x005795B6
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node17()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x06012AC5 RID: 76485 RVA: 0x0057B1CC File Offset: 0x005795CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4B7 RID: 50359
		private float opl_p0;
	}
}
