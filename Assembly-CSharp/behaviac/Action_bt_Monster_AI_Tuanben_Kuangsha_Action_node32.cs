using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003ADB RID: 15067
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node32 : Action
	{
		// Token: 0x06015D75 RID: 89461 RVA: 0x00698F18 File Offset: 0x00697318
		public Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node32()
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
			item.skillID = 21033;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015D76 RID: 89462 RVA: 0x00698FA8 File Offset: 0x006973A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F684 RID: 63108
		private List<Input> method_p0;

		// Token: 0x0400F685 RID: 63109
		private bool method_p1;
	}
}
