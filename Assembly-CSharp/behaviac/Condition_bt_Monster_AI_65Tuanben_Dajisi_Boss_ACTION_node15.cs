using System;

namespace behaviac
{
	// Token: 0x02002D74 RID: 11636
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node15 : Condition
	{
		// Token: 0x060143CA RID: 82890 RVA: 0x0061439A File Offset: 0x0061279A
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node15()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.85f;
		}

		// Token: 0x060143CB RID: 82891 RVA: 0x006143BC File Offset: 0x006127BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD95 RID: 56725
		private HMType opl_p0;

		// Token: 0x0400DD96 RID: 56726
		private BE_Operation opl_p1;

		// Token: 0x0400DD97 RID: 56727
		private float opl_p2;
	}
}
