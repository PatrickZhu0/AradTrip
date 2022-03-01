using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027BE RID: 10174
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node15 : Action
	{
		// Token: 0x060138BB RID: 80059 RVA: 0x005D44B8 File Offset: 0x005D28B8
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node15()
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
			item.skillID = 3617;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060138BC RID: 80060 RVA: 0x005D4548 File Offset: 0x005D2948
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D319 RID: 54041
		private List<Input> method_p0;

		// Token: 0x0400D31A RID: 54042
		private bool method_p1;
	}
}
