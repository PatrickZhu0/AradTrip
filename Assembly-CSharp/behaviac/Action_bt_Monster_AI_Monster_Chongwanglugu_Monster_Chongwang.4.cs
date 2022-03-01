using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020035FD RID: 13821
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node45 : Action
	{
		// Token: 0x06015420 RID: 87072 RVA: 0x0066862C File Offset: 0x00666A2C
		public Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node45()
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
			item.skillID = 5443;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015421 RID: 87073 RVA: 0x006686BC File Offset: 0x00666ABC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDD8 RID: 60888
		private List<Input> method_p0;

		// Token: 0x0400EDD9 RID: 60889
		private bool method_p1;
	}
}
