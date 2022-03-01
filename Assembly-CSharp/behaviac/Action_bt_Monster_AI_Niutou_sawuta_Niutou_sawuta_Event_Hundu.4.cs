using System;

namespace behaviac
{
	// Token: 0x02003720 RID: 14112
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node14 : Action
	{
		// Token: 0x0601564D RID: 87629 RVA: 0x006744E7 File Offset: 0x006728E7
		public Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528401;
		}

		// Token: 0x0601564E RID: 87630 RVA: 0x00674508 File Offset: 0x00672908
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F01A RID: 61466
		private BE_Target method_p0;

		// Token: 0x0400F01B RID: 61467
		private int method_p1;
	}
}
