using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B68 RID: 15208
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node40 : Action
	{
		// Token: 0x06015E85 RID: 89733 RVA: 0x0069DF70 File Offset: 0x0069C370
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node40()
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
			item.skillID = 21080;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015E86 RID: 89734 RVA: 0x0069E000 File Offset: 0x0069C400
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F74C RID: 63308
		private List<Input> method_p0;

		// Token: 0x0400F74D RID: 63309
		private bool method_p1;
	}
}
