using System;

namespace behaviac
{
	// Token: 0x02003DC2 RID: 15810
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node12 : Condition
	{
		// Token: 0x06016313 RID: 90899 RVA: 0x006B57D8 File Offset: 0x006B3BD8
		public Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node12()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06016314 RID: 90900 RVA: 0x006B57FC File Offset: 0x006B3BFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB69 RID: 64361
		private HMType opl_p0;

		// Token: 0x0400FB6A RID: 64362
		private BE_Operation opl_p1;

		// Token: 0x0400FB6B RID: 64363
		private float opl_p2;
	}
}
