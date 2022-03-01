using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200237B RID: 9083
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node35 : Action
	{
		// Token: 0x0601305D RID: 77917 RVA: 0x005A0B44 File Offset: 0x0059EF44
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node35()
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

		// Token: 0x0601305E RID: 77918 RVA: 0x005A0BD4 File Offset: 0x0059EFD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA71 RID: 51825
		private List<Input> method_p0;

		// Token: 0x0400CA72 RID: 51826
		private bool method_p1;
	}
}
