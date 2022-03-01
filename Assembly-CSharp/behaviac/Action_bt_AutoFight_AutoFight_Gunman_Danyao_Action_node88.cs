using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025A0 RID: 9632
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node88 : Action
	{
		// Token: 0x06013487 RID: 78983 RVA: 0x005BC0A0 File Offset: 0x005BA4A0
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node88()
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
			item.skillID = 1308;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013488 RID: 78984 RVA: 0x005BC130 File Offset: 0x005BA530
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEBB RID: 52923
		private List<Input> method_p0;

		// Token: 0x0400CEBC RID: 52924
		private bool method_p1;
	}
}
