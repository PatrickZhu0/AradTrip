using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002336 RID: 9014
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node8 : Action
	{
		// Token: 0x06012FDD RID: 77789 RVA: 0x0059DFA8 File Offset: 0x0059C3A8
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node8()
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
			item.skillID = 1609;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012FDE RID: 77790 RVA: 0x0059E038 File Offset: 0x0059C438
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9F5 RID: 51701
		private List<Input> method_p0;

		// Token: 0x0400C9F6 RID: 51702
		private bool method_p1;
	}
}
