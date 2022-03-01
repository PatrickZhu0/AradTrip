using System;

namespace behaviac
{
	// Token: 0x02002248 RID: 8776
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node15 : Condition
	{
		// Token: 0x06012E18 RID: 77336 RVA: 0x00590ADF File Offset: 0x0058EEDF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node15()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012E19 RID: 77337 RVA: 0x00590AF4 File Offset: 0x0058EEF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C817 RID: 51223
		private float opl_p0;
	}
}
