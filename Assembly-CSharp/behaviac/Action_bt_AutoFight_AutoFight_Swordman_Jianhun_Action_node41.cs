using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002941 RID: 10561
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node41 : Action
	{
		// Token: 0x06013BB8 RID: 80824 RVA: 0x005E5810 File Offset: 0x005E3C10
		public Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node41()
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
			item.skillID = 1716;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013BB9 RID: 80825 RVA: 0x005E58A0 File Offset: 0x005E3CA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D61D RID: 54813
		private List<Input> method_p0;

		// Token: 0x0400D61E RID: 54814
		private bool method_p1;
	}
}
