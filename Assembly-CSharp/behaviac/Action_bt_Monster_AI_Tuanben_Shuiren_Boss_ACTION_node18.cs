using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B55 RID: 15189
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node18 : Action
	{
		// Token: 0x06015E5F RID: 89695 RVA: 0x0069D974 File Offset: 0x0069BD74
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node18()
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
			item.skillID = 21081;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015E60 RID: 89696 RVA: 0x0069DA04 File Offset: 0x0069BE04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F72E RID: 63278
		private List<Input> method_p0;

		// Token: 0x0400F72F RID: 63279
		private bool method_p1;
	}
}
