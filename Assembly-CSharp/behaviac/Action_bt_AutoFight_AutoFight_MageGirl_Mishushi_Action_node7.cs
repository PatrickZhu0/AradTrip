using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026B4 RID: 9908
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node75 : Action
	{
		// Token: 0x060136AB RID: 79531 RVA: 0x005C87AC File Offset: 0x005C6BAC
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node75()
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
			item.skillID = 2113;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060136AC RID: 79532 RVA: 0x005C883C File Offset: 0x005C6C3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0FF RID: 53503
		private List<Input> method_p0;

		// Token: 0x0400D100 RID: 53504
		private bool method_p1;
	}
}
