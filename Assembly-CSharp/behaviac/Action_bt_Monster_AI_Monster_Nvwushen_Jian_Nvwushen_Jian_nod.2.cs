using System;

namespace behaviac
{
	// Token: 0x020036E7 RID: 14055
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node2 : Action
	{
		// Token: 0x060155E3 RID: 87523 RVA: 0x00672777 File Offset: 0x00670B77
		public Action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521696;
		}

		// Token: 0x060155E4 RID: 87524 RVA: 0x00672798 File Offset: 0x00670B98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFB9 RID: 61369
		private BE_Target method_p0;

		// Token: 0x0400EFBA RID: 61370
		private int method_p1;
	}
}
