using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EEE RID: 7918
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Action_node26 : Action
	{
		// Token: 0x06012781 RID: 75649 RVA: 0x00566D64 File Offset: 0x00565164
		public Action_bt_AutoFight_AutoFight_Fightergirl_Action_node26()
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
			item.skillID = 3010;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012782 RID: 75650 RVA: 0x00566DF4 File Offset: 0x005651F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C176 RID: 49526
		private List<Input> method_p0;

		// Token: 0x0400C177 RID: 49527
		private bool method_p1;
	}
}
