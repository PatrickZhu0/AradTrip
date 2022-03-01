using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F32 RID: 12082
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node3 : Action
	{
		// Token: 0x06014736 RID: 83766 RVA: 0x0062721C File Offset: 0x0062561C
		public Action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node3()
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
			item.skillID = 7057;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014737 RID: 83767 RVA: 0x006272AC File Offset: 0x006256AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0A7 RID: 57511
		private List<Input> method_p0;

		// Token: 0x0400E0A8 RID: 57512
		private bool method_p1;
	}
}
