using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029CE RID: 10702
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node64 : Action
	{
		// Token: 0x06013CD0 RID: 81104 RVA: 0x005EBAC0 File Offset: 0x005E9EC0
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node64()
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
			item.skillID = 1818;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013CD1 RID: 81105 RVA: 0x005EBB50 File Offset: 0x005E9F50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D73F RID: 55103
		private List<Input> method_p0;

		// Token: 0x0400D740 RID: 55104
		private bool method_p1;
	}
}
