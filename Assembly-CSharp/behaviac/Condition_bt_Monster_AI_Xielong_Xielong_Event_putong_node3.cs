using System;

namespace behaviac
{
	// Token: 0x02003E3B RID: 15931
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node3 : Condition
	{
		// Token: 0x060163FB RID: 91131 RVA: 0x006BA3BE File Offset: 0x006B87BE
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.75f;
		}

		// Token: 0x060163FC RID: 91132 RVA: 0x006BA3E0 File Offset: 0x006B87E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC56 RID: 64598
		private HMType opl_p0;

		// Token: 0x0400FC57 RID: 64599
		private BE_Operation opl_p1;

		// Token: 0x0400FC58 RID: 64600
		private float opl_p2;
	}
}
