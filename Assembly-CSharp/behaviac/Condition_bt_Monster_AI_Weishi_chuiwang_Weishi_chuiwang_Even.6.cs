using System;

namespace behaviac
{
	// Token: 0x02003DB7 RID: 15799
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node17 : Condition
	{
		// Token: 0x060162FE RID: 90878 RVA: 0x006B5024 File Offset: 0x006B3424
		public Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node17()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x060162FF RID: 90879 RVA: 0x006B5048 File Offset: 0x006B3448
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB4F RID: 64335
		private HMType opl_p0;

		// Token: 0x0400FB50 RID: 64336
		private BE_Operation opl_p1;

		// Token: 0x0400FB51 RID: 64337
		private float opl_p2;
	}
}
