using System;

namespace behaviac
{
	// Token: 0x020036BF RID: 14015
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node6 : Condition
	{
		// Token: 0x06015597 RID: 87447 RVA: 0x00670C4B File Offset: 0x0066F04B
		public Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node6()
		{
			this.opl_p0 = EventType.OnHurt;
		}

		// Token: 0x06015598 RID: 87448 RVA: 0x00670C5C File Offset: 0x0066F05C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF6C RID: 61292
		private EventType opl_p0;
	}
}
