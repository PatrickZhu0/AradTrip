using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002DE5 RID: 11749
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node47 : Action
	{
		// Token: 0x060144A7 RID: 83111 RVA: 0x006189E0 File Offset: 0x00616DE0
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node47()
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
			item.skillID = 21640;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060144A8 RID: 83112 RVA: 0x00618A70 File Offset: 0x00616E70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE5D RID: 56925
		private List<Input> method_p0;

		// Token: 0x0400DE5E RID: 56926
		private bool method_p1;
	}
}
