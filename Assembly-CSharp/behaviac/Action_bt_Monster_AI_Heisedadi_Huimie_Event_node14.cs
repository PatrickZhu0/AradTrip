using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200342A RID: 13354
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node14 : Action
	{
		// Token: 0x060150A3 RID: 86179 RVA: 0x00656B04 File Offset: 0x00654F04
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node14()
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
			item.skillID = 6219;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060150A4 RID: 86180 RVA: 0x00656B94 File Offset: 0x00654F94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E974 RID: 59764
		private List<Input> method_p0;

		// Token: 0x0400E975 RID: 59765
		private bool method_p1;
	}
}
