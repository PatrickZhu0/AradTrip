using System;

namespace behaviac
{
	// Token: 0x02003A37 RID: 14903
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node83 : Condition
	{
		// Token: 0x06015C37 RID: 89143 RVA: 0x00693113 File Offset: 0x00691513
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node83()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x06015C38 RID: 89144 RVA: 0x00693134 File Offset: 0x00691534
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F54D RID: 62797
		private HMType opl_p0;

		// Token: 0x0400F54E RID: 62798
		private BE_Operation opl_p1;

		// Token: 0x0400F54F RID: 62799
		private float opl_p2;
	}
}
