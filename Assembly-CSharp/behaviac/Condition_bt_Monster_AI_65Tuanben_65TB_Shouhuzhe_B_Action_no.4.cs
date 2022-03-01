using System;

namespace behaviac
{
	// Token: 0x02002C5C RID: 11356
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node6 : Condition
	{
		// Token: 0x060141B3 RID: 82355 RVA: 0x00609C2E File Offset: 0x0060802E
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node6()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060141B4 RID: 82356 RVA: 0x00609C50 File Offset: 0x00608050
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB75 RID: 56181
		private HMType opl_p0;

		// Token: 0x0400DB76 RID: 56182
		private BE_Operation opl_p1;

		// Token: 0x0400DB77 RID: 56183
		private float opl_p2;
	}
}
