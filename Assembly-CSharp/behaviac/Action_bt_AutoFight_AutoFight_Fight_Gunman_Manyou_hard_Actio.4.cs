using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002159 RID: 8537
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node10 : Action
	{
		// Token: 0x06012C43 RID: 76867 RVA: 0x00584808 File Offset: 0x00582C08
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node10()
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

		// Token: 0x06012C44 RID: 76868 RVA: 0x00584898 File Offset: 0x00582C98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C636 RID: 50742
		private List<Input> method_p0;

		// Token: 0x0400C637 RID: 50743
		private bool method_p1;
	}
}
