using System;

namespace behaviac
{
	// Token: 0x02003221 RID: 12833
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node12 : Action
	{
		// Token: 0x06014CCB RID: 85195 RVA: 0x006443C2 File Offset: 0x006427C2
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570259;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014CCC RID: 85196 RVA: 0x006443F9 File Offset: 0x006427F9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E61A RID: 58906
		private BE_Target method_p0;

		// Token: 0x0400E61B RID: 58907
		private int method_p1;

		// Token: 0x0400E61C RID: 58908
		private int method_p2;

		// Token: 0x0400E61D RID: 58909
		private int method_p3;

		// Token: 0x0400E61E RID: 58910
		private int method_p4;
	}
}
