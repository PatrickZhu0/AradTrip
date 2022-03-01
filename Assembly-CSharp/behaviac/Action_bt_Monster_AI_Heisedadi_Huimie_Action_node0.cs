using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200340C RID: 13324
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Action_node0 : Action
	{
		// Token: 0x06015069 RID: 86121 RVA: 0x00655A28 File Offset: 0x00653E28
		public Action_bt_Monster_AI_Heisedadi_Huimie_Action_node0()
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
			item.skillID = 6217;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601506A RID: 86122 RVA: 0x00655AB8 File Offset: 0x00653EB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E942 RID: 59714
		private List<Input> method_p0;

		// Token: 0x0400E943 RID: 59715
		private bool method_p1;
	}
}
