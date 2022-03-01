using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002111 RID: 8465
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node20 : Action
	{
		// Token: 0x06012BB5 RID: 76725 RVA: 0x00580FB8 File Offset: 0x0057F3B8
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node20()
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

		// Token: 0x06012BB6 RID: 76726 RVA: 0x00581048 File Offset: 0x0057F448
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5A8 RID: 50600
		private List<Input> method_p0;

		// Token: 0x0400C5A9 RID: 50601
		private bool method_p1;
	}
}
