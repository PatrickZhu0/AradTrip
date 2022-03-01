using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200299D RID: 10653
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node124 : Action
	{
		// Token: 0x06013C6E RID: 81006 RVA: 0x005EA598 File Offset: 0x005E8998
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node124()
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
			item.skillID = 1812;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013C6F RID: 81007 RVA: 0x005EA628 File Offset: 0x005E8A28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6D9 RID: 55001
		private List<Input> method_p0;

		// Token: 0x0400D6DA RID: 55002
		private bool method_p1;
	}
}
