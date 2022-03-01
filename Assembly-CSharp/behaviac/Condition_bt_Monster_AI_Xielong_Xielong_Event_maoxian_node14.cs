using System;

namespace behaviac
{
	// Token: 0x02003E35 RID: 15925
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node14 : Condition
	{
		// Token: 0x060163F0 RID: 91120 RVA: 0x006B9D3A File Offset: 0x006B813A
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node14()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.25f;
		}

		// Token: 0x060163F1 RID: 91121 RVA: 0x006B9D5C File Offset: 0x006B815C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC50 RID: 64592
		private HMType opl_p0;

		// Token: 0x0400FC51 RID: 64593
		private BE_Operation opl_p1;

		// Token: 0x0400FC52 RID: 64594
		private float opl_p2;
	}
}
