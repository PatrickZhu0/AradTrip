using System;

namespace behaviac
{
	// Token: 0x02003DB0 RID: 15792
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node8 : Condition
	{
		// Token: 0x060162F0 RID: 90864 RVA: 0x006B4D98 File Offset: 0x006B3198
		public Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node8()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x060162F1 RID: 90865 RVA: 0x006B4DBC File Offset: 0x006B31BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB37 RID: 64311
		private HMType opl_p0;

		// Token: 0x0400FB38 RID: 64312
		private BE_Operation opl_p1;

		// Token: 0x0400FB39 RID: 64313
		private float opl_p2;
	}
}
