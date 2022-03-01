using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020022E4 RID: 8932
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node8 : Action
	{
		// Token: 0x06012F42 RID: 77634 RVA: 0x00599CDC File Offset: 0x005980DC
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node8()
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
			item.skillID = 1515;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = true;
		}

		// Token: 0x06012F43 RID: 77635 RVA: 0x00599D6C File Offset: 0x0059816C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C953 RID: 51539
		private List<Input> method_p0;

		// Token: 0x0400C954 RID: 51540
		private bool method_p1;
	}
}
