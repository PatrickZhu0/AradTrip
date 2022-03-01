using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200200D RID: 8205
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node45 : Action
	{
		// Token: 0x060129B6 RID: 76214 RVA: 0x00574208 File Offset: 0x00572608
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node45()
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
			item.skillID = 2507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060129B7 RID: 76215 RVA: 0x00574298 File Offset: 0x00572698
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3A9 RID: 50089
		private List<Input> method_p0;

		// Token: 0x0400C3AA RID: 50090
		private bool method_p1;
	}
}
