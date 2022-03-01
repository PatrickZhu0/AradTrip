using System;

namespace behaviac
{
	// Token: 0x02002B9D RID: 11165
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2 : Action
	{
		// Token: 0x06014044 RID: 81988 RVA: 0x00602E8A File Offset: 0x0060128A
		public Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 96;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014045 RID: 81989 RVA: 0x00602EBE File Offset: 0x006012BE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA3A RID: 55866
		private BE_Target method_p0;

		// Token: 0x0400DA3B RID: 55867
		private int method_p1;

		// Token: 0x0400DA3C RID: 55868
		private int method_p2;

		// Token: 0x0400DA3D RID: 55869
		private int method_p3;

		// Token: 0x0400DA3E RID: 55870
		private int method_p4;
	}
}
