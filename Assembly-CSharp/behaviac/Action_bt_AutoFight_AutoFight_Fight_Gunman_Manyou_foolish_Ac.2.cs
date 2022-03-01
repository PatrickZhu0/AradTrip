using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200212D RID: 8493
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node5 : Action
	{
		// Token: 0x06012BEC RID: 76780 RVA: 0x00582850 File Offset: 0x00580C50
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node5()
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

		// Token: 0x06012BED RID: 76781 RVA: 0x005828E0 File Offset: 0x00580CE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5DF RID: 50655
		private List<Input> method_p0;

		// Token: 0x0400C5E0 RID: 50656
		private bool method_p1;
	}
}
