using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002125 RID: 8485
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node45 : Action
	{
		// Token: 0x06012BDD RID: 76765 RVA: 0x00581980 File Offset: 0x0057FD80
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node45()
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
			item.skillID = 1204;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012BDE RID: 76766 RVA: 0x00581A10 File Offset: 0x0057FE10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5D0 RID: 50640
		private List<Input> method_p0;

		// Token: 0x0400C5D1 RID: 50641
		private bool method_p1;
	}
}
