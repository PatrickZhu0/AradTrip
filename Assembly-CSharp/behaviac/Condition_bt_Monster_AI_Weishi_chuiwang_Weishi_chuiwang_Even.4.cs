using System;

namespace behaviac
{
	// Token: 0x02003DB3 RID: 15795
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node12 : Condition
	{
		// Token: 0x060162F6 RID: 90870 RVA: 0x006B4EC1 File Offset: 0x006B32C1
		public Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node12()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060162F7 RID: 90871 RVA: 0x006B4EE4 File Offset: 0x006B32E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB42 RID: 64322
		private HMType opl_p0;

		// Token: 0x0400FB43 RID: 64323
		private BE_Operation opl_p1;

		// Token: 0x0400FB44 RID: 64324
		private float opl_p2;
	}
}
