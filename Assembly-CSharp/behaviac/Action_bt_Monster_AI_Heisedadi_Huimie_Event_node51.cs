using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003440 RID: 13376
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node51 : Action
	{
		// Token: 0x060150CE RID: 86222 RVA: 0x006574C4 File Offset: 0x006558C4
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node51()
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
			item.skillID = 6221;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060150CF RID: 86223 RVA: 0x00657554 File Offset: 0x00655954
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E99F RID: 59807
		private List<Input> method_p0;

		// Token: 0x0400E9A0 RID: 59808
		private bool method_p1;
	}
}
