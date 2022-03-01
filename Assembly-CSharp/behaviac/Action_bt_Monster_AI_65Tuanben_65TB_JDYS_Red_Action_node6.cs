using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002BB1 RID: 11185
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node6 : Action
	{
		// Token: 0x06014069 RID: 82025 RVA: 0x00603B44 File Offset: 0x00601F44
		public Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node6()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 20773;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601406A RID: 82026 RVA: 0x00603BD4 File Offset: 0x00601FD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_INVALID;
		}

		// Token: 0x0400DA62 RID: 55906
		private List<Input> method_p0;

		// Token: 0x0400DA63 RID: 55907
		private bool method_p1;
	}
}
