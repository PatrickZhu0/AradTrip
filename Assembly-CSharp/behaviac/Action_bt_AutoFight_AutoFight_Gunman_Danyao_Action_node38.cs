using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025A8 RID: 9640
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node38 : Action
	{
		// Token: 0x06013497 RID: 78999 RVA: 0x005BC408 File Offset: 0x005BA808
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node38()
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
			item.skillID = 1309;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013498 RID: 79000 RVA: 0x005BC498 File Offset: 0x005BA898
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CECB RID: 52939
		private List<Input> method_p0;

		// Token: 0x0400CECC RID: 52940
		private bool method_p1;
	}
}
