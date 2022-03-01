using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002571 RID: 9585
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Action_node52 : Action
	{
		// Token: 0x0601342A RID: 78890 RVA: 0x005B9D08 File Offset: 0x005B8108
		public Action_bt_AutoFight_AutoFight_Gunman_Action_node52()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 500;
			item.randomChangeDirection = false;
			item.skillID = 2;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601342B RID: 78891 RVA: 0x005B9D98 File Offset: 0x005B8198
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE52 RID: 52818
		private List<Input> method_p0;

		// Token: 0x0400CE53 RID: 52819
		private bool method_p1;
	}
}
