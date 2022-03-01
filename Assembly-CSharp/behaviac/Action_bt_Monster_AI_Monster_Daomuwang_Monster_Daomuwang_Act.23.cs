using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200367A RID: 13946
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node20 : Action
	{
		// Token: 0x06015515 RID: 87317 RVA: 0x0066DBD0 File Offset: 0x0066BFD0
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node20()
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
			item.skillID = 5426;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015516 RID: 87318 RVA: 0x0066DC60 File Offset: 0x0066C060
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EECB RID: 61131
		private List<Input> method_p0;

		// Token: 0x0400EECC RID: 61132
		private bool method_p1;
	}
}
