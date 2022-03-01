using System;

namespace behaviac
{
	// Token: 0x0200321D RID: 12829
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node5 : Action
	{
		// Token: 0x06014CC3 RID: 85187 RVA: 0x0064426A File Offset: 0x0064266A
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570257;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014CC4 RID: 85188 RVA: 0x006442A1 File Offset: 0x006426A1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E60C RID: 58892
		private BE_Target method_p0;

		// Token: 0x0400E60D RID: 58893
		private int method_p1;

		// Token: 0x0400E60E RID: 58894
		private int method_p2;

		// Token: 0x0400E60F RID: 58895
		private int method_p3;

		// Token: 0x0400E610 RID: 58896
		private int method_p4;
	}
}
