using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025F1 RID: 9713
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node48 : Action
	{
		// Token: 0x06013529 RID: 79145 RVA: 0x005BE3C0 File Offset: 0x005BC7C0
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node48()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 3;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1500;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 4;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x0601352A RID: 79146 RVA: 0x005BE4A4 File Offset: 0x005BC8A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF70 RID: 53104
		private List<Input> method_p0;

		// Token: 0x0400CF71 RID: 53105
		private bool method_p1;
	}
}
