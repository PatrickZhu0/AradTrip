using System;

namespace behaviac
{
	// Token: 0x02003DB1 RID: 15793
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node9 : Condition
	{
		// Token: 0x060162F2 RID: 90866 RVA: 0x006B4DFB File Offset: 0x006B31FB
		public Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node9()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060162F3 RID: 90867 RVA: 0x006B4E1C File Offset: 0x006B321C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB3A RID: 64314
		private HMType opl_p0;

		// Token: 0x0400FB3B RID: 64315
		private BE_Operation opl_p1;

		// Token: 0x0400FB3C RID: 64316
		private float opl_p2;
	}
}
