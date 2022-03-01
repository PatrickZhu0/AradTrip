using System;

namespace behaviac
{
	// Token: 0x02003E30 RID: 15920
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node20 : Condition
	{
		// Token: 0x060163E6 RID: 91110 RVA: 0x006B9B87 File Offset: 0x006B7F87
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node20()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThan;
			this.opl_p2 = 0.25f;
		}

		// Token: 0x060163E7 RID: 91111 RVA: 0x006B9BA8 File Offset: 0x006B7FA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC4A RID: 64586
		private HMType opl_p0;

		// Token: 0x0400FC4B RID: 64587
		private BE_Operation opl_p1;

		// Token: 0x0400FC4C RID: 64588
		private float opl_p2;
	}
}
