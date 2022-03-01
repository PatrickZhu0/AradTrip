using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200289A RID: 10394
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node8 : Action
	{
		// Token: 0x06013A6F RID: 80495 RVA: 0x005DE760 File Offset: 0x005DCB60
		public Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node8()
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
			item.skillID = 1710;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013A70 RID: 80496 RVA: 0x005DE7F0 File Offset: 0x005DCBF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4CA RID: 54474
		private List<Input> method_p0;

		// Token: 0x0400D4CB RID: 54475
		private bool method_p1;
	}
}
