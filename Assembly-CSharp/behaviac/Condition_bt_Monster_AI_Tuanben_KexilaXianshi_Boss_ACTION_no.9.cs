using System;

namespace behaviac
{
	// Token: 0x02003A41 RID: 14913
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node54 : Condition
	{
		// Token: 0x06015C4B RID: 89163 RVA: 0x0069350F File Offset: 0x0069190F
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node54()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06015C4C RID: 89164 RVA: 0x00693530 File Offset: 0x00691930
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F56A RID: 62826
		private HMType opl_p0;

		// Token: 0x0400F56B RID: 62827
		private BE_Operation opl_p1;

		// Token: 0x0400F56C RID: 62828
		private float opl_p2;
	}
}
