using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020035C4 RID: 13764
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node14 : Action
	{
		// Token: 0x060153B3 RID: 86963 RVA: 0x0066630C File Offset: 0x0066470C
		public Action_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node14()
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
			item.skillID = 5038;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060153B4 RID: 86964 RVA: 0x0066639C File Offset: 0x0066479C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED76 RID: 60790
		private List<Input> method_p0;

		// Token: 0x0400ED77 RID: 60791
		private bool method_p1;
	}
}
