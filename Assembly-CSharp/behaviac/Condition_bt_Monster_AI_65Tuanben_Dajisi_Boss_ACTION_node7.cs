using System;

namespace behaviac
{
	// Token: 0x02002D6D RID: 11629
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node7 : Condition
	{
		// Token: 0x060143BC RID: 82876 RVA: 0x006140C4 File Offset: 0x006124C4
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node7()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.15f;
		}

		// Token: 0x060143BD RID: 82877 RVA: 0x006140E8 File Offset: 0x006124E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD83 RID: 56707
		private HMType opl_p0;

		// Token: 0x0400DD84 RID: 56708
		private BE_Operation opl_p1;

		// Token: 0x0400DD85 RID: 56709
		private float opl_p2;
	}
}
