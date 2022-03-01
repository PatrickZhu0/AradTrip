using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002229 RID: 8745
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node62 : Action
	{
		// Token: 0x06012DDC RID: 77276 RVA: 0x0058E970 File Offset: 0x0058CD70
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node62()
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
			item.skillID = 1700;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012DDD RID: 77277 RVA: 0x0058EA00 File Offset: 0x0058CE00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7D7 RID: 51159
		private List<Input> method_p0;

		// Token: 0x0400C7D8 RID: 51160
		private bool method_p1;
	}
}
