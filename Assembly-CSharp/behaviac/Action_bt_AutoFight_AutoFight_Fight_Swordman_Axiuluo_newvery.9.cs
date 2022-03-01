using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200222D RID: 8749
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node28 : Action
	{
		// Token: 0x06012DE4 RID: 77284 RVA: 0x0058EB74 File Offset: 0x0058CF74
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 750;
			item.randomChangeDirection = false;
			item.skillID = 1707;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012DE5 RID: 77285 RVA: 0x0058EC08 File Offset: 0x0058D008
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7E3 RID: 51171
		private List<Input> method_p0;

		// Token: 0x0400C7E4 RID: 51172
		private bool method_p1;
	}
}
