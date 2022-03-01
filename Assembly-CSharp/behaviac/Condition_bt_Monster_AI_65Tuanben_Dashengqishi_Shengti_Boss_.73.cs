using System;

namespace behaviac
{
	// Token: 0x02002E4B RID: 11851
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node219 : Condition
	{
		// Token: 0x06014573 RID: 83315 RVA: 0x0061B1D7 File Offset: 0x006195D7
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node219()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.9f;
		}

		// Token: 0x06014574 RID: 83316 RVA: 0x0061B1F8 File Offset: 0x006195F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF02 RID: 57090
		private HMType opl_p0;

		// Token: 0x0400DF03 RID: 57091
		private BE_Operation opl_p1;

		// Token: 0x0400DF04 RID: 57092
		private float opl_p2;
	}
}
