using System;

namespace behaviac
{
	// Token: 0x020030CE RID: 12494
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node2 : Condition
	{
		// Token: 0x06014A55 RID: 84565 RVA: 0x0063796E File Offset: 0x00635D6E
		public Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node2()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.07f;
		}

		// Token: 0x06014A56 RID: 84566 RVA: 0x00637990 File Offset: 0x00635D90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3BC RID: 58300
		private HMType opl_p0;

		// Token: 0x0400E3BD RID: 58301
		private BE_Operation opl_p1;

		// Token: 0x0400E3BE RID: 58302
		private float opl_p2;
	}
}
