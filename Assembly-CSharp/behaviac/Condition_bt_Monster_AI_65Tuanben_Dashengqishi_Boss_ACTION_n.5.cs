using System;

namespace behaviac
{
	// Token: 0x02002D8D RID: 11661
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node25 : Condition
	{
		// Token: 0x060143FB RID: 82939 RVA: 0x00615725 File Offset: 0x00613B25
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node25()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x060143FC RID: 82940 RVA: 0x00615748 File Offset: 0x00613B48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDC7 RID: 56775
		private HMType opl_p0;

		// Token: 0x0400DDC8 RID: 56776
		private BE_Operation opl_p1;

		// Token: 0x0400DDC9 RID: 56777
		private float opl_p2;
	}
}
