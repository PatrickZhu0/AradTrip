using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B74 RID: 15220
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node54 : Action
	{
		// Token: 0x06015E9D RID: 89757 RVA: 0x0069E498 File Offset: 0x0069C898
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node54()
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
			item.skillID = 21079;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015E9E RID: 89758 RVA: 0x0069E528 File Offset: 0x0069C928
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F764 RID: 63332
		private List<Input> method_p0;

		// Token: 0x0400F765 RID: 63333
		private bool method_p1;
	}
}
