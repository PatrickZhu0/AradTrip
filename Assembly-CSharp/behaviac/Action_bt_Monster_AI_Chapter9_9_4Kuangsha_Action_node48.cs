using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200318F RID: 12687
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node48 : Action
	{
		// Token: 0x06014BB5 RID: 84917 RVA: 0x0063DD60 File Offset: 0x0063C160
		public Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node48()
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
			item.skillID = 21540;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014BB6 RID: 84918 RVA: 0x0063DDF0 File Offset: 0x0063C1F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E523 RID: 58659
		private List<Input> method_p0;

		// Token: 0x0400E524 RID: 58660
		private bool method_p1;
	}
}
