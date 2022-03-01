using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002015 RID: 8213
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node5 : Action
	{
		// Token: 0x060129C5 RID: 76229 RVA: 0x005751C4 File Offset: 0x005735C4
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node5()
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
			item.skillID = 2518;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060129C6 RID: 76230 RVA: 0x00575254 File Offset: 0x00573654
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3B8 RID: 50104
		private List<Input> method_p0;

		// Token: 0x0400C3B9 RID: 50105
		private bool method_p1;
	}
}
