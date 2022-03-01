using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002437 RID: 9271
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node58 : Action
	{
		// Token: 0x060131C6 RID: 78278 RVA: 0x005AA95C File Offset: 0x005A8D5C
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node58()
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
			item.skillID = 1511;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060131C7 RID: 78279 RVA: 0x005AA9EC File Offset: 0x005A8DEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBF0 RID: 52208
		private List<Input> method_p0;

		// Token: 0x0400CBF1 RID: 52209
		private bool method_p1;
	}
}
