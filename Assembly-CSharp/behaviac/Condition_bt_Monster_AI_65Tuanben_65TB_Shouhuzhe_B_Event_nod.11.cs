using System;

namespace behaviac
{
	// Token: 0x02002C75 RID: 11381
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node20 : Condition
	{
		// Token: 0x060141E3 RID: 82403 RVA: 0x0060A9AD File Offset: 0x00608DAD
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node20()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x060141E4 RID: 82404 RVA: 0x0060A9D0 File Offset: 0x00608DD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBA5 RID: 56229
		private HMType opl_p0;

		// Token: 0x0400DBA6 RID: 56230
		private BE_Operation opl_p1;

		// Token: 0x0400DBA7 RID: 56231
		private float opl_p2;
	}
}
