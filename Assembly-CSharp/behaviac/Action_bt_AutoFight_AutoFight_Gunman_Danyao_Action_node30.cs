using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025D8 RID: 9688
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node30 : Action
	{
		// Token: 0x060134F7 RID: 79095 RVA: 0x005BD7A8 File Offset: 0x005BBBA8
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node30()
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
			item.skillID = 1305;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060134F8 RID: 79096 RVA: 0x005BD838 File Offset: 0x005BBC38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF3B RID: 53051
		private List<Input> method_p0;

		// Token: 0x0400CF3C RID: 53052
		private bool method_p1;
	}
}
