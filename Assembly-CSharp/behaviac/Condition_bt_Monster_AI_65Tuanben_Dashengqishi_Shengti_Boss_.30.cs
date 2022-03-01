using System;

namespace behaviac
{
	// Token: 0x02002DFF RID: 11775
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node95 : Condition
	{
		// Token: 0x060144DB RID: 83163 RVA: 0x00619449 File Offset: 0x00617849
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node95()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x060144DC RID: 83164 RVA: 0x0061946C File Offset: 0x0061786C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE88 RID: 56968
		private HMType opl_p0;

		// Token: 0x0400DE89 RID: 56969
		private BE_Operation opl_p1;

		// Token: 0x0400DE8A RID: 56970
		private float opl_p2;
	}
}
