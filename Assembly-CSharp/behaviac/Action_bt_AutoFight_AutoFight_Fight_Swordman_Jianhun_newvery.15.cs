using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020022E8 RID: 8936
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node3 : Action
	{
		// Token: 0x06012F4A RID: 77642 RVA: 0x00599E74 File Offset: 0x00598274
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node3()
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
			item2.delay = 1000;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 4;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = true;
		}

		// Token: 0x06012F4B RID: 77643 RVA: 0x00599F58 File Offset: 0x00598358
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C95A RID: 51546
		private List<Input> method_p0;

		// Token: 0x0400C95B RID: 51547
		private bool method_p1;
	}
}
