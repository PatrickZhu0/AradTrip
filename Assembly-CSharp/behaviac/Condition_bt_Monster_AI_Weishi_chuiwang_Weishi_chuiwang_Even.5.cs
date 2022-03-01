using System;

namespace behaviac
{
	// Token: 0x02003DB4 RID: 15796
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node13 : Condition
	{
		// Token: 0x060162F8 RID: 90872 RVA: 0x006B4F23 File Offset: 0x006B3323
		public Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node13()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x060162F9 RID: 90873 RVA: 0x006B4F44 File Offset: 0x006B3344
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB45 RID: 64325
		private HMType opl_p0;

		// Token: 0x0400FB46 RID: 64326
		private BE_Operation opl_p1;

		// Token: 0x0400FB47 RID: 64327
		private float opl_p2;
	}
}
