using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B6C RID: 15212
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node43 : Action
	{
		// Token: 0x06015E8D RID: 89741 RVA: 0x0069E128 File Offset: 0x0069C528
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node43()
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
			item.skillID = 21082;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015E8E RID: 89742 RVA: 0x0069E1B8 File Offset: 0x0069C5B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F754 RID: 63316
		private List<Input> method_p0;

		// Token: 0x0400F755 RID: 63317
		private bool method_p1;
	}
}
