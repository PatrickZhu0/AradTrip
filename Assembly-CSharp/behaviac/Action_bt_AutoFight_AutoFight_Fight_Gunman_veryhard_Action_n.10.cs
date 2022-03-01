using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020021F5 RID: 8693
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node25 : Action
	{
		// Token: 0x06012D77 RID: 77175 RVA: 0x0058BC58 File Offset: 0x0058A058
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node25()
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

		// Token: 0x06012D78 RID: 77176 RVA: 0x0058BCE8 File Offset: 0x0058A0E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C76A RID: 51050
		private List<Input> method_p0;

		// Token: 0x0400C76B RID: 51051
		private bool method_p1;
	}
}
