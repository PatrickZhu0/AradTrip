using System;

namespace behaviac
{
	// Token: 0x02003DBE RID: 15806
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node7 : Condition
	{
		// Token: 0x0601630B RID: 90891 RVA: 0x006B56C7 File Offset: 0x006B3AC7
		public Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node7()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x0601630C RID: 90892 RVA: 0x006B56E8 File Offset: 0x006B3AE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB60 RID: 64352
		private HMType opl_p0;

		// Token: 0x0400FB61 RID: 64353
		private BE_Operation opl_p1;

		// Token: 0x0400FB62 RID: 64354
		private float opl_p2;
	}
}
