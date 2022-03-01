using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200234B RID: 9035
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node35 : Action
	{
		// Token: 0x06013003 RID: 77827 RVA: 0x0059E878 File Offset: 0x0059CC78
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node35()
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
			item.skillID = 1608;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013004 RID: 77828 RVA: 0x0059E908 File Offset: 0x0059CD08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA18 RID: 51736
		private List<Input> method_p0;

		// Token: 0x0400CA19 RID: 51737
		private bool method_p1;
	}
}
