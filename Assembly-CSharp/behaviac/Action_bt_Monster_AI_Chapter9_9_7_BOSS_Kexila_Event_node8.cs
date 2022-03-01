using System;

namespace behaviac
{
	// Token: 0x02003220 RID: 12832
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node8 : Action
	{
		// Token: 0x06014CC9 RID: 85193 RVA: 0x00644379 File Offset: 0x00642779
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 2;
		}

		// Token: 0x06014CCA RID: 85194 RVA: 0x0064439C File Offset: 0x0064279C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E618 RID: 58904
		private int method_p0;

		// Token: 0x0400E619 RID: 58905
		private int method_p1;
	}
}
