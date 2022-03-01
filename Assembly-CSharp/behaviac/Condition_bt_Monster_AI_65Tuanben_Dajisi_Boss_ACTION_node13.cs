using System;

namespace behaviac
{
	// Token: 0x02002D7E RID: 11646
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node13 : Condition
	{
		// Token: 0x060143DE RID: 82910 RVA: 0x006147C2 File Offset: 0x00612BC2
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node13()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.15f;
		}

		// Token: 0x060143DF RID: 82911 RVA: 0x006147E4 File Offset: 0x00612BE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDAD RID: 56749
		private HMType opl_p0;

		// Token: 0x0400DDAE RID: 56750
		private BE_Operation opl_p1;

		// Token: 0x0400DDAF RID: 56751
		private float opl_p2;
	}
}
