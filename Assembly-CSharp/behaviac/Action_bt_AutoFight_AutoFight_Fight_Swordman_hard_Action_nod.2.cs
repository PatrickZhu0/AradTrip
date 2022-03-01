using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020022A0 RID: 8864
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node16 : Action
	{
		// Token: 0x06012EBD RID: 77501 RVA: 0x00595170 File Offset: 0x00593570
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node16()
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
			item.skillID = 1505;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012EBE RID: 77502 RVA: 0x00595200 File Offset: 0x00593600
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8C7 RID: 51399
		private List<Input> method_p0;

		// Token: 0x0400C8C8 RID: 51400
		private bool method_p1;
	}
}
