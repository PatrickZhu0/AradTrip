using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025E0 RID: 9696
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node63 : Action
	{
		// Token: 0x06013507 RID: 79111 RVA: 0x005BDB10 File Offset: 0x005BBF10
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node63()
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
			item.skillID = 1013;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013508 RID: 79112 RVA: 0x005BDBA0 File Offset: 0x005BBFA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF4B RID: 53067
		private List<Input> method_p0;

		// Token: 0x0400CF4C RID: 53068
		private bool method_p1;
	}
}
