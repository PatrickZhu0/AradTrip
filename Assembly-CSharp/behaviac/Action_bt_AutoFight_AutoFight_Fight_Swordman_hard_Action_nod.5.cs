using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020022AA RID: 8874
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node28 : Action
	{
		// Token: 0x06012ED0 RID: 77520 RVA: 0x00595588 File Offset: 0x00593988
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node28()
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
			item.skillID = 1510;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012ED1 RID: 77521 RVA: 0x00595618 File Offset: 0x00593A18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8DA RID: 51418
		private List<Input> method_p0;

		// Token: 0x0400C8DB RID: 51419
		private bool method_p1;
	}
}
