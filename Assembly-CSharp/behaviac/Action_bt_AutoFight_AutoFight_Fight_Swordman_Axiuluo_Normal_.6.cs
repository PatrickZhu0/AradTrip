using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200225D RID: 8797
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node28 : Action
	{
		// Token: 0x06012E42 RID: 77378 RVA: 0x00591A18 File Offset: 0x0058FE18
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node28()
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

		// Token: 0x06012E43 RID: 77379 RVA: 0x00591AAC File Offset: 0x0058FEAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C84F RID: 51279
		private List<Input> method_p0;

		// Token: 0x0400C850 RID: 51280
		private bool method_p1;
	}
}
