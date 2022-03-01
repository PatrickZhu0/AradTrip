using System;

namespace behaviac
{
	// Token: 0x02003B48 RID: 15176
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node28 : Condition
	{
		// Token: 0x06015E45 RID: 89669 RVA: 0x0069D581 File Offset: 0x0069B981
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node28()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.1f;
		}

		// Token: 0x06015E46 RID: 89670 RVA: 0x0069D5A4 File Offset: 0x0069B9A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F717 RID: 63255
		private HMType opl_p0;

		// Token: 0x0400F718 RID: 63256
		private BE_Operation opl_p1;

		// Token: 0x0400F719 RID: 63257
		private float opl_p2;
	}
}
