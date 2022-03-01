using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002105 RID: 8453
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node5 : Action
	{
		// Token: 0x06012B9D RID: 76701 RVA: 0x00580A34 File Offset: 0x0057EE34
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node5()
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
			item.skillID = 1106;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012B9E RID: 76702 RVA: 0x00580AC4 File Offset: 0x0057EEC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C590 RID: 50576
		private List<Input> method_p0;

		// Token: 0x0400C591 RID: 50577
		private bool method_p1;
	}
}
