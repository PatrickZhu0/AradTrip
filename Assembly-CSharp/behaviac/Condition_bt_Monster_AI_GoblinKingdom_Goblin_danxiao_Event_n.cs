using System;

namespace behaviac
{
	// Token: 0x0200330B RID: 13067
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node7 : Condition
	{
		// Token: 0x06014E7F RID: 85631 RVA: 0x0064CA99 File Offset: 0x0064AE99
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node7()
		{
			this.opl_p0 = EventType.OnHurt;
		}

		// Token: 0x06014E80 RID: 85632 RVA: 0x0064CAA8 File Offset: 0x0064AEA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E76A RID: 59242
		private EventType opl_p0;
	}
}
