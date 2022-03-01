using System;

namespace behaviac
{
	// Token: 0x020036EA RID: 14058
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node3 : Condition
	{
		// Token: 0x060155E8 RID: 87528 RVA: 0x006728D8 File Offset: 0x00670CD8
		public Condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node3()
		{
			this.opl_p0 = EventType.OnHurt;
		}

		// Token: 0x060155E9 RID: 87529 RVA: 0x006728E8 File Offset: 0x00670CE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFBC RID: 61372
		private EventType opl_p0;
	}
}
