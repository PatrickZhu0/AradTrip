using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020040CD RID: 16589
	[GeneratedTypeMetaInfo]
	internal class Action_bt_ActionBT_node2 : Action
	{
		// Token: 0x060168F0 RID: 92400 RVA: 0x006D4DAC File Offset: 0x006D31AC
		public Action_bt_ActionBT_node2()
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
			item.skillID = 5000;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060168F1 RID: 92401 RVA: 0x006D4E3C File Offset: 0x006D323C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010136 RID: 65846
		private List<Input> method_p0;

		// Token: 0x04010137 RID: 65847
		private bool method_p1;
	}
}
