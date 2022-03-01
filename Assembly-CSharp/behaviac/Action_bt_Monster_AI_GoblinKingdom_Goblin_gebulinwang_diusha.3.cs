using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200332A RID: 13098
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2 : Action
	{
		// Token: 0x06014EBA RID: 85690 RVA: 0x0064D96C File Offset: 0x0064BD6C
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 2;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 5758;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014EBB RID: 85691 RVA: 0x0064D9FC File Offset: 0x0064BDFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7A0 RID: 59296
		private List<Input> method_p0;

		// Token: 0x0400E7A1 RID: 59297
		private bool method_p1;
	}
}
