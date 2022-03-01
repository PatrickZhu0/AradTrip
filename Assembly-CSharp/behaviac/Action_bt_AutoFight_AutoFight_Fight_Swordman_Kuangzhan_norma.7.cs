using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020023FC RID: 9212
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node46 : Action
	{
		// Token: 0x06013157 RID: 78167 RVA: 0x005A81FC File Offset: 0x005A65FC
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node46()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1604;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1200;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1606;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013158 RID: 78168 RVA: 0x005A82E8 File Offset: 0x005A66E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB81 RID: 52097
		private List<Input> method_p0;

		// Token: 0x0400CB82 RID: 52098
		private bool method_p1;
	}
}
