using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020020D9 RID: 8409
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node10 : Action
	{
		// Token: 0x06012B47 RID: 76615 RVA: 0x0057E700 File Offset: 0x0057CB00
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node10()
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
			item.skillID = 1007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012B48 RID: 76616 RVA: 0x0057E790 File Offset: 0x0057CB90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C53A RID: 50490
		private List<Input> method_p0;

		// Token: 0x0400C53B RID: 50491
		private bool method_p1;
	}
}
