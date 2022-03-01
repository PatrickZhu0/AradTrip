using System;

namespace behaviac
{
	// Token: 0x02003E2F RID: 15919
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node8 : Condition
	{
		// Token: 0x060163E4 RID: 91108 RVA: 0x006B9B26 File Offset: 0x006B7F26
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node8()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060163E5 RID: 91109 RVA: 0x006B9B48 File Offset: 0x006B7F48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC47 RID: 64583
		private HMType opl_p0;

		// Token: 0x0400FC48 RID: 64584
		private BE_Operation opl_p1;

		// Token: 0x0400FC49 RID: 64585
		private float opl_p2;
	}
}
