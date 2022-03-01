using System;

namespace behaviac
{
	// Token: 0x0200312F RID: 12591
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node20 : Condition
	{
		// Token: 0x06014B03 RID: 84739 RVA: 0x0063AB75 File Offset: 0x00638F75
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node20()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.35f;
		}

		// Token: 0x06014B04 RID: 84740 RVA: 0x0063AB98 File Offset: 0x00638F98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E476 RID: 58486
		private HMType opl_p0;

		// Token: 0x0400E477 RID: 58487
		private BE_Operation opl_p1;

		// Token: 0x0400E478 RID: 58488
		private float opl_p2;
	}
}
