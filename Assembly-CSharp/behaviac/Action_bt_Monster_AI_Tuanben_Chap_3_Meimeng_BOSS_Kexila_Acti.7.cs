using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020038E7 RID: 14567
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node33 : Action
	{
		// Token: 0x060159AB RID: 88491 RVA: 0x00685894 File Offset: 0x00683C94
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node33()
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
			item.skillID = 21205;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060159AC RID: 88492 RVA: 0x00685924 File Offset: 0x00683D24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F356 RID: 62294
		private List<Input> method_p0;

		// Token: 0x0400F357 RID: 62295
		private bool method_p1;
	}
}
