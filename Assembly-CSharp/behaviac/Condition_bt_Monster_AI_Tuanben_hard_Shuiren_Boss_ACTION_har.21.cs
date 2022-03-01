using System;

namespace behaviac
{
	// Token: 0x02003D5E RID: 15710
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node68 : Condition
	{
		// Token: 0x06016252 RID: 90706 RVA: 0x006B11F2 File Offset: 0x006AF5F2
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node68()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.1f;
		}

		// Token: 0x06016253 RID: 90707 RVA: 0x006B1214 File Offset: 0x006AF614
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAAC RID: 64172
		private HMType opl_p0;

		// Token: 0x0400FAAD RID: 64173
		private BE_Operation opl_p1;

		// Token: 0x0400FAAE RID: 64174
		private float opl_p2;
	}
}
