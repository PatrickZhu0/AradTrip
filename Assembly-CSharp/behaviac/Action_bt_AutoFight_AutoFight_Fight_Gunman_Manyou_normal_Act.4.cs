using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002181 RID: 8577
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node10 : Action
	{
		// Token: 0x06012C92 RID: 76946 RVA: 0x00586624 File Offset: 0x00584A24
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node10()
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

		// Token: 0x06012C93 RID: 76947 RVA: 0x005866B4 File Offset: 0x00584AB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C685 RID: 50821
		private List<Input> method_p0;

		// Token: 0x0400C686 RID: 50822
		private bool method_p1;
	}
}
