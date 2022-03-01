using System;

namespace behaviac
{
	// Token: 0x02002B3A RID: 11066
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node9 : Condition
	{
		// Token: 0x06013F82 RID: 81794 RVA: 0x005FEC45 File Offset: 0x005FD045
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node9()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06013F83 RID: 81795 RVA: 0x005FEC68 File Offset: 0x005FD068
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9A8 RID: 55720
		private HMType opl_p0;

		// Token: 0x0400D9A9 RID: 55721
		private BE_Operation opl_p1;

		// Token: 0x0400D9AA RID: 55722
		private float opl_p2;
	}
}
