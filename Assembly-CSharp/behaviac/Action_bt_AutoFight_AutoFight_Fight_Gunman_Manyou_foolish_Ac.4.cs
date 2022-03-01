using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002131 RID: 8497
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node10 : Action
	{
		// Token: 0x06012BF4 RID: 76788 RVA: 0x005829EC File Offset: 0x00580DEC
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node10()
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
			item.skillID = 1101;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012BF5 RID: 76789 RVA: 0x00582A7C File Offset: 0x00580E7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5E7 RID: 50663
		private List<Input> method_p0;

		// Token: 0x0400C5E8 RID: 50664
		private bool method_p1;
	}
}
