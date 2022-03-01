using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003349 RID: 13129
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_liebing_xiashu_Event_node2 : Action
	{
		// Token: 0x06014EF5 RID: 85749 RVA: 0x0064EDB8 File Offset: 0x0064D1B8
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_liebing_xiashu_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 5677;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014EF6 RID: 85750 RVA: 0x0064EE48 File Offset: 0x0064D248
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7D3 RID: 59347
		private List<Input> method_p0;

		// Token: 0x0400E7D4 RID: 59348
		private bool method_p1;
	}
}
