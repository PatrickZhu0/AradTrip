using System;

namespace behaviac
{
	// Token: 0x02003B64 RID: 15204
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node68 : Condition
	{
		// Token: 0x06015E7D RID: 89725 RVA: 0x0069DE02 File Offset: 0x0069C202
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node68()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.1f;
		}

		// Token: 0x06015E7E RID: 89726 RVA: 0x0069DE24 File Offset: 0x0069C224
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F743 RID: 63299
		private HMType opl_p0;

		// Token: 0x0400F744 RID: 63300
		private BE_Operation opl_p1;

		// Token: 0x0400F745 RID: 63301
		private float opl_p2;
	}
}
