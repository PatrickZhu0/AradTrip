using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020034E5 RID: 13541
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Action_node27 : Action
	{
		// Token: 0x0601520F RID: 86543 RVA: 0x0065DD9C File Offset: 0x0065C19C
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Action_node27()
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
			item.skillID = 6262;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015210 RID: 86544 RVA: 0x0065DE2C File Offset: 0x0065C22C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB29 RID: 60201
		private List<Input> method_p0;

		// Token: 0x0400EB2A RID: 60202
		private bool method_p1;
	}
}
