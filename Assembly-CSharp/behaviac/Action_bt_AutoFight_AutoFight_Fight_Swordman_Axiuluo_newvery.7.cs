using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002225 RID: 8741
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node45 : Action
	{
		// Token: 0x06012DD4 RID: 77268 RVA: 0x0058E76C File Offset: 0x0058CB6C
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node45()
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
			item.skillID = 1701;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012DD5 RID: 77269 RVA: 0x0058E7FC File Offset: 0x0058CBFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7CB RID: 51147
		private List<Input> method_p0;

		// Token: 0x0400C7CC RID: 51148
		private bool method_p1;
	}
}
