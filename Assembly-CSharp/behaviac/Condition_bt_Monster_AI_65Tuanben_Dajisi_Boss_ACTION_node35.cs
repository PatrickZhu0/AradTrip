using System;

namespace behaviac
{
	// Token: 0x02002D72 RID: 11634
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node35 : Condition
	{
		// Token: 0x060143C6 RID: 82886 RVA: 0x0061428F File Offset: 0x0061268F
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node35()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x060143C7 RID: 82887 RVA: 0x006142B0 File Offset: 0x006126B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD90 RID: 56720
		private HMType opl_p0;

		// Token: 0x0400DD91 RID: 56721
		private BE_Operation opl_p1;

		// Token: 0x0400DD92 RID: 56722
		private float opl_p2;
	}
}
