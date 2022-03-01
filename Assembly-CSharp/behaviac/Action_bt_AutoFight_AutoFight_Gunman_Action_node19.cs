using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002575 RID: 9589
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Action_node19 : Action
	{
		// Token: 0x06013432 RID: 78898 RVA: 0x005B9F24 File Offset: 0x005B8324
		public Action_bt_AutoFight_AutoFight_Gunman_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 1000;
			item.randomChangeDirection = false;
			item.skillID = 1014;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013433 RID: 78899 RVA: 0x005B9FB8 File Offset: 0x005B83B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE5B RID: 52827
		private List<Input> method_p0;

		// Token: 0x0400CE5C RID: 52828
		private bool method_p1;
	}
}
