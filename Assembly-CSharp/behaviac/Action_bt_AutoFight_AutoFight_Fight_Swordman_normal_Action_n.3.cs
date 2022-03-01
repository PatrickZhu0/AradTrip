using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002448 RID: 9288
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node43 : Action
	{
		// Token: 0x060131E4 RID: 78308 RVA: 0x005ABE20 File Offset: 0x005AA220
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node43()
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
			item.skillID = 1514;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 400;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1514;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x060131E5 RID: 78309 RVA: 0x005ABF0C File Offset: 0x005AA30C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC0B RID: 52235
		private List<Input> method_p0;

		// Token: 0x0400CC0C RID: 52236
		private bool method_p1;
	}
}
