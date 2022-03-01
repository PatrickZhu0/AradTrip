using System;

namespace behaviac
{
	// Token: 0x02003DC9 RID: 15817
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node22 : Condition
	{
		// Token: 0x06016321 RID: 90913 RVA: 0x006B5A64 File Offset: 0x006B3E64
		public Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node22()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06016322 RID: 90914 RVA: 0x006B5A88 File Offset: 0x006B3E88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB81 RID: 64385
		private HMType opl_p0;

		// Token: 0x0400FB82 RID: 64386
		private BE_Operation opl_p1;

		// Token: 0x0400FB83 RID: 64387
		private float opl_p2;
	}
}
