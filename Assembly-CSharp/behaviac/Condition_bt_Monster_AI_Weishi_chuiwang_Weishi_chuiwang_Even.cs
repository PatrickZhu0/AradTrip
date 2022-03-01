using System;

namespace behaviac
{
	// Token: 0x02003DAC RID: 15788
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3 : Condition
	{
		// Token: 0x060162E8 RID: 90856 RVA: 0x006B4C85 File Offset: 0x006B3085
		public Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x060162E9 RID: 90857 RVA: 0x006B4CA8 File Offset: 0x006B30A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB2E RID: 64302
		private HMType opl_p0;

		// Token: 0x0400FB2F RID: 64303
		private BE_Operation opl_p1;

		// Token: 0x0400FB30 RID: 64304
		private float opl_p2;
	}
}
