using System;

namespace behaviac
{
	// Token: 0x02003721 RID: 14113
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node15 : Action
	{
		// Token: 0x0601564F RID: 87631 RVA: 0x00674522 File Offset: 0x00672922
		public Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528402;
			this.method_p2 = 500;
			this.method_p3 = 100;
			this.method_p4 = 0;
		}

		// Token: 0x06015650 RID: 87632 RVA: 0x0067455D File Offset: 0x0067295D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F01C RID: 61468
		private BE_Target method_p0;

		// Token: 0x0400F01D RID: 61469
		private int method_p1;

		// Token: 0x0400F01E RID: 61470
		private int method_p2;

		// Token: 0x0400F01F RID: 61471
		private int method_p3;

		// Token: 0x0400F020 RID: 61472
		private int method_p4;
	}
}
