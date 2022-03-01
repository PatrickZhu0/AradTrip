using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020034D9 RID: 13529
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Action_node11 : Action
	{
		// Token: 0x060151F7 RID: 86519 RVA: 0x0065D838 File Offset: 0x0065BC38
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Action_node11()
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
			item.skillID = 6255;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060151F8 RID: 86520 RVA: 0x0065D8C8 File Offset: 0x0065BCC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB0B RID: 60171
		private List<Input> method_p0;

		// Token: 0x0400EB0C RID: 60172
		private bool method_p1;
	}
}
