using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200260E RID: 9742
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node62 : Action
	{
		// Token: 0x06013562 RID: 79202 RVA: 0x005C0AA0 File Offset: 0x005BEEA0
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node62()
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
			item.skillID = 2;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 165;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1104;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013563 RID: 79203 RVA: 0x005C0B88 File Offset: 0x005BEF88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFAE RID: 53166
		private List<Input> method_p0;

		// Token: 0x0400CFAF RID: 53167
		private bool method_p1;
	}
}
