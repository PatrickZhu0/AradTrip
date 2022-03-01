using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002945 RID: 10565
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node8 : Action
	{
		// Token: 0x06013BBF RID: 80831 RVA: 0x005E6B38 File Offset: 0x005E4F38
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node8()
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

		// Token: 0x06013BC0 RID: 80832 RVA: 0x005E6BC8 File Offset: 0x005E4FC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D623 RID: 54819
		private List<Input> method_p0;

		// Token: 0x0400D624 RID: 54820
		private bool method_p1;
	}
}
