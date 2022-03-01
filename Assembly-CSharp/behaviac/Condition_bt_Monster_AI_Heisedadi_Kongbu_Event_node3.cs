using System;

namespace behaviac
{
	// Token: 0x020034B0 RID: 13488
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node3 : Condition
	{
		// Token: 0x060151A6 RID: 86438 RVA: 0x0065BF72 File Offset: 0x0065A372
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x060151A7 RID: 86439 RVA: 0x0065BF94 File Offset: 0x0065A394
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAA7 RID: 60071
		private HMType opl_p0;

		// Token: 0x0400EAA8 RID: 60072
		private BE_Operation opl_p1;

		// Token: 0x0400EAA9 RID: 60073
		private float opl_p2;
	}
}
