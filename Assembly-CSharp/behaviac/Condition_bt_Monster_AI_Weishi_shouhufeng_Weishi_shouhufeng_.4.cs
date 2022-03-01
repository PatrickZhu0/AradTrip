using System;

namespace behaviac
{
	// Token: 0x02003DC3 RID: 15811
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node13 : Condition
	{
		// Token: 0x06016315 RID: 90901 RVA: 0x006B583B File Offset: 0x006B3C3B
		public Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node13()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06016316 RID: 90902 RVA: 0x006B585C File Offset: 0x006B3C5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB6C RID: 64364
		private HMType opl_p0;

		// Token: 0x0400FB6D RID: 64365
		private BE_Operation opl_p1;

		// Token: 0x0400FB6E RID: 64366
		private float opl_p2;
	}
}
