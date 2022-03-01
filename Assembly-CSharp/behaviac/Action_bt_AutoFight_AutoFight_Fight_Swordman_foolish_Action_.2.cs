using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002287 RID: 8839
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node16 : Action
	{
		// Token: 0x06012E8F RID: 77455 RVA: 0x00593F0C File Offset: 0x0059230C
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node16()
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
			item.skillID = 1505;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012E90 RID: 77456 RVA: 0x00593F9C File Offset: 0x0059239C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C89A RID: 51354
		private List<Input> method_p0;

		// Token: 0x0400C89B RID: 51355
		private bool method_p1;
	}
}
