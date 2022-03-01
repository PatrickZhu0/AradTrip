using System;

namespace behaviac
{
	// Token: 0x020030CA RID: 12490
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node2 : Condition
	{
		// Token: 0x06014A4E RID: 84558 RVA: 0x0063771F File Offset: 0x00635B1F
		public Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node2()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.05f;
		}

		// Token: 0x06014A4F RID: 84559 RVA: 0x00637740 File Offset: 0x00635B40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3B6 RID: 58294
		private HMType opl_p0;

		// Token: 0x0400E3B7 RID: 58295
		private BE_Operation opl_p1;

		// Token: 0x0400E3B8 RID: 58296
		private float opl_p2;
	}
}
