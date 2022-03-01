using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002DA8 RID: 11688
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node52 : Action
	{
		// Token: 0x06014431 RID: 82993 RVA: 0x006160BC File Offset: 0x006144BC
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node52()
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
			item.skillID = 21652;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014432 RID: 82994 RVA: 0x0061614C File Offset: 0x0061454C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDF5 RID: 56821
		private List<Input> method_p0;

		// Token: 0x0400DDF6 RID: 56822
		private bool method_p1;
	}
}
