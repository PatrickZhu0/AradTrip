using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025A4 RID: 9636
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node18 : Action
	{
		// Token: 0x0601348F RID: 78991 RVA: 0x005BC254 File Offset: 0x005BA654
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node18()
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
			item.skillID = 1300;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013490 RID: 78992 RVA: 0x005BC2E4 File Offset: 0x005BA6E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEC3 RID: 52931
		private List<Input> method_p0;

		// Token: 0x0400CEC4 RID: 52932
		private bool method_p1;
	}
}
