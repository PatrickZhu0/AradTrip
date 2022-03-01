using System;

namespace behaviac
{
	// Token: 0x02003C10 RID: 15376
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node21 : Condition
	{
		// Token: 0x06015FCB RID: 90059 RVA: 0x006A4CA5 File Offset: 0x006A30A5
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node21()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x06015FCC RID: 90060 RVA: 0x006A4CC8 File Offset: 0x006A30C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F84D RID: 63565
		private HMType opl_p0;

		// Token: 0x0400F84E RID: 63566
		private BE_Operation opl_p1;

		// Token: 0x0400F84F RID: 63567
		private float opl_p2;
	}
}
