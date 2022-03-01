using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002579 RID: 9593
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Action_node23 : Action
	{
		// Token: 0x0601343A RID: 78906 RVA: 0x005BA0DC File Offset: 0x005B84DC
		public Action_bt_AutoFight_AutoFight_Gunman_Action_node23()
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
			item.skillID = 1013;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601343B RID: 78907 RVA: 0x005BA16C File Offset: 0x005B856C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE63 RID: 52835
		private List<Input> method_p0;

		// Token: 0x0400CE64 RID: 52836
		private bool method_p1;
	}
}
