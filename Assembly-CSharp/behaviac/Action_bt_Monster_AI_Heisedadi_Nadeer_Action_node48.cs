using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020034D2 RID: 13522
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Action_node48 : Action
	{
		// Token: 0x060151E9 RID: 86505 RVA: 0x0065D4FC File Offset: 0x0065B8FC
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Action_node48()
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
			item.skillID = 6253;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060151EA RID: 86506 RVA: 0x0065D58C File Offset: 0x0065B98C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAFA RID: 60154
		private List<Input> method_p0;

		// Token: 0x0400EAFB RID: 60155
		private bool method_p1;
	}
}
