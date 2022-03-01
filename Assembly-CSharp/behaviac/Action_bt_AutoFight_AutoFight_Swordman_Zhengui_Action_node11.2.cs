using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029AF RID: 10671
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node112 : Action
	{
		// Token: 0x06013C92 RID: 81042 RVA: 0x005EACFC File Offset: 0x005E90FC
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node112()
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
			item.skillID = 1510;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013C93 RID: 81043 RVA: 0x005EAD8C File Offset: 0x005E918C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6FE RID: 55038
		private List<Input> method_p0;

		// Token: 0x0400D6FF RID: 55039
		private bool method_p1;
	}
}
