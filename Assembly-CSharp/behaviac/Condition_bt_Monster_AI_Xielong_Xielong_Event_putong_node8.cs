using System;

namespace behaviac
{
	// Token: 0x02003E41 RID: 15937
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node8 : Condition
	{
		// Token: 0x06016407 RID: 91143 RVA: 0x006BA5D2 File Offset: 0x006B89D2
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node8()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06016408 RID: 91144 RVA: 0x006BA5F4 File Offset: 0x006B89F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC5F RID: 64607
		private HMType opl_p0;

		// Token: 0x0400FC60 RID: 64608
		private BE_Operation opl_p1;

		// Token: 0x0400FC61 RID: 64609
		private float opl_p2;
	}
}
