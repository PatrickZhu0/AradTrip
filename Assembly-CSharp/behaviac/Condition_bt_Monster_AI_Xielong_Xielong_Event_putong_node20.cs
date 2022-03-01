using System;

namespace behaviac
{
	// Token: 0x02003E42 RID: 15938
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node20 : Condition
	{
		// Token: 0x06016409 RID: 91145 RVA: 0x006BA633 File Offset: 0x006B8A33
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node20()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThan;
			this.opl_p2 = 0.25f;
		}

		// Token: 0x0601640A RID: 91146 RVA: 0x006BA654 File Offset: 0x006B8A54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC62 RID: 64610
		private HMType opl_p0;

		// Token: 0x0400FC63 RID: 64611
		private BE_Operation opl_p1;

		// Token: 0x0400FC64 RID: 64612
		private float opl_p2;
	}
}
